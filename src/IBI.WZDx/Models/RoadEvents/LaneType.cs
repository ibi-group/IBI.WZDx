using System;

namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// A description of the static properties of a section of a lane of a roadway, intended to reflect
/// information about its function that is not covered by its status (see <see cref="LaneStatus"/>).
/// </summary>
public enum LaneType 
{
    /// <summary>
    /// A generic lane type, intended to be used for general purpose travel lanes.
    /// </summary>
    General,
    
    /// <summary>
    /// A lane leading towards an egress from the current roadway. An exit lane usually becomes an
    /// exit ramp (see <see cref="ExitRamp"/>) after a gore point.
    /// </summary>
    ExitLane,

    /// <summary>
    /// A lane at an interchange leading away from the current roadway to another roadway.
    /// </summary>
    ExitRamp,

    /// <summary>
    /// A lane leading away from an ingress to the current roadway. An entrance ramp 
    /// (see <see cref="EntranceRamp"/>) usually becomes an entrance lane after a gore point.
    /// </summary>
    EntranceLane,

    /// <summary>
    /// A lane at an interchange for traffic to ingress from another roadway to the mainline.
    /// </summary>
    EntranceRamp,

    /// <summary>
    /// A path for pedestrians, usually on the side of the roadway.
    /// </summary>
    Sidewalk,

    /// <summary>
    /// A lane on the roadway for use by cyclists only.
    /// </summary>
    BikeLane,

    /// <summary>
    /// A portion of the roadway that is outside (either right or left) of the main travel lanes. A
    /// shoulder can have many uses but is not intended for general traffic.
    /// </summary>
    Shoulder,

    /// <summary>
    /// A lane used for parking, not allowed for travel.
    /// </summary>
    Parking,

    /// <summary>
    /// An often unpaved, non-drivable area that separates sections of the roadway. In most cases a
    /// median should only be described if it separates lanes in a single direction of travel, as
    /// each direction of travel is represented by a separate road event.
    /// </summary>
    Median,

    /// <summary>
    /// A lane in the center of a bidirectional roadway that traffic from both directions uses to
    /// make a turn that crosses opposite direction of traffic (i.e. left in right-side driving
    /// countries, and right in left-side driving countries).
    /// </summary>
    TwoWayCenterTurnLane,

    /// <summary>
    /// A lane in the center of a bidirectional roadway that traffic from both directions uses to
    /// make a left turn.
    /// </summary>
    [Obsolete("Use TwoWayCenterTurnLane instead.")]
    CenterLeftTurnLane
}