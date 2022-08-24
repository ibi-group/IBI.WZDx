namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Describes a dynamic message sign (DMS), also known as changeable message sign (CMS) or variable
/// message sign (VMS), which is an electronic traffic sign deployed on the roadway used to provide
/// information to travelers.
/// </summary>
/// <param name="CoreDetails">
/// The core details of the dynamic message sign device.
/// </param>
/// <param name="MessageMultiString">
/// The <see href="https://www.ntcip.org/file/2018/11/NTCIP1203v03f.pdf">NTCIP 1203 v03</see>
/// MUTLI-formatted string describing the message currently posted to the sign. A value of 
/// <c>null</c> indiciates that the message is not known, e.g. due to an error; blank messages 
/// can be represented with an empty string.
/// </param>
public record DynamicMessageSign(
    FieldDeviceCoreDetails CoreDetails,
    string? MessageMultiString = null
    ) : IFieldDevice;