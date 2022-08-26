using System;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// A <see href="https://tools.ietf.org/html/rfc7946#section-3.2">GeoJSON Feature</see>
/// representing a deployed field device (see <see cref="IFieldDevice"/>).
/// </summary>
/// <param name="Id">
/// A unique identifier for the field device described by the <see cref="FieldDeviceFeature"/>. It
/// is recommended that this identifier is a <see cref="Guid"/>.
/// </param>
/// <param name="Properties">
/// The specific details of the field device contained by the <see cref="FieldDeviceFeature"/>.
/// </param>
/// <param name="Geometry">
/// The geometry describing the location of the field device.
/// </param>
/// <param name="Bbox">
/// Information on the coordinate range for the field device. See
/// <see href="https://datatracker.ietf.org/doc/html/rfc7946#section-5"> GeoJSON Bounding Box</see>.
/// </param>
public record FieldDeviceFeature(
    string Id,
    IFieldDevice Properties,
    FieldDeviceFeatureGeometry Geometry,
    object? Bbox = null
    )
{
    /// <summary>
    /// The GeoJSON object type.
    /// </summary>
    public string Type { get; } = "Feature";
}