using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using IBI.WZDx.Models;
using IBI.WZDx.Models.FieldDevices;
using IBI.WZDx.Models.RoadEvents;
using IBI.WZDx.Models.RoadEvents.WorkZones;
using IBI.WZDx.Serialization;
using Xunit;

namespace IBI.WZDx.UnitTests;

/// <summary>
/// Tests for the <see cref="WzdxSerializer"/> class.
/// </summary>
public class WzdxSerializerTests
{
    /// <summary>
    /// Tests for <see cref="DeviceFeed"/>s.
    /// </summary>
    public class DeviceFeedTests
    {
        [Fact]
        public void DeserializeFeed_JsonNotValid_ThrowsJsonException()
        {
            DeserializeFeed_JsonNotValid_ThrowsJsonException<DeviceFeed>();
        }

        [Fact]
        public void DeserializeFeed_JsonValid_DoesNotThrowException()
        {
            var action = () => WzdxSerializer.DeserializeFeed<DeviceFeed>(_testValidDeviceFeed);

            var exception = Record.Exception(action);

            Assert.Null(exception);
        }

        [Theory]
        [MemberData(nameof(DeviceFeedEquivalentRepresentations))]
        public void DeserializeFeed_DeviceFeedObjectEqualsExpected(
            DeviceFeed expectedFeedObject,
            string feedJson
            )
        {
            DeviceFeed actualFeedObject = WzdxSerializer.DeserializeFeed<DeviceFeed>(feedJson);

            Assert.Equal(expectedFeedObject, actualFeedObject);
        }

        [Theory]
        [MemberData(nameof(DeviceFeedEquivalentRepresentations))]
        public void SerializeFeed_DeviceFeedJsonEqualsExpected(
            DeviceFeed feedObject,
            string expectedFeedJson
            )
        {
            string actualFeedJson = WzdxSerializer.SerializeFeed(feedObject);

            string expectedFeedJsonWithoutWhitespace = new string(
                expectedFeedJson.Where(c => !Char.IsWhiteSpace(c)).ToArray()
                );
            string actualFeedJsonWithoutWhitespace = new string(
                actualFeedJson.Where(c => !Char.IsWhiteSpace(c)).ToArray()
                );

            Assert.Equal(expectedFeedJsonWithoutWhitespace, actualFeedJsonWithoutWhitespace);
        }

