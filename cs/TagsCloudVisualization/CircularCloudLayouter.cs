﻿using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public class CircularCloudLayouter
    {
        public Point Center => spiral.Center;
        private readonly Spiral spiral;
        private readonly List<Rectangle> rectangles = new List<Rectangle>();

        public IEnumerable<Rectangle> Rectangles => rectangles;

        public CircularCloudLayouter(Point center)
        {
            spiral = new Spiral(center);
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            Rectangle rect;
            do
                rect = new Rectangle(spiral.GetNextSpiralPosition(), rectangleSize);
            while (rect.IntersectsWithAnyFrom(rectangles));

            rectangles.Add(rect);
            return rect;
        }
    }
}