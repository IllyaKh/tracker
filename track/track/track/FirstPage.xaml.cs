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
        }
        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistarionPage());
        }
        private async void RegButton_Clicked(object sender, EventArgs e)
        {   
            await Navigation.PushModalAsync(new ORLOW());
        }

    }
 
}