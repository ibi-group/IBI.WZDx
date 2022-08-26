using IBI.WZDx.Models.RoadEvents;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Data for a single lane within a <see cref="IRoadEvent"/> measured by a
/// <see cref="TrafficSensor"/> deployed within the road event.
/// </summary>
/// <param name="LaneOrder">
/// The lane's position in sequence within the road event (specified by <see cref="RoadEventId"/>).
/// The value of this property corresponds to the associated road event's lane's order.
/// </param>
/// <param name="RoadEventId">
/// The identifier of the road event (see <see cref="RoadEventFeature.Id"/>) that the lane data
/// applies to, if known.
/// </param>
/// <param name="AverageSpeedKph">
/// The average speed of traffic in the lane over the collection interval in kilometers per hour.
/// </param>
/// <param name="VolumeVph">
/// The rate of vehicles passing by the sensor in the lane during the collection interval in
/// vehicles per hour.
/// </param>
/// <param name="OccupancyPercent">
/// The percent of time the lane monitored by the sensor was occupied by a vehicle over the
/// collection interval.
/// </param>
public record TrafficSensorLaneData(
    int LaneOrder,
    string? RoadEventId = null, 
    double? AverageSpeedKph = null,
    double? VolumeVph = null,
    double? OccupancyPercent = null
    );