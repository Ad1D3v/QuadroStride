using UnityEngine;
using Unity.MLAgents.Sensors;

namespace QuadroStride
{
    // This class should be used for training walker and fighter agents in tandem.
    public class CR_StriderCommon : CR_StriderUpgrade
    {
        public override void CollectObservations(VectorSensor sensor)
        {
            // Observed target angles are set by fighter agent, 
            // directions are needed for error calculation.
            TargetAnglesToDirections();

            base.CollectObservations(sensor);
        }
    }
}