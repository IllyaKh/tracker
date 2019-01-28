using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace track.Views
{
    public class Show : ContentPage
    {
        private ListView _listView;
        private readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public Show()
        {
            this.Title = "111";
            var db = new SQLiteConnection(_dbPath);
            
            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();

            _listView.ItemsSource = db.Table<Models.User>().OrderBy(x => x.Name).ToList();

            stackLayout.Children.Add(_listView);
            Content = stackLayout;
        }
    }
}