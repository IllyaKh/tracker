using PropertyChanged;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using track;
using track.Views;

namespace track
{
    public partial class MainLogPage : ContentPage
    {

        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public MainLogPage()
        {
            InitializeComponent();
        }
        private async void Account_Clicked(object sender, EventArgs e)
        {

            var db = new SQLiteConnection(_dbPath);

            await DisplayAlert("INFO", db.Get<Models.User>(LoginPage.curId).GetLogin() + " " + db.Get<Models.User>(LoginPage.curId).GetPassword(), "OK!");
        }
    }
}
