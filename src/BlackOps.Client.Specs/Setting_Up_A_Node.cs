namespace BlackOps.Client.Specs
{
    using NUnit.Framework;

    public class Setting_Up_A_Node
    {
        [Test]
        public void Setting_up_the_node()
        {
            Node n = BlackOps.Client.Configuration.NodeBuilder.Build("name","");
        }

        [Test]
        public void NAME()
        {
            Node n = BlackOps.Client.Configuration.NodeBuilder.Build("name","mongo:address");
            n.ReportStatus(f=>f.Msmq(), s=>s.QueueFull());
        }
    }

    public static class MyApplicationFeatures
    {
        public static void Msmq(this Features features)
        {
            
        }
    }

    public static class MyApplicationStatus
    {
        public static void QueueFull(this Statuses statuses)
        {
            
        }
    }
}
