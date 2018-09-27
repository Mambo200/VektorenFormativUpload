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
                _quad.m_Vertices[1] - _quad.m_Vertices[0],
                _quad.m_Vertices[3] - _quad.m_Vertices[0]
                );

            collide = NormNCompare(_point, norm, _quad);
            if (collide == false)
                return false;


            // prepare for normalize - B
            norm = Vector.Cross(
                _quad.m_Vertices[1] - _quad.m_Vertices[0],
                _quad.m_Vertices[7] - _quad.m_Vertices[0]
                );

            collide = NormNCompare(_point, norm, _quad);
            if (collide == false)
                return false;

            // prepare to normalize - C
            norm = Vector.Cross(
                _quad.m_Vertices[3] - _quad.m_Vertices[0],
                _quad.m_Vertices[7] - _quad.m_Vertices[0]
                );

            collide = NormNCompare(_point, norm, _quad);
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
            float fMagnSqr = Vector.SqrMagnitude(vMagn);

            if (fMagnSqr <= (_sphere1.m_Radius * _sphere1.m_Radius + _sphere2.m_Radius * _sphere2.m_Radius))
                return true;
            else
                return false;
        }

        public static bool CuboidInCuboid(Cuboid _quad1, Cuboid _quad2)
        {
            // [1, -] first Cuboid
            // [2, -] second Cuboid
            float[,] Cube = new float[2, 8];

            // Normalzie Variables
            Vector[] Norm = new Vector[15];
            Vector[,] NormMath = new Vector[15, 2];

            Norm[0] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[1],
                _quad1.m_Vertices[0] - _quad1.m_Vertices[3]);
            Norm[1] = Vector.Cross(_quad1.m_Vertices[1] - _quad1.m_Vertices[6],
                _quad1.m_Vertices[1] - _quad1.m_Vertices[2]);
            Norm[2] = Vector.Cross(_quad1.m_Vertices[3] - _quad1.m_Vertices[2],
                _quad1.m_Vertices[3] - _quad1.m_Vertices[4]);

            Norm[3] = Vector.Cross(_quad2.m_Vertices[0] - _quad2.m_Vertices[1],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[3]);
            Norm[4] = Vector.Cross(_quad2.m_Vertices[1] - _quad2.m_Vertices[6],
                _quad2.m_Vertices[1] - _quad2.m_Vertices[2]);
            Norm[5] = Vector.Cross(_quad2.m_Vertices[3] - _quad2.m_Vertices[2],
                _quad2.m_Vertices[3] - _quad2.m_Vertices[4]);

            Norm[6] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[3],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[3]);
            Norm[7] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[3],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[1]);
            Norm[8] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[3],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[7]);
            Norm[9] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[1],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[3]);
            Norm[10] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[1],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[1]);
            Norm[11] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[1],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[7]);
            Norm[12] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[7],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[3]);
            Norm[13] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[7],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[1]);
            Norm[14] = Vector.Cross(_quad1.m_Vertices[0] - _quad1.m_Vertices[7],
                _quad2.m_Vertices[0] - _quad2.m_Vertices[7]);

            return false;
        }

        public static bool CuboidInSphere(Cuboid _quad, Sphere _sphere)
        {
            return false;
        }

        /// <summary>
        /// Norms the n compare.
        /// </summary>
        /// <param name="_point">The point.</param>
        /// <param name="_normNotNormalized">The norm not normalized.</param>
        /// <param name="_quad">The Cube</param>
        /// <returns>Colide yes or no</returns>
        private static bool NormNCompare(Vector _point, Vector _normNotNormalized, Cuboid _quad)
        {
            float[] compare = new float[8];
            float min = float.MaxValue;
            float max = float.MinValue;
            float point;

            // normalize
            _normNotNormalized = Vector.Normalize(_normNotNormalized);

            // get P_i
            for (int i = 0; i < compare.GetLength(0); i++)
            {
                compare[i] = (Vector.Dot((_quad.m_Vertices[i]), _normNotNormalized)) / Vector.Magnitude(_normNotNormalized);
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

            point = Vector.Dot(_point, _normNotNormalized);

            if (point < min && point > max)
            {
                return false;
            }
            else
                return true;
        }
    }
}
