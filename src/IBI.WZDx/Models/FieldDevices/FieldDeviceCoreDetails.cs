using System;
using System.Collections.Generic;
using IBI.WZDx.Equality;
using IBI.WZDx.Models.RoadEvents;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Represents the core details of a field device that are shared by all types of field devices.
/// </summary>
/// <param name="DeviceType">
/// The type of field device.
/// </param>
/// <param name="DataSourceId">
/// The identifier for the <see cref="FeedDataSource"/> from which the field device data originates.
/// The value should match <see cref="FeedDataSource.DataSourceId"/> of a data source in the same
/// feed.
/// </param>
/// <param name="DeviceStatus">
/// The operational status of the field device.
/// </param>
/// <param name="UpdateDate">
/// The UTC date and time when any information in the <see cref="FieldDeviceFeature"/> (including
/// child objects) that the <see cref="FieldDeviceCoreDetails"/> applies to was most recently
/// updated or confirmed as up to date.
/// </param>
/// <param name="RoadDirection">
/// The direction of the road that the field device is on. This value indicates the direction of the
/// traffic flow of the road, not a real heading angle.
/// </param>
/// <param name="HasAutomaticLocation">
/// Indicates if the field device location (<see cref="FieldDeviceFeature.Geometry"/>) is determined
/// automatically from an on-board GPS (true) or manually set/overridden (false).
/// </param>
/// /// <param name="RoadNames">
/// A list of publicly known names of the road on which the device is located. This may include the
/// road number designated by a jurisdiction such as a county, state, or interstate (e.g. "I-5",
/// "VT 133", "Main Street").
/// </param>
/// <param name="Name">
/// A human-readable name for the field device. For a unique identifier for the device, see
/// <see cref="FieldDeviceFeature.Id"/>.
/// </param>
/// <param name="Description">
/// A description of the field device.
/// </param>
/// <param name="Milepost">
/// The linear distance measured against a milepost marker along a roadway where the device is
/// located.
/// </param>
/// <param name="StatusMessages">
/// A list of messages associated with the device's status, if applicable. Provides additional
/// information about the status such as specific warning or error messages.
/// </param>
/// <param name="IsMoving">
/// A yes/no value indicating if the device is actively moving (not statically placed) as part of a
/// mobile work zone operation.
/// </param>
/// <param name="RoadEventIds">
/// A list of strings corresponding to <see cref="RoadEventFeature.Id"/>s that the device is
/// associated with or provides data for, if applicable.
/// </param>
/// <param name="Make">
/// The make or manufacturer of the field device.
/// </param>
/// <param name="Model">
/// The model of the field device.
/// </param>
/// <param name="SerialNumber">
/// The serial number of the field device.
/// </param>
/// <param name="FirmwareVersion">
///  The version of firmware the device is using to operate.
/// </param>
/// <param name="VelocityKph">
/// The velocity of the device in kilometers per hour.
/// </param>
public record FieldDeviceCoreDetails(
    FieldDeviceType DeviceType,
    string DataSourceId,
    FieldDeviceStatus DeviceStatus,
    DateTimeOffset UpdateDate,
    bool HasAutomaticLocation,
    IEnumerable<string>? RoadNames = null,
    RoadDirection? RoadDirection = null,
    string? Name = null,
    string? Description = null,
    double? Milepost = null,
    IEnumerable<string>? StatusMessages = null,
    bool? IsMoving = null,
    IEnumerable<string>? RoadEventIds = null,
    string? Make = null,
    string? Model = null,
    string? SerialNumber = null,
    string? FirmwareVersion = null,
    double? VelocityKph = null
    )
{
    /// <inheritdoc/>
    public virtual bool Equals(FieldDeviceCoreDetails? other)
    {
        return other != null
            && DeviceType == other.DeviceType
            && DataSourceId == other.DataSourceId
            && DeviceStatus == other.DeviceStatus
            && UpdateDate == other.UpdateDate
            && HasAutomaticLocation == other.HasAutomaticLocation
            && RoadNames.NullHandlingSequenceEqual(other.RoadNames)
            && RoadDirection == other.RoadDirection
            && Name == other.Name
            && Description == other.Description
            && Milepost == other.Milepost
            && StatusMessages.NullHandlingSequenceEqual(other.StatusMessages)
            && IsMoving == other.IsMoving
            && RoadEventIds.NullHandlingSequenceEqual(other.RoadEventIds)
            && Make == other.Make
            && Model == other.Model
            && SerialNumber == other.SerialNumber
            && FirmwareVersion == other.FirmwareVersion
            && VelocityKph == other.VelocityKph;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(DeviceType);
        hash.Add(DataSourceId);
        hash.Add(DeviceStatus);
        hash.Add(UpdateDate);
        hash.Add(HasAutomaticLocation);

        if (RoadNames != null)
        {
            foreach (string roadName in RoadNames)
            {
                hash.Add(roadName);
            }
        }

        hash.Add(RoadDirection);
        hash.Add(Name);
        hash.Add(Description);
        hash.Add(Milepost);

        if (StatusMessages != null)
        {
            foreach (string statusMessage in StatusMessages)
            {
                hash.Add(statusMessage);
            }
        }

        hash.Add(IsMoving);

        if (RoadEventIds != null)
        {
            foreach (string roadEventId in RoadEventIds)
            {
                hash.Add(roadEventId);
            }
        }

        hash.Add(Make);
        hash.Add(Model);
        hash.Add(SerialNumber);
        hash.Add(FirmwareVersion);
        
        if (RoadNames is not null)
        {
            foreach (string roadName in RoadNames)
            {
                hash.Add(roadName);
            }
        }

        if (StatusMessages != null)
        {
            foreach (string statusMessage in StatusMessages)
            {
                hash.Add(statusMessage);
            }
        }

        if (RoadEventIds != null)
        {
            foreach (string roadEventId in RoadEventIds)
            {
                hash.Add(roadEventId);
            }
        }

        if (VelocityKph != null)
        {
            hash.Add(VelocityKph);
        }

        return hash.ToHashCode();
    }
}