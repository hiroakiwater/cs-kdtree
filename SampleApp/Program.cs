using System;
using Geometry.PointSet;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            KdTree<Point3D, float> kdTree = new KdTree<Point3D, float>();
            kdTree.Add(new Point3D(20.0f, 10.0f, 3.0f));
            kdTree.Add(new Point3D(5.0f, 3.0f, 12.0f));
            kdTree.Add(new Point3D(5.0f, 3.5f, 11.0f));
            kdTree.Add(new Point3D(2.0f, 12.0f, 2.0f));
            kdTree.Add(new Point3D(1.0f, 61.0f, 3.0f));
            kdTree.Add(new Point3D(3.0f, 16.0f, 40.0f));
            kdTree.Add(new Point3D(-3.0f, -16.0f, -40.0f));
            kdTree.Add(new Point3D(-5.0f, -18.0f, -4.0f));

            kdTree.Create();

            Point3D[] results = kdTree.RangeSearch(new Point3D(3.0f, 2.0f, 10.0f), new Point3D(6.0f, 5.0f, 13.0f));
            Console.WriteLine("result 1:");
            foreach (Point3D i in results)
            {
                Console.WriteLine(i.ToString());
            }

            Point3D[] results2 = kdTree.RangeSearch(new Point3D(2.0f, 10.0f, 30.0f), new Point3D(4.0f, 20.0f, 50.0f));
            Console.WriteLine("result 2:");
            foreach (Point3D i in results2)
            {
                Console.WriteLine(i.ToString());
            }


            KdTree<Point3D, float> kdTreeBitmap = new KdTree<Point3D, float>();
            StreamWriter writer = new StreamWriter("pointset.csv");
            StreamWriter writer_search = new StreamWriter("search.csv");

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                float x = (float)random.NextDouble() * 200;
                float y = (float)random.NextDouble() * 200;

                
                kdTreeBitmap.Add(new Point3D(x, y, 11.0f));

                writer.WriteLine("{0}\t{1}", x, y);
            }
            writer.Close();

            kdTreeBitmap.Create();


            Point3D[] results_search = kdTreeBitmap.RangeSearch(new Point3D(100.0f, 100.0f, 0.0f), new Point3D(150.0f, 150.0f, 13.0f));
            Console.WriteLine("result 1:");
            foreach (Point3D i in results_search)
            {
                Console.WriteLine(i.ToString());
                writer_search.WriteLine("{0}\t{1}", i.X, i.Y);
            }
            writer_search.Close();
        }
    }
}
