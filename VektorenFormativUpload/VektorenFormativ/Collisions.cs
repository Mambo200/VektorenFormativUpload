namespace VektorenFormativ
{
    public static class Collisions
    {
        public static bool PointInCuboid(Vector _point, Cuboid _quad)
        {
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
        }

        public static bool CuboidInSphere(Cuboid _quad, Sphere _sphere)
        {
        }
    }
}
