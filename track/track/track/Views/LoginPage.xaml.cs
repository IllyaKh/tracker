using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace track.Views
{
    public interface IValidationRule<T>
    {
        string Description { get; }
        bool Validate(T value);
    }

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // Indicates that the ViewModel is busy
        public bool IsBusy { get; protected set; }
    }
    public class PasswordValidator : IValidationRule<string>
    {
        const int minLength = 6;
        public string Description =>
        $"Password should be at least {minLength} characters long.";
        public bool Validate(string value) =>
        !string.IsNullOrEmpty(value) && value.Length >= minLength;
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

        }
        public  async void Lol()
        {
            await DisplayAlert("kk", "kk", "kk");
        }
    }
    
    public class EmailValidator : IValidationRule<string>
    {
        const string pattern = @"^(?!\.)(“”([^””\r\\]|\\[“”\r\\])*””|” + @”([-a - z0 - 9!#$%&’*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)” + @”@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        public string Description => "Please enter a valid email.";
        public bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(value);
        }
    }
    public class LoginViewModel : BaseViewModel
    {
        public ValidatableObject<string> Email { get; }
        public ValidatableObject<string> Password { get; }
        public ICommand LoginCmd { get; }

        Action propChangedCallBack => (LoginCmd as Command).ChangeCanExecute;
        public LoginViewModel()
        {/*
            LoginCmd = new Command(
                async () => await Login(),
                () => Email.IsValid && Password.IsValid && !IsBusy);

            Email = new ValidatableObject<string>
                (propChangedCallBack, new EmailValidator());
            Password = new ValidatableObject<string>
                (propChangedCallBack, new PasswordValidator());

            async Task Login() => (
                
            };*/
        }
        public class ValidatableObject<T> : BaseViewModel
        {
            // Collection of validation rules to apply
            public List<IValidationRule<T>> Validations { get; }
                = new List<IValidationRule<T>>();


            // The value itself
            public T Value { get; set; }
            // PropertyChanged.Fody will call this method on Value change
            void OnValueChanged() => propertyChangedCallback?.Invoke();


            readonly Action propertyChangedCallback;
            public ValidatableObject(
                Action propertyChangedCallback = null,
                params IValidationRule<T>[] validations)
            {
                this.propertyChangedCallback = propertyChangedCallback;
                foreach (var val in validations)
                    Validations.Add(val);
            }

            // PropertyChanged.Fody attribute, on Value change IsValid will change as well
            [DependsOn(nameof(Value))]
            public bool IsValid => Validations.TrueForAll(v => v.Validate(Value));
            // Validation descriptions aggregator
            public string ValidationDescriptions =>
                string.Join(Environment.NewLine, Validations.Select(v => v.Description));
        }

    }
}