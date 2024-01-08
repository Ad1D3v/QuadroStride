using Unity.MLAgents;
using Unity.MLAgents.Policies;

namespace QuadroStride
{
    public abstract class CR_StriderCore : Agent
    {
        protected string m_BehaviorName;
        protected ML_DecisionRequester m_Requester;
        protected bool IsActive => m_Requester.Active;

        public override void Initialize()
        {
            m_BehaviorName = GetComponent<BehaviorParameters>().BehaviorName;
            m_Requester = GetComponent<ML_DecisionRequester>();

            if (m_Requester == null)
            {
                m_Requester = gameObject.AddComponent<ML_DecisionRequester>();
            }
        }

        public virtual void SetAgentActive(bool active, int decisionInterval = 0)
        {
            m_Requester.Active = active;
            m_Requester.DecisionInterval = decisionInterval > 0 ? decisionInterval : m_Requester.DecisionInterval;
            m_Requester.PerStepActions = m_Requester.DecisionInterval > 1;
        }
    }
}
