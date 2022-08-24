using System;
using System.Linq;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// The geometry for a WZDx GeoJSON feature used for <see cref="FieldDeviceFeature"/>. From
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.1">GeoJSON Geometry</see>.
/// </summary>
/// <param name="Type">
/// The type of geometry.
/// </param>
/// <param name="Coordinates">
/// A position as a double[] with two or three elements, either [Longitude, Latitude] or 
/// [Longitude, Latitude, Altitude].
/// </param>
public record FieldDeviceFeatureGeometry(FieldDeviceFeatureGeometryType Type, double[] Coordinates)
{
    /// <inheritdoc/>
    public virtual bool Equals(FieldDeviceFeatureGeometry? other)
    {
        return other != null
            && Type == other.Type
            && Coordinates.SequenceEqual(other.Coordinates);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(Type);

        foreach (double coordinate in Coordinates)
        {
            hashCode.Add(coordinate);
        }

        return hashCode.ToHashCode();
    }
}