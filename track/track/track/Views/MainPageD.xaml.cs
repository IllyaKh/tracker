using System;
using track.Views;
using Xamarin.Forms;

namespace track
{
    public partial class MainPageD : MasterDetailPage
    {
        public MainPageD()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            masterPage.listView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                NavigationPage.SetHasNavigationBar(this, false);

                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
