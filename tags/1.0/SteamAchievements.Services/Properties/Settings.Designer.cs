﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SteamAchievements.Services.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<div class=\"achieveTxt\">\\s*<h3>(?<name>.*?)</h3>\\s*<h5>(?<description>.*?)</h5>\\s" +
            "*</div>")]
        public string AchievementTextRegex {
            get {
                return ((string)(this["AchievementTextRegex"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<div class=\"achieveImgHolder\">\\s*<img src=\"(?<image>.*?)\"\\swidth=\"64\"\\sheight=\"64" +
            "\"\\sborder=\"0\"\\s+/>\\s*</div>")]
        public string AchievementImageRegex {
            get {
                return ((string)(this["AchievementImageRegex"]));
            }
        }
    }
}
