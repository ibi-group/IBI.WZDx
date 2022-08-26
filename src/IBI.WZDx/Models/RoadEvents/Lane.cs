using System;
using System.Collections.Generic;
using IBI.WZDx.Equality;

namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// An individual lane on the roadway within a road event.
/// </summary>
/// <remarks>
/// "Lane" is used generically and includes shoulders, medians, sidewalks, and similar.
/// </remarks>
/// <param name="Order">
/// The position of a lane in sequence on the roadway. This value starts at 1 from the left-most
/// lane in each direction of travel. Is used as an index to indicate the order of all lanes
/// provided for a road event.
/// </param>
/// <param name="Type">
/// An indication of the type of lane or shoulder.
/// </param>
/// <param name="Status">
/// The status of the lane for the traveling public.
/// </param>
/// <param name="Restrictions">
/// A collection of zero or more restrictions specific to the lane.
/// </param>
public record Lane(
    int Order,
    LaneType Type,
    LaneStatus Status,
    IEnumerable<Restriction>? Restrictions = null
    )
{
    /// <summary>
    /// Determine if another <see cref="Lane"/> is equal to this <see cref="Lane"/>.
    /// </summary>
    public virtual bool Equals(Lane? other)
    {
        return other != null
            && Order == other.Order
            && Type == other.Type
            && Status == other.Status
            && Restrictions.NullHandlingSequenceEqual(other.Restrictions);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(Order);
        hash.Add(Type);
        hash.Add(Status);

        if (Restrictions != null)
        {
            foreach (Restriction restriction in Restrictions)
            {
                hash.Add(restriction);
            }
        }
        
        return hash.ToHashCode();
    }
}