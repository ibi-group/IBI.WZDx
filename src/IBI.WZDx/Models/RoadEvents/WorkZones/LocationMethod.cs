namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// The method used to define the begin and end of a work zone impact area.
/// </summary>
public enum LocationMethod 
{
    /// <summary>
    /// The location method is not known.
    /// </summary>
    Unknown,

    /// <summary>
    /// Location of first and last channeling device (e.g., cone or barrier) that is part of a
    /// “travel impact effect” (taper) or designation of a work zone transition area.
    /// </summary>
    ChannelDeviceMethod,
    
    /// <summary>
    /// Location of first and last work zone-related signs.
    /// </summary>
    SignMethod,

    /// <summary>
    /// Location of a junction (e.g., a cross street or exit/entrance ramp) before and after a work
    /// zone.
    /// </summary>
    JunctionMethod,
    
    /// <summary>
    /// The location method does not match any of the other options.
    /// </summary>
    Other
}