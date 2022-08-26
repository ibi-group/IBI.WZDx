using System.Collections.Generic;
using System.Linq;

namespace IBI.WZDx.Equality;

/// <summary>
/// Extensions for <see cref="IEnumerable{T}"/> related to equality.
/// </summary>
internal static class EnumerableExtensions
{
    /// <summary>
    /// Determines whether two nullable sequences are equal according to an equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">A nullable <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
    /// <param name="second">A nullable <see cref="IEnumerable{T}"/> to compare to <paramref name="first"/>.</param>
    /// <returns>
    /// <c>true</c> if the two source sequences are of equal length and their corresponding elements
    /// are equal according to the default equality comparer for their type, or if both sequences
    /// are null; otherwise, <c>false</c>.
    /// </returns>
    public static bool NullHandlingSequenceEqual<TSource>(
        this IEnumerable<TSource>? first,
        IEnumerable<TSource>? second
        )
    {
        if (first == null && second == null)
        {
            return true;
        }

        if (first == null || second == null)
        {
            return false;
        }

        return first.SequenceEqual(second);
    }
}
