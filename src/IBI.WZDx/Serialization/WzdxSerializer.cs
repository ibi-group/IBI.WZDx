using System.Text.Json;
using System.Text.Json.Serialization;
using IBI.WZDx.Models;

namespace IBI.WZDx.Serialization;

/// <summary>
/// Provides functionality to serialize WZDx feed objects to GeoJSON and deserialize WZDx
/// GeoJSON into objects.
/// </summary>
public static class WzdxSerializer
{
    /// <summary>
    /// Options for serializing and deserializing WZDx data models.
    /// </summary>
    public static JsonSerializerOptions SerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
        WriteIndented = true,
        Converters =
        {
            // System.Text.Json JsonStringEnumConverter does not use naming policy on
            // deserialization, thus we have to use JsonStringEnumMemberConverter from 
            // Macross.Json.Extensions.
            new JsonStringEnumMemberConverter(new KebabCaseNamingPolicy()), 
            new FieldDeviceConverter(),
            new RoadEventConverter()
        }
    };

    /// <summary>
    /// Deserialize a WZDx Feed of a supplied type from a GeoJSON string containing the feed.
    /// </summary>
    /// <param name="feedGeoJson">
    /// A GeoJSON string containing a feed object.
    /// </param>
    /// <returns>
    /// The feed as a <typeparam name="TWzdxFeed"/> object.
    /// </returns>
    /// <exception cref="JsonException">
    /// Unable to deserialize the provided string into the supplied type.
    /// </exception>
    public static TWzdxFeed DeserializeFeed<TWzdxFeed>(string feedGeoJson) where TWzdxFeed : IWzdxFeed
    {
        var exceptionMessage = $"Unable to deserialize the provided string as a {typeof(TWzdxFeed).Name}.";
        TWzdxFeed? feedObject;
        try
        {
            feedObject = JsonSerializer.Deserialize<TWzdxFeed>(feedGeoJson, SerializerOptions);
        }
        catch (JsonException jsonException)
        {
            throw new JsonException(exceptionMessage, jsonException);
        }
        
        if (feedObject == null)
        {
            throw new JsonException(exceptionMessage);
        }

        return feedObject;
    }

    /// <summary>
    /// Serialize a WZDx feed object into a string containing WZDx GeoJSON.
    /// </summary>
    /// <typeparam name="TWzdxFeed">The type feed to serialize.</typeparam>
    /// <param name="wzdxFeed">The feed object to serialize.</param>
    /// <returns>A string containing the GeoJSON representation of the WZDx feed.</returns>
    public static string SerializeFeed<TWzdxFeed>(TWzdxFeed wzdxFeed) where TWzdxFeed : IWzdxFeed
    {
        return JsonSerializer.Serialize(wzdxFeed, SerializerOptions);
    }
}