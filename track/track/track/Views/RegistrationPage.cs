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
        string[] RegistrationPass();
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

 
    public class RegistrationPage : ContentPage, ISame, IFull,ICorrect
    {
        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        private Entry _nameEntry;
        private Entry _surnameEntry;
        private Entry _passwordEntry;
        private Entry _loginEntry;
        private Entry _passwordEntryR;
        private readonly Button _regButton;

     
        public string[] RegistrationPass()
        {
            string[] text= new string[3];
            text[0] = "Incorrect password";
            text[2] = "Retry";
            if (!IsLength())
            {       
                text[1] = "Your password hasn`t got 6-15 symbols";
                return text;
            }
            else if (!IsFull())
            {
                text[1] = "Your password hasn`t got A-Z and 1-0 symbols ";
                return text;
            }
            else if (!IsSame())
            {
                text[1] = "Your passwords aren`t same ";
                return text;
            }
            text[0] = "Success";
            text[1] = "You have been successfully signed up!";
            text[2] = "Continue";
            return text;
        }
        public bool IsSame()
        {
            if (_passwordEntry.Text == _passwordEntryR.Text)
                return true;
            return false;
        }
        private async void _regButton_Clicked(object sender, EventArgs e)
        {
            string[] text = new string[3];
            text = RegistrationPass();
            if(text[2] == "Retry")
            {
                await DisplayAlert(text[0], text[1], text[2]);
                _passwordEntry.Text = null;
                _passwordEntryR.Text = null;
                return;
            }
            
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
            await DisplayAlert(null, user.Name + "with ID: " + user.Id + " successfully signed up!", "All right");
            await Navigation.PopAsync();
        }

      

        public bool IsFull()
        {
            if (_passwordEntry == null || _passwordEntry.Text == null|| _passwordEntry.Text == " " || _passwordEntry.Text == "")
                return false;

            bool isUpperFlag = false, isNumberFlag = false;
            string str = _passwordEntry.Text;
            int l = _passwordEntry.Text.Length;

            foreach (char letter in str)
            {
                if (Char.IsUpper(letter))
                {
                    isUpperFlag = true;
                    break;
                }
            }

            for (int i = 0; i < l; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    isNumberFlag = true;
                    break;
                }
            }
            if (isUpperFlag == true && isNumberFlag == true)
                return true;
            else
                return false;
        }

        public  bool IsLength()
        {
            if (_passwordEntry == null || _passwordEntry.Text == null || _passwordEntry.Text == " " || _passwordEntry.Text == "")
                return false;
            if (_passwordEntry.Text.Length > 15 || _passwordEntry.Text.Length < 6)
                return false;
            else
                return true;
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
                Text = "Sign Up",
                BackgroundColor = Color.FromHex("1c74da"),
                TextColor = Color.White
            };
            _regButton.Clicked += _regButton_Clicked;
            stackLayout.Children.Add(_regButton);
            Content = stackLayout;

        }

       
	}
}