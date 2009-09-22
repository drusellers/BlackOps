using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Framework;
using Pulse.OpsDB.Model.Observations;

namespace Pulse.OpsDB.Model.Observations
{
    /// <summary>
    /// The heart of the OpsDB. Each is a single data point.
    /// Server nodes will mainly send performance stats to OpsDB (Measurements).
    /// 
    /// </summary>
    public abstract class Observation : Entity
    {
        /// <summary>
        /// Observation needs a node from which it came.
        /// </summary>
        public virtual Node Node { get; set; }

        /// <summary>
        /// Observations must have a type
        /// </summary>
        public virtual ObservationType Type { get; set; }
    }
}