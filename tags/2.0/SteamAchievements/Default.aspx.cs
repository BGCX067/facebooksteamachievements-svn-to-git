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
using System.Web.UI;
using SteamAchievements.Data;

namespace SteamAchievements
{
    public partial class Default : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Load += Page_Load;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            steamUserIdHidden.Value = Master.SteamUserId;

            try
            {
                if (Master.IsLoggedIn)
                {
                    using (IAchievementManager manager = new AchievementManager())
                    {
                        User user = manager.GetUser(Master.FacebookUserId);
                        user.AccessToken = Master.AccessToken;

                        manager.UpdateUser(user);
                    }
                }
            }
            catch (Exception ex)
            {
                errorLiteral.Text = ex.Message;
            }
        }
    }
}