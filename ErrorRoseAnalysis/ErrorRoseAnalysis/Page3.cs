using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ErrorRoseAnalysis
{
    public class Page3 : ContentPage
    {
        Stopwatch stopwatch = new Stopwatch();

        View3 a;
        View3 b;
        View3B c;
        View3B d;

        public Page3()
        {
            var grid = new Grid();

            grid.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) }
            };

            grid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) }
            };

            a = new View3(stopwatch);
            b = new View3(stopwatch);
            c = new View3B(stopwatch, "Button1");
            d = new View3B(stopwatch, "Button2");

            grid.Children.Add(a, 0, 0);
            grid.Children.Add(b, 0, 1);
            grid.Children.Add(c, 1, 0);
            grid.Children.Add(d, 1, 1);

            Content = grid;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnAppearing()
        {
            stopwatch.Start();
            c.Start();
            d.Start();
        }

        protected override void OnDisappearing()
        {
            stopwatch.Stop();
            c.Stop();
            d.Stop();
        }
    }
}

