using System.Collections.Generic;
using FluentNHibernate.Framework;

namespace Pulse.OpsDB.Model.Observations
{
    /// <summary>
    /// Somewhere where observations come from.
    /// Each requires it's own Id. 
    /// </summary>
    public class Node : Entity
    {
        /// <summary>
        /// Not a database id, but the ID allocated to the server/application that sends data.
        /// </summary>
        public virtual string UniqueId { get; set; }
        
        /// <summary>
        /// A human readable description of the node (eg. COMP-MSSQL1 (Production SQL Server 2005))
        /// </summary>
        public virtual string Description { get; set; }
        
        /// <summary>
        /// Nodes use other nodes. This can be handy for troubleshooting, as you can see 
        /// dependency chains. This is optional, as it can be a pain in the butt to catalogue.
        /// </summary>
        //public virtual IList<Node> DependentOn { get; set; }

        public virtual IList<Feature> Features { get; set; }
    }
}