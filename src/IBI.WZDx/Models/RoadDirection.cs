using IBI.WZDx.Models.RoadEvents;

namespace IBI.WZDx.Models;

/// <summary>
/// The direction of a road based on standard naming in the United States.
/// </summary>
public enum RoadDirection 
{
    /// <summary>
    /// The road direction is not known.
    /// </summary>
    Unknown,

    /// <summary>
    /// The road direction is toward the north.
    /// </summary>
    Northbound,

    /// <summary>
    /// The road direction is toward the south.
    /// </summary>
    Southbound,
    
    /// <summary>
    /// The road direction is toward the east.
    /// </summary>
    Eastbound,

    /// <summary>
    /// The road direction is toward the west.
    /// </summary>
    Westbound,

    /// <summary>
    /// The road direction is on the inner loop of a ring road or beltway.
    /// </summary>
    InnerLoop,

    /// <summary>
    /// The road direction is on the outer loop of a ring road or beltway.
    /// </summary>
    OuterLoop,

    /// <summary>
    /// The road does not have a signed direction.
    /// </summary>
    /// <remarks>
    /// For a <see cref="RoadEventFeature"/>, the first
    /// and last coordinates in <see cref="RoadEventFeature.Geometry"/> represent the beginning and
    /// end of the road event in the direction of travel it impacts.
    /// </remarks>
    Undefined
}