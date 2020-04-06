using System;
using ErrorRoseAnalysis.Shared;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ErrorRoseAnalysis
{
    public class A : ContentPage
    {
        public A()
        {
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.Silver);

            canvas.Translate(info.Width / 2, info.Height / 2);

            SKPaint paint = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.Black,
                StrokeWidth = 2
            };

            canvas.DrawLine(-info.Width / 2, 0, info.Width / 2, 0, paint);
            canvas.DrawLine(0, -info.Height / 2, 0, info.Height / 2, paint);

            SKPaint paintA = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.Red,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 5,
                StrokeCap = SKStrokeCap.Round,
                StrokeJoin = SKStrokeJoin.Round
            };

            for (var i = 0; i <= 72; i++)
            {
                canvas.DrawPath(new Route(100f, i).Path, paintA);
            }

            for (var i = -72; i <= 0; i++)
            {
                canvas.DrawPath(new Route(100f, i).Path, paintA);
            }
        }
    }
}