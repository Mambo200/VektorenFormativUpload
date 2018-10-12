namespace VektorenFormativ
{
    public static class Collisions
    {
        public static bool PointInCuboid(Vector _point, Cuboid _quad)
        {
            bool collide = false;
            

            // prepare to normalize - A
            Vector norm;
            norm = Vector.Cross(
                _quad.m_Vertices[3] - _quad.m_Vertices[0],
                _quad.m_Vertices[1] - _quad.m_Vertices[0]
                );

            // normalize
            norm = Vector.Normalize(norm);

            collide = Collision(norm, _quad, _point);
            if (collide == false)
                return false;


            // prepare for normalize - B
            norm = Vector.Cross(
                _quad.m_Vertices[3] - _quad.m_Vertices[0],
                _quad.m_Vertices[4] - _quad.m_Vertices[0]
                );

            // normalize
            norm = Vector.Normalize(norm);

            collide = Collision(norm, _quad, _point);
            if (collide == false)
                return false;

            // prepare to normalize - C
            norm = Vector.Cross(
                _quad.m_Vertices[1] - _quad.m_Vertices[0],
                _quad.m_Vertices[4] - _quad.m_Vertices[0]
                );

            // normalize
            norm = Vector.Normalize(norm);

            collide = Collision(norm, _quad, _point);
            if (collide == false)
                return false;

            return true;
        }

        public static bool PointInSphere(Vector _point, Sphere _sphere)
        {
            Vector vMag = _point - _sphere.m_Center;
            float fMagSqr = Vector.SqrMagnitude(vMag);

            if (fMagSqr <= (_sphere.m_Radius * _sphere.m_Radius))
                return true;
            else
                return false;
        }

        public static bool SphereInSphere(Sphere _sphere1, Sphere _sphere2)
        {
            Vector vMagn = _sphere1.m_Center - _sphere2.m_Center;
            //float fMagnSqr = Vector.SqrMagnitude(vMagn);
            //
            //if (fMagnSqr <= (_sphere1.m_Radius * _sphere1.m_Radius + _sphere2.m_Radius * _sphere2.m_Radius))
            //    return true;
            //else
            //    return false;

            float fMagn = Vector.Magnitude(vMagn);

            if (fMagn <= _sphere1.m_Radius + _sphere2.m_Radius)
                return true;
            else
                return false;
        }

        public static bool CuboidInCuboid(Cuboid _quad1, Cuboid _quad2)
        {
            //bool collide = true;

            // Normalzie Variables
            //Vector[] Norm = new Vector[15];

            Vector norm = new Vector();

            // Würfel 1
            norm = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
                _quad1.m_Vertices[1] - _quad1.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
                _quad1.m_Vertices[4] - _quad1.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[1] - _quad1.m_Vertices[0],
                _quad1.m_Vertices[4] - _quad1.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            // Würfel 2
            norm = Vector.Cross(_quad2.m_Vertices[3] - _quad2.m_Vertices[0],
                _quad2.m_Vertices[1] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad2.m_Vertices[3] - _quad2.m_Vertices[0],
                _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad2.m_Vertices[1] - _quad2.m_Vertices[0],
                _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            // Würfel 1 und 2
            norm = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
                _quad2.m_Vertices[3] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
                _quad2.m_Vertices[1] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
                _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[1] - _quad1.m_Vertices[0],
                _quad2.m_Vertices[3] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[1] - _quad1.m_Vertices[0],
                _quad2.m_Vertices[1] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[1] - _quad1.m_Vertices[0],
                _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[4] - _quad1.m_Vertices[0],
                _quad2.m_Vertices[3] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[4] - _quad1.m_Vertices[0],
                _quad2.m_Vertices[1] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;

            norm = Vector.Cross(_quad1.m_Vertices[4] - _quad1.m_Vertices[0],
                _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);
            if ((Collision(norm, _quad1, _quad2)) == false)
                return false;


            //Norm[0] = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
            //    _quad1.m_Vertices[1] - _quad1.m_Vertices[0]);
            //Norm[1] = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
            //    _quad1.m_Vertices[4] - _quad1.m_Vertices[0]);
            //Norm[2] = Vector.Cross(_quad1.m_Vertices[1] - _quad1.m_Vertices[0],
            //    _quad1.m_Vertices[4] - _quad1.m_Vertices[0]);
            //
            //Norm[3] = Vector.Cross(_quad2.m_Vertices[3] - _quad2.m_Vertices[0],
            //    _quad2.m_Vertices[1] - _quad2.m_Vertices[0]);
            //Norm[4] = Vector.Cross(_quad2.m_Vertices[3] - _quad2.m_Vertices[0],
            //    _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);
            //Norm[5] = Vector.Cross(_quad2.m_Vertices[1] - _quad2.m_Vertices[0],
            //    _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);
            //
            //Norm[6] = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
            //    _quad2.m_Vertices[3] - _quad2.m_Vertices[0]);
            //Norm[7] = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
            //    _quad2.m_Vertices[1] - _quad2.m_Vertices[0]);
            //Norm[8] = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[0],
            //    _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);
            //Norm[9] = Vector.Cross(_quad1.m_Vertices[1] - _quad1.m_Vertices[0],
            //    _quad2.m_Vertices[3] - _quad2.m_Vertices[0]);
            //Norm[10] = Vector.Cross(_quad1.m_Vertices[1] - _quad1.m_Vertices[0],
            //    _quad2.m_Vertices[1] - _quad2.m_Vertices[0]);
            //Norm[11] = Vector.Cross(_quad1.m_Vertices[1] - _quad1.m_Vertices[0],
            //    _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);
            //Norm[12] = Vector.Cross(_quad1.m_Vertices[4] - _quad1.m_Vertices[0],
            //    _quad2.m_Vertices[3] - _quad2.m_Vertices[0]);
            //Norm[13] = Vector.Cross(_quad1.m_Vertices[4] - _quad1.m_Vertices[0],
            //    _quad2.m_Vertices[1] - _quad2.m_Vertices[0]);
            //Norm[14] = Vector.Cross(_quad1.m_Vertices[4] - _quad1.m_Vertices[0],
            //    _quad2.m_Vertices[4] - _quad2.m_Vertices[0]);

            //for (int i = 0; i < Norm.GetLength(0); i++)
            //{
            //    collide = Collision(Norm[i], _quad1, _quad2);
            //    if (collide == false)
            //        return false;
            //}

            return true;
        }

        public static bool CuboidInSphere(Cuboid _quad, Sphere _sphere)
        {
            Vector norm = new Vector();
            bool collide = true;

            // prepare for normalize - A
            norm = Vector.Cross(
                _quad.m_Vertices[1] - _quad.m_Vertices[0],
                _quad.m_Vertices[3] - _quad.m_Vertices[0]
                );
            norm = Vector.Normalize(norm);
            collide = Collision(norm, _quad, _sphere);

            if (collide == false)
                return false;

            // prepare for normalize - B
            norm = Vector.Cross(
                _quad.m_Vertices[4] - _quad.m_Vertices[0],
                _quad.m_Vertices[3] - _quad.m_Vertices[0]
                );
            norm = Vector.Normalize(norm);
            collide = Collision(norm, _quad, _sphere);

            if (collide == false)
                return false;

            // prepare to normalize - C
            norm = Vector.Cross(
                _quad.m_Vertices[4] - _quad.m_Vertices[0],
                _quad.m_Vertices[1] - _quad.m_Vertices[0]
                );
            norm = Vector.Normalize(norm);
            collide = Collision(norm, _quad, _sphere);

            if (collide == false)
                return false;

            return true;
        }

        /// <summary>
        /// Check Collision of Cube and Point - Extension.
        /// </summary>
        /// <param name="_norm">The norm.</param>
        /// <param name="_quad">The Cube</param>
        /// <param name="_point">The point.</param>
        /// <returns>Colide yes or no</returns>
        private static bool Collision(Vector _norm, Cuboid _quad, Vector _point)
        {
            float[] compare = new float[8];
            float min = float.MaxValue;
            float max = float.MinValue;
            float point;


            // get P_i
            for (int i = 0; i < compare.GetLength(0); i++)
            {
                //compare[i] = (Vector.Dot((_quad.m_Vertices[i]), _norm)) / Vector.Magnitude(_norm);
                compare[i] = Vector.Dot(_quad.m_Vertices[i], _norm);
            }

            // set min/max
            for (int i = 0; i < compare.GetLength(0); i++)
            {
                if (compare[i] < min)
                {
                    min = compare[i];
                }

                if (compare[i] > max)
                {
                    max = compare[i];
                }
            }

            point = Vector.Dot(_point, _norm);

            if (min <= point && point <= max)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Check Collision of two Cubes - Extension
        /// </summary>
        /// <param name="_norm">The norm</param>
        /// <param name="_quad1">first Cube</param>
        /// <param name="_quad2">second Cube</param>
        /// <returns>Colide</returns>
        private static bool Collision(Vector _norm, Cuboid _quad1, Cuboid _quad2)
        {
            float[] compare1 = new float[8];
            float[] compare2 = new float[8];
            float min1 = float.MaxValue;
            float min2 = float.MaxValue;
            float max1 = float.MinValue;
            float max2 = float.MinValue;


            // get P_i of first Cube
            for (int i = 0; i < compare1.GetLength(0); i++)
            {
                //compare[i] = (Vector.Dot((_quad.m_Vertices[i]), _norm)) / Vector.Magnitude(_norm);
                compare1[i] = Vector.Dot(_quad1.m_Vertices[i], _norm);
            }

            // set min/max
            for (int i = 0; i < compare1.GetLength(0); i++)
            {
                if (compare1[i] < min1)
                {
                    min1 = compare1[i];
                }

                if (compare1[i] > max1)
                {
                    max1 = compare1[i];
                }
            }

            // get P_i of second Cube
            for (int i = 0; i < compare2.GetLength(0); i++)
            {
                compare2[i] = Vector.Dot(_quad2.m_Vertices[i], _norm);
            }

            // set min/max
            for (int i = 0; i < compare2.GetLength(0); i++)
            {
                if (compare2[i] < min2)
                {
                    min2 = compare2[i];
                }

                if (compare2[i] > max2)
                {
                    max2 = compare2[i];
                }
            }

            if ((max1 >= min2 && max1 <= max2) ||
                (max2 >= min1 && max2 <= max1))
                return true;
            else
                return false;


            #region Wrong
            //bool min1begin = false;
            //bool min2begin = false;
            //
            //float maxmax;
            //float minmin;
            //
            ////set minmin
            //if (min1 < min2)
            //    minmin = min1;
            //else
            //    minmin = min2;
            //
            ////set maxmax
            //if (max1 > max2)
            //    maxmax = max1;
            //else
            //    maxmax = max2;
            //
            //for (float i = minmin; i < maxmax + 1; i++)
            //{
            //    if (i == min1)
            //        min1begin = true;
            //    else if (i == min2)
            //        min2begin = true;
            //
            //    if (i == max1)
            //    {
            //        if (min2begin == true)
            //        {
            //            return true;
            //        }
            //        else
            //            min1begin = false;
            //    }
            //
            //    if (i == max2)
            //    {
            //        if (min1begin == true)
            //        {
            //            return true;
            //        }
            //        else
            //            min2begin = false;
            //    }
            //}
            //return false;
            #endregion
        }

        /// <summary>
        /// Check Collision of Cube and Sphere
        /// </summary>
        /// <param name="_norm">Norm</param>
        /// <param name="_quad">Cube</param>
        /// <param name="_sphere">Sphere</param>
        /// <returns>Colide</returns>
        private static bool Collision(Vector _norm, Cuboid _quad, Sphere _sphere)
        {
            float[] compare1 = new float[8];
            float compare2 = 0;
            float min1 = float.MaxValue;
            float min2 = float.MaxValue;
            float max1 = float.MinValue;
            float max2 = float.MinValue;

            #region Cube
            // get P_i of first Cube
            for (int i = 0; i < compare1.GetLength(0); i++)
            {
                //compare[i] = (Vector.Dot((_quad.m_Vertices[i]), _norm)) / Vector.Magnitude(_norm);
                compare1[i] = Vector.Dot(_quad.m_Vertices[i], _norm);
            }

            // set min/max
            for (int i = 0; i < compare1.GetLength(0); i++)
            {
                if (compare1[i] < min1)
                {
                    min1 = compare1[i];
                }

                if (compare1[i] > max1)
                {
                    max1 = compare1[i];
                }
            }
            #endregion

            #region Sphere
            // N of Sphere
            compare2 = Vector.Dot(_sphere.m_Center, _norm);

            // set min/max
            min2 = compare2 - _sphere.m_Radius;
            max2 = compare2 + _sphere.m_Radius;

            if ((max1 > min2 && max1 < max2) ||
                (max2 > min1 && max2 < max1))
                return true;
            else
                return false;

            #endregion

        }
    }
}
