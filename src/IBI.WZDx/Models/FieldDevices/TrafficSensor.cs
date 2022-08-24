using System;
using System.Collections.Generic;
using IBI.WZDx.Equality;
using IBI.WZDx.Models.RoadEvents;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// A traffic sensor deployed on a roadway which captures traffic metrics (e.g. speed, volume,
/// occupancy) over a collection interval.
/// </summary>
/// <remarks>
/// The <see cref="AverageSpeedKph"/>, <see cref="VolumeVph"/>, and <see cref="OccupancyPercent"/>
/// values apply to the inclusive interval of
/// <see cref="CollectionIntervalStartDate"/> to <see cref="CollectionIntervalEndDate"/>.
/// </remarks>
/// <param name="CoreDetails">
/// The core details of the traffic sensor device.
/// </param>
/// <param name="CollectionIntervalStartDate">
/// The date and time where the traffic sensor data collection began.
/// </param>
/// <param name="CollectionIntervalEndDate">
/// The date and time where the traffic sensor data collection ended. 
/// </param>
/// <param name="AverageSpeedKph">
/// The average speed of vehicles across all lanes over the collection interval in kilometers per
/// hour.
/// </param>
/// <param name="VolumeVph">
/// The rate of vehicles passing by the sensor during the collection interval in vehicles per hour.
/// </param>
/// <param name="OccupancyPercent">
/// The percent of time the roadway section monitored by the sensor was occupied by a vehicle over
/// the collection interval.
/// </param>
/// <param name="LaneData">
/// A list of objects each describing traffic data for a specific lane. Each points to a
/// <see cref="Lane"/> in a road event and describes the current data for that lane.
/// </param>
public record TrafficSensor(
    FieldDeviceCoreDetails CoreDetails,
    DateTimeOffset CollectionIntervalStartDate,
    DateTimeOffset CollectionIntervalEndDate,
    double? AverageSpeedKph = null,
    double? VolumeVph = null,
    double? OccupancyPercent = null,
    IEnumerable<TrafficSensorLaneData>? LaneData = null
    ) : IFieldDevice
{
    /// <summary>
    /// Determine if another <see cref="TrafficSensor"/> is equal to this <see cref="TrafficSensor"/>.
    /// </summary>
    public virtual bool Equals(TrafficSensor? other)
    {
        return other != null
            && CoreDetails == other.CoreDetails
            && CollectionIntervalStartDate == other.CollectionIntervalStartDate
            && CollectionIntervalEndDate == other.CollectionIntervalEndDate
            && AverageSpeedKph == other.AverageSpeedKph
            && VolumeVph == other.VolumeVph
            && OccupancyPercent == other.OccupancyPercent
            && LaneData.NullHandlingSequenceEqual(other.LaneData);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(CoreDetails);
        hash.Add(CollectionIntervalStartDate);
        hash.Add(CollectionIntervalEndDate);
        hash.Add(AverageSpeedKph);
        hash.Add(VolumeVph);
        hash.Add(OccupancyPercent);

        if (LaneData != null)
        {
            foreach (TrafficSensorLaneData laneData in LaneData)
            {
                hash.Add(laneData);
            }
        }

        return hash.ToHashCode();
    } 
}