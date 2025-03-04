using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using IBI.WZDx.Models.RoadEvents;
using IBI.WZDx.Models.RoadEvents.WorkZones;

namespace IBI.WZDx.Serialization;

/// <summary>
/// JSON converter for serialization of <see cref="IRoadEvent"/> types.
/// </summary>
internal class RoadEventConverter : JsonConverter<IRoadEvent>
{
    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(IRoadEvent);

    /// <inheritdoc />
    /// <summary>
    /// Reads and converts the JSON representation of a <see cref="IRoadEvent"/> to an
    /// implementation of a road event based on the <see cref="RoadEventCoreDetails.EventType"/>
    /// set in the JSON. 
    /// </summary>
    /// <param name="reader">
    /// The reader.
    /// </param>
    /// <param name="typeToConvert">
    /// A type of <see cref="IRoadEvent"/>.
    /// </param>
    /// <param name="options">
    /// An object that specifies serialization options to use.
    /// </param>
    /// <returns>
    /// One of the concrete road event objects that implements <see cref="IRoadEvent"/>.
    /// </returns>
    public override IRoadEvent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader);
        string jsonObject = jsonDocument.RootElement.GetRawText();
        string? eventType = jsonDocument.RootElement.GetProperty("core_details")
            .GetProperty("event_type")
            .GetString();

        IRoadEvent? DeserializeAsType(Type type) => JsonSerializer.Deserialize(jsonObject, type, options) as IRoadEvent;
        
        return eventType switch
        {
            "work-zone" => DeserializeAsType(typeof(WorkZoneRoadEvent)),
            "detour" => DeserializeAsType(typeof(DetourRoadEvent)),
            _ => throw new JsonException($"Unsupported event type '{eventType}'.")
        };
    }

    /// <inheritdoc />
    /// <summary>
    /// Write a <see cref="IRoadEvent"/> as JSON.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    /// <param name="value">The <see cref="IRoadEvent"/> object to convert to JSON.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> cannot be null.</exception>
    public override void Write(Utf8JsonWriter writer, IRoadEvent value, JsonSerializerOptions options)
    {
        ArgumentNullException.ThrowIfNull(value);
        Type type = value.GetType();
        JsonSerializer.Serialize(writer, value, type, options);
    }
}