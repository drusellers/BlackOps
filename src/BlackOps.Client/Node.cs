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
    public class Node
    {
        string _name;

        public Node(string name)
        {
            _name = name;
        }

        //kojack with a kodax
        public void ReportStatus(string feature, string status)
        {
        }

        public void ReportMeasurement(string feature, double value)
        {
        }


        // observation {
        //     node = "/usa/east/srv23"
        //     event = "newsale"
        //     feature = "/cashier/sales"
        // }
        public void ReportEvent(string feature)
        {
        }

        //what would this look like?
        public void Usage()
        {
            //code
            //code
            ReportEvent("/APP/MAKE/MONEY");
            //i think this should happen off of a node object. 
        }
    }

   
}