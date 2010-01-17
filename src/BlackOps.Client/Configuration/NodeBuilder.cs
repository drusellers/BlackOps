namespace BlackOps.Client.Configuration
{
    using System;

    public class NodeBuilder
    {
        public static Node Build(string name, string mongoAddress)
        {
            return new Node(name);
        }
    }
}