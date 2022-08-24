namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Options for what a <see cref="FlashingBeacon"/> is being used to indicate.
/// </summary>
public enum FlashingBeaconFunction
{
    /// <summary>
    /// Vehicles are entering the roadway.
    /// </summary>
    VehicleEntering,

    /// <summary>
    /// There is a queue of vehicles.
    /// </summary>
    QueueWarning,

    /// <summary>
    /// There is a reduced speed limit.
    /// </summary>
    ReducedSpeed,

    /// <summary>
    /// There are workers are present on or near the roadway.
    /// </summary>
    WorkersPresent
}