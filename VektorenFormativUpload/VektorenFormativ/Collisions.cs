namespace VektorenFormativ
{
    public static class Collisions
    {
        public static bool PointInCuboid(Vector _point, Cuboid _quad)
        {
            return false;
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
    }
}
