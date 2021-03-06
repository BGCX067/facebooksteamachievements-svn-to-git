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
using Microsoft.Practices.Unity;
using SteamAchievements.Controls;
using SteamAchievements.Services;

namespace SteamAchievements
{
    public class FacebookPage : Page
    {
        internal const string FacebookSettingsCacheKey = "FacebookSettings";

        /// <summary>
        /// Gets the container.
        /// </summary>
        protected IUnityContainer Container
        {
            get { return ContainerManager.Container; }
        }

        /// <summary>
        /// Gets the facebook settings.
        /// </summary>
        /// <remarks>
        /// This is set by <see cref="FacebookLogin"/>.
        /// </remarks>
        protected FacebookSettings FacebookSettings
        {
            get { return Session[FacebookSettingsCacheKey] as FacebookSettings; }
        }
    }
}