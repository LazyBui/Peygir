﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Peygir.Presentation.Forms.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("amir_saniyan@yahoo.com")]
        public string ProgrammerEmail {
            get {
                return ((string)(this["ProgrammerEmail"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool FormatDateTime {
            get {
                return ((bool)(this["FormatDateTime"]));
            }
            set {
                this["FormatDateTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PersianCalendar")]
        public string Calendar {
            get {
                return ((string)(this["Calendar"]));
            }
            set {
                this["Calendar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("yyyy/MM/dd HH:mm:ss")]
        public string DateTimePattern {
            get {
                return ((string)(this["DateTimePattern"]));
            }
            set {
                this["DateTimePattern"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("{0}\\Help\\Help.htm")]
        public string HelpPath {
            get {
                return ((string)(this["HelpPath"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("en")]
        public string Language {
            get {
                return ((string)(this["Language"]));
            }
            set {
                this["Language"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Tahoma")]
        public string SansSerifFont {
            get {
                return ((string)(this["SansSerifFont"]));
            }
            set {
                this["SansSerifFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8.25")]
        public float SansSerifFontSize {
            get {
                return ((float)(this["SansSerifFontSize"]));
            }
            set {
                this["SansSerifFontSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Courier New")]
        public string MonospaceFont {
            get {
                return ((string)(this["MonospaceFont"]));
            }
            set {
                this["MonospaceFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9")]
        public float MonospaceFontSize {
            get {
                return ((float)(this["MonospaceFontSize"]));
            }
            set {
                this["MonospaceFontSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool WordWrapDefault {
            get {
                return ((bool)(this["WordWrapDefault"]));
            }
            set {
                this["WordWrapDefault"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseSansSerifDefault {
            get {
                return ((bool)(this["UseSansSerifDefault"]));
            }
            set {
                this["UseSansSerifDefault"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Regular")]
        public global::System.Drawing.FontStyle MonospaceFontStyle {
            get {
                return ((global::System.Drawing.FontStyle)(this["MonospaceFontStyle"]));
            }
            set {
                this["MonospaceFontStyle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Regular")]
        public global::System.Drawing.FontStyle SansSerifFontStyle {
            get {
                return ((global::System.Drawing.FontStyle)(this["SansSerifFontStyle"]));
            }
            set {
                this["SansSerifFontStyle"] = value;
            }
        }
    }
}
