using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.PointSet
{
    class KdTreeNode<T>
    {
        public T Location { get; set; }
        public KdTreeNode<T> LeftChild { get; set; }
        public KdTreeNode<T> RightChild { get; set; }
        public int Depth { get; set; }
        public int Axis { get; set; }
    }
}
