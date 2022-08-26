namespace IBI.WZDx.Models;

/// <summary>
/// Describes the root object of Work Zone Data Exchange feed, such as a
/// <see cref="WorkZoneFeed"/>.
/// </summary>
public interface IWzdxFeed
{
    /// <summary>
    /// Information about the WZDx feed such as metadata, contact information, and data sources.
    /// </summary>
    FeedInfo FeedInfo { get; }
}
