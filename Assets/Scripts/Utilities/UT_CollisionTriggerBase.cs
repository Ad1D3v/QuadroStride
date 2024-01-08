using System;
using UnityEngine;

namespace QuadroStride
{
    public class UT_CollisionTriggerBase : MonoBehaviour
    {
        public event Action BulletHitSufferedEvent;
        public event Action<int, bool> CollisionEvent;

        public void InvokeBulletHitSufferedEvent()
        {
            BulletHitSufferedEvent?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckCollision(other.gameObject.layer, true);

            // CHANGED invoked by bullet.
            //if (other.gameObject.layer == Layer.Bullet)
            //{
            //    if (!transform.CompareTag(other.GetComponent<Bullet>().AgentTag))
            //    {
            //        // Ignores friendly fire.
            //        BulletHitSufferedEvent?.Invoke();
            //    }
            //}
        }

        private void OnTriggerStay(Collider other)
        {
            CheckCollision(other.gameObject.layer, false);
        }

        private void CheckCollision(int layer, bool isEnter)
        {
            if (layer == UT_ChasisLayer.Obstacle || layer == UT_ChasisLayer.Trigger)
            {
                CollisionEvent?.Invoke(layer, isEnter);
            }
        }
    }
}
