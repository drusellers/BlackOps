// Copyright 2007-2008 The Apache Software Foundation.
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
namespace BlackOps.Client
{
    using System;
    using System.Linq.Expressions;

    public class Node
    {
        string _name;

        public Node(string name)
        {
            _name = name;
        }

        //kojack with a kodax
        public void ReportStatus(Expression<Action<Features>> feature, Expression<Action<Statuses>> status)
        {
            var f = MethodCallStringulator.Convert(feature);
            var s = MethodCallStringulator.Convert(status);
            var o = new Observation()
                    {
                        Feature = f,
                        Status = s,
                        Node = _name
                    };
            // observation {
            //     Feature = "/msmq/up"
            //     Status = "down"
            //     Node = "srvtopeka22"
            // }
        }

        public void ReportMeasurement(Expression<Action<Features>> feature, Expression<Action<Measurements>> measurement, double value)
        {
            var f = MethodCallStringulator.Convert(feature);
            var v = value;
            var o = new Observation()
                    {
                        Node = _name,
                        Feature = f,
                        Value = v
                    };
        }


        // observation {
        //     node = "/usa/east/srv23"
        //     event = "newsale"
        //     feature = "/cashier/sales"
        // }
        public void ReportEvent(Expression<Action<Features>> feature, string evt)
        {
            var f = MethodCallStringulator.Convert(feature);
            var o = new Observation()
                    {
                        Event = evt,
                        Feature = f,
                        Node = _name
                    };
        }
    }

   
}