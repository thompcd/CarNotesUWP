﻿using System;

using CarNotes.Core.Helpers;
using CarNotes.Core.Services;
using CarNotes.Services;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace CarNotes
{
    public sealed partial class App : Application
    {
        private IdentityService IdentityService => Singleton<IdentityService>.Instance;

        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();

            // TODO: Add your app in the app center and set your secret here. More at https://docs.microsoft.com/appcenter/sdk/getting-started/uwp
            AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));
            UnhandledException += OnAppUnhandledException;

            // Deferred execution until used. Check https://docs.microsoft.com/dotnet/api/system.lazy-1 for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
            IdentityService.LoggedOut += OnLoggedOut;
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private void OnAppUnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // TODO: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.unhandledexception
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.MainPage), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }

        private async void OnLoggedOut(object sender, EventArgs e)
        {
            ActivationService.SetShell(new Lazy<UIElement>(CreateShell));
            await ActivationService.RedirectLoginPageAsync();
        }
    }
}
