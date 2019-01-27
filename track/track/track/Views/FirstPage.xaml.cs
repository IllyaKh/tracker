using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using track.Views;

namespace track
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstPage : ContentPage
	{
		public FirstPage ()
		{
			InitializeComponent ();
            Image1.Source = ImageSource.FromResource("track.heart-health.png");
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ViewModel_HL();
            AdminPanel_Clicked();
            
        }
        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.LoginPage());
        }
        private async void RegButton_Clicked(object sender, EventArgs e)
        {   
            await Navigation.PushAsync(new Views.RegistrationPage());
        }
        private void AdminPanel_Clicked()
        {
            AdminPanel.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await DisplayAlert("Admin Panel", "Тут можно все сломать.", "НУ ПОГНАЛИ");
                    await Navigation.PushAsync(new AdminPage());
                })
            });
        }

    }
 
}