namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// Describes a linear event that occurs on a road.
/// </summary>
public interface IRoadEvent
{
    /// <summary>
    /// The core details of the road event that are common to all types of road events.
    /// </summary>
    RoadEventCoreDetails CoreDetails { get; }
}