        /// <summary>
        /// A collection of pairs of WZDx Device Feeds as <see cref="DeviceFeed"/> objects and
        /// their equivalent JSON representations for testing.
        /// </summary>
        public static IEnumerable<object[]> DeviceFeedEquivalentRepresentations =>
            new List<object[]>
            {
                // Device Feed with all supported types of devices.
                new object[]
                {
                    new DeviceFeed(
                        FeedInfo: new FeedInfo(
                            UpdateDate: new DateTimeOffset(2023, 6, 18, 15, 0, 0, TimeSpan.Zero),
                            Publisher: "TestDOT",
                            Version: "4.1",
                            ContactName: "Frederick Francis Feedmanager",
                            ContactEmail: "fred.feedmanager@testdot.gov",
                            UpdateFrequency: 60,
                            DataSources: new FeedDataSource[]
                            {
                                new FeedDataSource(
                                    DataSourceId: "0d8c63cb-69f0-4b87-baed-b11d6bca9abf",
                                    OrganizationName: "Test City 1",
                                    ContactName: "Solomn Soliel Sourcefeed",
                                    ContactEmail: "solomon.sourcefeed@testcity1.gov",
                                    UpdateFrequency: 300,
                                    UpdateDate: new DateTimeOffset(2023, 6, 18, 14, 37, 31, TimeSpan.Zero)
                                    )
                            }
                            ),
                        Features: new FieldDeviceFeature[]
                        {
                            // Arrow Board.
                            // Includes all optional fields except Bbox.
                            new FieldDeviceFeature(
                                Id: "3b46c53d-24a2-46e9-be73-f0d1165dfb3b",
                                Properties: new ArrowBoard(
                                    CoreDetails: new FieldDeviceCoreDetails(
                                        DeviceType: FieldDeviceType.ArrowBoard,
                                        DataSourceId: "0d8c63cb-69f0-4b87-baed-b11d6bca9abf",
                                        DeviceStatus: FieldDeviceStatus.Ok,
                                        UpdateDate: new DateTimeOffset(2023, 6, 18, 14, 37, 31, TimeSpan.Zero),
                                        HasAutomaticLocation: true,
                                        RoadNames: new string[] { "I-80" },
                                        RoadDirection: RoadDirection.Northbound,
                                        Name: "Arrow Board 1",
                                        Description: "An arrow board for testing",
                                        Milepost: 15.1,
                                        StatusMessages: new string[] { "Arrow board is operational." },
                                        IsMoving: false,
                                        RoadEventIds: new string[] { "1f334f6b-14ad-4123-b92d-9d4a7e416629" },
                                        Make: "Ver-Mac",
                                        Model: "AB-1",
                                        SerialNumber: "1234567890",
                                        FirmwareVersion: "1.0.0"
                                        ),
                                    Pattern: ArrowBoardPattern.RightArrowFlashing,
                                    IsMoving: false,
                                    IsInTransportPosition: true
                                    ),
                                Geometry: new FieldDeviceFeatureGeometry(
                                    Type: FieldDeviceFeatureGeometryType.Point,
                                    Coordinates: new double[]
                                    {
                                        -93.77668405099996,
                                        41.617961698000045
                                    }
                                    )
                                ),
                            // Camera.
                            new FieldDeviceFeature(
                                Id: "395fff35-46c5-41d9-acdd-85dc5bd3cba8",
                                Properties: new Camera(
                                    CoreDetails: new FieldDeviceCoreDetails(
                                        DeviceType: FieldDeviceType.Camera,
                                        DataSourceId: "4f880fce-2dd1-4d29-9676-b2152fce1336",
                                        DeviceStatus: FieldDeviceStatus.Warning,
                                        UpdateDate: new DateTimeOffset(2024, 6, 18, 14, 37, 31, TimeSpan.Zero),
                                        HasAutomaticLocation: true
                                        ),
                                    ImageUrl: "https://test.com/image.jpg",
                                    ImageTimestamp: new DateTimeOffset(2024, 6, 18, 14, 37, 10, TimeSpan.Zero)
                                    ),
                                Geometry: new FieldDeviceFeatureGeometry(
                                    Type: FieldDeviceFeatureGeometryType.Point,
                                    Coordinates: new double[]
                                    {
                                        -93.77667436599995,
                                        41.62032278300006
                                    }
                                    )
                                ),
                            // Dynamic Message Sign.
                            new FieldDeviceFeature(
                                Id: "395fff35-46c5-41d9-acdd-85dc5bd3cba8",
                                Properties: new DynamicMessageSign(
                                    CoreDetails: new FieldDeviceCoreDetails(
                                        DeviceType: FieldDeviceType.DynamicMessageSign,
                                        DataSourceId: "4f880fce-2dd1-4d29-9676-b2152fce1336",
                                        DeviceStatus: FieldDeviceStatus.Error,
                                        UpdateDate: new DateTimeOffset(2024, 6, 18, 14, 37, 31, TimeSpan.Zero),
                                        HasAutomaticLocation: false
                                        ),
                                    MessageMultiString: "I-90 WB[nl]TRAFFIC[nl]BACKUPS[np]PLEASE[nl]USE[nl]CAUTION"
                                    ),
                                Geometry: new FieldDeviceFeatureGeometry(
                                    Type: FieldDeviceFeatureGeometryType.Point,
                                    Coordinates: new double[]
                                    {
                                        -93.77667436599995,
                                        41.62032278300006
                                    }
                                    )
                                ),
                            // Flashing Beacon.
                            new FieldDeviceFeature(
                                Id: "395fff35-46c5-41d9-acdd-85dc5bd3cba8",
                                Properties: new FlashingBeacon(
                                    CoreDetails: new FieldDeviceCoreDetails(
                                        DeviceType: FieldDeviceType.FlashingBeacon,
                                        DataSourceId: "4f880fce-2dd1-4d29-9676-b2152fce1336",
                                        DeviceStatus: FieldDeviceStatus.Error,
                                        UpdateDate: new DateTimeOffset(2024, 6, 18, 14, 37, 31, TimeSpan.Zero),
                                        HasAutomaticLocation: false
                                        ),
                                    Function: FlashingBeaconFunction.ReducedSpeed,
                                    IsFlashing: true,
                                    SignText: "SPEED LIMIT 50 MPH"
                                    ),
                                Geometry: new FieldDeviceFeatureGeometry(
                                    Type: FieldDeviceFeatureGeometryType.Point,
                                    Coordinates: new double[]
                                    {
                                        -93.77667436599995,
                                        41.62032278300006
                                    }
                                    )
                                ),
                            // Hybrid Sign.
                            new FieldDeviceFeature(
                                Id: "395fff35-46c5-41d9-acdd-85dc5bd3cba8",
                                Properties: new HybridSign(
                                    CoreDetails: new FieldDeviceCoreDetails(
                                        DeviceType: FieldDeviceType.HybridSign,
                                        DataSourceId: "4f880fce-2dd1-4d29-9676-b2152fce1336",
                                        DeviceStatus: FieldDeviceStatus.Ok,
                                        UpdateDate: new DateTimeOffset(2024, 6, 18, 14, 37, 31, TimeSpan.Zero),
                                        HasAutomaticLocation: true
                                        ),
                                    DynamicMessageFunction: HybridSignDynamicMessageFunction.SpeedLimit,
                                    DynamicMessageText: "50",
                                    StaticSignText: "SPEED LIMIT"
                                    ),
                                Geometry: new FieldDeviceFeatureGeometry(
                                    Type: FieldDeviceFeatureGeometryType.Point,
                                    Coordinates: new double[]
                                    {
                                        -93.77667436599995,
                                        41.62032278300006
                                    }
                                    )
                                ),
                            // Location Marker.
                            new FieldDeviceFeature(
                                Id: "395fff35-46c5-41d9-acdd-85dc5bd3cba8",
                                Properties: new LocationMarker(
                                    CoreDetails: new FieldDeviceCoreDetails(
                                        DeviceType: FieldDeviceType.LocationMarker,
                                        DataSourceId: "4f880fce-2dd1-4d29-9676-b2152fce1336",
                                        DeviceStatus: FieldDeviceStatus.Ok,
                                        UpdateDate: new DateTimeOffset(2024, 6, 18, 14, 37, 31, TimeSpan.Zero),
                                        HasAutomaticLocation: true
                                        ),
                                    MarkedLocations: new MarkedLocation[]
                                    {
                                        new MarkedLocation(
                                            Type: MarkedLocationType.WorkZoneStart,
                                            RoadEventId: "395fff35-46aa-41d9-acdd-85dc5bd3cba8"
                                            )
                                    }
                                    ),
                                Geometry: new FieldDeviceFeatureGeometry(
                                    Type: FieldDeviceFeatureGeometryType.Point,
                                    Coordinates: new double[]
                                    {
                                        -93.77667436599995,
                                        41.62032278300006
                                    }
                                    )
                                ),
                            // Traffic Sensor.
                            new FieldDeviceFeature(
                                Id: "395fff35-46c5-41d9-acdd-85dc5bd3cba8",
                                Properties: new TrafficSensor(
                                    CoreDetails: new FieldDeviceCoreDetails(
                                        DeviceType: FieldDeviceType.TrafficSensor,
                                        DataSourceId: "4f880fce-2dd1-4d29-9676-b2152fce1336",
                                        DeviceStatus: FieldDeviceStatus.Ok,
                                        UpdateDate: new DateTimeOffset(2024, 6, 18, 14, 37, 31, TimeSpan.Zero),
                                        HasAutomaticLocation: true
                                        ),
                                    CollectionIntervalStartDate: new DateTimeOffset(2024, 6, 18, 14, 36, 00, TimeSpan.Zero),
                                    CollectionIntervalEndDate: new DateTimeOffset(2024, 6, 18, 14, 37, 00, TimeSpan.Zero),
                                    AverageSpeedKph: 89.4,
                                    VolumeVph: 2300,
                                    OccupancyPercent: 5.22,
                                    LaneData: new TrafficSensorLaneData[]
                                    {
                                        new TrafficSensorLaneData(
                                            LaneOrder: 1,
                                            RoadEventId: "395fff35-46c5-41d9-acdd-85dc5bd3cba8",
                                            AverageSpeedKph: 89.4,
                                            VolumeVph: 2300,
                                            OccupancyPercent: 5.22
                                            )
                                    }
                                    ),
                                Geometry: new FieldDeviceFeatureGeometry(
                                    Type: FieldDeviceFeatureGeometryType.Point,
                                    Coordinates: new double[]
                                    {
                                        -93.77667436599995,
                                        41.62032278300006
                                    }
                                    )
                                ),
                            // Traffic Signal
                            new FieldDeviceFeature(
                                Id: "395fff35-46c5-41d9-acdd-85dc5bd3cba8",
                                Properties: new TrafficSignal(
                                    CoreDetails: new FieldDeviceCoreDetails(
                                        DeviceType: FieldDeviceType.TrafficSignal,
                                        DataSourceId: "4f880fce-2dd1-4d29-9676-b2152fce1336",
                                        DeviceStatus: FieldDeviceStatus.Ok,
                                        UpdateDate: new DateTimeOffset(2024, 6, 18, 14, 37, 31, TimeSpan.Zero),
                                        HasAutomaticLocation: true
                                        ),
                                    Mode: TrafficSignalMode.PreTimed
                                    ),
                                Geometry: new FieldDeviceFeatureGeometry(
                                    Type: FieldDeviceFeatureGeometryType.Point,
                                    Coordinates: new double[]
                                    {
                                        -93.77667436599995,
                                        41.62032278300006
                                    }
                                    )
                                )
                        }
                        ),
                    @"
                    {
                        ""feed_info"": {
                            ""publisher"": ""TestDOT"",
                            ""version"": ""4.1"",
                            ""update_date"": ""2023-06-18T15:00:00+00:00"",
                                ""data_sources"": [
                                {
                                    ""data_source_id"": ""0d8c63cb-69f0-4b87-baed-b11d6bca9abf"",
                                    ""organization_name"": ""Test City 1"",
                                    ""update_date"": ""2023-06-18T14:37:31+00:00"",
                                    ""update_frequency"": 300,
                                    ""contact_name"": ""Solomn Soliel Sourcefeed"",
                                    ""contact_email"": ""solomon.sourcefeed@testcity1.gov""
                                }
                            ],
                            ""update_frequency"": 60,
                            ""contact_name"": ""Frederick Francis Feedmanager"",
                            ""contact_email"": ""fred.feedmanager@testdot.gov"",
                            ""license"": ""https://creativecommons.org/publicdomain/zero/1.0/""
                        },
                        ""features"": [
                            {
                                ""id"": ""3b46c53d-24a2-46e9-be73-f0d1165dfb3b"",
                                ""properties"": {
                                    ""core_details"": {
                                        ""device_type"": ""arrow-board"",
                                        ""data_source_id"": ""0d8c63cb-69f0-4b87-baed-b11d6bca9abf"",
                                        ""device_status"": ""ok"",
                                        ""update_date"": ""2023-06-18T14:37:31+00:00"",
                                        ""has_automatic_location"": true,
                                        ""road_names"": [
                                            ""I-80""
                                        ],
                                        ""road_direction"": ""northbound"",
                                        ""name"": ""Arrow Board 1"",
                                        ""description"": ""An arrow board for testing"",
                                        ""milepost"": 15.1,
                                        ""status_messages"": [
                                            ""Arrow board is operational.""
                                        ],
                                        ""is_moving"": false,
                                        ""road_event_ids"": [
                                            ""1f334f6b-14ad-4123-b92d-9d4a7e416629""
                                        ],
                                        ""make"": ""Ver-Mac"",
                                        ""model"": ""AB-1"",
                                        ""serial_number"": ""1234567890"",
                                        ""firmware_version"": ""1.0.0""
                                    },
                                    ""pattern"": ""right-arrow-flashing"",
                                    ""is_moving"": false,
                                    ""is_in_transport_position"": true
                                },
                                ""geometry"": {
                                    ""type"": ""Point"",
                                    ""coordinates"": [
                                        -93.77668405099996,
                                        41.617961698000045
                                    ]
                                },
                                ""type"": ""Feature""
                            },
                            {
                                ""id"": ""395fff35-46c5-41d9-acdd-85dc5bd3cba8"",
                                ""properties"": {
                                    ""core_details"": {
                                        ""device_type"": ""camera"",
                                        ""data_source_id"": ""4f880fce-2dd1-4d29-9676-b2152fce1336"",
                                        ""device_status"": ""warning"",
                                        ""update_date"": ""2024-06-18T14:37:31+00:00"",
                                        ""has_automatic_location"": true
                                    },
                                    ""image_url"": ""https://test.com/image.jpg"",
                                    ""image_timestamp"": ""2024-06-18T14:37:10+00:00""
                                },
                                ""geometry"": {
                                    ""type"": ""Point"",
                                    ""coordinates"": [
                                        -93.77667436599995,
                                        41.62032278300006
                                    ]
                                },
                                ""type"": ""Feature""
                            },
                            {
                                ""id"": ""395fff35-46c5-41d9-acdd-85dc5bd3cba8"",
                                ""properties"": {
                                    ""core_details"": {
                                        ""device_type"": ""dynamic-message-sign"",
                                        ""data_source_id"": ""4f880fce-2dd1-4d29-9676-b2152fce1336"",
                                        ""device_status"": ""error"",
                                        ""update_date"": ""2024-06-18T14:37:31+00:00"",
                                        ""has_automatic_location"": false
                                    },
                                    ""message_multi_string"": ""I-90 WB[nl]TRAFFIC[nl]BACKUPS[np]PLEASE[nl]USE[nl]CAUTION""
                                },
                                ""geometry"": {
                                    ""type"": ""Point"",
                                    ""coordinates"": [
                                        -93.77667436599995,
                                        41.62032278300006
                                    ]
                                },
                                ""type"": ""Feature""
                            },
                            {
                                ""id"": ""395fff35-46c5-41d9-acdd-85dc5bd3cba8"",
                                ""properties"": {
                                    ""core_details"": {
                                        ""device_type"": ""flashing-beacon"",
                                        ""data_source_id"": ""4f880fce-2dd1-4d29-9676-b2152fce1336"",
                                        ""device_status"": ""error"",
                                        ""update_date"": ""2024-06-18T14:37:31+00:00"",
                                        ""has_automatic_location"": false
                                    },
                                    ""function"": ""reduced-speed"",
                                    ""is_flashing"": true,
                                    ""sign_text"": ""SPEED LIMIT 50 MPH""
                                },
                                ""geometry"": {
                                    ""type"": ""Point"",
                                    ""coordinates"": [
                                        -93.77667436599995,
                                        41.62032278300006
                                    ]
                                },
                                ""type"": ""Feature""
                            },
                            {
                                ""id"": ""395fff35-46c5-41d9-acdd-85dc5bd3cba8"",
                                ""properties"": {
                                    ""core_details"": {
                                        ""device_type"": ""hybrid-sign"",
                                        ""data_source_id"": ""4f880fce-2dd1-4d29-9676-b2152fce1336"",
                                        ""device_status"": ""ok"",
                                        ""update_date"": ""2024-06-18T14:37:31+00:00"",
                                        ""has_automatic_location"": true
                                    },
                                    ""dynamic_message_function"": ""speed-limit"",
                                    ""dynamic_message_text"": ""50"",
                                    ""static_sign_text"": ""SPEED LIMIT""
                                },
                                ""geometry"": {
                                    ""type"": ""Point"",
                                    ""coordinates"": [
                                        -93.77667436599995,
                                        41.62032278300006
                                    ]
                                },
                                ""type"": ""Feature""
                            },
                            {
                                ""id"": ""395fff35-46c5-41d9-acdd-85dc5bd3cba8"",
                                ""properties"": {
                                    ""core_details"": {
                                        ""device_type"": ""location-marker"",
                                        ""data_source_id"": ""4f880fce-2dd1-4d29-9676-b2152fce1336"",
                                        ""device_status"": ""ok"",
                                        ""update_date"": ""2024-06-18T14:37:31+00:00"",
                                        ""has_automatic_location"": true
                                    },
                                    ""marked_locations"": [
                                        {
                                            ""type"": ""work-zone-start"",
                                            ""road_event_id"": ""395fff35-46aa-41d9-acdd-85dc5bd3cba8""
                                        }
                                    ]
                                },
                                ""geometry"": {
                                    ""type"": ""Point"",
                                    ""coordinates"": [
                                        -93.77667436599995,
                                        41.62032278300006
                                    ]
                                },
                                ""type"": ""Feature""
                            },
                            {
                                ""id"": ""395fff35-46c5-41d9-acdd-85dc5bd3cba8"",
                                ""properties"": {
                                    ""core_details"": {
                                        ""device_type"": ""traffic-sensor"",
                                        ""data_source_id"": ""4f880fce-2dd1-4d29-9676-b2152fce1336"",
                                        ""device_status"": ""ok"",
                                        ""update_date"": ""2024-06-18T14:37:31+00:00"",
                                        ""has_automatic_location"": true
                                    },
                                    ""collection_interval_start_date"": ""2024-06-18T14:36:00+00:00"",
                                    ""collection_interval_end_date"": ""2024-06-18T14:37:00+00:00"",
                                    ""average_speed_kph"": 89.4,
                                    ""volume_vph"": 2300,
                                    ""occupancy_percent"": 5.22,
                                    ""lane_data"": [
                                        {
                                            ""lane_order"": 1,
                                            ""road_event_id"": ""395fff35-46c5-41d9-acdd-85dc5bd3cba8"",
                                            ""average_speed_kph"": 89.4,
                                            ""volume_vph"": 2300,
                                            ""occupancy_percent"": 5.22
                                        }
                                    ]
                                },
                                ""geometry"": {
                                    ""type"": ""Point"",
                                    ""coordinates"": [
                                        -93.77667436599995,
                                        41.62032278300006
                                    ]
                                },
                                ""type"": ""Feature""
                            },
                            {
                                ""id"": ""395fff35-46c5-41d9-acdd-85dc5bd3cba8"",
                                ""properties"": {
                                    ""core_details"": {
                                        ""device_type"": ""traffic-signal"",
                                        ""data_source_id"": ""4f880fce-2dd1-4d29-9676-b2152fce1336"",
                                        ""device_status"": ""ok"",
                                        ""update_date"": ""2024-06-18T14:37:31+00:00"",
                                        ""has_automatic_location"": true
                                    },
                                    ""mode"": ""pre-timed""
                                },
                                ""geometry"": {
                                    ""type"": ""Point"",
                                    ""coordinates"": [
                                        -93.77667436599995,
                                        41.62032278300006
                                    ]
                                },
                                ""type"": ""Feature""
                            }
                        ],
                        ""type"": ""FeatureCollection""
                    }
                    "
                }
            };

