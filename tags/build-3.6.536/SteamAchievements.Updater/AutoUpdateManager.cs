﻿#region License

// Copyright 2010 John Rummell
// 
// This file is part of SteamAchievements.
// 
//     SteamAchievements is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     SteamAchievements is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with SteamAchievements.  If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Facebook;
using Disposable = SteamAchievements.Data.Disposable;
using SteamAchievements.Services;
using SteamAchievements.Services.Models;

namespace SteamAchievements.Updater
{
    public class AutoUpdateManager : Disposable, IAutoUpdateManager
    {
        private readonly IAchievementService _achievementService;
        private readonly IAutoUpdateLogger _log;
        private readonly IFacebookClientService _publisher;
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor for unit testing.
        /// </summary>
        /// <param name="achievementService">The achievement service.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="log">The log.</param>
        public AutoUpdateManager(IAchievementService achievementService, IUserService userService,
                                 IFacebookClientService publisher, IAutoUpdateLogger log)
        {
            if (achievementService == null)
            {
                throw new ArgumentNullException("achievementService");
            }

            if (userService == null)
            {
                throw new ArgumentNullException("userService");
            }

            if (publisher == null)
            {
                throw new ArgumentNullException("publisher");
            }

            if (log == null)
            {
                throw new ArgumentNullException("log");
            }

            _achievementService = achievementService;
            _userService = userService;
            _publisher = publisher;
            _log = log;
        }

        #region IAutoUpdateManager Members

        /// <summary>
        /// Gets the auto update steam user ids.
        /// </summary>
        public ICollection<User> GetAutoUpdateUsers()
        {
            // get users configured for auto update
            ICollection<User> users = _userService.GetAutoUpdateUsers();

            _log.Log("Users: {0}", String.Join(", ", users.Select(user => user.SteamUserId)));

            return users;
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        public IAutoUpdateLogger Logger
        {
            get { return _log; }
        }

        /// <summary>
        /// Publishes the user's achievements.
        /// </summary>
        /// <param name="user">The user.</param>
        public void PublishUserAchievements(User user)
        {
            _log.Log(String.Format("User {0} ({1})", user.SteamUserId, user.FacebookUserId));

            if (String.IsNullOrEmpty(user.AccessToken))
            {
                _log.Log("Empty AccessToken");

                // if there is no access token, the user hasn't given the app offline_access
                return;
            }

            try
            {
                // update the user's achievements
                int updated = _achievementService.UpdateAchievements(user.FacebookUserId, user.Language);

                if (updated == 0)
                {
                    _log.Log("No updated achievements");

                    return;
                }
            }
            catch (InvalidGamesXmlException exception)
            {
                _log.Log("Invalid games URL for {0}.", user.SteamUserId);
                _log.Log(exception);

                throw;
            }
            catch (XmlException exception)
            {
                _log.Log("Invalid xml for {0}.", user.SteamUserId);
                _log.Log(exception);

                throw;
            }

            // get unpublished achievements earned in the last 24-48 hours to make up for time zone differences 
            // and the time it takes to run the Auto Update process
            DateTime oldestDate = DateTime.UtcNow.AddHours(-48).Date;
            ICollection<Achievement> achievements =
                _achievementService.GetUnpublishedAchievements(user.FacebookUserId, oldestDate, user.Language);

            if (!achievements.Any())
            {
                _log.Log("No unpublished achievements");

                return;
            }

            // only publish the top 5
            achievements = achievements.Take(5).ToList();

            // since the api only supports one attachment, use the first achievement's image
            // and build the description from all achievements
            Achievement firstAchievement = achievements.First();
            Uri statsUrl = SteamCommunityManager.GetProfileUrl(user.SteamUserId, false);
            string message = String.Format("{0} unlocked {1} achievement{2}!",
                                           user.SteamUserId,
                                           achievements.Count,
                                           achievements.Count > 1 ? "s" : String.Empty);

            IDictionary<string, object> parameters =
                new Dictionary<string, object>
                    {
                        {"link", statsUrl.ToString()},
                        {"message", message},
                        {"name", user.SteamUserId},
                        {"picture", firstAchievement.ImageUrl},
                        {"description", BuildDescription(achievements, user.PublishDescription)}
                    };

            List<int> publishedAchievements = new List<int>();
            try
            {
                // publish the post
                _publisher.Publish(user, parameters);

                publishedAchievements.AddRange(achievements.Select(a => a.Id));
            }
            catch (FacebookOAuthException exception)
            {
                // The user's access token is invalid. They may have changed their password performed another action to invalidate it.
                _log.Log("User {0} has an invalid AccessToken, the value will be removed.", user.SteamUserId);
                _log.Log(exception);

                // Reset the user's access token.
                user.AccessToken = String.Empty;
                _userService.UpdateUser(user);

                return;
            }
            catch (FacebookApiException exception)
            {
                _log.Log(exception);

                return;
            }

            // update the published flag
            _achievementService.PublishAchievements(user.FacebookUserId, publishedAchievements);

            _log.Log("Published {0} achievements.", publishedAchievements.Count);
        }

        #endregion

        /// <summary>
        /// Builds the post description
        /// </summary>
        /// <param name="achievements">The achievements.</param>
        /// <param name="publishDescription">if set to <c>true</c> [publish description].</param>
        /// <returns></returns>
        private static string BuildDescription(IEnumerable<Achievement> achievements, bool publishDescription)
        {
            StringBuilder message = new StringBuilder();

            int currentGameId = 0;
            foreach (Achievement achievement in achievements)
            {
                message.Append(" ");

                if (currentGameId != achievement.Game.Id)
                {
                    message.Append(achievement.Game.Name).Append(":");
                    currentGameId = achievement.Game.Id;
                }

                message.AppendFormat(" {0}", achievement.Name);

                if (publishDescription)
                {
                    message.AppendFormat(" ({0})", achievement.Description);
                }

                message.Append(",");
            }

            // remove the last comma
            message.Remove(message.Length - 1, 1);

            return message.ToString();
        }

        /// <summary>
        /// Disposes the managed resources.
        /// </summary>
        protected override void DisposeManaged()
        {
            _log.Flush();

            _userService.Dispose();
            _achievementService.Dispose();
        }
    }
}