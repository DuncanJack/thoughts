using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ErrorRoseAnalysis
{
    public class Page4 : ContentPage
    {
        public Page4()
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
                Style = SKPaintStyle.Fill
            };

            SKPath pathA = new SKPath();
            pathA.MoveTo(0, 0);

            pathA.LineTo(0.1f * info.Width, -0.1f * info.Height);
            pathA.LineTo(0.3f * info.Width, -0.2f * info.Height);
            pathA.LineTo(0.5f * info.Width, -0.4f * info.Height);

            pathA.LineTo(0, -0.5f * info.Height);

            pathA.LineTo(-0.5f * info.Width, -0.4f * info.Height);
            pathA.LineTo(-0.3f * info.Width, -0.2f * info.Height);
            pathA.LineTo(-0.1f * info.Width, -0.1f * info.Height);

            pathA.Close();

            canvas.DrawPath(pathA, paintA);

            //SKPaint paintB= new SKPaint
            //{
            //    IsAntialias = true,
            //    Color = SKColors.Blue,
            //    Style = SKPaintStyle.Fill
            //};

            //SKPath pathB = new SKPath();
            //pathB.MoveTo(0, 0);
            //pathB.LineTo(info.Width / 8, -info.Height / 4);
            //pathB.LineTo(0, -info.Height / 2);
            //pathB.LineTo(-info.Width / 8, -info.Height / 4);
            //pathB.Close();

            //canvas.DrawPath(pathB, paintB);
        }
    }
}

