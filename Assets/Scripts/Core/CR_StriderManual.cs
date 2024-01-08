using UnityEngine;

namespace QuadroStride
{
    public class CR_StriderManual : CR_StriderBase
    {
        private IF_StriderSynthesis m_Controls; 

        public override void Initialize()
        {
            base.Initialize();

            m_Controls = FindObjectOfType<IF_StriderSynthesis>();

            if (m_Controls != null)
            {
                m_Controls.WalkUpdateEvent += OnWalkUpdate;
                m_Controls.LookUpdateEvent += OnLookUpdate;

                OnWalkUpdate();
                OnLookUpdate();
            }
        }

        private void OnWalkUpdate()
        {
            NormTargetSpeed = m_Controls.NormSpeed;
            NormTargetWalkAngle = m_Controls.NormWalkAngle;
        }

        private void OnLookUpdate()
        {
            NormTargetLookAngle = m_Controls.NormLookAngle;
        }

        private void OnDestroy()
        {
            if (m_Controls != null)
            {
                m_Controls.WalkUpdateEvent -= OnWalkUpdate;
                m_Controls.LookUpdateEvent -= OnLookUpdate;
            }
        }
    }
}