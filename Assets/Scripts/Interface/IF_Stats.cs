using System.Collections.Generic;
using UnityEngine;

namespace QuadroStride
{
    public class IF_Stats : MonoBehaviour
    {
        [SerializeField]
        private int m_BufferSize = 128;

        private Dictionary<string, UT_StatsBuffer> m_Buffers;
        private IF_GraphFactory m_GraphFactory;

        private void Awake()
        {
            m_Buffers = new Dictionary<string, UT_StatsBuffer>();
            m_GraphFactory = FindObjectOfType<IF_GraphFactory>(true);
        }

        public void Clear()
        {
            foreach (var buffer in m_Buffers.Values)
            {
                buffer.Clear();
            }
        }

        public float Add(float value, string graphName, string valueLabel, string color, bool showValue = true)
        {
            return Add(value, graphName, valueLabel, UT_ChasisColors.Parse(color), showValue);
        }

        public float Add(float value, string graphName, string valueLabel, Color color, bool showValue = true)
        {
            var key = graphName + valueLabel;

            if (!m_Buffers.TryGetValue(key, out UT_StatsBuffer buffer))
            {
                buffer = new UT_StatsBuffer(m_BufferSize, valueLabel);
                m_Buffers.Add(key, buffer);

                if (!m_GraphFactory.HasGraph(graphName, out IF_GraphCore graph))
                {
                    graph = m_GraphFactory.AddGraph(graphName);
                }

                graph.Add(buffer, color, showValue);
            }

            buffer.Add(value);
            return value;
        }
    }
}
