namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// describes the operational status/health of a field device.
/// </summary>
public enum FieldDeviceStatus
{
    /// <summary>
    /// The device is turned on and working without issue.
    /// </summary>
    Ok,

    /// <summary>
    /// The device is functional but is impaired or impacted in a way that is not critical to
    /// operation.
    /// </summary>
    Warning,
    
    /// <summary>
    /// The device is impaired such that it is not able to perform one or more necessary
    /// functions.
    /// </summary>
    Error,
    
    /// <summary>
    /// The device's operational status is not known.
    /// </summary>
    Unknown
}