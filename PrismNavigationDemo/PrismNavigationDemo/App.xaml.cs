﻿using System.Threading.Tasks;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using PrismNavigationDemo.ViewModels;
using PrismNavigationDemo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismNavigationDemo
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        public Task StartAsync()
        {
            return Task.Run(async () =>
            {
                await NavigationService.NavigateAsync("NavigationPage/MainPage");
            });
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<INavigationService, Prism.Xamarin.AsyncNavigation.PageNavigationService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<FirstPage, FirstPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondPage, SecondPageViewModel>();
        }
    }
}
