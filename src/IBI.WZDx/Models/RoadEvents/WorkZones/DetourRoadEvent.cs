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
/// <param name="LocationMethod">
/// The typical method used to locate the beginning and end of a detour area.
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
/// <param name="IsStartPositionVerified">
/// Indicates if the start position (first geometric coordinate pair, see
/// <see cref="RoadEventFeature.Geometry"/>) is based on actual reported  data from a GPS-equipped
/// device that measured the location of the start of the detour.
/// </param>
/// <param name="IsEndPositionVerified">
/// Indicates if the end position (last geometric coordinate pair, see
/// <see cref="RoadEventFeature.Geometry"/>) is based on actual reported data from a GPS-equipped
/// device that measured the location of the end of the detour.
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
/// <param name="TypesOfWork">
/// A list of the types of work being done in a road event and an indication of if each type
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
/// <param name="ImpactedCdsCurbZones">
/// A list of references to external 
/// <see href="https://github.com/openmobilityfoundation/curb-data-specification/tree/main/curbs#curb-zone">
/// CDS Curb Zones
/// </see> 
/// impacted by the detour.
/// </param>
/// <param name="WorkZoneType">
/// The type of detour road event, such as if the road event is static or actively moving as part
/// of a moving operation.
/// </param>
public record DetourRoadEvent(
    RoadEventCoreDetails CoreDetails,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    LocationMethod LocationMethod,
    VehicleImpact VehicleImpact,
    bool? IsStartDateVerified = null,
    bool? IsEndDateVerified = null,
    bool? IsStartPositionVerified = null,
    bool? IsEndPositionVerified = null,
    WorkZoneType? WorkZoneType = null,
    List<CdsCurbZonesReference>? ImpactedCdsCurbZones = null,
    List<Lane>? Lanes = null,
    string? BeginningCrossStreet = null,
    string? EndingCrossStreet = null,
    double? BeginningMilepost = null,
    double? EndingMilepost = null,
    List<TypeOfWork>? TypesOfWork = null,
    WorkerPresence? WorkerPresence = null,
    double? ReducedSpeedLimitKph = null,
    List<Restriction>? Restrictions = null
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
            && LocationMethod == other.LocationMethod
            && VehicleImpact == other.VehicleImpact
            && IsStartDateVerified == other.IsStartDateVerified
            && IsEndDateVerified == other.IsEndDateVerified
            && IsStartPositionVerified == other.IsStartPositionVerified
            && IsEndPositionVerified == other.IsEndPositionVerified
            && Lanes.NullHandlingSequenceEqual(other.Lanes)
            && BeginningCrossStreet == other.BeginningCrossStreet
            && EndingCrossStreet == other.EndingCrossStreet
            && BeginningMilepost.NullEqualsApproximation(other.BeginningMilepost)
            && EndingMilepost.NullEqualsApproximation(other.EndingMilepost)
            && TypesOfWork.NullHandlingSequenceEqual(other.TypesOfWork)
            && WorkerPresence == other.WorkerPresence
            && ReducedSpeedLimitKph.NullEqualsApproximation(other.ReducedSpeedLimitKph)
            && Restrictions.NullHandlingSequenceEqual(other.Restrictions)
            && ImpactedCdsCurbZones.NullHandlingSequenceEqual(other.ImpactedCdsCurbZones)
            && WorkZoneType == other.WorkZoneType;
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
        hash.Add(IsStartPositionVerified);
        hash.Add(IsEndPositionVerified);

        if (Lanes is not null)
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

        if (TypesOfWork is not null)
        {
            foreach (TypeOfWork typeOfWork in TypesOfWork)
            {
                hash.Add(typeOfWork);
            }
        }

        hash.Add(WorkerPresence);
        hash.Add(ReducedSpeedLimitKph);

        if (Restrictions is not null)
        {
            foreach (Restriction restriction in Restrictions)
            {
                hash.Add(restriction);
            }
        }

        if (ImpactedCdsCurbZones is not null)
        {
            foreach (CdsCurbZonesReference cdsCurbZonesReference in ImpactedCdsCurbZones)
            {
                hash.Add(cdsCurbZonesReference);
            }
        }

        hash.Add(WorkZoneType);

        return hash.ToHashCode();
    }
}