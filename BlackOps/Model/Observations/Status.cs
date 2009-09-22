using Pulse.OpsDB.Model.Observations;

namespace Pulse.OpsDB.Model.Observations
{
    /// <summary>
    /// Some objects will record state transitions. A Circuit Breaker might
    /// record when it changes state.
    /// Status can be other things. A dashboard would show the last state transition.
    /// </summary>
    public class Status : Observation
    {
    }
}