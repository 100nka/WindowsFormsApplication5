﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WFA_FISGenerator.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\")]
        public string L5X_file_dir {
            get {
                return ((string)(this["L5X_file_dir"]));
            }
            set {
                this["L5X_file_dir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\")]
        public string XLSM_cust_file_dir {
            get {
                return ((string)(this["XLSM_cust_file_dir"]));
            }
            set {
                this["XLSM_cust_file_dir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\")]
        public string XLSM_General_dir {
            get {
                return ((string)(this["XLSM_General_dir"]));
            }
            set {
                this["XLSM_General_dir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\")]
        public string SavePath {
            get {
                return ((string)(this["SavePath"]));
            }
            set {
                this["SavePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\")]
        public string XLSM_designSheet {
            get {
                return ((string)(this["XLSM_designSheet"]));
            }
            set {
                this["XLSM_designSheet"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Pf_Alarm8\\((?<FBI>.*?),(?<I1>\\d+),(?<I2>\\d+),(?<I3>\\d+),(?<I4>\\d+),(?<I5>\\d+),(?<" +
            "I6>\\d+),(?<I7>\\d+),(?<I8>\\d+),(?<zVar>.*?),.*?\\)")]
        public string filtr_PF_Alarm8 {
            get {
                return ((string)(this["filtr_PF_Alarm8"]));
            }
            set {
                this["filtr_PF_Alarm8"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool cbupdateactualDesignSheet {
            get {
                return ((bool)(this["cbupdateactualDesignSheet"]));
            }
            set {
                this["cbupdateactualDesignSheet"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool cbcreateNew {
            get {
                return ((bool)(this["cbcreateNew"]));
            }
            set {
                this["cbcreateNew"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool cbCreateTxTout {
            get {
                return ((bool)(this["cbCreateTxTout"]));
            }
            set {
                this["cbCreateTxTout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool cbCreateL5Xout {
            get {
                return ((bool)(this["cbCreateL5Xout"]));
            }
            set {
                this["cbCreateL5Xout"] = value;
            }
        }
    }
}
