using System;
using UnityEngine;

/// <summary>
/// Originally "UnityUtilities" from https://github.com/TobiasWehrum/unity-utilities
/// </summary>
namespace UniFramework.Utility
{
    /// <summary>
    /// Provides input for a value range in the editor and various convencience functions to work with that range.
    /// </summary>
    [Serializable]
    public class RangedInt
    {
        /// <summary>
        /// The range start.
        /// </summary>
        [SerializeField] int from;

        /// <summary>
        /// The range end.
        /// </summary>
        [SerializeField] int to;

        /// <summary>
        /// The range start.
        /// </summary>
        public int From { get { return from; } }

        /// <summary>
        /// The range end.
        /// </summary>
        public int To { get { return to; } }

        /// <summary>
        /// Returns how wide the range between from and to is.
        /// </summary>
        public int Range { get { return to - from; } }

        /// <summary>
        /// Returns a random number between from [inclusive] and to [inclusive].
        /// </summary>
        public int RandomInclusive { get { return UnityEngine.Random.Range(from, to + 1); } }

        /// <summary>
        /// Returns a random number between from [inclusive] and to [exclusive].
        /// </summary>
        public int RandomExclusive { get { return UnityEngine.Random.Range(from, to); } }

        /// <summary>
        /// Create a RangeFloat with 0-0 as the range. Needed for the editor.
        /// </summary>
        public RangedInt()
        {
        }

        /// <summary>
        /// Create a RangeFloat with a certain range.
        /// </summary>
        /// <param name="from">Lower range bound.</param>
        /// <param name="to">Upper range bound.</param>
        public RangedInt(int from, int to)
        {
            this.from = from;
            this.to = to;
        }
    }
}