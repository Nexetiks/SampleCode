namespace AIBase
{
    public class Inverter : Node
    {
        protected Node node;

        public Inverter(Node node)
        {
            this.node = node;
        }

        public override NodeState Evaluate()
        {
            if (node.Evaluate() == NodeState.Success)
            {
                nodeState = NodeState.Failure;
                return NodeState.Failure;
            }

            if (node.Evaluate() == NodeState.Failure)
            {
                nodeState = NodeState.Success;
                return nodeState;
            }

            nodeState = NodeState.Running;
            return nodeState;
        }
    }
}