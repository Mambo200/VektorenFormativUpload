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
            Matrix nm = new Matrix();
            nm.Values[0, 0] = 1;
            nm.Values[1, 1] = 1;
            nm.Values[2, 2] = 1;
            nm.Values[3, 3] = 1;

            nm.Values[3, 0] = _v.X;
            nm.Values[3, 1] = _v.Y;
            nm.Values[3, 2] = _v.Z;

            return nm;
        }

        public static Matrix Rotation(Vector _v)
        {
            Matrix nm = new Matrix();

            nm = RotateX(_v.X) * RotateY(_v.Y);
            Matrix delete = RotateZ(_v.Z);
            //nm = nm * RotateZ(_v.Z);
            nm = nm * delete;


            return nm;
        }

        private static Matrix RotateX(float _x)
        {
            double angle;
            angle = System.Convert.ToDouble(_x);

            Matrix nm = new Matrix();
            nm.Values[0, 0] = 1;
            nm.Values[3, 3] = 1;

            nm.Values[1, 1] = (float)Math.Round(Math.Cos(angle));
            nm.Values[1, 2] = (float)Math.Round(Math.Sin(angle));

            nm.Values[2, 1] = (float)-(Math.Round(Math.Sin(angle)));
            nm.Values[2, 2] = (float)Math.Round(Math.Cos(angle));
            return nm;
        }

        private static Matrix RotateY(float _y)
        {
            double angle;
            angle = System.Convert.ToDouble(_y);

            Matrix nm = new Matrix();
            nm.Values[1, 1] = 1;
            nm.Values[3, 3] = 1;

            nm.Values[0, 0] = (float)Math.Round(Math.Cos(angle));
            nm.Values[0, 2] = (float)-(Math.Round(Math.Sin(angle)));

            nm.Values[2, 0] = (float)Math.Round(Math.Sin(angle));
            nm.Values[2, 2] = (float)Math.Round(Math.Cos(angle));
            return nm;
        }

        private static Matrix RotateZ(float _z)
        {
            double angle;
            angle = System.Convert.ToDouble(_z);

            Matrix nm = new Matrix();
            nm.Values[2, 2] = 1;
            nm.Values[3, 3] = 1;

            nm.Values[0, 1] = (float)Math.Round(Math.Sin(angle));
            nm.Values[0, 0] = (float)Math.Round(Math.Cos(angle));

            nm.Values[1, 0] = (float)-(Math.Round(Math.Sin(angle)));
            nm.Values[1, 1] = (float)Math.Round(Math.Cos(angle));

            return nm;
        }

        public static Matrix Scale(Vector _v)
        {
            Matrix nm = new Matrix();

            nm.Values[0, 0] = _v.X;
            nm.Values[1, 1] = _v.Y;
            nm.Values[2, 2] = _v.Z;
            nm.Values[3, 3] = 1;

            return nm;
        }

        public static Matrix TRS(Vector _pos, Vector _rot, Vector _scale)
        {
            Matrix nm = new Matrix();

            nm = Scale(_scale) * Rotation(_rot) * Translate(_pos);

            return nm;
        }

        public static Matrix operator *(Matrix _m1, Matrix _m2)
        {
            Matrix nm = new Matrix();
            //float tmp = 0;
            //for (int x = 0; x < _m2.Values.GetLength(0); x++)
            //{
            //    for (int y = 0; y < _m1.Values.GetLength(1); y++)
            //    {
            //        for (int i = 0; i < _m1.Values.GetLength(0); i++)
            //        {
            //            tmp = 0;
            //            tmp += _m1.Values[x, i] * _m2.Values[i, y];
            //            nm.Values[x, y] = tmp;
            //        }
            //    }
            //}

            nm.Values[0, 0] =
                _m1.Values[0, 0] * _m2.Values[0, 0] +
                _m1.Values[0, 1] * _m2.Values[1, 0] +
                _m1.Values[0, 2] * _m2.Values[2, 0] +
                _m1.Values[0, 3] * _m2.Values[3, 0]
                ;
            nm.Values[1, 0] =
                _m1.Values[1, 0] * _m2.Values[0, 0] +
                _m1.Values[1, 1] * _m2.Values[1, 0] +
                _m1.Values[1, 2] * _m2.Values[2, 0] +
                _m1.Values[1, 3] * _m2.Values[3, 0]
                ;
            nm.Values[2, 0] =
                _m1.Values[2, 0] * _m2.Values[0, 0] +
                _m1.Values[2, 1] * _m2.Values[1, 0] +
                _m1.Values[2, 2] * _m2.Values[2, 0] +
                _m1.Values[2, 3] * _m2.Values[3, 0]
                ;
            nm.Values[3, 0] =
                _m1.Values[3, 0] * _m2.Values[0, 0] +
                _m1.Values[3, 1] * _m2.Values[1, 0] +
                _m1.Values[3, 2] * _m2.Values[2, 0] +
                _m1.Values[3, 3] * _m2.Values[3, 0]
                ;
            // -------------------------- //
            nm.Values[0, 1] =
                _m1.Values[0, 0] * _m2.Values[0, 1] +
                _m1.Values[0, 1] * _m2.Values[1, 1] +
                _m1.Values[0, 2] * _m2.Values[2, 1] +
                _m1.Values[0, 3] * _m2.Values[3, 1]
                ;

            nm.Values[1, 1] =
                _m1.Values[1, 0] * _m2.Values[0, 1] +
                _m1.Values[1, 1] * _m2.Values[1, 1] +
                _m1.Values[1, 2] * _m2.Values[2, 1] +
                _m1.Values[1, 3] * _m2.Values[3, 1]
                ;

            nm.Values[2, 1] =
                _m1.Values[2, 0] * _m2.Values[0, 1] +
                _m1.Values[2, 1] * _m2.Values[1, 1] +
                _m1.Values[2, 2] * _m2.Values[2, 1] +
                _m1.Values[2, 3] * _m2.Values[3, 1]
                ;

            nm.Values[3, 1] =
                _m1.Values[3, 0] * _m2.Values[0, 1] +
                _m1.Values[3, 1] * _m2.Values[1, 1] +
                _m1.Values[3, 2] * _m2.Values[2, 1] +
                _m1.Values[3, 3] * _m2.Values[3, 1]
                ;
            // -------------------------- //
            nm.Values[0, 2] =
                _m1.Values[0, 0] * _m2.Values[0, 2] +
                _m1.Values[0, 1] * _m2.Values[1, 2] +
                _m1.Values[0, 2] * _m2.Values[2, 2] +
                _m1.Values[0, 3] * _m2.Values[3, 2]
                ;

            nm.Values[1, 2] =
                _m1.Values[1, 0] * _m2.Values[0, 2] +
                _m1.Values[1, 1] * _m2.Values[1, 2] +
                _m1.Values[1, 2] * _m2.Values[2, 2] +
                _m1.Values[1, 3] * _m2.Values[3, 2]
                ;

            nm.Values[2, 2] =
                _m1.Values[2, 0] * _m2.Values[0, 2] +
                _m1.Values[2, 1] * _m2.Values[1, 2] +
                _m1.Values[2, 2] * _m2.Values[2, 2] +
                _m1.Values[2, 3] * _m2.Values[3, 2]
                ;

            nm.Values[3, 2] =
                _m1.Values[3, 0] * _m2.Values[0, 2] +
                _m1.Values[3, 1] * _m2.Values[1, 2] +
                _m1.Values[3, 2] * _m2.Values[2, 2] +
                _m1.Values[3, 3] * _m2.Values[3, 2]
                ;
            // -------------------------- //
            nm.Values[0, 3] =
                _m1.Values[0, 0] * _m2.Values[0, 3] +
                _m1.Values[0, 1] * _m2.Values[1, 3] +
                _m1.Values[0, 2] * _m2.Values[2, 3] +
                _m1.Values[0, 3] * _m2.Values[3, 3]
                ;

            nm.Values[1, 3] =
                _m1.Values[1, 0] * _m2.Values[0, 3] +
                _m1.Values[1, 1] * _m2.Values[1, 3] +
                _m1.Values[1, 2] * _m2.Values[2, 3] +
                _m1.Values[1, 3] * _m2.Values[3, 3]
                ;

            nm.Values[2, 3] =
                _m1.Values[2, 0] * _m2.Values[0, 3] +
                _m1.Values[2, 1] * _m2.Values[1, 3] +
                _m1.Values[2, 2] * _m2.Values[2, 3] +
                _m1.Values[2, 3] * _m2.Values[3, 3]
                ;

            nm.Values[3, 3] =
                _m1.Values[3, 0] * _m2.Values[0, 3] +
                _m1.Values[3, 1] * _m2.Values[1, 3] +
                _m1.Values[3, 2] * _m2.Values[2, 3] +
                _m1.Values[3, 3] * _m2.Values[3, 3]
                ;





            return nm;
        }

        public static Vector operator *(Matrix _m, Vector _v)
        {
            Vector nv = new Vector();

            nv.X = (_m.Values[0, 0] * _v.X) + (_m.Values[1, 0] * _v.Y) + (_m.Values[2, 0] * _v.Z) + (_m.Values[3, 0] * 1);
            nv.Y = (_m.Values[0, 1] * _v.X) + (_m.Values[1, 1] * _v.Y) + (_m.Values[2, 1] * _v.Z) + (_m.Values[3, 1] * 1);
            nv.Z = (_m.Values[0, 2] * _v.X) + (_m.Values[1, 2] * _v.Y) + (_m.Values[2, 2] * _v.Z) + (_m.Values[3, 2] * 1);

            //nv.X = (_m.Values[0, 0] * _v.X) + (_m.Values[0, 1] * _v.Y) + (_m.Values[0, 2] * _v.Z) + (_m.Values[0, 3] * 1);
            //nv.Y = (_m.Values[1, 0] * _v.X) + (_m.Values[1, 1] * _v.Y) + (_m.Values[1, 2] * _v.Z) + (_m.Values[1, 3] * 1);
            //nv.Z = (_m.Values[2, 0] * _v.X) + (_m.Values[2, 1] * _v.Y) + (_m.Values[2, 2] * _v.Z) + (_m.Values[2, 3] * 1);


            return nv;
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

        /// <summary>
        /// Wandelt eine Grad-Zahl in eine Radiant-Zahl um
        /// </summary>
        /// <param name="_angle">Winkel (Vor der Rechnung des Sinus/Cosinus/Tangenz!)</param>
        /// <returns>gerundete Raniantzahl</returns>
        private static double DegreeToRadian(double _angle)
        {
            double tmp = Math.PI * _angle / 180.0;
            Math.Round(tmp);
            return (float)tmp;
        }

        /// <summary>
        /// Wandelt eine Radiant-Zahl in eine Grad-Zahl um
        /// </summary>
        /// <param name="_angle">Winkel (Vor der Rechnung des Sinus/Cosinus/Tangenz!)</param>
        /// <returns>Gradzahl</returns>
        private static double RadianToDegree(double _angle)
        {
            double tmp = _angle * 180 / Math.PI;
            return (float)tmp;
        }

        private static Matrix Transponieren(Matrix _m)
        {
            Matrix nm = new Matrix();

            for (int x = 0; x < _m.Values.GetLength(0); x++)
            {
                for (int y = 0; y < _m.Values.GetLength(1); y++)
                {
                    nm.Values[x, y] = _m.Values[y, x];
                }
            }

            return nm;
        }
    }
}
