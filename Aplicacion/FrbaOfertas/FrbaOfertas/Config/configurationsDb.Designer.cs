﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrbaOfertas.Config {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class configurationsDb : global::System.Configuration.ApplicationSettingsBase {
        
        private static configurationsDb defaultInstance = ((configurationsDb)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new configurationsDb())));
        
        public static configurationsDb Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=HP-PC\\SQLSERVER2012;Initial Catalog=GD2C2019;Persist Security Info=Tr" +
            "ue;User ID=gdCupon2019;Password=gd2019")]
        public string connectionString {
            get {
                return ((string)(this["connectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2019-01-01 12:00:00")]
        public string fechaSistema {
            get {
                return ((string)(this["fechaSistema"]));
            }
            set {
                this["fechaSistema"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("yyyy-MM-dd HH:mm:ss")]
        public string formatoFecha {
            get {
                return ((string)(this["formatoFecha"]));
            }
            set {
                this["formatoFecha"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9000")]
        public string Command_Timeout {
            get {
                return ((string)(this["Command_Timeout"]));
            }
            set {
                this["Command_Timeout"] = value;
            }
        }
    }
}
