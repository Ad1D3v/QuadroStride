using UnityEngine;

namespace QuadroStride
{
    public interface CR_IStriderHandler
    {
        float NormTargetSpeed { set; get; }
        float NormTargetWalkAngle { set; get; }
        float NormTargetLookAngle { set; get; }
        
        Matrix4x4 Matrix { get; }
        Vector3 LocalVelocity { get; }
        Vector3 WorldVelocity { get; }

        void ResetAgent();
        void SetAgentActive(bool active, int decisionInterval = 1);
    }
}