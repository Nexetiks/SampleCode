namespace AIBase
{
    public abstract class Node
    {
        public NodeState NodeState
        {
            get { return nodeState; }
            private set { nodeState = value; }
        }

        protected NodeState nodeState;

        public abstract NodeState Evaluate();
    }
}