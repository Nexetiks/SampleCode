namespace AIBase
{
    public abstract class Node
    {
        public NodeState NodeState { get; protected set; }

        public abstract NodeState Evaluate();
    }
}