using System;
using System.Collections.Generic;
using System.Linq;
using IBI.WZDx.Equality;
using IBI.WZDx.Models.RoadEvents.WorkZones;

namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// The core details of an event occurring on a roadway (a "road event") that is shared by all
/// types of road events, such as work zones (see <see cref="WorkZoneRoadEvent"/>).
/// </summary>
/// <param name="EventType">
/// The type/classification of road event.
/// </param>
/// <param name="DataSourceId">
/// Identifies the data source from which the road event originates.
/// </param>
/// <param name="RoadNames">
/// A list of publicly known names of the road on which the event occurs. This may include the road
/// number designated by a jurisdiction such as a county, state or interstate (e.g. I-5, VT 133).
/// </param>
/// <param name="Direction">
/// The digitization direction of the road that is impacted by the event. This value is based on the
/// standard naming for US roadways and indicates the direction of the traffic flow regardless of 
/// the real heading angle.
/// </param>
/// <param name="Name">
/// A human-readable name for the road event.
/// </param>
/// <param name="RelatedRoadEvents">
/// A list describing one or more road events which are related to this road event, such as a work
/// zone project it is part of or another road event that occurs before or after it in sequence.
/// </param>
/// <param name="Description">
/// Short free text description of road event.
/// </param>
/// <param name="CreationDate">
/// The UTC time and date when the activity or event was created.
/// </param>
/// <param name="UpdateDate">
/// The UTC date and time when any information in the <see cref="RoadEventFeature"/> (including
/// child objects) that the <see cref="RoadEventCoreDetails"/> applies to was most recently updated
/// or confirmed as up to date.
/// </param>
/// <param name="Relationship">
/// Identifies both sequential and hierarchical relationships between the road event and other
/// entities.
/// </param>
public record RoadEventCoreDetails(
    EventType EventType,
    string DataSourceId,
    IEnumerable<string> RoadNames,
    RoadDirection Direction,
    string? Name = null,
    IEnumerable<RelatedRoadEvent>? RelatedRoadEvents = null,
    string? Description = null,
    DateTimeOffset? CreationDate = null,
    DateTimeOffset? UpdateDate = null,
    [property: Obsolete("Use RelatedRoadEvents instead.")]Relationship? Relationship = null
    )
{
    /// <summary>
    /// Determine if an other <see cref="RoadEventCoreDetails"/> is equal to this <see cref="RoadEventCoreDetails"/>.
    /// </summary>
    public virtual bool Equals(RoadEventCoreDetails? other)
    {
        return other != null
            && EventType == other.EventType
            && DataSourceId == other.DataSourceId
            && RoadNames.SequenceEqual(other.RoadNames)
            && Direction == other.Direction
            && Name == other.Name
            && RelatedRoadEvents.NullHandlingSequenceEqual(other.RelatedRoadEvents)
            && Description == other.Description
            && CreationDate == other.CreationDate
            && UpdateDate == other.UpdateDate
            && Relationship == other.Relationship;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(EventType);
        hash.Add(DataSourceId);

        foreach(string roadName in RoadNames)
        {
            hash.Add(roadName);
        }

        hash.Add(Direction);
        hash.Add(Name);

        if (RelatedRoadEvents != null)
        {
            foreach(RelatedRoadEvent relatedRoadEvent in RelatedRoadEvents)
            {
                hash.Add(relatedRoadEvent);
            }
        }

        hash.Add(Description);
        hash.Add(CreationDate);
        hash.Add(UpdateDate);
        hash.Add(Relationship);

        return hash.ToHashCode();
    }
}