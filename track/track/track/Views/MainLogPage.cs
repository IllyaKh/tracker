using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace track.Views
{
    class MainLogPage : ContentPage
    {
        public MainLogPage()
        {
            StackLayout layout = new StackLayout();
            Grid graphs = new Grid()
            {
                ColumnSpacing = 20,
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star), }
                }
            };


            Grid buttons = new Grid()
            {
                ColumnSpacing = 20,
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) }
                }
            };
            Button b1 = new Button
            {
                BackgroundColor = Color.Green
            };
            Button b2 = new Button
            {
                BackgroundColor = Color.Green
            };
            Button b3 = new Button
            {
                BackgroundColor = Color.Red
            };

            graphs.Children.Add(b1,0,0);
            graphs.Children.Add(b2,1,0);
            graphs.Children.Add(b3,2,0);
            layout.Children.Add(graphs);
            Button b = new Button()
            {
                Text = "hhhh"
            };
            layout.Children.Add(b);

            Content = layout;



        }
    }
}