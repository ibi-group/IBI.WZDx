using System;

namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// A measure of how accurate a date-time is.
/// </summary>
[Obsolete("Determine verification of start and end dates from verification properties instead.")]
public enum TimeVerification
{
    /// <summary>
    /// Specific times/dates when work will or is occurring; includes advanced notice of activities
    /// or unverified work zone activities. This date/time may be reported in advance, but is not
    /// actively verified on day of event.
    /// </summary>
    Estimated,

    /// <summary>
    /// Actual reported times/dates when work occurs.
    /// </summary>
    Verified
}