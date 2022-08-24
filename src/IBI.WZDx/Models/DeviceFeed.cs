using System;
using System.Collections.Generic;
using System.Linq;
using IBI.WZDx.Models.FieldDevices;

namespace IBI.WZDx.Models;

/// <summary>
/// The root object of a WZDx Device Feed.
/// </summary>
/// <param name="FeedInfo">
/// Information about the feed.
/// </param>
/// <param name="Features">
///  A collection of GeoJSON Feature objects which each describe a field device.
/// </param>
/// <param name="Bbox">
/// Information on the coordinate range for all features in the feed. See
/// <see href="https://datatracker.ietf.org/doc/html/rfc7946#section-5">GeoJSON Bounding Box</see>.
/// </param>
public record DeviceFeed(
    FeedInfo FeedInfo,
    IEnumerable<FieldDeviceFeature> Features,
    object? Bbox = null
    ) : IWzdxFeed
{
    /// <summary>
    /// The GeoJSON object type.
    /// </summary>
    public string Type { get; } = "FeatureCollection";

    /// <summary>
    /// Determine if an other <see cref="DeviceFeed"/> is equal to this <see cref="DeviceFeed"/>.
    /// </summary>
    public virtual bool Equals(DeviceFeed? other)
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

        foreach (FieldDeviceFeature feature in Features)
        {
            hash.Add(feature);
        }

        return hash.ToHashCode();
    }
}