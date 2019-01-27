using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace track.Views
{

	public class AdminPage : ContentPage
	{
        private Entry _nameEntry;
        private Entry _surnameEntry;
        private Entry _passwordEntry;
        private Entry _loginEntry;
        private Entry _passwordEntryR;
        private readonly Button _updButton;
        Models.User _user = new Models.User();
        private ListView _listView;
        private readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public AdminPage ()
        {
            var db = new SQLiteConnection(_dbPath);
            this.Title = "AdminPage";
            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();

            _listView.ItemsSource = db.Table<Models.User>().OrderBy(x => x.Name).ToList();
            
            stackLayout.Children.Add(_listView);
            ShowContent(stackLayout);


           

            _loginEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Your login"
            };
            stackLayout.Children.Add(_loginEntry);

            _nameEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Your name"
            };
            stackLayout.Children.Add(_nameEntry);

            _surnameEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Your surname"
            };
            stackLayout.Children.Add(_surnameEntry);

            _passwordEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Password",
                IsPassword = true
            };
            stackLayout.Children.Add(_passwordEntry);
            _updButton = new Button
            {
                Text = "Update",
                BackgroundColor = Color.FromHex("1c74da")
            };
            stackLayout.Children.Add(_updButton);
            _updButton.Clicked += _updButton_Clicked;
            Content = stackLayout;
        }

        private async void _updButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Models.User user = new Models.User()
            {
                Name = _nameEntry.Text,
                Password = _passwordEntry.Text
            };
            db.Update(user);
            await Navigation.PopAsync();
        }

        private void ShowContent(StackLayout stackLayout)
        {
            Content = stackLayout;
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _user = (Models.User)e.SelectedItem;
            _nameEntry.Text = _user.Name;
            _passwordEntry.Text = _user.Password;
        }
    }
}