namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// The status of a lane for the traveling public.
/// </summary>
public enum LaneStatus
{
    /// <summary>
    /// The lane is open for travel.
    /// </summary>
    Open,
    
    /// <summary>
    /// The lane is closed to travel.
    /// </summary>
    Closed,

    /// <summary>
    /// The lane shifts left from its current bearing and continues.
    /// </summary>
    ShiftLeft,

    /// <summary>
    /// The lane shifts right from its current bearing and continues.
    /// </summary>
    ShiftRight,

    /// <summary>
    /// The lane gradually tapers while merging into the lane directly to the left.
    /// </summary>
    MergeLeft,

    /// <summary>
    /// The lane gradually tapers while merging into the lane directly to the right.
    /// </summary>
    MergeRight,

    /// <summary>
    /// Traffic may travel in either direction, depending on certain conditions. Example conditions
    /// include time of day (e.g. reversible lanes), automated controls, or on-site personnel.
    /// </summary>
    AlternatingFlow
}