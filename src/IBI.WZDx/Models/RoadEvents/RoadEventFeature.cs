using System;

namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// A <see href="https://tools.ietf.org/html/rfc7946#section-3.2">GeoJSON Feature</see>
/// representing a road event (see <see cref="IRoadEvent"/>).
/// </summary>
/// <param name="Id">
/// A unique identifier for the road event described by the <see cref="RoadEventFeature"/>. It is
/// recommended that this identifier is a <see cref="Guid"/>.
/// </param>
/// <param name="Properties">
/// The specific details of the road event contained by the <see cref="RoadEventFeature"/>.
/// </param>
/// <param name="Geometry">
/// The geometry describing the location of the road event.
/// </param>
/// <param name="Bbox">
/// Information on the coordinate range for the road event. See
/// <see href="https://datatracker.ietf.org/doc/html/rfc7946#section-5"> GeoJSON Bounding Box</see>.
/// </param>
public record RoadEventFeature(
    string Id,
    IRoadEvent Properties,
    RoadEventFeatureGeometry Geometry,
    object? Bbox = null
    )
{
    /// <summary>
    /// The GeoJSON object type.
    /// </summary>
    public string Type { get; } = "Feature";
}