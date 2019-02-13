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


namespace track.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Diagrams : ContentPage
	{
        List<Entry> entries = new List<Entry>
          {
                new Entry((float)5.6)
                {
                    Label = "10.02.2019",
                    ValueLabel = "5.6",
                    Color = SKColor.Parse("#00FF7F")
                },
               new Entry((float)8.6)
                {
                    Label = "11.02.2019",
                    ValueLabel = "8.6",
                    Color = SKColor.Parse("#FF0000")
                },
               new Entry((float)4.6)
                {
                    Label = "12.02.2019",
                    ValueLabel = "4.6",
                    Color = SKColor.Parse("#20B2AA")
                }
            };
        public Diagrams ()
		{
			InitializeComponent();
           
            var chart = new LineChart() { Entries = entries };
            var chart1 = new BarChart() { Entries = entries };
            var chart2 = new PointChart() { Entries = entries };
        
            Sugar.Chart = chart;
            Sugar1.Chart = chart1;
            Sugar2.Chart = chart2;
          

        }
    }
}