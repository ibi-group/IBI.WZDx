using System.Runtime.Serialization;

namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// Options for the geometry type of a <see cref="RoadEventFeature"/>.
/// </summary>
public enum RoadEventFeatureGeometryType
{
    /// <summary>
    /// The start and end locations of a road event.
    /// See <see href="https://datatracker.ietf.org/doc/html/rfc7946#section-3.1.3">GeoJSON
    /// MultiPoint Geometry</see>.
    /// </summary>
    [EnumMember(Value = "MultiPoint")]
    MultiPoint,

    /// <summary>
    /// The linestring path of a road event.
    /// See <see href="https://datatracker.ietf.org/doc/html/rfc7946#section-3.1.4">GeoJSON
    /// LineString Geometry</see>.
    /// </summary>
    [EnumMember(Value = "LineString")]
    LineString
}