namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// A high-level text description of the type of work being done in a work zone road event.
/// </summary>
public enum WorkTypeName
{
    /// <summary>
    /// Work with no impact on the roadway. This includes events such as trash pickup, mowing,
    /// or landscaping.
    /// </summary>
    Maintenance,

    /// <summary>
    /// Pothole repair, road crack repair and sealing, and other small road defect repairs.
    /// </summary>
    MinorRoadDefectRepair,

    /// <summary>
    /// Work that is isolated to the side of the road and not in the main travel way, such as
    /// repair, replacement, or addition of streetlights, VMS, signs (guide, warning, regulatory,
    /// and information signs) in the ground.
    /// </summary>
    RoadsideWork,

    /// <summary>
    /// Work that occurs above the road, such as repair/replacement of overpasses, overhead VMS,
    /// wires, overhead signs, signals, etc. This type of work requires a bucket truck or similar
    /// setup rather than being isolated to the side of the road.
    /// </summary>
    OverheadWork,

    /// <summary>
    /// Work occurring below the road such as boring or bridge repair.
    /// </summary>
    BelowRoadWork,

    /// <summary>
    /// Repair, replacement, addition, or change of barriers, guardrails, retaining walls,
    /// K-barriers, or similar.
    /// </summary>
    BarrierWork,

    /// <summary>
    /// New resurfacing, such as adding new lanes, moving lanes, or adding or changing connectivity
    /// (turn lanes), as well as creation or repair of non-drivable surfaces such as the shoulder or
    /// median.
    /// </summary>
    SurfaceWork,

    /// <summary>
    /// Repainting, re-striping, adding new lanes, moving lanes, adding stop bars/lines, etc.
    /// </summary>
    Painting,

    /// <summary>
    /// Physically relocating the road, such as adding a bridge or removing a sharp curve.
    /// </summary>
    RoadwayRelocation,
    
    /// <summary>
    /// Adding a new road.
    /// </summary>
    RoadwayCreation
}