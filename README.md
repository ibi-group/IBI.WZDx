# IBI WZDx .NET Library

This repository contains the source code for IBI Group's [.NET 6.0](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6) [WZDx (Work Zone Data Exchange)](https://github.com/usdot-jpo-ode/wzdx) class library, `IBI.WZDx`.

## About

The `IBI.WZDx` class library provides models and utitlies for producing and consuming [Work Zone Data Exchange (WZDx)](https://github.com/usdot-jpo-ode/wzdx) data feeds.

The library provides the following functionality:

- Utilize WZDx concepts in .NET code.
- Create a WZDx [WorkZoneFeed](https://github.com/usdot-jpo-ode/wzdx/blob/main/spec-content/objects/WorkZoneFeed.md) or [DeviceFeed](https://github.com/usdot-jpo-ode/wzdx/blob/main/spec-content/objects/DeviceFeed.md) GeoJSON string by serializing WZDx C# objects modeled in this library.
- Deserialize a WZDx Work Zone Feed or Device Feed GeoJSON string into C# objects modeled in this library.

### WZDx Version Support

WZDx versions 4.0, 4.1 & 4.2 are supported; the [WzdxSerializer](./src/IBI.WZDx/Serialization/WzdxSerializer.cs) defaults to outputting v4.2 (latest WZDx).

[Detour road events](https://github.com/usdot-jpo-ode/wzdx/blob/main/spec-content/objects/DetourRoadEvent.md) are not supported. When provided with a Work Zone Feed that includes detour road events, the WzdxSerializer.DeserializeFeed method will deserialize the detour events into a [RoadEventFeature](./src/IBI.WZDx/Models/RoadEvents/RoadEventFeature.cs) with `Properties` as `null`.

## Usage

### NuGet Package

To use the library, you need to reference it in your .NET project. The easiest way to do this is to add the [IBI.WZDx NuGet package](https://www.nuget.org/packages/IBI.WZDx/), available from [nuget.org](https://nuget.org), as a dependency to your project:

```shell
dotnet add package IBI.WZDx
```

### Create a WZDx feed GeoJSON string

Use the [WzdxSerializer](./src/IBI.WZDx/Serialization/WzdxSerializer.cs) static class to serialize a WZDx feed object into a GeoJSON string that represents a valid WZDx feed object.

For example:

```c#
using IBI.WZDx.Models;
using IBI.WZDx.Serialization;

var myWzdxWorkZoneFeed = new WorkZoneFeed(...);

string wzdxGeoJsonString = WzdxSerializer.SerializeFeed(myWzdxWorkZoneFeed);
```

### Read in a WZDx feed GeoJSON string

Use the [WzdxSerializer](./src/IBI.WZDx/Serialization/WzdxSerializer.cs) static class to deserialize a WZDx feed JSON string into an IBI.WZDx library model representation of the feed content.

For Example:

```c#
using IBI.WZDx.Models;
using IBI.WZDx.Serialization;

var httpClient = new HttpClient();

HttpResponseMessage feedResponse = await httpClient.GetAsync("https://url.to.wzdx.feed/wzdx-device-feed");
string wzdxDeviceFeedGeoJson = await feedResponse.Content.ReadAsStringAsync();

DeviceFeed wzdxDeviceFeed = WzdxSerializer.DeserializeFeed<DeviceFeed>(wzdxDeviceFeedGeoJson);
```

## Versioning 

The package uses [Semantic Versioning](https://semver.org/) in a MAJOR.MINOR.PATCH format.

The MAJOR and MINOR version numbers correspond to the MAJOR and MINOR version numbers of the [WZDx specification](https://github.com/usdot-jpo-ode/wzdx) that it conforms to.

The PATCH version number is incremented as changes are made to the library that are unrelated to progress of WZDx.

## Tests

This solution includes a [IBI.WZDx.UnitTests](/tests/IBI.WZDx.UnitTests/) Xunit test project. Run all unit tests with the following command:

```
dotnet test
```