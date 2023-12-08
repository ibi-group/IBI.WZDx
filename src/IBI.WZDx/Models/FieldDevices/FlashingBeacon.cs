namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// The FlashingBeacon object describes a flashing warning beacon used to supplement a temporary 
/// traffic control device. A flashing warning beacon is mounted on a sign or channelizing device 
/// and used to indicate a warning condition and capture driver attention.
/// </summary>
/// <param name="CoreDetails">
/// The core details of the flashing beacon device.
/// </param>
/// <param name="Function">
/// What the flashing beacon is being used to indicate.
/// </param>
/// <param name="IsFlashing">
/// Indicates if the flashing beacon is currently flashing.
/// </param>
/// <param name="SignText">
/// The text on the sign the beacon is mounted on, if applicable.
/// </param>
public record FlashingBeacon(
    FieldDeviceCoreDetails CoreDetails,
    FlashingBeaconFunction Function,
    bool? IsFlashing = null,
    string? SignText = null
    ) : IFieldDevice;