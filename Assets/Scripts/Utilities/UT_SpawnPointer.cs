using UnityEngine;

namespace QuadroStride
{
    public class UT_SpawnPointer
    {
        private readonly Vector3 m_Center = Vector3.zero;
        private readonly float m_SpawnRadius;
        private readonly float m_ClearRadius;
        private readonly int m_MaxTries;

        private const int c_ClearMask = UT_ChasisLayer.BotMask | UT_ChasisLayer.ObstacleMask;

        public UT_SpawnPointer(float spawnRadius, float clearRadius, int maxTries = 100)
        {
            m_SpawnRadius = spawnRadius;
            m_ClearRadius = clearRadius;
            m_MaxTries = maxTries;
        }

        public bool HasFreePosition(out Vector3 point)
        {
            int i = m_MaxTries;
            do
            {
                if (HasFreePos(out point))
                {
                    return true;
                }
            }
            while (--i > 0);

            return false;
        }

        private bool HasFreePos(out Vector3 point)
        {
            Vector2 rnd = Random.insideUnitCircle * m_SpawnRadius;
            Vector3 pos = m_Center + new Vector3(rnd.x, 50, rnd.y);

            if (Physics.Raycast(pos, Vector3.down, out RaycastHit hitInfo, 100, UT_ChasisLayer.GroundMask))
            {
                point = hitInfo.point;
                return Physics.OverlapSphere(point, m_ClearRadius, c_ClearMask).Length == 0;
            }

            point = default;
            return false;
        }
    }
}