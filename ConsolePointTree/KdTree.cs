using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolePointTree
{
    class KdTree<T, R> where T : IPointAxis<T, R>
    {
        List<T> points = new List<T>();
        private KdTreeNode<T> root;

        List<T> pointsResults = new List<T>();

        public void Add(T p)
        {
            points.Add(p);
        }

        public void Create()
        {
            this.root = CreateKdTree(this.points.ToArray(), 0);
        }

        private KdTreeNode<T> CreateKdTree(T[] points, int depth)
        {
            if (points.Length == 0)
            {
                return null;
            }


            int axis = depth % points[0].GetDimension();

            T[] sortedPoints = points.OrderBy(x => x.CompareByAxis(axis)).ToArray<T>();

            //for (int i = 0; i < sortedPoints.Length; i++)
            //{
            //    Console.WriteLine("{0} : {1}", depth, sortedPoints[i].ToString());
            //}
            //Console.WriteLine("---");

            int median = points.Length / 2;
            KdTreeNode<T> node = new KdTreeNode<T>();
            node.Location = sortedPoints[median];
            node.LeftChild = CreateKdTree(sortedPoints.Take(median).ToArray(), depth + 1);
            node.RightChild = CreateKdTree(sortedPoints.Skip(median + 1).ToArray(), depth + 1);
            node.Depth = depth;
            node.Axis = axis;

            return node;
        }

        public T[] RangeSearch(T min, T max)
        {
            this.pointsResults.Clear();
            SearchNode(this.root, min, max);

            return this.pointsResults.ToArray();
        }

        private void SearchNode(KdTreeNode<T> node, T min, T max)
        {
            if (node == null)
            {
                return;
            }

            if (node.Location.InRange(min, max))
            {
                this.pointsResults.Add(node.Location);
            }

            if (node.Location.InRight(min, max, node.Axis))
            {
                SearchNode(node.LeftChild, min, max);
            }
            if (node.Location.InLeft(min, max, node.Axis))
            {
                SearchNode(node.RightChild, min, max);
            }
        }
    }
    
}
