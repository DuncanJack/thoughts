using System;
using SkiaSharp;

namespace ErrorRoseAnalysis.Shared
{
    public class Route
    {
        public SKPath Path { get; private set; }

        public Route(float length, float angle)
        {
            var segments = new Segment[5];

            for (var i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    segments[0] = new Segment(0, 0, length, 1 * angle);
                }
                else
                {
                    segments[i] = new Segment(segments[i - 1].X1, segments[i - 1].Y1, length, (i + 1) * angle);
                }
            }

            Path = new SKPath();
            Path.MoveTo(0, 0);
            for (var i = 0; i < 5; i++)
            {
                Path.LineTo(segments[i].X1, -segments[i].Y1);
            }
        }
    }
}