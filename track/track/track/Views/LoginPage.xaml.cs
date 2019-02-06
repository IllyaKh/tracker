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
     
    }
    
    
}