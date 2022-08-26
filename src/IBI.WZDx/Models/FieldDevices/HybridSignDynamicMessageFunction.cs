namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Options for the function of the dynamic message displayed on the electronic display on a
/// <see cref="HybridSign"/>.
/// </summary>
public enum HybridSignDynamicMessageFunction
{
    /// <summary>
    /// The value of <see cref="HybridSign.DynamicMessageText"/> is a speed limit.
    /// </summary>
    SpeedLimit,

    /// <summary>
    /// The value of <see cref="HybridSign.DynamicMessageText"/> is a travel time.
    /// </summary>
    TravelTime,

    /// <summary>
    /// The hybrid sign message function does not match one of the other
    /// options described by the <see cref="HybridSignDynamicMessageFunction"/>.
    /// </summary>
    Other
}