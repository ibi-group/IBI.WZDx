using System;
using System.Collections.Generic;
using IBI.WZDx.Equality;

namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// Identifies both sequential and hierarchical relationships between a road events and other
/// entities. For example, a relationship can be used to link multiple road events to a common
/// "parent", such as a project or phase, or identify a sequence of road events that make up a
/// larger work zone.
/// </summary>
/// <param name="First">
/// Indicates the first (can be multiple) road event in a sequence of road events.
/// </param>
/// <param name="Next">
/// Indicates the next (can be multiple) road event in a sequence of road events.
/// </param>
/// <param name="Parents">
/// Indicates entities that the road event with this relationship is a part of, such as a work zone
/// project or phase.
/// </param>
/// <param name="Children">
/// Indicates entities that are part of the road event with this relationship, such as a detour or
/// piece of equipment.
/// </param>
[Obsolete("Use RelatedRoadEvent instead.")]
public record Relationship(
    IEnumerable<string>? First,
    IEnumerable<string>? Next,
    IEnumerable<string>? Parents,
    IEnumerable<string>? Children
    )
{
    /// <summary>
    /// Determine if another <see cref="Relationship"/> is equal to this <see cref="Relationship"/>.
    /// </summary>
    public virtual bool Equals(Relationship? other)
    {
        return other != null
            && First.NullHandlingSequenceEqual(other.First)
            && Next.NullHandlingSequenceEqual(other.Next)
            && Parents.NullHandlingSequenceEqual(other.Parents)
            && Children.NullHandlingSequenceEqual(other.Children);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        if(First != null)
        {
            foreach (string first in First)
            {
                hash.Add(first);
            }
        }

        if(Next != null)
        {
            foreach (string next in Next)
            {
                hash.Add(next);
            }
        }

        if(Parents != null)
        {
            foreach (string parent in Parents)
            {
                hash.Add(parent);
            }
        }

        if(Children != null)
        {
            foreach (string child in Children)
            {
                hash.Add(child);
            }
        }

        return hash.ToHashCode();
    }   
}