        private static string _testValidDeviceFeed = @"
            {
                ""feed_info"": {
                    ""update_date"": ""2021-12-06T15:00:00Z"",
                    ""publisher"": ""TestVendor"",
                    ""contact_name"": ""Robert Vendor"",
                    ""contact_email"": ""robert.vendor@testvendor.com"",
                    ""update_frequency"": 60,
                    ""version"": ""4.0"",
                    ""license"": ""https://creativecommons.org/publicdomain/zero/1.0/"",
                    ""data_sources"": [
                        {
                            ""data_source_id"": ""ff55b721-bd18-4c21-8ad7-1b31fdddd876"",
                            ""organization_name"": ""Test Vendor Inc."",
                            ""contact_name"": ""Timmy Testor"",
                            ""contact_email"": ""timmy.testor@testvendor.com"",
                            ""update_frequency"": 60,
                            ""update_date"": ""2021-12-06T14:54:12Z""
                        }
                    ]
                },
                ""type"": ""FeatureCollection"",
                ""features"": [
                    {
                        ""id"": ""280258a2-d131-4d8d-b5a7-2cef813b25a8"",
                        ""type"": ""Feature"",
                        ""properties"": {
                            ""core_details"": {
                                ""device_type"": ""arrow-board"",
                                ""data_source_id"": ""ff55b721-bd18-4c21-8ad7-1b31fdddd876"",
                                ""road_names"": [
                                    ""I-80"",
                                    ""I-35""
                                ],
                                ""device_status"": ""ok"",
                                ""has_automatic_location"": true,
                                ""name"": ""Arrow Board 1"",
                                ""update_date"": ""2021-12-06T14:54:12Z""
                            },
                            ""pattern"": ""right-arrow-flashing"",
                            ""is_moving"": false,
                            ""is_in_transport_position"": false
                        },
                        ""geometry"": {
                            ""type"": ""Point"",
                            ""coordinates"": [
                                -93.776684050999961,
                                41.617961698000045
                            ]
                        }
                    }
                ]
            }";
    }

