namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// The type of work zone road event.
/// </summary>
public enum WorkZoneType
{
    /// <summary>
    /// The road event is statically placed and is not moving.
    /// </summary>
    Static,

    /// <summary>
    /// The road event is actively moving on the roadway.
    /// </summary>
    /// <remarks>
    /// As opposed to <see cref="PlannedMovingArea"/>, the road event geometry changes at the operation moves. 
    /// </remarks>
    Moving,

    /// <summary>
    /// The road event is the planned extent of a moving operation. The active work area will be 
    /// somewhere within this road event.
    /// </summary>
    /// <remarks>
    /// As opposed to <see cref="Moving"/>, the road event geometry typically does not actively change. 
    /// </remarks>
    PlannedMovingArea
}
