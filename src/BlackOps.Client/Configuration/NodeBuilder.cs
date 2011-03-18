namespace BlackOps.Client.Configuration
{
    using System;

    public class NodeBuilder
    {
        public static Node Build(string name)
        {
            return new Node(name);
        }
    }
}