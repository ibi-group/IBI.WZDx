using System;
using System.Collections.Generic;
using System.Linq;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Describes any GPS-enabled ITS device that is placed at a point on a roadway to dynamically know 
/// the location of something (often the beginning or end of a work zone).
/// </summary>
/// <param name="CoreDetails">
/// The core details of the location marker device.
/// </param>
/// <param name="MarkedLocations">
/// A list of locations that the location marker is marking.
/// </param>
public record LocationMarker(
    FieldDeviceCoreDetails CoreDetails,
    IEnumerable<MarkedLocation> MarkedLocations
    ) : IFieldDevice
{
    /// <summary>
    /// Determine if another <see cref="LocationMarker"/> is equal to this <see cref="LocationMarker"/>.
    /// </summary>
    public virtual bool Equals(LocationMarker? other)
    {
        return other != null
            && CoreDetails == other.CoreDetails
            && MarkedLocations.SequenceEqual(other.MarkedLocations);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(CoreDetails);

        foreach (MarkedLocation markedLocation in MarkedLocations)
        {
            hash.Add(markedLocation);
        }

        return hash.ToHashCode();
    } 
}