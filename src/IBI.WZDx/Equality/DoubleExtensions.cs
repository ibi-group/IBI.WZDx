using System;

namespace IBI.WZDx.Equality;

/// <summary>
/// Extensions for <see cref="double"/> related to equality.
/// </summary>
public static class DoubleExtensions
{
    /// <summary>
    /// Determines whether two nullable double values are approximately equal.
    /// </summary>
    /// <param name="value">The first nullable double value to compare.</param>
    /// <param name="other">The second nullable double value to compare.</param>
    /// <returns>
    /// True if both values are null, or their absolute difference is less than or equal
    /// to <see cref="double.Epsilon"/>; otherwise, false.
    /// </returns>
    public static bool NullEqualsApproximation(this double? value, double? other)
    {
        if (value is null && other is null)
            return true;
        
        if (value is null || other is null)
            return false;
        
        return Math.Abs(value.Value - other.Value) <= double.Epsilon;
    }
}