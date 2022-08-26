namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Describes a temporary traffic signal deployed on a roadway.
/// </summary>
/// <param name="CoreDetails">
/// The core details of the traffic signal device.
/// </param>
/// <param name="Mode">
/// The current operating mode of the traffic signal.
/// </param>
public record TrafficSignal(
    FieldDeviceCoreDetails CoreDetails,
    TrafficSignalMode Mode
    ) : IFieldDevice;