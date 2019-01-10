using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace track
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
           
            InitializeComponent();
            Detail = new NavigationPage(new ORLOW())
            {
                BarBackgroundColor = Color.FromHex("#1c74da")
            };
            IsPresented = true;
        }
        private void Button1_Click(object sender,EventArgs e)
        {
            Detail = new NavigationPage(new ORLOW())
            {
                BarBackgroundColor = Color.FromHex("#1c74da")
            };
             IsPresented = false;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ORLOW_1())
            {
                BarBackgroundColor = Color.FromHex("#1c74da")
            };
            IsPresented = false;
        }
    }
}
