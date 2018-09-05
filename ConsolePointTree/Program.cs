﻿using System;

namespace ConsolePointTree
{
    class Program
    {
        static void Main(string[] args)
        {
            KdTree<Point3D, float> kdTree = new KdTree<Point3D, float>();
            kdTree.Add(new Point3D(20.0f, 10.0f, 3.0f));
            kdTree.Add(new Point3D(5.0f, 3.0f, 12.0f));
            kdTree.Add(new Point3D(2.0f, 12.0f, 2.0f));
            kdTree.Add(new Point3D(1.0f, 61.0f, 3.0f));
            kdTree.Add(new Point3D(3.0f, 16.0f, 40.0f));
            kdTree.Add(new Point3D(-3.0f, -16.0f, -40.0f));
            kdTree.Add(new Point3D(-5.0f, -18.0f, -4.0f));

            kdTree.Create();

            kdTree.RangeSearch(new Point3D(3.0f, 2.0f, 10.0f), new Point3D(6.0f, 5.0f, 13.0f));
        }
    }
}