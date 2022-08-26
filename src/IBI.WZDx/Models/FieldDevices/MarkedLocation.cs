using IBI.WZDx.Models.RoadEvents;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// A specific location where a <see cref="LocationMarker"/> is placed, such as the start or end of
/// a work zone road event. The marked location can be linked to a <see cref="RoadEventFeature"/>.
/// </summary>
/// <param name="Type">
/// The type of location (e.g. start or end) that is marked.
/// </param>
/// <param name="RoadEventId">
/// The <see cref="RoadEventFeature.Id"/> that the <see cref="MarkedLocation"/> applies to, if
/// applicable.
/// </param>
public record MarkedLocation(
    MarkedLocationType Type,
    string? RoadEventId = null
    );