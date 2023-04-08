using System.Collections.Generic;

namespace AIBase
{
    public class Selector : Node
    {
        private List<Node> nodes = new List<Node>();

        public Selector(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        public override NodeState Evaluate()
        {
            foreach (Node node in nodes)
            {
                if (node.Evaluate() == NodeState.Success)
                {
                    nodeState = NodeState.Success;
                    return nodeState;
                }
                else if (node.Evaluate() == NodeState.Running)
                {
                    nodeState = NodeState.Running;
                    return nodeState;
                }
            }

            nodeState = NodeState.Failure;
            return nodeState;
        }
    }
}