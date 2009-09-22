using FluentNHibernate.Framework;

namespace Pulse.OpsDB.Model.Observations
{
    /// <summary>
    /// The universe of information in the OpsDB.
    /// </summary>
    public class ObservationType : Entity
    {
        public virtual string Name { get; set; }
    }
}