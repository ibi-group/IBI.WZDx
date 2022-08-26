using System;
using System.Linq;

namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// The geometry for a WZDx GeoJSON feature used for <see cref="RoadEventFeature"/>. From
/// <see href="https://tools.ietf.org/html/rfc7946#section-3.1">GeoJSON Geometry</see>.
/// </summary>
/// <param name="Type">
/// The type of geometry.
/// </param>
/// <param name="Coordinates">
/// A position or array of positions where each position is a double[] with two or three elements,
/// either [Longitude, Latitude] or [Longitude, Latitude, Altitude].
/// </param>
public record RoadEventFeatureGeometry(RoadEventFeatureGeometryType Type, double[][] Coordinates)
{
    /// <inheritdoc/>
    public virtual bool Equals(RoadEventFeatureGeometry? other)
    {
        if (other is null)
            return false;

        var areCoordinatesEqual = Coordinates.Length == other.Coordinates.Length
            && Enumerable.Range(0, Coordinates.Length)
                .All(index => Coordinates[index].SequenceEqual(other.Coordinates[index]));

        return areCoordinatesEqual;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(Type);

        foreach (double[] position in Coordinates)
        {
            foreach (double coordinate in position)
            {
                hashCode.Add(coordinate);
            }
        }

        return hashCode.ToHashCode();
    }
}