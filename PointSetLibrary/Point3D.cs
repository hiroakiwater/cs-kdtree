using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.PointSet
{
    public class Point3D : IPointAxis<Point3D, float>
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Point3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public float CompareByAxis(int axis)
        {
            if (axis == 0)
            {
                return this.X;
            }
            else if (axis == 1)
            {
                return this.Y;
            }
            else
            {
                return this.Z;
            }
        }

        public int GetDimension()
        {
            return 3;
        }


        public bool InRange(Point3D min , Point3D max)
        {
            if (min.X < this.X && max.X > this.X)
            {
                if (min.Y < this.Y && max.Y > this.Y)
                {
                    if (min.Z < this.Z && max.Z > this.Z)
                    {
                        return true;
                    }
                }
            }
           
            return false;
            
        }

        public bool InLeft(Point3D min, Point3D max, int axis)
        {
            if (axis == 0)
            {
                if (min.X < this.X && max.X < this.X)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (axis == 1)
            {
                if (min.Y < this.Y && max.Y < this.Y)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (min.Z < this.Z && max.Z < this.Z)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
        }

        public bool InRight(Point3D min, Point3D max, int axis)
        {
            if (axis == 0)
            {
                if (min.X > this.X && max.X > this.X)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (axis == 1)
            {
                if (min.Y > this.Y && max.Y > this.Y)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (min.Z > this.Z && max.Z > this.Z)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

        public override string ToString()
        {
            return this.X.ToString() + "," + this.Y.ToString() + "," + this.Z.ToString();
        }
    }
}
