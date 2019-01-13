using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;

namespace track
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistarionPage : ContentPage
	{
        private static readonly HttpClient client = new HttpClient();
        private static readonly string HelloUrl="http://192.168.0.15/serv/DoMath";

		public RegistarionPage ()
		{
            
            InitializeComponent();
		}

        private async void ServClick(object sender, EventArgs e)
        {
            DigitPair dP = new DigitPair()
            {
                Username = Convert.ToDouble(Entry1.Text),
                Password = Convert.ToDouble(Entry2.Text)
            };

            string jsonStr =JsonConvert.SerializeObject(dP);

            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"s", jsonStr}
            };

            FormUrlEncodedContent form = new FormUrlEncodedContent(dict);
            HttpResponseMessage response = await client.PostAsync(HelloUrl,form);

            string result = await response.Content.ReadAsStringAsync();
            await DisplayAlert("hi", result, "ok");

        }
	}
}