using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace track.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage
	{
        public static int cc;
        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public Settings ()
		{
			InitializeComponent ();
		}
        private async void ChooseGreen(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            cc = 1;
            await Navigation.PushAsync(new Statistic());


        }
        private async void ChooseBlue(object sender, EventArgs e)
        {
            cc = 2;
            await Navigation.PushAsync(new FirstPage());


        }

        private async void ChooseRed(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            cc = 3;
            await Navigation.PushAsync(new FirstPage());
         

        }
    }
}