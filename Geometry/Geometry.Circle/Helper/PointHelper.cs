﻿using DataStructure.Models.Geometry;
using System;

namespace Geometry.Helper
{
    public class PointHelper
    {
        public static int OrientationOfThreePoints(Point<double> p1, Point<double> p2, Point<double> p3)
        {
            double val = (p2.Y - p1.Y) * (p3.X - p2.X) - (p2.X - p1.X) * (p3.Y - p2.Y);

            if (val == 0) return 0;  // colinear

            // clock or counterclock wise
            return (val > 0) ? 1 : 2;
        }

        public static Point<double> RotatePoint(Point<double> pointToRotate, Point<double> centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point<double>
            (
              cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X,
              sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y
            );
        }
    }
}
