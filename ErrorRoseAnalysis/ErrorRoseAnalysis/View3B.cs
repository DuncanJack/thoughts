using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ErrorRoseAnalysis
{
    public class View3B : ContentView
    {
        public View3B(Stopwatch stopwatch, string text)
        {
            var button = new Button { Text = text };
            button.Clicked += (object sender, EventArgs e) => Console.WriteLine($"{text} {stopwatch.Elapsed}");
            Content = button;
        }

        internal void Start()
        {
            Console.WriteLine("Start");
        }

        internal void Stop()
        {
            Console.WriteLine("Stop");
        }
    }
}