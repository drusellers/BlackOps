using System.Collections.Generic;
using FluentNHibernate.Framework;

namespace Pulse.OpsDB.Model.Observations
{
    /// <summary>
    /// A unit of business significant functionality. SLA's are written about features.
    /// A feature is probably implemented across many hosts (db, web, app), 
    /// applications on each tier, firewalls, SANS, firewalls etc. All these <see cref="Node"/>s 
    /// contribute toward a feature.
    /// 
    /// </summary>
    public class Feature : Entity
    {
        public virtual IList<Node> Nodes { get; set; }
    }
}