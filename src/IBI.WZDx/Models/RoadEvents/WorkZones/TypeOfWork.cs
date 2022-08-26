namespace IBI.WZDx.Models.RoadEvents.WorkZones;

/// <summary>
/// Indicates the type of work being done in a road event, if applicable (e.g. typical work zones),
/// as well as optionally noting if the type of work will result in an architectural change to the
/// roadway.
/// </summary>
/// <param name="TypeName">
/// A high-level text description of the type of work being done.
/// </param>
/// <param name="IsArchitecturalChange">
/// A flag indicating whether the type of work will result in an architectural change to the
/// roadway.
/// </param>
public readonly record struct TypeOfWork(
    WorkTypeName TypeName,
    bool? IsArchitecturalChange = null
    );