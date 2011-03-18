// Copyright 2007-2010 The Apache Software Foundation.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace BlackOps.Client.Specs
{
    using Configuration;
    using NUnit.Framework;

    public class Setting_Up_A_Node
    {
        [Test]
        public void Setting_up_the_node()
        {
            Node n = NodeBuilder.Build("name");

            //Msmq() / QueueFull() / Depth() are extension methods
            //on Features, Statuses, Measurements classes.
            //this feels and looks somewhat ugly to me so 
            //I am looking for feedback
            n.ReportStatus(f => f.Msmq(), s => s.QueueFull());

            n.ReportEvent(f => f.Msmq(), "evt");

            n.ReportMeasurement(f => f.Msmq(), m => m.Depth(), 22);
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
    public static class MyApplicationMeasurements
    {
        public static void Depth(this Measurements m)
        {
            
        }
    }
}