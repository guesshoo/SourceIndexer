﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SourceIndexer {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SourceIndexer.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -c &quot;{0}&quot;.
        /// </summary>
        internal static string AlreadyIndexed {
            get {
                return ResourceManager.GetString("AlreadyIndexed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -r &quot;{0}&quot;.
        /// </summary>
        internal static string GetSourceFiles {
            get {
                return ResourceManager.GetString("GetSourceFiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SRCSRV: ini ------------------------------------------------
        ///VERSION=1
        ///SRCSRV: variables ------------------------------------------
        ///DATETIME={0}
        ///{1}
        ///SRCSRVTRG={2}
        ///SRCSRVCMD={3}
        ///SRCSRV: source files ---------------------------------------
        ///{4}
        ///SRCSRV: end ------------------------------------------------.
        /// </summary>
        internal static string SymbolStream {
            get {
                return ResourceManager.GetString("SymbolStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -w -s:srcsrv -p:&quot;{0}&quot; -i:&quot;{1}&quot;.
        /// </summary>
        internal static string WriteCommand {
            get {
                return ResourceManager.GetString("WriteCommand", resourceCulture);
            }
        }
    }
}
