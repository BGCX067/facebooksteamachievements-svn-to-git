#region License

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

using System.Web.Configuration;
using System.Web.UI;

namespace SteamAchievements.Controls
{
    public partial class GoogleAds : UserControl
    {
        /// <summary>
        /// Gets the ad client.
        /// </summary>
        /// <value>The ad client.</value>
        protected string AdClient
        {
            get { return WebConfigurationManager.AppSettings["GoogleAdClient"]; }
        }

        /// <summary>
        /// Gets the ad slot.
        /// </summary>
        /// <value>The ad slot.</value>
        protected string AdSlot
        {
            get { return WebConfigurationManager.AppSettings["GoogleAdSlot"]; }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        protected string Width
        {
            get { return WebConfigurationManager.AppSettings["GoogleAdWidth"]; }
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        protected string Height
        {
            get { return WebConfigurationManager.AppSettings["GoogleAdHeight"]; }
        }
    }
}