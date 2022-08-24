using System;
using System.Collections.Generic;
using IBI.WZDx.Equality;

namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// Describes a work zone road event including where, when, and what activities are taking place
/// within a work zone on a roadway.
/// </summary>
/// <remarks>
/// A full "work zone" is represented by one or more <see cref="WorkZoneRoadEvent"/>s.
/// </remarks>
/// <param name="CoreDetails">
/// The core details of the road event that apply to all types of road events, not specific to work
/// zones.
/// </param>
/// <param name="StartDate">
/// The UTC time and date when the event begins.
/// </param>
/// <param name="EndDate">
/// The UTC time and date when the event ends.
/// </param>
/// <param name="LocationMethod">
/// The typical method used to locate the beginning and end of a work zone impact area.
/// </param>
/// <param name="VehicleImpact">
/// The impact to vehicular lanes along a single road in a single direction.
/// </param>
/// <param name="IsStartDateVerified">
/// Indicates if work has been confirmed to have started, such as from a person or field device.
/// </param>
/// <param name="IsEndDateVerified">
/// Indicates if work has been confirmed to have ended, such as from a person or field device.
/// </param>
/// <param name="StartDateAccuracy">
/// A measure of how accurate the start date-time is.
/// </param>
/// <param name="EndDateAccuracy">
/// A measure of how accurate the end date-time is.
/// </param>
/// <param name="IsStartPositionVerified">
/// Indicates if the start position (first geometric coordinate pair, see
/// <see cref="RoadEventFeature.Geometry"/>) is based on actual reported  data from a GPS-equipped
/// device that measured the location of the start of the work zone.
/// </param>
/// <param name="IsEndPositionVerified">
/// Indicates if the end position (last geometric coordinate pair, see
/// <see cref="RoadEventFeature.Geometry"/>) is based on actual reported data from a GPS-equipped
/// device that measured the location of the end of the work zone.
/// </param>
/// <param name="BeginningAccuracy">
/// Indicates how the beginning coordinate was defined.
/// </param>
/// <param name="EndingAccuracy">
/// Indicates how the ending coordinate was defined.
/// </param>
/// <param name="Lanes">
/// A list of individual lanes within a road event (roadway segment).
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
/// <param name="EventStatus">
/// The status of the event.
/// </param>
/// <param name="TypesOfWork">
/// A list of the types of work being done in a road event and an indiciation of if each type
/// results in an architectural change to the roadway.
/// </param>
/// <param name="WorkerPresence">
/// Information about whether workers are present in the road event area.
/// </param>
/// <param name="ReducedSpeedLimitKph">
/// The reduced speed limit posted within the road event, in kilometers per hour. This property only
/// needs to be supplied if the speed limit within the road event is lower than the posted speed
/// limit of the roadway.
/// </param>
/// <param name="Restrictions">
/// A list of zero or more road restrictions that apply to the roadway segment described by this
/// road event.
/// </param>
public record WorkZoneRoadEvent(
    RoadEventCoreDetails CoreDetails,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    LocationMethod LocationMethod,
    VehicleImpact VehicleImpact,
    bool? IsStartDateVerified = null,
    bool? IsEndDateVerified = null,
    [property: Obsolete("Use IsStartDateVerified instead.")]TimeVerification? StartDateAccuracy = null,
    [property: Obsolete("Use IsEndDateVerified instead.")]TimeVerification? EndDateAccuracy = null,
    bool? IsStartPositionVerified = null,
    bool? IsEndPositionVerified = null,
    [property: Obsolete("Use IsStartPositionVerified instead.")]SpatialVerification? BeginningAccuracy = null,
    [property: Obsolete("Use IsEndPositionVerified instead.")]SpatialVerification? EndingAccuracy = null,
    IEnumerable<Lane>? Lanes = null,
    string? BeginningCrossStreet = null,
    string? EndingCrossStreet = null,
    double? BeginningMilepost = null,
    double? EndingMilepost = null,
    [property: Obsolete("Determine an event's status based on the dates and verification properties.")]
        EventStatus? EventStatus = null,
    IEnumerable<TypeOfWork>? TypesOfWork = null,
    WorkerPresence? WorkerPresence = null,
    double? ReducedSpeedLimitKph = null,
    IEnumerable<Restriction>? Restrictions = null
    ) : IRoadEvent
{
    /// <summary>
    /// Determine if another <see cref="WorkZoneRoadEvent"/> is equal to this <see cref="WorkZoneRoadEvent"/>.
    /// </summary>
    public virtual bool Equals(WorkZoneRoadEvent? other)
    {
        return other != null
            && CoreDetails == other.CoreDetails
            && StartDate == other.StartDate
            && EndDate == other.EndDate
            && LocationMethod == other.LocationMethod
            && VehicleImpact == other.VehicleImpact
            && IsStartDateVerified == other.IsStartDateVerified
            && IsEndDateVerified == other.IsEndDateVerified
            && StartDateAccuracy == other.StartDateAccuracy
            && EndDateAccuracy == other.EndDateAccuracy
            && IsStartPositionVerified == other.IsStartPositionVerified
            && IsEndPositionVerified == other.IsEndPositionVerified
            && BeginningAccuracy == other.BeginningAccuracy
            && EndingAccuracy == other.EndingAccuracy
            && Lanes.NullHandlingSequenceEqual(other.Lanes)
            && BeginningCrossStreet == other.BeginningCrossStreet
            && EndingCrossStreet == other.EndingCrossStreet
            && BeginningMilepost == other.BeginningMilepost
            && EndingMilepost == other.EndingMilepost
            && EventStatus == other.EventStatus
            && TypesOfWork.NullHandlingSequenceEqual(other.TypesOfWork)
            && WorkerPresence == other.WorkerPresence
            && ReducedSpeedLimitKph == other.ReducedSpeedLimitKph
            && Restrictions.NullHandlingSequenceEqual(other.Restrictions);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(CoreDetails);
        hash.Add(StartDate);
        hash.Add(EndDate);
        hash.Add(LocationMethod);
        hash.Add(VehicleImpact);
        hash.Add(IsStartDateVerified);
        hash.Add(IsEndDateVerified);
        hash.Add(StartDateAccuracy);
        hash.Add(EndDateAccuracy);
        hash.Add(IsStartPositionVerified);
        hash.Add(IsEndPositionVerified);
        hash.Add(BeginningAccuracy);
        hash.Add(EndingAccuracy);

        if (Lanes != null)
        {
            foreach (Lane lane in Lanes)
            {
                hash.Add(lane);
            }
        }

        hash.Add(BeginningCrossStreet);
        hash.Add(EndingCrossStreet);
        hash.Add(BeginningMilepost);
        hash.Add(EndingMilepost);
        hash.Add(EventStatus);

        if (TypesOfWork != null)
        {
            foreach (TypeOfWork typeOfWork in TypesOfWork)
            {
                hash.Add(typeOfWork);
            }
        }

        hash.Add(WorkerPresence);
        hash.Add(ReducedSpeedLimitKph);

        if (Restrictions != null)
        {
            foreach (Restriction restriction in Restrictions)
            {
                hash.Add(restriction);
            }
        }

        return hash.ToHashCode();
    }
}