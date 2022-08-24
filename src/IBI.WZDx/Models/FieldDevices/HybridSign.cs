namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// A hybrid sign that contains static text (e.g. on an aluminum sign) along with a single
/// electronic message display, used to provide information to travelers.
/// </summary>
/// <param name="CoreDetails">
/// The core details of the hybrid sign.
/// </param>
/// <param name="DynamicMessageFunction">
/// The function the dynamic message displayed (specifically, the value of
/// <see cref="HybridSign.DynamicMessageText"/>).
/// </param>
/// <param name="DynamicMessageText">
/// The static text on the non-electronic component of the hybrid sign. This is plain text, not
/// NTCIP MULTI.
/// </param>
/// <param name="StaticSignText">
/// The static text on the non-electronic component of the hybrid sign. This is plain text, not
/// NTCIP MULTI.
/// </param>
public record HybridSign(
    FieldDeviceCoreDetails CoreDetails,
    HybridSignDynamicMessageFunction DynamicMessageFunction,
    string? DynamicMessageText = null,
    string? StaticSignText = null
    ) : IFieldDevice;