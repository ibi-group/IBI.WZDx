namespace IBI.WZDx.Models.RoadEvents;

/// <summary>
/// Describes a restriction on a roadway or lane.
/// </summary>
/// <param name="Type">
/// The type of restriction being enforced.
/// </param>
/// <param name="Value">
/// A value associated with the restriction, if applicable.
/// </param>
/// <param name="Unit">
/// Unit of measurement for the restriction <paramref name="Value"/>, if applicable.
/// </param>
public readonly record struct Restriction(
    RestrictionType Type,
    double? Value = null,
    UnitOfMeasurement? Unit = null
    );