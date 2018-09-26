using Math = System.Math;

namespace VektorenFormativ
{
    public struct Vector
    {
        public float X;
        public float Y;
        public float Z;

        public Vector(float _x, float _y, float _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        #region operator
        public static Vector operator +(Vector _a, Vector _b)
        {
            Vector v;

            v.X = _a.X + _b.X;
            v.Y = _a.Y + _b.Y;
            v.Z = _a.Z + _b.Z;

            return v;
        }

        public static Vector operator -(Vector _a, Vector _b)
        {
            Vector v;

            v.X = _a.X - _b.X;
            v.Y = _a.Y - _b.Y;
            v.Z = _a.Z - _b.Z;

            return v;
        }

        public static Vector operator -(Vector _a)
        {
            Vector v;

            v.X = -_a.X;
            v.Y = -_a.Y;
            v.Z = -_a.Z;

            return v;
        }

        public static Vector operator *(Vector _a, float _b)
        {
            Vector v;

            v.X = _a.X * _b;
            v.Y = _a.Y * _b;
            v.Z = _a.Z * _b;

            return v;
        }

        public static Vector operator /(Vector _a, float _b)
        {
            Vector v;

            v.X = _a.X / _b;
            v.Y = _a.Y / _b;
            v.Z = _a.Z / _b;

            return v;
        }
        #endregion

        public override bool Equals(object _obj)
        {
            if (_obj == null)
                return false;

            if(_obj.GetType() != typeof(Vector))
            {
                return false;
            }

            Vector tmp = new Vector();
            tmp = (Vector)_obj - this;
            if (tmp.X == 0 && tmp.Y == 0 && tmp.Z == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // mit wurzel ziehen
        // Betrag / Länge - |v|
        public static float Magnitude(Vector _v)
        {
            float f = SqrMagnitude(_v);

            f = (float)Math.Sqrt(f);

            return f;
        }

        // Ohne wurzel ziehen
        // Betrag / Länge - |v|
        public static float SqrMagnitude(Vector _v)
        {
            float f;

            f = (_v.X * _v.X) + (_v.Y * _v.Y) + (_v.Z * _v.Z);

            return f;

        }

        public static Vector Cross(Vector _v1, Vector _v2)
        {
            Vector v;

            v.X = _v1.Y * _v2.Z - _v2.Y * _v1.Z;
            v.Y = _v1.Z * _v2.X - _v2.Z * _v1.X;
            v.Z = _v1.X * _v2.Y - _v2.X * _v1.Y;

            return v;
        }

        // Skalarprodukt
        public static float Dot(Vector _v1, Vector _v2)
        {
            float f;

            f = _v1.X * _v2.X + _v1.Y * _v2.Y + _v1.Z * _v2.Z;

            return f;
        }

        // ???
        public static Vector Normalize(Vector _v)
        {
            Vector v = _v;

            v = _v / Magnitude(_v);

            return v;

        }

		public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }
}
