﻿#pragma checksum "..\..\..\Pages\TicketPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "594869FA0511BF7B01A41341A30DF37C04B50219ABE527633B8EC380D2FD864E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HTTPClient.Pages;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace HTTPClient.Pages {
    
    
    /// <summary>
    /// TicketPage
    /// </summary>
    public partial class TicketPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonBack;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridCheckRequest;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonGetCheckRequestTicket;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonPostCheckRequestTicket;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridGetRequest;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewResponse;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridPostRequest;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxWeekPostRequestTicket;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxUserPostRequestTicket;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxPricePostRequestTicket;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\Pages\TicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonPostRequestTicket;
        
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
            System.Uri resourceLocater = new System.Uri("/HTTPClient;component/pages/ticketpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\TicketPage.xaml"
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
            this.buttonBack = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Pages\TicketPage.xaml"
            this.buttonBack.Click += new System.Windows.RoutedEventHandler(this.buttonBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridCheckRequest = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.buttonGetCheckRequestTicket = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Pages\TicketPage.xaml"
            this.buttonGetCheckRequestTicket.Click += new System.Windows.RoutedEventHandler(this.buttonGetCheckRequestTicket_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonPostCheckRequestTicket = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Pages\TicketPage.xaml"
            this.buttonPostCheckRequestTicket.Click += new System.Windows.RoutedEventHandler(this.buttonPostCheckRequestTicket_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gridGetRequest = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.listViewResponse = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.gridPostRequest = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.textBoxWeekPostRequestTicket = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.textBoxUserPostRequestTicket = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.textBoxPricePostRequestTicket = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.buttonPostRequestTicket = ((System.Windows.Controls.Button)(target));
            
            #line 145 "..\..\..\Pages\TicketPage.xaml"
            this.buttonPostRequestTicket.Click += new System.Windows.RoutedEventHandler(this.buttonPostRequestTicket_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 81 "..\..\..\Pages\TicketPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonInformationItem_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 91 "..\..\..\Pages\TicketPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonEditItem_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 101 "..\..\..\Pages\TicketPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonDeleteItem_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

