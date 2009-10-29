namespace BlackOps.Model.Observations
{
    using FluentNHibernate.Data;

    /// <summary>
    /// The universe of information in the OpsDB.
    /// </summary>
    public class ObservationType : Entity
    {
        public virtual string Key { get; set; }
        public virtual string Description { get; set; }
    }
}