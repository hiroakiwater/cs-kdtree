using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.PointSet
{
    public interface IPointAxis<T, R>
    {
        int GetDimension();

        R CompareByAxis(int axis);

        bool InRange(T min, T max);
        bool InLeft(T min, T max, int axis);
        bool InRight(T min, T max, int axis);
    }
}
