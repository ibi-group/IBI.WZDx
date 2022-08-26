using System;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// A camera device deployed in the field, capable of capturing still images.
/// </summary>
/// <param name="CoreDetails">
/// The core details of the camera device.
/// </param>
/// <param name="ImageUrl">
/// A URL pointing to an image file for the camera image still.
/// </param>
/// <param name="ImageTimestamp">
/// The date and time when the camera image was captured.
/// </param>
public record Camera(
    FieldDeviceCoreDetails CoreDetails,
    string? ImageUrl = null,
    DateTimeOffset? ImageTimestamp = null
    ) : IFieldDevice;