namespace BlackOps.Model.Observations
{
    /// <summary>
    /// Typically measurments are periodic.
    /// Sent from servers.
    /// Could be performance statistics.
    /// And status of important system objects.
    /// 
    /// </summary>
    public class Measurement : Observation
    {
        public virtual long Value { get; set; }
    }
}