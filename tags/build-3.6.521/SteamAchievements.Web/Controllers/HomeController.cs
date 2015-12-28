#region License

//  Copyright 2012 John Rummell
//  
//  This file is part of SteamAchievements.
//  
//      SteamAchievements is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//  
//      SteamAchievements is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//      GNU General Public License for more details.
//  
//      You should have received a copy of the GNU General Public License
//      along with SteamAchievements.  If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Web.Mvc;
using AutoMapper;
using Elmah;
using SteamAchievements.Services;
using SteamAchievements.Services.Models;
using SteamAchievements.Web.Models;

namespace SteamAchievements.Web.Controllers
{
    public class HomeController : FacebookController
    {
        private readonly IAchievementService _achievementService;
        private readonly IFacebookClientService _facebookClient;

        public HomeController(IAchievementService achievementService, IUserService userService,
                              IFacebookClientService facebookClient)
            : base(userService)
        {
            _achievementService = achievementService;
            _facebookClient = facebookClient;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            ViewResultBase result = filterContext.Result as ViewResultBase;
            if (result != null)
            {
                SettingsViewModel model = result.Model as SettingsViewModel;
                if (model != null)
                {
                    model.EnableLog = Properties.Settings.Default.EnableClientLogging;
                }
            }
        }

        public ActionResult Index()
        {
            if (UserSettings == null)
            {
                UserSettings = new User();
            }

            IndexViewModel model = Mapper.Map<User, IndexViewModel>(UserSettings);

            if (Properties.Settings.Default.Mode != FacebookMode.None && model.FacebookUserId == 0)
            {
                model.LogOnRedirectUrl = _facebookClient.GetLogOnUrl();
            }

            return View(model);
        }

        public ActionResult Publish()
        {
            User user = UserSettings ?? new User();

            SettingsViewModel model = Mapper.Map<User, SettingsViewModel>(user);

            return View(model);
        }

        public ActionResult Settings()
        {
            User user = UserSettings ?? new User();
            SettingsViewModel model = Mapper.Map<User, SettingsViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveSettings(SettingsViewModel model)
        {
            // Since facebook posts to the canvas iframe, we need a separate action to post
            // our form.

            if (!ModelState.IsValid)
            {
                return View("Settings", model);
            }

            User user = UserService.GetUser(UserSettings.FacebookUserId);
            bool newUser = false;
            if (user == null)
            {
                newUser = true;
                user = new User {FacebookUserId = UserSettings.FacebookUserId, AccessToken = String.Empty};
            }

            Mapper.Map(model, user);

            UserService.UpdateUser(user);

            UserSettings = user;

            if (newUser)
            {
                try
                {
                    _achievementService.UpdateNewUserAchievements(user);
                }
                catch (Exception ex)
                {
                    // log and swallow exceptions so that the settings can be saved
                    ErrorSignal.FromCurrentContext().Raise(ex);
                }
            }

            ViewBag.Success = true;

            return View("Settings", model);
        }

        public ActionResult Deauthorize()
        {
            if (UserSettings == null)
            {
                return View();
            }

            UserService.DeauthorizeUser(UserSettings.FacebookUserId);

            UserSettings = null;

            return View();
        }
    }
}