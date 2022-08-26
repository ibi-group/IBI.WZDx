namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// A high-level description of a feed publisher's confidence in the reported value of
/// <see cref="WorkerPresence.AreWorkersPresent"/>.
/// </summary>
public enum WorkerPresenceConfidence
{
    /// <summary>
    /// Low confidence in the reported value, such as when data is manually reported or not updated
    /// frequently.
    /// </summary>
    Low,
    
    /// <summary>
    /// Medium confidence in the reported value, such as when the value is still manually reported
    /// but is being updated in a timely manner, or when worker presence is indirectly inferred from
    /// other equipment like a smart arrow board.
    /// </summary>
    Medium,
    
    /// <summary>
    /// High confidence in the reported value, such as when automated systems with GPS locations are
    /// used to generate the value.
    /// </summary>
    High
}