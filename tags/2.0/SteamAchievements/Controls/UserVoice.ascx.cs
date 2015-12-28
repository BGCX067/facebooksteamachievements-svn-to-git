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

using System.Web.UI;
using SteamAchievements.Properties;
using AppSettings = SteamAchievements.Properties.Settings;

namespace SteamAchievements.Controls
{
    public partial class UserVoice : UserControl
    {
        /// <summary>
        /// Gets the user voice key.
        /// </summary>
        /// <value>The user voice key.</value>
        protected string UserVoiceKey
        {
            get { return AppSettings.Default.UserVoiceKey; }
        }

        /// <summary>
        /// Gets the user voice forum.
        /// </summary>
        /// <value>The user voice forum.</value>
        protected string UserVoiceForum
        {
            get { return AppSettings.Default.UserVoiceForum; }
        }
    }
}