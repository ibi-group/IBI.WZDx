using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using IBI.WZDx.Models.FieldDevices;

namespace IBI.WZDx.Serialization;

/// <summary>
/// JSON converter for serialization of <see cref="IFieldDevice"/> types.
/// </summary>
internal class FieldDeviceConverter : JsonConverter<IFieldDevice>
{
    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(IFieldDevice);

    /// <inheritdoc />
    /// <summary>
    /// Reads and converts the JSON representation of a <see cref="IFieldDevice"/> to an
    /// implementation of a field device based on the
    /// <see cref="FieldDeviceCoreDetails.DeviceType"/> property in the JSON. 
    /// </summary>
    /// <param name="reader">
    /// The reader.
    /// </param>
    /// <param name="typeToConvert">
    /// System.Text.Json will pass a type of <see cref="IFieldDevice"/> here.
    /// </param>
    /// <param name="options">
    /// An object that specifies serialization options to use.
    /// </param>
    /// <returns>
    /// One of the concrete field device objects that implement <see cref="IFieldDevice"/>.
    /// </returns>
    /// <exception cref="JsonException">
    /// The device type in the JSON is not supported.
    /// </exception>
    public override IFieldDevice? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDocument.RootElement.GetRawText();
        var deviceType = jsonDocument.RootElement.GetProperty("core_details")
            .GetProperty("device_type")
            .GetString();

        Func<Type, IFieldDevice?> deserializeAsType = type =>
            JsonSerializer.Deserialize(jsonObject, type, options) as IFieldDevice;

        return deviceType switch
        {
            "arrow-board" => deserializeAsType(typeof(ArrowBoard)),
            "camera" => deserializeAsType(typeof(Camera)),
            "dynamic-message-sign" => deserializeAsType(typeof(DynamicMessageSign)),
            "flashing-beacon" => deserializeAsType(typeof(FlashingBeacon)),
            "hybrid-sign" => deserializeAsType(typeof(HybridSign)),
            "location-marker" => deserializeAsType(typeof(LocationMarker)),
            "traffic-sensor" => deserializeAsType(typeof(TrafficSensor)),
            "traffic-signal" => deserializeAsType(typeof(TrafficSignal)),
            _ => throw new JsonException($"Unsupported field device type '{deviceType}'.")
        };
    }

    /// <inheritdoc />
    /// <summary>
    /// Write a <see cref="IFieldDevice"/> as JSON.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    /// <param name="value">The <see cref="IFieldDevice"/> object to convert to JSON.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> cannot be null.</exception>
    public override void Write(Utf8JsonWriter writer, IFieldDevice value, JsonSerializerOptions options)
    {   
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        var type = value.GetType();

        JsonSerializer.Serialize(writer, value, type, options);
    }
}