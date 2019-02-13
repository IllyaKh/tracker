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

namespace track.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage, IFull
    {
        public static int curId;
        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        private Entry _passwordEntry;
        private Entry _loginEntry;
        private readonly Button _signInButton;
        

        public LoginPage()
        {
         
            StackLayout stackLayout = new StackLayout();
            _loginEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Your login"
            };
            stackLayout.Children.Add(_loginEntry);
            _passwordEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Password",
                IsPassword = true
            };
            stackLayout.Children.Add(_passwordEntry);
            _signInButton = new Button
            {
                Text = "Sign In",
                BackgroundColor = Color.FromHex("1c74da"),
                TextColor = Color.White
            };
            _signInButton.Clicked += _signInButton_Clicked;
            stackLayout.Children.Add(_signInButton);
            Content = stackLayout;


        }
        private bool CheckPass(int num)
        {
            var db = new SQLiteConnection(_dbPath);
            if (db.Get<Models.User>(num).GetLogin() == _passwordEntry.Text)
            {
                return true;
            }
            return false;

        }
         internal int _getCur()
        {
            return curId;
        }
        private int FindId()
        {
            var db = new SQLiteConnection(_dbPath);
            var maxPK = db.Table<Models.User>().OrderByDescending(c => c.Id).FirstOrDefault();
            for (int i = 1; i <= maxPK.Id; i++)
            {
                if (db.Get<Models.User>(i).GetLogin() == _loginEntry.Text)
                    return i;                    
            }
            return -1;
        }
        private bool ValidPass(int lockId)
        {
            var db = new SQLiteConnection(_dbPath);
            if (db.Get<Models.User>(lockId).GetPassword() == _passwordEntry.Text)
            {
                return true;
            }
            return false;
        }

        private async void _signInButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            string[] text = new string[3];
            text = RegistrationPass();
            if (text[1] == "Retry")
            {
                await DisplayAlert(text[0], text[1], text[2]);
                return;
            }
            curId = FindId();
            if (curId != -1)
            {
                if (ValidPass(curId))
                {

                    await DisplayAlert("Success", db.Get<Models.User>(curId).GetLogin() + " " + db.Get<Models.User>(curId).GetPassword(), "OK!");
                    await Navigation.PushAsync(new MainPageD());
                }
                else
                    await DisplayAlert("Error", "Password is not valid", "Retry");
            }
            else
                await DisplayAlert("Error", "Login isn`t correct", "Retry");

        }

        public bool IsFull()
        {
            if (_passwordEntry == null || _passwordEntry.Text == null || _passwordEntry.Text == " " || _passwordEntry.Text == "")
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

        public bool IsLength()
        {
            if (_passwordEntry == null || _passwordEntry.Text == null || _passwordEntry.Text == " " || _passwordEntry.Text == "")
                return false;
            if (_passwordEntry.Text.Length > 15 || _passwordEntry.Text.Length < 6)
                return false;
            else
                return true;
        }

        public string[] RegistrationPass()
        {
            string[] text = new string[3];
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

            return text;
        }


    }


}