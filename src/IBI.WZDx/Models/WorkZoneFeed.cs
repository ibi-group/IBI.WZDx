using System;
using System.Collections.Generic;
using System.Linq;
using IBI.WZDx.Models.RoadEvents;

namespace IBI.WZDx.Models;

/// <summary>
/// The root object of a WZDx Work Zone Feed.
/// </summary>
/// <param name="FeedInfo">
/// Information about the feed.
/// </param>
/// <param name="Features">
/// A collection of GeoJSON Feature objects that each describe a road event.
/// </param>
/// <param name="Bbox">
/// Information on the coordinate range for all features in the feed. See
/// <see href="https://datatracker.ietf.org/doc/html/rfc7946#section-5">GeoJSON Bounding Box</see>.
/// </param>
public record WorkZoneFeed(
    FeedInfo FeedInfo,
    IEnumerable<RoadEventFeature> Features,
    object? Bbox = null
    ) : IWzdxFeed
{
    /// <summary>
    /// The GeoJSON object type.
    /// </summary>
    public string Type { get; } = "FeatureCollection";

    /// <summary>
    /// Determine if an other <see cref="WorkZoneFeed"/> is equal to this <see cref="WorkZoneFeed"/>.
    /// </summary>
    public virtual bool Equals(WorkZoneFeed? other)
    {
        return other != null
            && FeedInfo == other.FeedInfo
            && Bbox == other.Bbox
            && Features.SequenceEqual(other.Features);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(FeedInfo);
        hash.Add(Bbox);
 
        foreach (RoadEventFeature feature in Features)
        {
            hash.Add(feature);
        }

        return hash.ToHashCode();
    }
}