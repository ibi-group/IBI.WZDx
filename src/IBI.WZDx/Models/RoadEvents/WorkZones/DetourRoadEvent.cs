using System;
using System.Collections.Generic;
using IBI.WZDx.Equality;

namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// Describes a detour on a roadway. It can be either a segment of a detour
/// (each segment represented by its own <see cref="DetourRoadEvent"/>) or the entire detour.
/// </summary>
/// <param name="CoreDetails">
/// The core details of the road event that apply to all types of road events, not specific to detour road events. 
/// </param>
/// <param name="StartDate">
/// The UTC time and date when the event begins.
/// </param>
/// <param name="EndDate">
/// The UTC time and date when the event ends.
/// </param>
/// <param name="IsStartDateVerified">
/// Indicates if work has been confirmed to have started, such as from a person or field device.
/// </param>
/// <param name="IsEndDateVerified">
/// Indicates if work has been confirmed to have ended, such as from a person or field device.
/// </param>
/// <param name="BeginningCrossStreet">
/// Name or number of the nearest cross street along the roadway where the event begins.
/// </param>
/// <param name="EndingCrossStreet">
/// Name or number of the nearest cross street along the roadway where the event ends.
/// </param>
/// <param name="BeginningMilepost">
/// The linear distance measured against a milepost marker along a roadway where the event begins.
/// </param>
/// <param name="EndingMilepost">
/// The linear distance measured against a milepost marker along a roadway where the event ends.
/// </param>
public record DetourRoadEvent(
    RoadEventCoreDetails CoreDetails,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    bool? IsStartDateVerified = null,
    bool? IsEndDateVerified = null,
    string? BeginningCrossStreet = null,
    string? EndingCrossStreet = null,
    double? BeginningMilepost = null,
    double? EndingMilepost = null
    ) : IRoadEvent
{
    /// <summary>
    /// Determine if another <see cref="DetourRoadEvent"/> is equal to this <see cref="DetourRoadEvent"/>.
    /// </summary>
    public virtual bool Equals(DetourRoadEvent? other)
    {
        return other != null
            && CoreDetails == other.CoreDetails
            && StartDate == other.StartDate
            && EndDate == other.EndDate
            && IsStartDateVerified == other.IsStartDateVerified
            && IsEndDateVerified == other.IsEndDateVerified
            && BeginningCrossStreet == other.BeginningCrossStreet
            && EndingCrossStreet == other.EndingCrossStreet
            && BeginningMilepost.NullEqualsApproximation(other.BeginningMilepost)
            && EndingMilepost.NullEqualsApproximation(other.EndingMilepost);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(CoreDetails);
        hash.Add(StartDate);
        hash.Add(EndDate);
        hash.Add(IsStartDateVerified);
        hash.Add(IsEndDateVerified);
        hash.Add(BeginningCrossStreet);
        hash.Add(EndingCrossStreet);
        hash.Add(BeginningMilepost);
        hash.Add(EndingMilepost);

        return hash.ToHashCode();
    }
}