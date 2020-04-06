using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ErrorRoseAnalysis
{
    public class Page1 : ContentPage
    {
        private Label label;
        private SKCanvasView canvasView;
        private float counter = 0f;

        public Page1()
        {
            Content = GetGrid();

            Device.StartTimer(TimeSpan.FromSeconds(1), Animate);
        }

        private Grid GetGrid()
        {
            var grid = new Grid();

            grid.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition{ Width = new GridLength(3, GridUnitType.Star) },
                new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) }
            };

            grid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition{ Height = new GridLength(3, GridUnitType.Star) },
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) }
            };

            var a = new BoxView { BackgroundColor = Color.Red };
            label = new Label { Text = "0", FontSize = 30 };
            var c = new Button { Text = "Click me"};
            c.Clicked += (object sender, EventArgs e) => Console.WriteLine("Clicked");
            var d = new Slider { Minimum = 0, Maximum = 10 };
            
            grid.Children.Add(GetSKCanvasView(), 0, 0);
            grid.Children.Add(label, 0, 1);
            grid.Children.Add(c, 1, 0);
            grid.Children.Add(d, 1, 1);

            return grid;
        }

        private SKCanvasView GetSKCanvasView()
        {
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            return canvasView;
        }

        private bool Animate()
        {
            canvasView.InvalidateSurface();
            return true;
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.Yellow);

            SKPaint paint = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.Blue,
                Style = SKPaintStyle.StrokeAndFill,
                StrokeWidth = 10
            };

            counter++;

            float factor = counter / 100f;

            label.Text = $"{counter} {factor}";

            SKPoint p0 = new SKPoint(0, 0);
            SKPoint p1 = new SKPoint(factor * info.Width,factor * info.Height);

            canvas.DrawLine(p0,p1,paint);
        }
    }
}

