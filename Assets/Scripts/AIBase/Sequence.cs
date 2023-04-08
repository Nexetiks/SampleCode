using System.Collections.Generic;

namespace AIBase
{
    public class Sequence : Node
    {
        protected List<Node> nodes = new List<Node>();

        public Sequence(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        public override NodeState Evaluate()
        {
            bool isAnyStateRunning = false;

            foreach (Node node in nodes)
            {
                if (node.Evaluate() == NodeState.Running)
                {
                    isAnyStateRunning = true;
                }
                else if (node.Evaluate() == NodeState.Failure)
                {
                    nodeState = NodeState.Failure;
                    return nodeState;
                }
            }

            nodeState = isAnyStateRunning ? NodeState.Running : NodeState.Success;
            return nodeState;
        }
    }
}