using System;
using System.Collections.Generic;
using IBI.WZDx.Equality;

namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// Information abut the presence of workers in a <see cref="WorkZoneRoadEvent"/>'s area.
/// </summary>
/// <param name="AreWorkersPresent">
/// Whether workers are present in the work zone event area. This value should be set in accordance
/// with the definition provided in <paramref name="Definition"/> if it is provided.
/// </param>
/// <param name="Definition">
/// A list of situations in which workers are considered to be present in the jurisdiction of the
/// data provider.
/// </param>
/// <param name="Method">
/// Describes the method for how worker presence in a work zone event area is determined.
/// </param>
/// <param name="WorkerPresenceLastConfirmedDate">
/// The UTC date and time at which the presence of workers was last confirmed.
/// </param>
/// <param name="Confidence">
/// The data producer’s confidence in the value of <paramref name="AreWorkersPresent"/>.
/// </param>
public record WorkerPresence(
    bool AreWorkersPresent,
    IEnumerable<WorkerPresenceDefinition>? Definition = null,
    WorkerPresenceMethod? Method = null,
    DateTimeOffset? WorkerPresenceLastConfirmedDate = null,
    WorkerPresenceConfidence? Confidence = null
    )
{
    /// <summary>
    /// Determine if another <see cref="WorkerPresence"/> is equal to this <see cref="WorkerPresence"/>.
    /// </summary>
    public virtual bool Equals(WorkerPresence? other)
    {
        return other != null
            && AreWorkersPresent == other.AreWorkersPresent
            && Definition.NullHandlingSequenceEqual(other.Definition)
            && Method == other.Method
            && WorkerPresenceLastConfirmedDate == other.WorkerPresenceLastConfirmedDate
            && Confidence == other.Confidence;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(AreWorkersPresent);
        
        if (Definition != null)
        {
            foreach (WorkerPresenceDefinition definition in Definition)
            {
                hash.Add(definition);
            }
        }
        
        hash.Add(Method);
        hash.Add(WorkerPresenceLastConfirmedDate);
        hash.Add(Confidence);
        
        return hash.ToHashCode();
    }
}