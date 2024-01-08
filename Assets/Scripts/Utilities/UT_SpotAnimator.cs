using UnityEngine;

namespace QuadroStride
{
    public class UT_SpotAnimator : MonoBehaviour
    {
        private static Quaternion rot = Quaternion.Euler(185, 0, 0);
        private void Update()
        {
            transform.localRotation = Quaternion.Inverse(transform.parent.localRotation) * rot;
        }
    }
}