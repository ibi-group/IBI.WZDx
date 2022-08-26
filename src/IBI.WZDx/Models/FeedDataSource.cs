using System;

namespace IBI.WZDx.Models;

/// <summary>
/// Describes information about a specific data source used to build a WZDx feed.
/// </summary>
/// <param name="DataSourceId">
/// A unique identifier for a data source providing data used in a feed. It is recommended that this
/// identifier is a <see cref="Guid"/>.
/// </param>
/// <param name="OrganizationName">
/// The name of the organization for the authoritative source of the data.
/// </param>
/// <param name="UpdateDate">
/// The moment in time when the data source was last updated.
/// </param>
/// <param name="UpdateFrequency">
/// The frequency in seconds at which the data source is updated.
/// </param>
/// <param name="ContactName">
/// The name of the individual or group responsible for the work zone data source.
/// </param>
/// <param name="ContactEmail">
/// The email address of the individual or group responsible for the data source.
/// </param>
public record FeedDataSource(
    string DataSourceId,
    string OrganizationName,
    DateTimeOffset? UpdateDate = null,
    int? UpdateFrequency = null,
    string? ContactName = null,
    string? ContactEmail = null
    );