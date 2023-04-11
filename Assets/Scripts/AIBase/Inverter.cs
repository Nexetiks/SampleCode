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
                NodeState = NodeState.Failure;
            }
            else if (node.Evaluate() == NodeState.Failure)
            {
                NodeState = NodeState.Success;
            }
            else
            {
                NodeState = NodeState.Running;
            }

            return NodeState;
        }
    }
}