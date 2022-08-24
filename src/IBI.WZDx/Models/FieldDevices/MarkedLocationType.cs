using System;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Describes options for what a <see cref="MarkedLocation"/> can mark.
/// </summary>
public enum MarkedLocationType
{
    /// <summary>
    /// An automatic flagger assistance device.
    /// </summary>
    Afad,

    /// <summary>
    /// A human who is directing traffic.
    /// </summary>
    Flagger,

    /// <summary>
    /// The start of a lane shift.
    /// </summary>
    LaneShift,

    /// <summary>
    /// The start of one or more lanes being closed.
    /// </summary>
    LaneClosure,

    /// <summary>
    /// The start point of a road event.
    /// </summary>
    RoadEventStart,

    /// <summary>
    /// The end point of a road event.
    /// </summary>
    RoadEventEnd,

    /// <summary>
    /// The start point of a work zone.
    /// </summary>
    WorkZoneStart,

    /// <summary>
    /// The end point of a work zone.
    /// </summary>
    WorkZoneEnd,

    /// <summary>
    /// A connected device that is worn or carried by an individual worker in a work zone.
    /// </summary>
    PersonalDevice,

    /// <summary>
    /// A generic delineation point in a work zone. This value can be used for most types of marked
    /// locations that don't match any of the other values.
    /// </summary>
    Delineator,

    /// <summary>
    /// The start of a closed ramp onto or off a main road or highway.
    /// </summary>
    RampClosure,

    /// <summary>
    /// The start of a closed road.
    /// </summary>
    RoadClosure,

    /// <summary>
    /// A temporary traffic signal.
    /// </summary>
    [Obsolete("Use TrafficSignal field device object instead.")]
    TemporaryTrafficSignal
}