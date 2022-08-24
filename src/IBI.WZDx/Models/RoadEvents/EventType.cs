namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// The type of WZDx road event.
/// </summary>
public enum EventType
{
    /// <summary>
    /// An area of a trafficway with highway construction, maintenance, or utility-work activities.
    /// </summary>
    WorkZone,
    
    /// <summary>
    /// A temporary rerouting of road users onto an existing trafficway to avoid a work zone or
    /// other impedance.
    /// </summary>
    Detour,

    /// <summary>
    /// A section of roadway that has limitations of how that section can be used.
    /// </summary>
    Restriction
}