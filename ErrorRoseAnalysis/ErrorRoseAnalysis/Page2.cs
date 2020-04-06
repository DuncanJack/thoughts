using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ErrorRoseAnalysis
{
    public class Page2 : ContentPage
    {
        private SKCanvasView canvasView;
        private float m = 0;
        private Stopwatch stopwatch = new Stopwatch();

        public Page2()
        {
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            stopwatch.Start();
            _ = Animate();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            stopwatch.Stop();
        }

        async Task Animate()
        {
            while(stopwatch.IsRunning)
            {
                m++;
                canvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0));
            };
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.Red);

            var height = info.Height;
            var width = info.Width;

            SKPaint stroke = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.White,
                StrokeWidth = 5,
                Style = SKPaintStyle.Stroke
            };

            SKPaint fill = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.Blue,
                Style = SKPaintStyle.Fill
            };

            SKPath path = new SKPath();
            path.MoveTo(width / 2, 0);
            path.LineTo(width, height / 2);
            path.LineTo(width / 2, height);
            path.LineTo(0, height / 2);
            path.Close();

            canvas.DrawPath(path, stroke);
            canvas.DrawPath(path, fill);

            canvas.DrawLine(new SKPoint { X = m/10f * width / 4f, Y = m/10f * height / 4f }, new SKPoint { X = 3 * width / 4, Y = 3 * height / 4 }, stroke);

            canvas.DrawLine(new SKPoint { X = 3 * width / 4, Y = 1 * height / 4 }, new SKPoint { X = 1 * width / 4, Y = 3 * height / 4 }, stroke);
        }
    }
}

