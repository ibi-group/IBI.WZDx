using System;
using System.Collections.Generic;
using IBI.WZDx.Equality;

namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// Describes specific curb zones that are impacted by a work zone via an external reference to the
/// curb data specification's.
/// </summary>
/// <param name="CdsCurbZoneIds">A list of CDS Curb Zone Ids</param>
/// <param name="CdsCurbsApiUrl">An identifier for the source of the requested CDS Curbs API.</param>
public record CdsCurbZonesReference(
    IEnumerable<string> CdsCurbZoneIds,
    string CdsCurbsApiUrl
    )
{
    /// <summary>
    /// Determine if another <see cref="CdsCurbZonesReference"/> is equal to this <see cref="CdsCurbZonesReference"/>.
    /// </summary>
    public virtual bool Equals(CdsCurbZonesReference? other)
    {
        return other != null
            && CdsCurbZoneIds.NullHandlingSequenceEqual(other.CdsCurbZoneIds)
            && CdsCurbsApiUrl == other.CdsCurbsApiUrl;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        foreach (string id in CdsCurbZoneIds)
        {
            hash.Add(id);
        }

        hash.Add(CdsCurbsApiUrl);

        return hash.ToHashCode();
    }
}
