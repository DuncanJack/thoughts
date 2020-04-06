using System;
using System.Diagnostics;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ErrorRoseAnalysis
{
    public class View3 : ContentView
    {
        Stopwatch _stopwatch;
        SKCanvasView canvasView;

        public View3(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;

            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Console.WriteLine("TAPPED");
            };
            GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.DarkRed);

            SKPaint paint = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.White,
                Style = SKPaintStyle.Fill
            };

            canvas.DrawCircle(info.Width / 4f, info.Height / 4f, info.Width / 4f, paint);
        }
    }
}

