namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// The type of vehicle restriction on a roadway.
/// </summary>
public enum RestrictionType
{
    /// <summary>
    /// Only vehicles accessing addresses along the segment being described are allowed; this
    /// includes emergency services, deliveries, and direct property access.
    /// </summary>
    LocalAccessOnly,

    /// <summary>
    /// Trucks are prohibited from traveling this part of the network.
    /// </summary>
    NoTrucks,

    /// <summary>
    /// Travel is restricted to travel peak hours only.
    /// </summary>
    TravelPeakHoursOnly,

    /// <summary>
    /// Travel is restricted to high occupancy vehicles of two or more.
    /// </summary>
    Hov2,

    /// <summary>
    /// Travel is restricted to high occupancy vehicles of three or more.
    /// </summary>
    Hov3,

    /// <summary>
    /// No parking along the segment being described.
    /// </summary>
    NoParking,

    /// <summary>
    /// Lane width reduced along the segment being described.
    /// </summary>
    ReducedWidth,

    /// <summary>
    /// Height restrictions reduced along the segment being described.
    /// </summary>
    ReducedHeight,

    /// <summary>
    /// Vehicle length restrictions reduced along the segment being described.
    /// </summary>
    ReducedLength,

    /// <summary>
    /// Vehicle weight restrictions reduced along the segment being described.
    /// </summary>
    ReducedWeight,

    /// <summary>
    /// Vehicle axle-load-limit restrictions reduced along the segment being described.
    /// </summary>
    AxleLoadLimit,

    /// <summary>
    /// Vehicle gross-weight-limit restrictions reduced along the segment being described.
    /// </summary>
    GrossWeightLimit,

    /// <summary>
    /// Towing is prohibited along the segment being described.
    /// </summary>
    TowingProhibited,

    /// <summary>
    /// “Permitted oversize loads” prohibited along the segment being described; this applies to
    /// annual oversize load permits.
    /// </summary>
    PermittedOversizeLoadsProhibited,
    
    /// <summary>
    /// Crossing the center line markings for passing is prohibited.
    /// </summary>
    NoPassing
}