    /// <summary>
    /// Tests for <see cref="WorkZoneFeed"/>s.
    /// </summary>
    public class WorkZoneFeedTests
    {
        [Fact]
        public void DeserializeFeed_JsonNotValid_ThrowsJsonException()
        {
            DeserializeFeed_JsonNotValid_ThrowsJsonException<WorkZoneFeed>();
        }

        [Fact]
        public void DeserializeFeed_JsonValid_DoesNotThrowException()
        {
            var action = () => WzdxSerializer.DeserializeFeed<WorkZoneFeed>(_testValidWorkZoneFeedWithoutDetours);

            var exception = Record.Exception(action);

            Assert.Null(exception);
        }

        [Fact]
        public void DeserializeFeed_IncludesDetours_DoesNotThrowException()
        {
            var action = () => WzdxSerializer.DeserializeFeed<WorkZoneFeed>(_testValidWorkZoneFeedWithDetours);

            var exception = Record.Exception(action);

            Assert.Null(exception);
        }

        [Fact]
        public void DeserializeFeed_IncludesDetours_DetourFeaturePropertiesIsNull()
        {
            WorkZoneFeed actualFeedObject = WzdxSerializer.DeserializeFeed<WorkZoneFeed>(_testValidWorkZoneFeedWithDetours);

            Assert.Null(actualFeedObject.Features.First().Properties);
        }

        [Theory]
        [MemberData(nameof(WorkZoneFeedEquivalentRepresentations))]
        public void DeserializeFeed_FeedObjectEqualsExpected(
            WorkZoneFeed expectedFeedObject,
            string feedJson
            )
        {
            WorkZoneFeed actualFeedObject = WzdxSerializer.DeserializeFeed<WorkZoneFeed>(feedJson);

            Assert.Equal(expectedFeedObject, actualFeedObject);
        }

        [Theory]
        [MemberData(nameof(WorkZoneFeedEquivalentRepresentations))]
        public void SerializeFeed_FeedJsonEqualsExpected(
            WorkZoneFeed feedObject,
            string expectedFeedJson
            )
        {
            string actualFeedJson = WzdxSerializer.SerializeFeed(feedObject);

            string expectedFeedJsonWithoutWhitespace = new string(
                expectedFeedJson.Where(c => !Char.IsWhiteSpace(c)).ToArray()
                );
            string actualFeedJsonWithoutWhitespace = new string(
                actualFeedJson.Where(c => !Char.IsWhiteSpace(c)).ToArray()
                );

            Assert.Equal(expectedFeedJsonWithoutWhitespace, actualFeedJsonWithoutWhitespace);
        }

