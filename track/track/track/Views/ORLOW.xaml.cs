using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace track
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ORLOW : ContentPage
	{

        static int value = 100;
        List<Entry> entries = new List<Entry>
          {
                new Entry(100)
                {
                    Label = "today",
                    ValueLabel = "22",
                    Color = SKColor.Parse("#1c74da")
                },
               new Entry(100)
                {
                    Label = "tod2ay",
                    ValueLabel = "22",
                    Color = SKColor.Parse("#1c74da")
                }

            };

       
        public ORLOW ()
		{

			InitializeComponent ();
            var chart = new LineChart() { Entries = entries };
            Sugar.Chart = chart;


        }

    }
}