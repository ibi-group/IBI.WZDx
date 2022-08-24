namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// Identifies a road event that is related to the road event that the
/// <see cref="RelatedRoadEvent"/> occurs on.
/// </summary>
/// <param name="Type">
/// The type of relationship with the road event being identifed, such as another sequence of
/// related work zones, a detour, or the next road event in sequence.
/// </param>
/// <param name="Id">
/// An identifier for the related road event of type specified by <paramref name="Type"/>. The value
/// of this property should correspond to a <see cref="RoadEventFeature.Id"/> within the same 
/// <see cref="WorkZoneFeed"/>.
/// </param>
public record RelatedRoadEvent(
    RelatedRoadEventType Type,
    string Id
    );