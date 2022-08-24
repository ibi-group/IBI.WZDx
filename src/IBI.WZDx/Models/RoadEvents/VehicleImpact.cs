namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// The impact to vehicular lanes along a single road in a single direction.
/// </summary>
public enum VehicleImpact 
{
    /// <summary>
    /// The vehicle impact is not known.
    /// </summary>
    Unknown,

    /// <summary>
    /// All lanes are open.
    /// </summary>
    AllLanesOpen,

    /// <summary>
    /// Some lanes are closed.
    /// </summary>
    SomeLanesClosed,

    /// <summary>
    /// All lanes are closed.
    /// </summary>
    AllLanesClosed,

    /// <summary>
    /// The roadway is alternating one way.
    /// </summary>
    AlternatingOneWay,

    /// <summary>
    /// Some lanes merge to the left.
    /// </summary>
    SomeLanesClosedMergeLeft,

    /// <summary>
    /// Some lanes merge to the right.
    /// </summary>
    SomeLanesClosedMergeRight,

    /// <summary>
    /// All lanes are open, shift to the left.
    /// </summary>
    AllLanesOpenShiftLeft,

    /// <summary>
    /// All lanes are open, shift to the right.
    /// </summary>
    AllLanesOpenShiftRight,

    /// <summary>
    /// Some lanes end and split and merge to the right and left.
    /// </summary>
    SomeLanesClosedSplit,

    /// <summary>
    /// A flagging operation is in effect.
    /// </summary>
    Flagging,
    
    /// <summary>
    /// A temporary traffic signal is in operation.
    /// </summary>
    TemporaryTrafficSignal
}