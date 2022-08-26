namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// Situations in which workers may be considered present in a work zone.
/// </summary>
public enum WorkerPresenceDefinition
{
    /// <summary>
    /// Humans are physically in the work zone event area, doing road work.
    /// </summary>
    WorkersInWorkZoneWorking,

    /// <summary>
    /// Humans are physically in the work zone event area but not performing work.
    /// </summary>
    WorkersInWorkZoneNotWorking,

    /// <summary>
    /// Mobile equipment is moving within the work zone event area, implying the presence of a
    /// worker.
    /// </summary>
    MobileEquipmentInWorkZoneMoving,

    /// <summary>
    /// Mobile equipment is in the work zone event area but is not moving.
    /// </summary>
    MobileEquipmentInWorkZoneNotMoving,

    /// <summary>
    /// Fixed equipment is in the work zone event area.
    /// </summary>
    FixedEquipmentInWorkZone,

    /// <summary>
    /// Humans are present in the work zone event area but separated from traffic by a barrier.
    /// </summary>
    HumansBehindBarrier,

    /// <summary>
    /// Humans are present on the drivable surface.
    /// </summary>
    HumansInRightOfWay
}