namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// The types of field devices supported by IBI.WZDx.
/// </summary>
public enum FieldDeviceType
{
    /// <summary>
    /// An electronic, connected arrow board which can display an arrow pattern to direct traffic.
    /// </summary>
    /// <remarks>
    /// See <see cref="ArrowBoard"/>.
    /// </remarks>
    ArrowBoard,

    /// <summary>
    /// A camera device deployed in the field, capable of capturing still images.
    /// </summary>
    /// <remarks>
    /// See <see cref="Camera"/>.
    /// </remarks>
    Camera,

    /// <summary>
    /// An electronic traffic sign deployed on the roadway, used to provide information to
    /// travelers.
    /// See <see cref="DynamicMessageSign"/>.
    /// </summary>
    DynamicMessageSign,

    /// <summary>
    /// A flashing beacon light of any form, used to indicate caution and capture driver attention.
    /// See <see cref="FlashingBeacon"/>.
    /// </summary>
    FlashingBeacon,

    /// <summary>
    /// A message sign that contains both static text (e.g. on an aluminum board) along with a
    /// variable electronic message sign, used to provide information to travelers.
    /// </summary>
    /// <remarks>
    /// See <see cref="HybridSign"/>.
    /// </remarks>
    HybridSign,

    /// <summary>
    /// Any GPS-enabled ITS device that is placed at a point on a roadway to mark a location (often
    /// the beginning or end of a road event).
    /// </summary>
    /// <remarks>
    /// See <see cref="LocationMarker"/>.
    /// </remarks>
    LocationMarker,

    /// <summary>
    /// A device deployed on a roadway which captures traffic metrics such as speed, volume, or
    /// occupancy.
    /// </summary>
    /// <remarks>
    /// See <see cref="TrafficSensor"/>.
    /// </remarks>
    TrafficSensor,

    /// <summary>
    /// A temporary traffic signal deployed on a roadway.
    /// </summary>
    /// <remarks>
    /// See <see cref="TrafficSignal"/>.
    /// </remarks>
    TrafficSignal
}