        /// <summary>
        /// A collection of pairs of WZDx Work Zone Feeds as <see cref="WorkZoneFeed"/> objects and
        /// their equivalent JSON representations.
        /// </summary>
        public static IEnumerable<object[]> WorkZoneFeedEquivalentRepresentations =>
            new List<object[]>
            {
                // This test case includes all optional fields except Bbox.
                new object[]
                {
                    new WorkZoneFeed(
                        FeedInfo: new FeedInfo(
                            UpdateDate: new DateTimeOffset(2023, 6, 18, 15, 0, 0, TimeSpan.Zero),
                            Publisher: "TestDOT",
                            Version: "4.1",
                            ContactName: "Frederick Francis Feedmanager",
                            ContactEmail: "fred.feedmanager@testdot.gov",
                            UpdateFrequency: 60,
                            DataSources: new FeedDataSource[]
                            {
                                new FeedDataSource(
                                    DataSourceId: "ef96bc81-3249-495a-aa54-68c5b417cceb",
                                    OrganizationName: "Test City 1",
                                    ContactName: "Solomn Soliel Sourcefeed",
                                    ContactEmail: "solomon.sourcefeed@testcity1.gov",
                                    UpdateFrequency: 300,
                                    UpdateDate: new DateTimeOffset(2023, 6, 18, 14, 37, 31, TimeSpan.Zero)
                                    )
                            }
                            ),
                        Features: new RoadEventFeature[]
                        {
                            new RoadEventFeature(
                                Id: "4fee99c9-e138-4a21-87ba-297ca22234ab",
                                Properties: new WorkZoneRoadEvent(
                                    CoreDetails: new RoadEventCoreDetails(
                                        EventType: EventType.WorkZone,
                                        DataSourceId: "ef96bc81-3249-495a-aa54-68c5b417cceb",
                                        RoadNames: new string[] { "I-80", "I-35"},
                                        Direction: RoadDirection.Northbound,
                                        Name: "Work Zone 1",
                                        RelatedRoadEvents: new RelatedRoadEvent[]
                                        {
                                            new RelatedRoadEvent(
                                                Id: "6db3aa76-8851-4e09-af28-cc81d58cd848",
                                                Type: RelatedRoadEventType.NextInSequence
                                                ),
                                            new RelatedRoadEvent(
                                                Id: "8739c2c3-8f46-421c-843b-2464fc00bf0b",
                                                Type: RelatedRoadEventType.RelatedDetour
                                                )
                                        },
                                        Description: "Single direction work zone with lane-level information.",
                                        CreationDate: new DateTimeOffset(2023, 6, 17, 18, 0, 0, TimeSpan.Zero),
                                        UpdateDate: new DateTimeOffset(2023, 6, 18, 14, 37, 31, TimeSpan.Zero),
                                        Relationship: new Relationship(
                                            First: new string[] { "4fee99c9-e138-4a21-87ba-297ca22234ab" },
                                            Next: new string[] { "6db3aa76-8851-4e09-af28-cc81d58cd848" },
                                            Parents: new string[] { "Parent Project" },
                                            Children: new string[] { "8739c2c3-8f46-421c-843b-2464fc00bf0b" }
                                            )
                                        ),
                                    StartDate: new DateTimeOffset(2023, 6, 19, 7, 0, 0, TimeSpan.Zero),
                                    EndDate: new DateTimeOffset(2023, 6, 19, 19, 0, 0, TimeSpan.Zero),
                                    VehicleImpact: VehicleImpact.SomeLanesClosed,
                                    LocationMethod: LocationMethod.ChannelDeviceMethod,
                                    IsStartDateVerified: false,
                                    IsEndDateVerified: false,
                                    StartDateAccuracy: TimeVerification.Estimated,
                                    EndDateAccuracy: TimeVerification.Estimated,
                                    IsStartPositionVerified: true,
                                    IsEndPositionVerified: true,
                                    BeginningAccuracy: SpatialVerification.Estimated,
                                    EndingAccuracy: SpatialVerification.Estimated,
                                    Lanes: new Lane[]
                                    {
                                        new Lane(
                                            Order: 1,
                                            Type: LaneType.General,
                                            Status: LaneStatus.Open,
                                            Restrictions: new Restriction[]
                                            {
                                                new Restriction(
                                                    Type: RestrictionType.ReducedWidth,
                                                    Value: 10,
                                                    Unit: UnitOfMeasurement.Feet
                                                    )
                                            }
                                            ),
                                        new Lane(
                                            Order: 2,
                                            Type: LaneType.General,
                                            Status: LaneStatus.Closed
                                            )
                                    },
                                    BeginningCrossStreet: "Main Street",
                                    EndingCrossStreet: "First Street",
                                    BeginningMilepost: 125.2,
                                    EndingMilepost: 126.3,
                                    EventStatus: EventStatus.Active,
                                    TypesOfWork: new TypeOfWork[]
                                    {
                                        new TypeOfWork(WorkTypeName.Maintenance),
                                    },
                                    WorkerPresence: new WorkerPresence(
                                        AreWorkersPresent: false,
                                        Definition: new WorkerPresenceDefinition[]
                                        {
                                            WorkerPresenceDefinition.WorkersInWorkZoneWorking,
                                            WorkerPresenceDefinition.WorkersInWorkZoneNotWorking
                                        },
                                        Method: WorkerPresenceMethod.CameraMonitoring,
                                        WorkerPresenceLastConfirmedDate: new DateTimeOffset(
                                            2023, 6, 18, 14, 30, 25, TimeSpan.Zero
                                            ),
                                        Confidence: WorkerPresenceConfidence.High
                                        ),
                                    ReducedSpeedLimitKph: 88.514,
                                    Restrictions: new Restriction[]
                                    {
                                        new Restriction(RestrictionType.NoTrucks)
                                    }
                                    ),
                                Geometry: new RoadEventFeatureGeometry(
                                    Type: RoadEventFeatureGeometryType.LineString,
                                    Coordinates: new double[][] {
                                        new double[]
                                        {
                                            -93.77668405099996,
                                            41.617961698000045
                                        },
                                        new double[]
                                        {
                                            -93.776682957,
                                            41.61824496200006
                                        },
                                        new double[]
                                        {
                                            -93.77667737299998,
                                            41.61960336200008
                                        },
                                        new double[]
                                        {
                                            -93.77667436599995,
                                            41.62032278300006
                                        },
                                        new double[]
                                        {
                                            -93.77667174199996,
                                            41.62095032100007
                                        },
                                        new double[]
                                        {
                                            -93.77668897499996,
                                            41.62229722600006
                                        }
                                    }
                                    )
                                )
                        }
                        ),
                    @"
                    {
                        ""feed_info"": {
                            ""publisher"": ""TestDOT"",
                            ""version"": ""4.1"",
                            ""update_date"": ""2023-06-18T15:00:00+00:00"",
                                ""data_sources"": [
                                {
                                    ""data_source_id"": ""ef96bc81-3249-495a-aa54-68c5b417cceb"",
                                    ""organization_name"": ""Test City 1"",
                                    ""update_date"": ""2023-06-18T14:37:31+00:00"",
                                    ""update_frequency"": 300,
                                    ""contact_name"": ""Solomn Soliel Sourcefeed"",
                                    ""contact_email"": ""solomon.sourcefeed@testcity1.gov""
                                }
                            ],
                            ""update_frequency"": 60,
                            ""contact_name"": ""Frederick Francis Feedmanager"",
                            ""contact_email"": ""fred.feedmanager@testdot.gov"",
                            ""license"": ""https://creativecommons.org/publicdomain/zero/1.0/""
                        },
                        ""features"": [
                            {
                                ""id"": ""4fee99c9-e138-4a21-87ba-297ca22234ab"",
                                ""properties"": {
                                    ""core_details"": {
                                        ""event_type"": ""work-zone"",
                                        ""data_source_id"": ""ef96bc81-3249-495a-aa54-68c5b417cceb"",
                                        ""road_names"": [
                                            ""I-80"",
                                            ""I-35""
                                        ],
                                        ""direction"": ""northbound"",
                                        ""name"": ""Work Zone 1"",
                                        ""related_road_events"": [
                                            {
                                                ""type"": ""next-in-sequence"",
                                                ""id"": ""6db3aa76-8851-4e09-af28-cc81d58cd848""
                                            },
                                            {
                                                ""type"": ""related-detour"",
                                                ""id"": ""8739c2c3-8f46-421c-843b-2464fc00bf0b""
                                            }
                                        ],
                                        ""description"": ""Single direction work zone with lane-level information."",
                                        ""creation_date"": ""2023-06-17T18:00:00+00:00"",
                                        ""update_date"": ""2023-06-18T14:37:31+00:00"",
                                        ""relationship"": {
                                            ""first"": [
                                                ""4fee99c9-e138-4a21-87ba-297ca22234ab""
                                            ],
                                            ""next"": [
                                                ""6db3aa76-8851-4e09-af28-cc81d58cd848""
                                            ],
                                            ""parents"": [
                                                ""Parent Project""
                                            ],
                                            ""children"": [
                                                ""8739c2c3-8f46-421c-843b-2464fc00bf0b""
                                            ]
                                        }
                                    },
                                    ""start_date"": ""2023-06-19T07:00:00+00:00"",
                                    ""end_date"": ""2023-06-19T19:00:00+00:00"",
                                    ""location_method"": ""channel-device-method"",
                                    ""vehicle_impact"": ""some-lanes-closed"",
                                    ""is_start_date_verified"": false,
                                    ""is_end_date_verified"": false,
                                    ""start_date_accuracy"": ""estimated"",
                                    ""end_date_accuracy"": ""estimated"",
                                    ""is_start_position_verified"": true,
                                    ""is_end_position_verified"": true,
                                    ""beginning_accuracy"": ""estimated"",
                                    ""ending_accuracy"": ""estimated"",
                                    ""lanes"": [
                                        {
                                            ""order"": 1,
                                            ""type"": ""general"",
                                            ""status"": ""open"",
                                            ""restrictions"": [
                                                {
                                                    ""type"": ""reduced-width"",
                                                    ""value"": 10,
                                                    ""unit"": ""feet""
                                                }
                                            ]
                                        },
                                        {
                                            ""order"": 2,
                                            ""type"": ""general"",
                                            ""status"": ""closed""
                                        }
                                    ],
                                    ""beginning_cross_street"": ""Main Street"",
                                    ""ending_cross_street"": ""First Street"",
                                    ""beginning_milepost"": 125.2,
                                    ""ending_milepost"": 126.3,
                                    ""event_status"": ""active"",
                                    ""types_of_work"": [
                                        {
                                            ""type_name"": ""maintenance"" 
                                        }
                                    ],
                                    ""worker_presence"": {
                                        ""are_workers_present"": false,
                                        ""definition"": [
                                            ""workers-in-work-zone-working"",
                                            ""workers-in-work-zone-not-working""
                                        ],
                                        ""method"": ""camera-monitoring"",
                                        ""worker_presence_last_confirmed_date"": ""2023-06-18T14:30:25+00:00"",
                                        ""confidence"": ""high""
                                    },
                                    ""reduced_speed_limit_kph"": 88.514,
                                    ""restrictions"": [
                                        {
                                            ""type"": ""no-trucks""
                                        }
                                    ]
                                },
                                ""geometry"": {
                                    ""type"": ""LineString"",
                                    ""coordinates"": [
                                        [
                                            -93.77668405099996,
                                            41.617961698000045
                                        ],
                                        [
                                            -93.776682957,
                                            41.61824496200006
                                        ],
                                        [
                                            -93.77667737299998,
                                            41.61960336200008
                                        ],
                                        [
                                            -93.77667436599995,
                                            41.62032278300006
                                        ],
                                        [
                                            -93.77667174199996,
                                            41.62095032100007
                                        ],
                                        [
                                            -93.77668897499996,
                                            41.62229722600006
                                        ]
                                    ]
                                },
                                ""type"": ""Feature""
                            }
                        ],
                        ""type"": ""FeatureCollection""
                    }
                    "
                }
            };

