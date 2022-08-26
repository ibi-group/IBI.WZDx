namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Describes a connected device deployed in the field in a work zone.
/// </summary>
public interface IFieldDevice
{
    /// <summary>
    /// The core details of the field device that are common to all types of field devices.
    /// </summary>
    FieldDeviceCoreDetails CoreDetails { get; }
}