﻿// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using System.Numerics;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Xunit;

namespace SixLabors.ImageSharp.Drawing.Tests.Drawing
{
    [GroupOutput("Drawing")]
    public class SolidBezierTests
    {
        [Theory]
        [WithBlankImages(500, 500, PixelTypes.Rgba32)]
        public void FilledBezier<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : struct, IPixel<TPixel>
        {
            PointF[] simplePath = {
                        new Vector2(10, 400),
                        new Vector2(30, 10),
                        new Vector2(240, 30),
                        new Vector2(300, 400)
            };

            Color blue = Color.Blue;
            Color hotPink = Color.HotPink;

            using (Image<TPixel> image = provider.GetImage())
            {
                image.Mutate(x => x.BackgroundColor(blue));
                image.Mutate(x => x.Fill(hotPink, new Polygon(new CubicBezierLineSegment(simplePath))));
                image.DebugSave(provider);
                image.CompareToReferenceOutput(provider);
            }
        }


        [Theory]
        [WithBlankImages(500, 500, PixelTypes.Rgba32)]
        public void OverlayByFilledPolygonOpacity<TPixel>(TestImageProvider<TPixel> provider)
            where TPixel : struct, IPixel<TPixel>
        {
            PointF[] simplePath = {
                        new Vector2(10, 400),
                        new Vector2(30, 10),
                        new Vector2(240, 30),
                        new Vector2(300, 400)
            };

            var color = new Rgba32(Rgba32.HotPink.R, Rgba32.HotPink.G, Rgba32.HotPink.B, 150);

            using (var image = provider.GetImage() as Image<Rgba32>)
            {
                image.Mutate(x => x.BackgroundColor(Rgba32.Blue));
                
                image.Mutate(x => x.Fill(color, new Polygon(new CubicBezierLineSegment(simplePath))));
                image.DebugSave(provider);
                image.CompareToReferenceOutput(provider);
            }
        }
    }
}
