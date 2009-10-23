namespace BlackOps.Model.Observations
{
    using System;
    using FluentNHibernate.Data;

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

        /// <summary>
        /// Observations occur at a point in time
        /// </summary>
        public virtual DateTime ObservedAt { get; set; }
    }
}