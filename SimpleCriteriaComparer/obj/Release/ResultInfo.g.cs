﻿#pragma checksum "..\..\ResultInfo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E548694A70DCAE9C4FB71780DDBC1692"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PieControls;
using SimpleCriteriaComparer;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using Xceed.Wpf.Toolkit;


namespace SimpleCriteriaComparer {
    
    
    /// <summary>
    /// ResultInfo
    /// </summary>
    public partial class ResultInfo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid body;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label startInstructions;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button about;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Charts;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button continueWork;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button openTable;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock infoBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox allListsBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button alternativeShow;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button returnToMain;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\ResultInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/SimpleCriteriaComparer;component/resultinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ResultInfo.xaml"
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
            
            #line 12 "..\..\ResultInfo.xaml"
            ((SimpleCriteriaComparer.ResultInfo)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.ExitClick);
            
            #line default
            #line hidden
            
            #line 12 "..\..\ResultInfo.xaml"
            ((SimpleCriteriaComparer.ResultInfo)(target)).Loaded += new System.Windows.RoutedEventHandler(this.LoadedActions);
            
            #line default
            #line hidden
            return;
            case 2:
            this.body = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.startInstructions = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.about = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\ResultInfo.xaml"
            this.about.Click += new System.Windows.RoutedEventHandler(this.about_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Charts = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.continueWork = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\ResultInfo.xaml"
            this.continueWork.Click += new System.Windows.RoutedEventHandler(this.continueWork_Click);
            
            #line default
            #line hidden
            
            #line 21 "..\..\ResultInfo.xaml"
            this.continueWork.MouseMove += new System.Windows.Input.MouseEventHandler(this.GetFocusOfMouse);
            
            #line default
            #line hidden
            
            #line 21 "..\..\ResultInfo.xaml"
            this.continueWork.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LostFocusOfMouse);
            
            #line default
            #line hidden
            return;
            case 7:
            this.openTable = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\ResultInfo.xaml"
            this.openTable.Click += new System.Windows.RoutedEventHandler(this.openTable_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.infoBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.allListsBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\ResultInfo.xaml"
            this.allListsBox.MouseMove += new System.Windows.Input.MouseEventHandler(this.GetFocusOfMouse);
            
            #line default
            #line hidden
            
            #line 27 "..\..\ResultInfo.xaml"
            this.allListsBox.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LostFocusOfMouse);
            
            #line default
            #line hidden
            return;
            case 10:
            this.alternativeShow = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\ResultInfo.xaml"
            this.alternativeShow.Click += new System.Windows.RoutedEventHandler(this.ShowDataForOneAlternative);
            
            #line default
            #line hidden
            
            #line 28 "..\..\ResultInfo.xaml"
            this.alternativeShow.MouseMove += new System.Windows.Input.MouseEventHandler(this.GetFocusOfMouse);
            
            #line default
            #line hidden
            
            #line 28 "..\..\ResultInfo.xaml"
            this.alternativeShow.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LostFocusOfMouse);
            
            #line default
            #line hidden
            return;
            case 11:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\ResultInfo.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            
            #line 41 "..\..\ResultInfo.xaml"
            this.button1.MouseMove += new System.Windows.Input.MouseEventHandler(this.GetFocusOfMouse);
            
            #line default
            #line hidden
            
            #line 41 "..\..\ResultInfo.xaml"
            this.button1.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LostFocusOfMouse);
            
            #line default
            #line hidden
            return;
            case 12:
            this.returnToMain = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\ResultInfo.xaml"
            this.returnToMain.Click += new System.Windows.RoutedEventHandler(this.returnToMain_Click);
            
            #line default
            #line hidden
            
            #line 43 "..\..\ResultInfo.xaml"
            this.returnToMain.MouseMove += new System.Windows.Input.MouseEventHandler(this.GetFocusOfMouse);
            
            #line default
            #line hidden
            
            #line 43 "..\..\ResultInfo.xaml"
            this.returnToMain.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LostFocusOfMouse);
            
            #line default
            #line hidden
            return;
            case 13:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

