namespace BlackOps.Model.Observations
{
    using FluentNHibernate.Data;

    /// <summary>
    /// The universe of information in the OpsDB.
    /// </summary>
    public class ObservationType : Entity
    {
        public virtual string Name { get; set; }
    }
}