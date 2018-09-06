using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.PointSet
{
    class KdTree<T, R> where T : IPointAxis<T, R>
    {
        List<T> points = new List<T>();
        private KdTreeNode<T> root;

      

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
            List<T> results = new List<T>();
            SearchNode(this.root, min, max, ref results);

            return results.ToArray();
        }

        private void SearchNode(KdTreeNode<T> node, T min, T max, ref List<T> results)
        {
            if (node == null)
            {
                return;
            }

            if (node.Location.InRange(min, max))
            {
                results.Add(node.Location);
            }

            if (node.Location.InRight(min, max, node.Axis))
            {
                SearchNode(node.LeftChild, min, max, ref results);
            }
            if (node.Location.InLeft(min, max, node.Axis))
            {
                SearchNode(node.RightChild, min, max, ref results);
            }
        }
    }
}
