﻿#pragma checksum "..\..\..\View\FilePathDisplay.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "49028601CFD5AA853EFD54CB2EB6D735255843923C860842AC28BA0CD70DFB6B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LogosLoggingUtility.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LogosLoggingUtility.View {
    
    
    /// <summary>
    /// FilePathDisplay
    /// </summary>
    public partial class FilePathDisplay : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\View\FilePathDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bttn_OpenFileLocation;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\FilePathDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FileHeader;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\FilePathDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FilePath;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\View\FilePathDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bttn_FindFileLocation;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LogosLoggingUtility;component/view/filepathdisplay.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\FilePathDisplay.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Bttn_OpenFileLocation = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\View\FilePathDisplay.xaml"
            this.Bttn_OpenFileLocation.Click += new System.Windows.RoutedEventHandler(this.Bttn_OpenFileLocation_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FileHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.FilePath = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Bttn_FindFileLocation = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\View\FilePathDisplay.xaml"
            this.Bttn_FindFileLocation.Click += new System.Windows.RoutedEventHandler(this.Bttn_FindFileLocation_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

