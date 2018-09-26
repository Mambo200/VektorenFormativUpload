using Math = System.Math;

namespace VektorenFormativ
{
    public class Matrix
    {
        private readonly float[,] Values = new float[4, 4];

        public Matrix()
        {
            float[,] f = Values;
        }

        public Matrix(float[,] _values)
        {
            float[,] f = _values;
        }

        public static Matrix Translate(Vector _v)
        {
            Matrix delete = new Matrix();
            return delete;
        }

        public static Matrix Rotation(Vector _v)
        {
            Matrix delete = new Matrix();
            return delete;
        }

        private static Matrix RotateX(float _x)
        {
            Matrix delete = new Matrix();
            return delete;
        }

        private static Matrix RotateY(float _y)
        {
            Matrix delete = new Matrix();
            return delete;
        }

        private static Matrix RotateZ(float _z)
        {
            Matrix delete = new Matrix();
            return delete;
        }

        public static Matrix Scale(Vector _v)
        {
            Matrix delete = new Matrix();
            return delete;
        }

        public static Matrix TRS(Vector _pos, Vector _rot, Vector _scale)
        {
            Matrix delete = new Matrix();
            return delete;
        }

        public static Matrix operator *(Matrix _m1, Matrix _m2)
        {
            float tmp = 0;
            Matrix nm = new Matrix();
            for (int x = 0; x < _m2.Values.GetLength(0); x++)
            {
                for (int y = 0; y < _m1.Values.GetLength(1); y++)
                {
                    for (int i = 0; i < _m1.Values.GetLength(0); i++)
                    {
                        tmp = 0;
                        tmp += _m1.Values[i, y] * _m2.Values[x, i];
                        nm.Values[x, y] = tmp;
                    }
                }
            }
            return nm;
        }

        public static Vector operator *(Matrix _m, Vector _v)
        {
            Vector delete = new Vector();
            return delete;
        }

        // new
        public static Matrix operator *(Matrix _m, float _f)
        {
            Matrix nm = new Matrix(_m.Values);

            for (int i = 0; i < _m.Values.GetLength(0); i++)
            {
                for (int u = 0; u < _m.Values.GetLength(1); u++)
                {
                    nm.Values[i, u] = nm.Values[i, u] * _f;
                }
            }

            return nm;
        }

    }
}
