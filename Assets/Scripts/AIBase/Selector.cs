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
                    NodeState = NodeState.Success;
                    return NodeState;
                }
                else if (node.Evaluate() == NodeState.Running)
                {
                    NodeState = NodeState.Running;
                    return NodeState;
                }
            }

            NodeState = NodeState.Failure;
            return NodeState;
        }
    }
}