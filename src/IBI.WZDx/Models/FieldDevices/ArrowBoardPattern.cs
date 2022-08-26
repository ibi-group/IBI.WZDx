namespace IBI.WZDx.Models.FieldDevices;

/// <summary>
/// Options for the posted pattern on an <see cref="ArrowBoard"/>.
/// </summary>
public enum ArrowBoardPattern
{
    /// <summary>
    /// No pattern; the board is not displaying anything.
    /// </summary>
    Blank,

    /// <summary>
    /// Merge right represented by an arrow pattern (e.g. -->) that does not flash or move.
    /// </summary>
    RightArrowStatic,

    /// <summary>
    /// Merge right represented by an arrow pattern (e.g. -->) that flashes on/off.
    /// </summary>
    RightArrowFlashing,

    /// <summary>
    /// Merge right represented by an arrow pattern (e.g. -->) that is displayed
    /// in a progressing sequence (e.g. > -> --> or - -- -->).
    /// </summary>
    RightArrowSequential,

    /// <summary>
    /// Merge right represented by a pattern of chevrons (e.g. >>>) that does not flash or move.
    /// </summary>
    RightChevronsStatic,

    /// <summary>
    /// Merge right represented by a pattern of chevrons (e.g. >>>) that that flashes on/off.
    /// </summary>
    RightChevronsFlashing,

    /// <summary>
    /// Merge right represented by a pattern of chevrons that is displayed in a progressing
    /// sequence.
    /// </summary>
    RightChevronsSequential,

    /// <summary>
    /// Merge left represented by an arrow pattern (e.g. &lt;--) that does not flash or move.
    /// </summary>
    LeftArrowStatic,

    /// <summary>
    /// Merge left represented by an arrow pattern (e.g. &lt;--) that flashes on/off.
    /// </summary>
    LeftArrowFlashing,

    /// <summary>
    /// Merge left represented by an arrow pattern (e.g. &lt;--) that is displayed
    /// in a progressing sequence (e.g. &lt; &lt;- &lt;-- or - -- &lt;--).
    /// </summary>
    LeftArrowSequential,

    /// <summary>
    /// Merge left represented by a pattern of chevrons (e.g. &lt;&lt;&lt;) that does not flash or move.
    /// </summary>
    LeftChevronsStatic,

    /// <summary>
    /// Merge left represented by a pattern of chevrons (e.g. &lt;&lt;&lt;) that that flashes on/off.
    /// </summary>
    LeftChevronsFlashing,

    /// <summary>
    /// Merge left represented by a pattern of chevrons that is displayed in a progressing
    /// sequence.
    /// </summary>
    LeftChevronsSequential,

    /// <summary>
    /// Split (merge left or right) represented by arrows pointing both left and right
    /// (e.g. &lt;-->) that does not flash or move.
    /// </summary>
    BidirectionalArrowStatic,

    /// <summary>
    /// Split (merge left or right) represented by arrows pointing both left and right
    /// (e.g. &lt;-->) that flashes on/off.
    /// </summary>
    BidirectionalArrowFlashing,

    /// <summary>
    /// A flashing line or bar (e.g. ---). This pattern indicates warning/caution, not a merge.
    /// </summary>
    LineFlashing,

    /// <summary>
    /// An alternating display of two diamond shapes (e.g. ◇ ◇). This pattern indicates
    /// warning/caution, not a merge.
    /// </summary>
    DiamondsAlternating,

    /// <summary>
    /// Four dots, one on each corner of the board, which flash. This pattern indicates
    /// warning/caution, not a merge.
    /// </summary>
    FourCornersFlashing,

    /// <summary>
    /// The pattern posted on the <see cref="ArrowBoard"/> is not known.
    /// </summary> 
    Unknown
}