using System.Runtime.Serialization;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Options for the geometry type of a <see cref="FieldDeviceFeature"/>.
/// </summary>
public enum FieldDeviceFeatureGeometryType
{
    /// <summary>
    /// The point location of a field device.
    /// See <see href="https://datatracker.ietf.org/doc/html/rfc7946#section-3.1.2">GeoJSON
    /// Point Geometry</see>.
    /// </summary>
    [EnumMember(Value = "Point")]
    Point
}