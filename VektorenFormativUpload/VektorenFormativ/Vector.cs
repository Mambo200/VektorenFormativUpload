﻿using Math = System.Math;

namespace VektorenFormativ
{
    public struct Vector
    {
        public Vector(float _x, float _y, float _z)
        {
        }

        public static Vector operator +(Vector _a, Vector _b)
        {
        }

        public static Vector operator -(Vector _a, Vector _b)
        {
        }

        public static Vector operator -(Vector _a)
        {
        }

        public static Vector operator *(Vector _a, float _b)
        {
        }

        public static Vector operator /(Vector _a, float _b)
        {
        }

        public override bool Equals(object _obj)
        {
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static float Magnitude(Vector _v)
        {
        }

        public static float SqrMagnitude(Vector _v)
        {
        }

        public static Vector Cross(Vector _v1, Vector _v2)
        {
        }

        public static float Dot(Vector _v1, Vector _v2)
        {
        }

        public static Vector Normalize(Vector _v)
        {
        }

		public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }
}
