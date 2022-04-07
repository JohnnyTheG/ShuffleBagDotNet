using System;

namespace ShuffleBagDotNet
{
    /// <summary>
    /// Exception thrown when attempting to get a value from the bag while empty.
    /// </summary>
    public class ShuffleBagEmptyException : Exception { public ShuffleBagEmptyException(string? message) : base(message) { } };
}
