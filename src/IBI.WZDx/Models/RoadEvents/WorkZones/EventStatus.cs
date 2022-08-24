using System;

namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// The status of a work zone road event.
/// </summary>
[Obsolete("Determine an event's status based on the start and end dates and verification properties.")]
public enum EventStatus
{
    /// <summary>
    /// Planned status is associated with overall project or phase timing and locations. Typically,
    /// this information is estimated during planning or early design phases. The WZDx will not
    /// generally include planned activities.
    /// </summary>
    Planned,
    
    /// <summary>
    /// Pending is used to alert stakeholders that work is scheduled for the near future
    /// (e.g., 2-3 weeks). The certainty of starting at this time is greater than 90% (barring
    /// weather and other unforeseen circumstances).
    /// </summary>
    Pending,

    /// <summary>
    /// Used to alert stakeholder that work zone is in place and active.
    /// </summary>
    Active,

    /// <summary>
    /// Reported cancellation of a proposed or active work zone; the coverage applies to the work
    /// zone activity record.
    /// </summary>
    Cancelled,

    /// <summary>
    /// Work zone is closed and completed; all work zone impacts are mitigated. This status may be
    /// used when a work zone activity is completed earlier than expected.
    /// </summary>
    Completed
}