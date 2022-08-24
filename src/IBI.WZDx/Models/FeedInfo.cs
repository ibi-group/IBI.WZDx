using System;
using System.Collections.Generic;
using System.Linq;

namespace IBI.WZDx.Models;

/// <summary>
/// Information about a WZDx feed such as metadata, contact information, and data sources.
/// </summary>
/// <param name="Publisher">
/// The organization responsible for publishing the feed.
/// </param>
/// <param name="Version">
/// The WZDx specification version the data feed conforms to in 'major.minor' format.
/// </param>
/// <param name="UpdateDate">
/// The date and time when the instance of the feed was generated.
/// </param>
/// <param name="DataSources">
/// A list of data sources used to provide the data in the feed.
/// </param>
/// <param name="UpdateFrequency">
/// The frequency in seconds at which the data feed is updated, if applicable.
/// </param>
/// <param name="ContactName">
/// The name of the individual or group responsible for the data feed.
/// </param>
/// <param name="ContactEmail">
/// The email address of the individual or group responsible for the data feed.
/// </param>
public record FeedInfo(
    string Publisher,
    string Version,
    DateTimeOffset UpdateDate,
    IEnumerable<FeedDataSource> DataSources,
    int? UpdateFrequency = null,
    string? ContactName = null,
    string? ContactEmail = null
    )
{
    /// <summary>
    /// The URL of the license that applies to the data in the feed.
    /// </summary>
    public string License { get; } = "https://creativecommons.org/publicdomain/zero/1.0/";

    /// <summary>
    /// Determine if an other <see cref="FeedInfo"/> is equal to this <see cref="FeedInfo"/>.
    /// </summary>
    public virtual bool Equals(FeedInfo? other)
    {
        return other != null
            && Publisher == other.Publisher
            && Version == other.Version
            && UpdateDate == other.UpdateDate
            && UpdateFrequency == other.UpdateFrequency
            && ContactName == other.ContactName
            && ContactEmail == other.ContactEmail
            && DataSources.SequenceEqual(other.DataSources);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(Publisher);
        hash.Add(Version);
        hash.Add(UpdateDate);
        hash.Add(UpdateFrequency);
        hash.Add(ContactName);
        hash.Add(ContactEmail);
        hash.Add(License);
        
        foreach (FeedDataSource dataSource in DataSources)
        {
            hash.Add(dataSource);
        }

        return hash.ToHashCode();
    }
}