namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// Describes how a road event is related to the road event that the RelatedRoadEvent object occurs
/// on. For example, the first road event in a sequence of events along the roadway, an instance of
/// a recurrent work zone, a nearby work zone-type road event, or a nearby detour-type road event. 
/// </summary>
public enum RelatedRoadEventType
{
    /// <summary>
    /// The first road event in a sequence of road events that together describe a full work zone or
    /// detour.
    /// </summary>
    FirstInSequence,

    /// <summary>
    /// The next (subsequent) road event in a sequence of road events that together describe a full
    /// work zone or detour.
    /// </summary>
    NextInSequence,

    /// <summary>
    /// The first road event in the first occurrence in time of a recurrent work zone.
    /// </summary>
    FirstOccurrence,

    /// <summary>
    /// The first road event in the next occurrence in time of a recurrent work zone.
    /// </summary>
    NextOccurrence,

    /// <summary>
    /// The first road event of related work zones (i.e. not part of a sequence of road events or
    /// recurrent work zone).
    /// </summary>
    RelatedWorkZone,

    /// <summary>
    /// The first road event of related detours (i.e. not part of a sequence of road events).
    /// </summary>
    RelatedDetour,

    /// <summary>
    /// The first road event of a related planned moving operation work zones (i.e. not part of a
    /// sequence of road events).
    /// </summary>
    PlannedMovingOperation,

    /// <summary>
    /// The first road event of a related active moving operation work zones (i.e. not part of a
    /// sequence of road events).
    /// </summary>
    ActiveMovingOperation
}