namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Describes a flashing beacon light of any form (e.g. trailer-mounted, vehicle), used to indicate
/// something and capture driver attention.
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