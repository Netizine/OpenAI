// ReSharper disable once CheckNamespace
namespace OpenAI.Infrastructure
{
    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// RandomUtils class.
    /// </summary>
    public static class RandomUtils
    {
        /// <summary>
        /// Gets the next random number between the minimum and maximum.
        /// </summary>
        /// <param name="generator">The generator.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>System.Int32.</returns>
        public static int Next(this RandomNumberGenerator generator, int min, int max)
        {
            // match Next of Random
            // where max is exclusive
            max = max - 1;

            var bytes = new byte[sizeof(int)]; // 4 bytes
            generator.GetNonZeroBytes(bytes);
            var val = BitConverter.ToInt32(bytes, 0);

            // constrain our values to between our min and max https://stackoverflow.com/a/3057867/86411
            var result = ((((val - min) % (max - min + 1)) + (max - min + 1)) % (max - min + 1)) + min;
            return result;
        }
    }
}
