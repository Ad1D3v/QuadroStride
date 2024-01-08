using UnityEngine;

namespace QuadroStride
{
    public class UT_GroundRayDetection : MonoBehaviour
    {
        public float GetGroundDistance()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1, UT_ChasisLayer.GroundMask))
            {
                //Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                return hitInfo.distance * 2 - 1;
            }
            //else
            //{
            //    Debug.DrawRay(transform.position, Vector3.down, Color.grey);
            //}

            return 1;
        }
    }
}