using System;

namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// An electronic, connected arrow board which can display an arrow pattern to direct traffic.
/// </summary>
/// <param name="CoreDetails">
/// The core details of the arrow board.
/// </param>
/// <param name="Pattern">
/// The current pattern displayed on the arrow board.
/// </param>
/// <param name="IsMoving">
/// Indicates if the arrow board is actively moving (not statically placed).
/// </param>
/// <param name="IsInTransportPosition">
/// Indicates whether the arrow board is in the stowed/transport position (true) or deployed/upright
/// position (false).
/// </param>
public record ArrowBoard(
    FieldDeviceCoreDetails CoreDetails,
    ArrowBoardPattern Pattern,
    [property: Obsolete("Use IsMoving on CoreDetails instead.")]bool? IsMoving = null,
    bool? IsInTransportPosition = null
    ) : IFieldDevice;