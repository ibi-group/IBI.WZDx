namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// Methods for how worker presence in a work zone event area is determined.
/// </summary>
public enum WorkerPresenceMethod
{
    /// <summary>
    /// Cameras in the work zone event area show workers are present.
    /// </summary>
    CameraMonitoring,

    /// <summary>
    /// A GPS-enabled arrow board is located in the work zone event area and broadcasting its
    /// location, implying that workers are present.
    /// </summary>
    ArrowBoardPresent,

   /// <summary>
   /// GPS-enabled cones are located in the road event area, implying that workers are present.
   /// </summary>
    ConesPresent,

    /// <summary>
    /// A GPS-enabled maintenance vehicle is located in the road event area, implying that workers
    /// are present.
    /// </summary>
    MaintenanceVehiclePresent,

    /// <summary>
    /// Workers wearing wearable detection equipment are present in the work zone.
    /// </summary>
    WearablesPresent,

    /// <summary>
    /// Workers with GPS-enabled mobile device tracking are present in the work zone.
    /// </summary>
    MobileDevicePresent,

    /// <summary>
    /// Workers have checked into the work zone via a mobile app.
    /// </summary>
    CheckInApp,

    /// <summary>
    /// Workers have checked into the work zone via phone or radio to a remote operations center.
    /// </summary>
    CheckInVerbal,

    /// <summary>
    /// Workers are scheduled to be in the road event area, but presence has not been confirmed.
    /// </summary>
    Scheduled
}