        private static string _testValidWorkZoneFeedWithoutDetours = @"
            {
                ""feed_info"": {
                    ""update_date"": ""2020-06-18T15:00:00Z"",
                    ""publisher"": ""TestDOT"",
                    ""contact_name"": ""Frederick Francis Feedmanager"",
                    ""contact_email"": ""fred.feedmanager@testdot.gov"",
                    ""update_frequency"": 60,
                    ""version"": ""4.0"",
                    ""license"": ""https://creativecommons.org/publicdomain/zero/1.0/"",
                    ""data_sources"": [
                        {
                            ""data_source_id"": ""1"",
                            ""organization_name"": ""Test City 1"",
                            ""contact_name"": ""Solomn Soliel Sourcefeed"",
                            ""contact_email"": ""solomon.sourcefeed@testcity1.gov"",
                            ""update_frequency"": 300,
                            ""update_date"": ""2020-06-18T14:37:31Z""
                        },
                        {
                            ""data_source_id"": ""2"",
                            ""organization_name"": ""TestDOT"",
                            ""contact_name"": ""Samuel Sonny Sourcefeed"",
                            ""contact_email"": ""samuel.sourcefeed@testdot.gov"",
                            ""update_frequency"": 60,
                            ""update_date"": ""2020-06-18T14:39:01Z""
                        }
                    ]
                },
                ""type"": ""FeatureCollection"",
                ""features"": [
                    {
                        ""id"": ""71234"",
                        ""type"": ""Feature"",
                        ""properties"": {
                            ""core_details"": {
                            ""data_source_id"": ""1"",
                            ""event_type"": ""work-zone"",
                            ""road_names"": [
                                ""I-80"",
                                ""I-35""
                            ],
                            ""direction"": ""northbound"",
                            ""description"": ""Single direction work zone without lane-level information."",
                            ""creation_date"": ""2009-12-31T18:01:01Z"",
                            ""update_date"": ""2009-12-31T18:01:01Z""
                            },
                            ""beginning_milepost"": 125.2,
                            ""ending_milepost"": 126.3,
                            ""beginning_accuracy"": ""estimated"",
                            ""ending_accuracy"": ""estimated"",
                            ""start_date"": ""2010-01-01T01:00:00Z"",
                            ""end_date"": ""2010-01-02T01:00:00Z"",
                            ""location_method"": ""channel-device-method"",
                            ""start_date_accuracy"": ""estimated"",
                            ""end_date_accuracy"": ""estimated"",
                            ""event_status"": ""active"",
                            ""vehicle_impact"": ""some-lanes-closed"",
                            ""reduced_speed_limit_kph"": 88.514
                        },
                        ""geometry"": {
                            ""type"": ""LineString"",
                            ""coordinates"": [
                                [
                                    -93.776684050999961,
                                    41.617961698000045
                                ],
                                [
                                    -93.776682957,
                                    41.618244962000063
                                ],
                                [
                                    -93.776677372999984,
                                    41.619603362000078
                                ],
                                [
                                    -93.776674365999952,
                                    41.620322783000063
                                ],
                                [
                                    -93.776671741999962,
                                    41.620950321000066
                                ],
                                [
                                    -93.776688974999956,
                                    41.622297226000057
                                ]
                            ]
                        }
                    },
                    {
                        ""id"": ""WDM-58493-NB"",
                        ""type"": ""Feature"",
                        ""properties"": {
                            ""core_details"": {
                            ""data_source_id"": ""1"",
                            ""event_type"": ""work-zone"",
                            ""road_names"": [
                                ""128th Street""
                            ],
                            ""direction"": ""northbound"",
                            ""description"": ""Single direction work zone with detailed lane-level information. Also includes additional details in vehicle impact"",
                            ""creation_date"": ""2009-12-13T13:35:26Z"",
                            ""update_date"": ""2009-12-31T15:11:16Z""
                            },
                            ""beginning_cross_street"": ""US 6, Hickman Road"",
                            ""ending_cross_street"": ""Douglas Ave"",
                            ""beginning_accuracy"": ""estimated"",
                            ""ending_accuracy"": ""estimated"",
                            ""start_date"": ""2010-01-01T06:00:00Z"",
                            ""end_date"": ""2010-05-01T05:00:00Z"",
                            ""location_method"": ""channel-device-method"",
                            ""start_date_accuracy"": ""estimated"",
                            ""end_date_accuracy"": ""estimated"",
                            ""event_status"": ""active"",
                            ""vehicle_impact"": ""some-lanes-closed-merge-left"",
                            ""lanes"": [
                            {
                                ""order"": 1,
                                ""status"": ""open"",
                                ""type"": ""general"",
                                ""restrictions"": [
                                    {
                                        ""type"": ""reduced-width"",
                                        ""value"": 10,
                                        ""unit"": ""feet""
                                    }
                                ]
                            },
                            {
                                ""order"": 2,
                                ""status"": ""closed"",
                                ""type"": ""general""
                            }
                            ]
                        },
                        ""geometry"": {
                            ""type"": ""LineString"",
                            ""coordinates"": [
                            [
                                -93.791522243999964,
                                41.614948252000033
                            ],
                            [
                                -93.791505319999942,
                                41.61501428300005
                            ],
                            [
                                -93.791405791999978,
                                41.615577076000079
                            ],
                            [
                                -93.791345430999968,
                                41.615782444000047
                            ],
                            [
                                -93.791280304999987,
                                41.615977213000065
                            ],
                            [
                                -93.791200891999949,
                                41.616140173000076
                            ],
                            [
                                -93.791079009999976,
                                41.616296165000051
                            ],
                            [
                                -93.790558010999973,
                                41.61681760700003
                            ],
                            [
                                -93.790135601999964,
                                41.617246805000036
                            ],
                            [
                                -93.789830552999945,
                                41.617562480000061
                            ],
                            [
                                -93.789680613999963,
                                41.617771613000059
                            ],
                            [
                                -93.789596382999946,
                                41.617913356000031
                            ],
                            [
                                -93.789502863999985,
                                41.618086964000042
                            ],
                            [
                                -93.78945179699997,
                                41.618264005000071
                            ],
                            [
                                -93.789424159999953,
                                41.61840914000004
                            ],
                            [
                                -93.789414473999955,
                                41.618523310000057
                            ],
                            [
                                -93.789406687999985,
                                41.618788623000057
                            ],
                            [
                                -93.789440425999942,
                                41.620294861000048
                            ],
                            [
                                -93.789441241999953,
                                41.620405535000032
                            ],
                            [
                                -93.789449826999942,
                                41.620516022000061
                            ],
                            [
                                -93.789466157999982,
                                41.620626017000063
                            ],
                            [
                                -93.78949019099997,
                                41.620735214000035
                            ],
                            [
                                -93.789521855999965,
                                41.62084330700003
                            ],
                            [
                                -93.78956107,
                                41.62095
                            ],
                            [
                                -93.789607718999946,
                                41.621054995000065
                            ],
                            [
                                -93.789661678999948,
                                41.621157998000058
                            ],
                            [
                                -93.789725124999961,
                                41.621262305000073
                            ],
                            [
                                -93.789796062999983,
                                41.621363857000063
                            ],
                            [
                                -93.789874285999986,
                                41.621462354000073
                            ],
                            [
                                -93.789959554999939,
                                41.621557500000051
                            ],
                            [
                                -93.790051618999939,
                                41.621649010000056
                            ],
                            [
                                -93.790150204999975,
                                41.621736613000053
                            ],
                            [
                                -93.790255013999968,
                                41.621820048000075
                            ],
                            [
                                -93.790365738,
                                41.621899067000072
                            ],
                            [
                                -93.790482044999976,
                                41.621973433000051
                            ],
                            [
                                -93.790603584999985,
                                41.622042923000038
                            ],
                            [
                                -93.790730001999975,
                                41.622107331000052
                            ],
                            [
                                -93.790860916999975,
                                41.622166468000046
                            ],
                            [
                                -93.791037923999966,
                                41.622265540000058
                            ],
                            [
                                -93.791219643999966,
                                41.622359685000049
                            ],
                            [
                                -93.791405833999988,
                                41.622448775000066
                            ],
                            [
                                -93.791596247999962,
                                41.62253269200005
                            ],
                            [
                                -93.791974661999973,
                                41.622789772000033
                            ],
                            [
                                -93.792348386999947,
                                41.623050684000077
                            ],
                            [
                                -93.79264079099994,
                                41.62326022700006
                            ],
                            [
                                -93.793051083999956,
                                41.623588822000045
                            ],
                            [
                                -93.793245118999948,
                                41.623807143000079
                            ],
                            [
                                -93.793416509999986,
                                41.62403972900006
                            ],
                            [
                                -93.793538291999937,
                                41.62424188500006
                            ],
                            [
                                -93.793626206999988,
                                41.624429215000077
                            ],
                            [
                                -93.793710504999979,
                                41.624653499000033
                            ],
                            [
                                -93.793764538999937,
                                41.624880703000031
                            ],
                            [
                                -93.793784475999985,
                                41.62510231300007
                            ],
                            [
                                -93.793785748999937,
                                41.625380807000056
                            ],
                            [
                                -93.793738188999953,
                                41.625670969000055
                            ],
                            [
                                -93.793679893999979,
                                41.625937897000028
                            ],
                            [
                                -93.793612129999985,
                                41.626248174000068
                            ],
                            [
                                -93.793525080999984,
                                41.626631768000038
                            ],
                            [
                                -93.793438316999982,
                                41.626965183000038
                            ],
                            [
                                -93.793363929999941,
                                41.627301995000039
                            ],
                            [
                                -93.793344298999955,
                                41.627537681000035
                            ],
                            [
                                -93.793345492999947,
                                41.627799206000077
                            ],
                            [
                                -93.793356849999952,
                                41.628019275000042
                            ],
                            [
                                -93.793396009,
                                41.62828070300003
                            ],
                            [
                                -93.79347973299997,
                                41.628577397000072
                            ]
                            ]
                        }
                    },
                    {
                        ""id"": ""65773-1"",
                        ""type"": ""Feature"",
                        ""properties"": {
                            ""core_details"": {
                            ""data_source_id"": ""2"",
                            ""event_type"": ""work-zone"",
                            ""relationship"": {
                                ""parents"": [
                                    ""65773""
                                ],
                                ""first"": [
                                    ""65773-1""
                                ],
                                ""next"": [
                                    ""65773-2""
                                ]
                            },
                            ""road_names"": [
                                ""I-235""
                            ],
                            ""direction"": ""westbound"",
                            ""description"": ""Single-direction work zone represented by three sequential road events; first event."",
                            ""creation_date"": ""2009-12-31T11:56:26Z"",
                            ""update_date"": ""2009-12-31T11:56:26Z""
                            },
                            ""beginning_milepost"": 3.1,
                            ""ending_milepost"": 2.9,
                            ""beginning_accuracy"": ""estimated"",
                            ""ending_accuracy"": ""estimated"",
                            ""start_date"": ""2010-01-01T14:00:00Z"",
                            ""end_date"": ""2010-01-05T23:00:00Z"",
                            ""location_method"": ""channel-device-method"",
                            ""start_date_accuracy"": ""estimated"",
                            ""end_date_accuracy"": ""estimated"",
                            ""event_status"": ""active"",
                            ""vehicle_impact"": ""some-lanes-closed"",
                            ""worker_presence"": {
                            ""are_workers_present"": false,
                            ""definition"": [
                                ""humans-in-right-of-way""
                            ]
                            },
                            ""reduced_speed_limit_kph"": 88.514,
                            ""restrictions"": [],
                            ""types_of_work"": [
                            {
                                ""type_name"": ""surface-work"",
                                ""is_architectural_change"": true
                            }
                            ],
                            ""lanes"": [
                            {
                                ""order"": 1,
                                ""status"": ""closed"",
                                ""type"": ""shoulder""
                            },
                            {
                                ""order"": 2,
                                ""status"": ""closed"",
                                ""type"": ""general""
                            },
                            {
                                ""order"": 3,
                                ""status"": ""open"",
                                ""type"": ""general""
                            },
                            {
                                ""order"": 4,
                                ""status"": ""open"",
                                ""type"": ""general""
                            },
                            {
                                ""order"": 5,
                                ""status"": ""open"",
                                ""type"": ""entrance-lane""
                            },
                            {
                                ""order"": 6,
                                ""status"": ""open"",
                                ""type"": ""shoulder""
                            }
                            ]
                        },
                        ""geometry"": {
                            ""type"": ""LineString"",
                            ""coordinates"": [
                            [
                                -93.720409507999989,
                                41.593422456000042
                            ],
                            [
                                -93.721987662999936,
                                41.593428462000077
                            ],
                            [
                                -93.724060080999948,
                                41.593444666000039
                            ],
                            [
                                -93.724769801999969,
                                41.593457451000063
                            ]
                            ]
                        }
                    },
                    {
                        ""id"": ""65773-2"",
                        ""type"": ""Feature"",
                        ""properties"": {
                            ""core_details"": {
                            ""data_source_id"": ""2"",
                            ""event_type"": ""work-zone"",
                            ""relationship"": {
                                ""parents"": [
                                    ""65773""
                                ],
                                ""first"": [
                                    ""65773-1""
                                ],
                                ""next"": [
                                    ""65773-3""
                                ]
                            },
                            ""road_names"": [
                                ""I-235""
                            ],
                            ""direction"": ""westbound"",
                            ""description"": ""Single-direction work zone represented by three sequential road events; second event."",
                            ""creation_date"": ""2009-12-31T11:56:26Z"",
                            ""update_date"": ""2009-12-31T11:56:26Z""
                            },
                            ""beginning_milepost"": 2.9,
                            ""ending_milepost"": 2.5,
                            ""beginning_accuracy"": ""estimated"",
                            ""ending_accuracy"": ""estimated"",
                            ""start_date"": ""2010-01-01T14:00:00Z"",
                            ""end_date"": ""2010-01-05T23:00:00Z"",
                            ""location_method"": ""channel-device-method"",
                            ""start_date_accuracy"": ""estimated"",
                            ""end_date_accuracy"": ""estimated"",
                            ""event_status"": ""active"",
                            ""vehicle_impact"": ""some-lanes-closed"",
                            ""worker_presence"": {
                            ""are_workers_present"": true,
                            ""method"": ""check-in-app"",
                            ""worker_presence_last_confirmed_date"": ""2010-01-04T15:00:00Z"",
                            ""confidence"": ""high"",
                            ""definition"": [
                                ""humans-in-right-of-way""
                            ]
                            },
                            ""reduced_speed_limit_kph"": 88.514,
                            ""restrictions"": [],
                            ""types_of_work"": [
                            {
                                ""type_name"": ""surface-work"",
                                ""is_architectural_change"": true
                            }
                            ],
                            ""lanes"": [
                            {
                                ""order"": 1,
                                ""status"": ""closed"",
                                ""type"": ""shoulder""
                            },
                            {
                                ""order"": 2,
                                ""status"": ""closed"",
                                ""type"": ""general""
                            },
                            {
                                ""order"": 3,
                                ""status"": ""open"",
                                ""type"": ""general""
                            },
                            {
                                ""order"": 4,
                                ""status"": ""open"",
                                ""type"": ""general""
                            },
                            {
                                ""order"": 5,
                                ""status"": ""open"",
                                ""type"": ""exit-lane""
                            },
                            {
                                ""order"": 6,
                                ""status"": ""open"",
                                ""type"": ""shoulder""
                            }
                            ]
                        },
                        ""geometry"": {
                            ""type"": ""LineString"",
                            ""coordinates"": [
                            [
                                -93.724769801999969,
                                41.593457451000063
                            ],
                            [
                                -93.725783878999948,
                                41.593459089000078
                            ],
                            [
                                -93.72589773499999,
                                41.593459271000029
                            ],
                            [
                                -93.727600448999965,
                                41.593468041000051
                            ],
                            [
                                -93.728253463999977,
                                41.593468762000043
                            ],
                            [
                                -93.72899278899996,
                                41.593459177000057
                            ],
                            [
                                -93.729737457999988,
                                41.593435398000054
                            ],
                            [
                                -93.730149926999957,
                                41.593410350000056
                            ]
                            ]
                        }
                    },
                    {
                        ""id"": ""65773-3"",
                        ""type"": ""Feature"",
                        ""properties"": {
                            ""core_details"": {
                            ""data_source_id"": ""2"",
                            ""event_type"": ""work-zone"",
                            ""relationship"": {
                                ""parents"": [
                                    ""65773""
                                ],
                                ""first"": [
                                    ""65773-1""
                                ]
                            },
                            ""road_names"": [
                                ""I-235""
                            ],
                            ""direction"": ""westbound"",
                            ""description"": ""Single-direction work zone represented by three sequential road events; third event."",
                            ""creation_date"": ""2009-12-31T11:56:26Z"",
                            ""update_date"": ""2009-12-31T11:56:26Z""
                            },
                            ""beginning_milepost"": 2.5,
                            ""ending_milepost"": 2.0,
                            ""beginning_accuracy"": ""estimated"",
                            ""ending_accuracy"": ""estimated"",
                            ""start_date"": ""2010-01-01T14:00:00Z"",
                            ""end_date"": ""2010-01-05T23:00:00Z"",
                            ""location_method"": ""channel-device-method"",
                            ""start_date_accuracy"": ""estimated"",
                            ""end_date_accuracy"": ""estimated"",
                            ""event_status"": ""active"",
                            ""vehicle_impact"": ""some-lanes-closed"",
                            ""worker_presence"": {
                            ""are_workers_present"": true,
                            ""method"": ""check-in-app"",
                            ""worker_presence_last_confirmed_date"": ""2010-01-04T15:00:00Z"",
                            ""confidence"": ""high"",
                            ""definition"": [
                                ""humans-in-right-of-way""
                            ]
                            },
                            ""reduced_speed_limit_kph"": 88.514,
                            ""restrictions"": [],
                            ""types_of_work"": [
                            {
                                ""type_name"": ""surface-work"",
                                ""is_architectural_change"": true
                            }
                            ],
                            ""lanes"": [
                            {
                                ""order"": 1,
                                ""status"": ""closed"",
                                ""type"": ""shoulder""
                            },
                            {
                                ""order"": 2,
                                ""status"": ""closed"",
                                ""type"": ""general""
                            },
                            {
                                ""order"": 3,
                                ""status"": ""open"",
                                ""type"": ""general""
                            },
                            {
                                ""order"": 4,
                                ""status"": ""open"",
                                ""type"": ""general""
                            },
                            {
                                ""order"": 5,
                                ""status"": ""open"",
                                ""type"": ""shoulder""
                            }
                            ]
                        },
                        ""geometry"": {
                            ""type"": ""LineString"",
                            ""coordinates"": [
                            [
                                -93.730150629999969,
                                41.593410307000056
                            ],
                            [
                                -93.730393025999945,
                                41.593395588000078
                            ],
                            [
                                -93.731358798999963,
                                41.593326786000034
                            ],
                            [
                                -93.731760730999952,
                                41.59329153300007
                            ],
                            [
                                -93.732583278999982,
                                41.59323325400004
                            ],
                            [
                                -93.732583278999982,
                                41.59323325400004
                            ],
                            [
                                -93.732761573999937,
                                41.593220621000057
                            ],
                            [
                                -93.733481823999966,
                                41.593160405000049
                            ],
                            [
                                -93.734099563999962,
                                41.59310849700006
                            ],
                            [
                                -93.735278425999979,
                                41.59301896900007
                            ],
                            [
                                -93.735701953999978,
                                41.592987710000045
                            ],
                            [
                                -93.736446499999943,
                                41.592931475000057
                            ],
                            [
                                -93.737679269999944,
                                41.592827630000045
                            ],
                            [
                                -93.738580275999936,
                                41.592760926000039
                            ],
                            [
                                -93.739154871999972,
                                41.592719210000041
                            ],
                            [
                                -93.739613443999986,
                                41.592679760000067
                            ],
                            [
                                -93.739774495999939,
                                41.592668639000067
                            ],
                            [
                                -93.739774495999939,
                                41.592668639000067
                            ],
                            [
                                -93.740036978999967,
                                41.592650510000055
                            ],
                            [
                                -93.740347204999978,
                                41.592627574000062
                            ],
                            [
                                -93.74078960199995,
                                41.592592205000074
                            ],
                            [
                                -93.741952240999979,
                                41.592498589000058
                            ],
                            [
                                -93.742189315999951,
                                41.592481500000076
                            ]
                            ]
                        }
                    }
                ]
            }";

