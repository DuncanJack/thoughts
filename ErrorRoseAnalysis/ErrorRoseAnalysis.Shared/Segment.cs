using System;
using SkiaSharp;

namespace ErrorRoseAnalysis.Shared
{
    public class Segment
    {
        public Segment(float x0, float y0, float magnitude, float direction)
        {
            X1 = x0 + magnitude * (float)Math.Sin(direction * Math.PI / 180);
            Y1 = y0 + magnitude * (float)Math.Cos(direction * Math.PI / 180);
        }

        public float X1 { get; private set; }
        public float Y1 { get; private set; }
    }
}