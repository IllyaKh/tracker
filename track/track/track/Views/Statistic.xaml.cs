using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;
using Microcharts.Forms;
using System.IO;
using SQLite;

namespace track.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistic : ContentPage
    {
        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        static float value = 10.0F;
        static float current=10.0F;
        private float StepValue= 0.1F;
      

        Entry[] entries = new []
          {
                new Entry(value-current)
                {
                    Label = "",
                     
                    Color = SKColor.Parse("#ffffff")
                },
             new Entry(current)
                {
                    Label = "",

                    ValueLabel = "Your sugar now: "+current.ToString(),
                    
                    Color = SKColor.Parse("#1c74da")
                },

            };


        public Statistic()
        {
            var db = new SQLiteConnection(_dbPath);
           
            InitializeComponent();
            if(Settings.cc == 1)
                {
                SliderMain.MinimumTrackColor = Color.FromHex("#008000");
                SliderMain.ThumbColor = Color.FromHex("#008000");
                entries[1].Color = SKColor.Parse("#008000");
                but.BackgroundColor= Color.FromHex("#008000");

            }

            else if (Settings.cc == 3)
            {
                SliderMain.MinimumTrackColor = Color.FromHex("#ff0000");
                SliderMain.ThumbColor = Color.FromHex("#ff0000");
                entries[1].Color = SKColor.Parse("#ff0000");
                but.BackgroundColor = Color.FromHex("#ff0000");

            }

           else
            {
                SliderMain.MinimumTrackColor = Color.FromHex("#1c74da");
                SliderMain.ThumbColor = Color.FromHex("#1c74da");
                entries[1].Color = SKColor.Parse("#1c74da");
                but.BackgroundColor = Color.FromHex("#1c74da");

            }
            SliderMain.MinimumTrackColor = Color.FromHex("#008000");
            var chart = new DonutChart() { Entries = entries };
            Sugar.Chart = chart;
           
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            var newStep = Math.Round(args.NewValue / StepValue);
            double value = args.NewValue;

            SliderMain.Value = newStep * StepValue;
            displayLabel.Text = String.Format("Sugar is: {0:0.0} mMol/l", SliderMain.Value);
            current = (float)SliderMain.Value;
        }

        private async void addPost(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

         
            //int ident = LoginPage.curId;
           // db.InsertOrReplace(data);
            await Navigation.PushAsync(new AddSugar());
            await Navigation.PushAsync(new Statistic());
           
        }
    }
}