        private static string _testValidWorkZoneFeedWithDetours = @"
            {
                ""feed_info"": {
                    ""update_date"": ""2020-06-18T15:00:00Z"",
                    ""publisher"": ""TestDOT"",
                    ""version"": ""4.1"",
                    ""license"": ""https://creativecommons.org/publicdomain/zero/1.0/"",
                    ""data_sources"": [
                        {
                            ""data_source_id"": ""1"",
                            ""organization_name"": ""Test City 1""
                        }
                    ]
                },
                ""type"": ""FeatureCollection"",
                ""features"": [
                    {
                        ""id"": ""71234"",
                        ""type"": ""Feature"",
                        ""properties"": {
                            ""core_details"": {
                                ""data_source_id"": ""1"",
                                ""event_type"": ""detour"",
                                ""road_names"": [
                                    ""I-80""
                                ],
                                ""direction"": ""northbound"",
                                ""description"": ""Test detour.""
                            },
                            ""is_start_date_verified"": false,
                            ""is_end_date_verified"": false,
                            ""start_date"": ""2010-01-01T01:00:00Z"",
                            ""end_date"": ""2010-01-02T01:00:00Z""
                        },
                        ""geometry"": {
                            ""type"": ""LineString"",
                            ""coordinates"": [
                                [
                                    -93.776684050999961,
                                    41.617961698000045
                                ],
                                [
                                    -93.776682957,
                                    41.618244962000063
                                ],
                                [
                                    -93.776677372999984,
                                    41.619603362000078
                                ],
                                [
                                    -93.776674365999952,
                                    41.620322783000063
                                ],
                                [
                                    -93.776671741999962,
                                    41.620950321000066
                                ],
                                [
                                    -93.776688974999956,
                                    41.622297226000057
                                ]
                            ]
                        }
                    }
                ]
            }";
    }

    private static void DeserializeFeed_JsonNotValid_ThrowsJsonException<TWzdxFeed>() where TWzdxFeed : IWzdxFeed
    {
        var invalidFeedJson = "test";

        Action action = () => WzdxSerializer.DeserializeFeed<TWzdxFeed>(invalidFeedJson);

        Assert.Throws<JsonException>(action);
    }
}