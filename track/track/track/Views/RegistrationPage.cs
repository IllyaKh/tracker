using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace track.Views
{
    interface ICorrect
    {
        bool RegistrationPass();
    }

    interface ISame:ICorrect
    {
        bool IsSame(); 
    }
    interface IFull: ICorrect
    {
        bool IsFull();
        bool IsLength();
    }

 /*   interface IPass : ICorrect
    {
        bool CheckPassValid();
    }
    */
    public class RegistrationPage : ContentPage,ISame, IFull
	{
        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        private Entry _nameEntry;
        private Entry _surnameEntry;
        private Entry _passwordEntry;
        private Entry _loginEntry;
        private Entry _passwordEntryR;
        private readonly Button _regButton;

        public bool IsSame()
        {
            if (_passwordEntryR.Text == _passwordEntry.Text)
                return true;
            return false;
        }
        private async void _regButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Models.User>();

            var maxPK = db.Table<Models.User>().OrderByDescending(c => c.Id).FirstOrDefault();
            Models.User user = new Models.User
            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                Surname = _surnameEntry.Text,
                Name = _nameEntry.Text,
                Login = _loginEntry.Text,
                Password = _passwordEntry.Text
                
            };
            db.Insert(user);
            await DisplayAlert(null, user.Name + "with" + user.Id + "New User successfully signed up!", "All right");
            await Navigation.PopAsync();
        }

        public bool RegistrationPass()
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public bool IsLength()
        {
            throw new NotImplementedException();
        }

        public RegistrationPage ()
		{
            this.Title = "Registration Page";
            StackLayout stackLayout = new StackLayout();

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
            _passwordEntryR = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Password confirmation",
                IsPassword = true

            };
            stackLayout.Children.Add(_passwordEntryR);
            _regButton = new Button
            {
                Text ="Sign Up",
                BackgroundColor = Color.FromHex("1c74da")
            };
            _regButton.Clicked += _regButton_Clicked;
            stackLayout.Children.Add(_regButton);
            Content = stackLayout;

        }

       
	}
}