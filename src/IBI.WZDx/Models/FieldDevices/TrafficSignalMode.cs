namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Describes the current operating mode of a <see cref="TrafficSignal"/>.
/// </summary>
public enum TrafficSignalMode
{
    /// <summary>
    /// The current operating mode is not known.
    /// </summary>
    Unknown,

    /// <summary>
    /// The signal is not displaying anything.
    /// </summary>
    Blank,

    /// <summary>
    /// The signal is in a flashing red state that could be part of startup or fault.
    /// </summary>
    FlashingRed,

    /// <summary>
    /// The signal is in a flashing yellow state that could be part of startup or fault.
    /// </summary>
    FlashingYellow,

    /// <summary>
    /// The signal is using an external trigger for all movements.
    /// </summary>
    FullyActuated,

    /// <summary>
    /// The signal is using a manual trigger.
    /// </summary>
    Manual,

    /// <summary>
    /// The signal is using a timed cycle.
    /// </summary>
    PreTimed,

    /// <summary>
    /// The signal is using an external trigger only for the minor movements.
    /// </summary>
    SemiActuated
}