using System;
using Voltaic;

namespace Akitaux.Twitch
{
    internal static class Preconditions
    {
        //Objects

        public static void NotNull<T>(T obj, string name, string msg = null) where T : class { if (obj == null) throw CreateNotNullException(name, msg); }
        public static void NotNull<T>(Optional<T> obj, string name, string msg = null) where T : class { if (obj.IsSpecified && obj.Value == null) throw CreateNotNullException(name, msg); }

        private static ArgumentNullException CreateNotNullException(string name, string msg)
        {
            if (msg == null) return new ArgumentNullException(name);
            else return new ArgumentNullException(name, msg);
        }

        // Collections

        public static void CountGreaterThan<T>(T[] obj, int value, string name, string msg = null) { if (obj.Length > value) throw CreateCountGreaterThanException(name, msg, value); }
        public static void CountGreaterThan<T>(Optional<T[]> obj, int value, string name, string msg = null) { if (obj.Value.Length > value) throw CreateCountGreaterThanException(name, msg, value); }

        private static ArgumentException CreateCountGreaterThanException(string name, string msg, int value)
        {
            if (msg == null) return new ArgumentException($"List must have at most {value} entries", name);
            else return new ArgumentException(msg, name);
        }

        public static void CountLessThan<T>(T[] obj, int value, string name, string msg = null) { if (obj.Length < value) throw CreateCountLessThanException(name, msg, value); }
        public static void CountLessThan<T>(Optional<T[]> obj, int value, string name, string msg = null) { if (obj.Value.Length < value) throw CreateCountLessThanException(name, msg, value); }

        private static ArgumentException CreateCountLessThanException(string name, string msg, int value)
        {
            if (msg == null) return new ArgumentException($"List must have at least {value} entries", name);
            else return new ArgumentException(msg, name);
        }

        //Strings

        public static void NotEmpty(string obj, string name, string msg = null) { if (obj.Length == 0) throw CreateNotEmptyException(name, msg); }
        public static void NotEmpty(Optional<string> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value.Length == 0) throw CreateNotEmptyException(name, msg); }
        public static void NotNullOrEmpty(string obj, string name, string msg = null)
        {
            if (obj == null) throw CreateNotNullException(name, msg);
            if (obj.Length == 0) throw CreateNotEmptyException(name, msg);
        }
        public static void NotNullOrEmpty(Optional<string> obj, string name, string msg = null)
        {
            if (obj.IsSpecified)
            {
                if (obj.Value == null) throw CreateNotNullException(name, msg);
                if (obj.Value.Length == 0) throw CreateNotEmptyException(name, msg);
            }
        }
        public static void NotNullOrWhitespace(string obj, string name, string msg = null)
        {
            if (obj == null) throw CreateNotNullException(name, msg);
            if (obj.Trim().Length == 0) throw CreateNotEmptyException(name, msg);
        }
        public static void NotNullOrWhitespace(Optional<string> obj, string name, string msg = null)
        {
            if (obj.IsSpecified)
            {
                if (obj.Value == null) throw CreateNotNullException(name, msg);
                if (obj.Value.Trim().Length == 0) throw CreateNotEmptyException(name, msg);
            }
        }

        public static void LengthAtLeast(string obj, int value, string name, string msg = null)
        {
            if (obj?.Length < value)
            {
                if (msg == null) throw new ArgumentException($"Length must be at least {value}", name);
                else throw new ArgumentException(msg, name);
            }
        }
        public static void LengthAtMost(string obj, int value, string name, string msg = null)
        {
            if (obj?.Length > value)
            {
                if (msg == null) throw new ArgumentException($"Length must be at most {value}", name);
                else throw new ArgumentException(msg, name);
            }
        }
        public static void LengthGreaterThan(string obj, int value, string name, string msg = null)
        {
            if (obj?.Length <= value)
            {
                if (msg == null) throw new ArgumentException($"Length must be greater than {value}", name);
                else throw new ArgumentException(msg, name);
            }
        }
        public static void LengthLessThan(string obj, int value, string name, string msg = null)
        {
            if (obj?.Length >= value)
            {
                if (msg == null) throw new ArgumentException($"Length must be less than {value}", name);
                else throw new ArgumentException(msg, name);
            }
        }
        public static void LengthAtLeast(Optional<string> obj, int value, string name, string msg = null)
        {
            if (!obj.IsSpecified) return;
            LengthAtLeast(obj.Value, value, name, msg);
        }
        public static void LengthAtMost(Optional<string> obj, int value, string name, string msg = null)
        {
            if (!obj.IsSpecified) return;
            LengthAtMost(obj.Value, value, name, msg);
        }
        public static void LengthGreaterThan(Optional<string> obj, int value, string name, string msg = null)
        {
            if (!obj.IsSpecified) return;
            LengthGreaterThan(obj.Value, value, name, msg);
        }
        public static void LengthLessThan(Optional<string> obj, int value, string name, string msg = null)
        {
            if (!obj.IsSpecified) return;
            LengthLessThan(obj.Value, value, name, msg);
        }

        private static ArgumentException CreateNotEmptyException(string name, string msg)
        {
            if (msg == null) return new ArgumentException("Argument cannot be blank", name);
            else return new ArgumentException(name, msg);
        }

        //Numerics

        public static void NotZero(sbyte obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(byte obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(short obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(ushort obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(int obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(uint obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(long obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(ulong obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<sbyte> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<byte> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<short> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<ushort> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<int> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<uint> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<long> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<ulong> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(sbyte? obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(byte? obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(short? obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(ushort? obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(int? obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(uint? obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(long? obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(ulong? obj, string name, string msg = null) { if (obj == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<sbyte?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<byte?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<short?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<ushort?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<int?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<uint?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<long?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }
        public static void NotZero(Optional<ulong?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value == 0) throw CreateNotZeroException(name, msg); }

        private static ArgumentException CreateNotZeroException(string name, string msg)
        {
            if (msg == null) return new ArgumentException($"Value must be non-zero", name);
            else return new ArgumentException(msg, name);
        }

        public static void Positive(sbyte obj, string name, string msg = null) { if (obj <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(short obj, string name, string msg = null) { if (obj <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(int obj, string name, string msg = null) { if (obj <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(long obj, string name, string msg = null) { if (obj <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(Optional<sbyte> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(Optional<short> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(Optional<int> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(Optional<long> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(sbyte? obj, string name, string msg = null) { if (obj <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(short? obj, string name, string msg = null) { if (obj <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(int? obj, string name, string msg = null) { if (obj <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(long? obj, string name, string msg = null) { if (obj <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(Optional<sbyte?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(Optional<short?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(Optional<int?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= 0) throw CreatePositiveException(name, msg); }
        public static void Positive(Optional<long?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= 0) throw CreatePositiveException(name, msg); }

        private static ArgumentException CreatePositiveException(string name, string msg)
        {
            if (msg == null) return new ArgumentException($"Value must be positive", name);
            else return new ArgumentException(msg, name);
        }

        public static void Negative(sbyte obj, string name, string msg = null) { if (obj >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(short obj, string name, string msg = null) { if (obj >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(int obj, string name, string msg = null) { if (obj >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(long obj, string name, string msg = null) { if (obj >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(Optional<sbyte> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(Optional<short> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(Optional<int> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(Optional<long> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(sbyte? obj, string name, string msg = null) { if (obj >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(short? obj, string name, string msg = null) { if (obj >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(int? obj, string name, string msg = null) { if (obj >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(long? obj, string name, string msg = null) { if (obj >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(Optional<sbyte?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(Optional<short?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(Optional<int?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= 0) throw CreateNegativeException(name, msg); }
        public static void Negative(Optional<long?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= 0) throw CreateNegativeException(name, msg); }

        private static ArgumentException CreateNegativeException(string name, string msg)
        {
            if (msg == null) return new ArgumentException($"Value must be negative", name);
            else return new ArgumentException(msg, name);
        }

        public static void NotNegative(sbyte obj, string name, string msg = null) { if (obj < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(short obj, string name, string msg = null) { if (obj < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(int obj, string name, string msg = null) { if (obj < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(long obj, string name, string msg = null) { if (obj < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(Optional<sbyte> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(Optional<short> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(Optional<int> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(Optional<long> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(sbyte? obj, string name, string msg = null) { if (obj < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(short? obj, string name, string msg = null) { if (obj < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(int? obj, string name, string msg = null) { if (obj < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(long? obj, string name, string msg = null) { if (obj < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(Optional<sbyte?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(Optional<short?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(Optional<int?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value < 0) throw CreateNotNegativeException(name, msg); }
        public static void NotNegative(Optional<long?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value < 0) throw CreateNotNegativeException(name, msg); }

        private static ArgumentException CreateNotNegativeException(string name, string msg)
        {
            if (msg == null) return new ArgumentException($"Value must be non-negative", name);
            else return new ArgumentException(msg, name);
        }

        public static void NotPositive(sbyte obj, string name, string msg = null) { if (obj > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(short obj, string name, string msg = null) { if (obj > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(int obj, string name, string msg = null) { if (obj > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(long obj, string name, string msg = null) { if (obj > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(Optional<sbyte> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(Optional<short> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(Optional<int> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(Optional<long> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(sbyte? obj, string name, string msg = null) { if (obj > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(short? obj, string name, string msg = null) { if (obj > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(int? obj, string name, string msg = null) { if (obj > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(long? obj, string name, string msg = null) { if (obj > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(Optional<sbyte?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(Optional<short?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(Optional<int?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value > 0) throw CreateNotPositiveException(name, msg); }
        public static void NotPositive(Optional<long?> obj, string name, string msg = null) { if (obj.IsSpecified && obj.Value > 0) throw CreateNotPositiveException(name, msg); }

        private static ArgumentException CreateNotPositiveException(string name, string msg)
        {
            if (msg == null) return new ArgumentException($"Value must be non-positive", name);
            else return new ArgumentException(msg, name);
        }

        public static void NotEqual(sbyte obj, sbyte value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(byte obj, byte value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(short obj, short value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(ushort obj, ushort value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(int obj, int value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(uint obj, uint value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(long obj, long value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(ulong obj, ulong value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<sbyte> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<byte> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<short> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<ushort> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<int> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<uint> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<long> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<ulong> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(sbyte? obj, sbyte value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(byte? obj, byte value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(short? obj, short value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(ushort? obj, ushort value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(int? obj, int value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(uint? obj, uint value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(long? obj, long value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(ulong? obj, ulong value, string name, string msg = null) { if (obj == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<sbyte?> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<byte?> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<short?> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<ushort?> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<int?> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<uint?> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<long?> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }
        public static void NotEqual(Optional<ulong?> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value == value) throw CreateNotEqualException(name, msg, value); }

        private static ArgumentException CreateNotEqualException<T>(string name, string msg, T value)
        {
            if (msg == null) return new ArgumentException($"Value may not be equal to {value}", name);
            else return new ArgumentException(msg, name);
        }

        public static void AtLeast(sbyte obj, sbyte value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(byte obj, byte value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(short obj, short value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(ushort obj, ushort value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(int obj, int value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(uint obj, uint value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(long obj, long value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(ulong obj, ulong value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<sbyte> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<byte> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<short> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<ushort> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<int> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<uint> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<long> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<ulong> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(sbyte? obj, sbyte value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(byte? obj, byte value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(short? obj, short value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(ushort? obj, ushort value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(int? obj, int value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(uint? obj, uint value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(long? obj, long value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(ulong? obj, ulong value, string name, string msg = null) { if (obj < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<sbyte?> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<byte?> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<short?> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<ushort?> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<int?> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<uint?> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<long?> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }
        public static void AtLeast(Optional<ulong?> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value < value) throw CreateAtLeastException(name, msg, value); }

        private static ArgumentException CreateAtLeastException<T>(string name, string msg, T value)
        {
            if (msg == null) return new ArgumentException($"Value must be at least {value}", name);
            else return new ArgumentException(msg, name);
        }

        public static void AtMost(sbyte obj, sbyte value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(byte obj, byte value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(short obj, short value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(ushort obj, ushort value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(int obj, int value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(uint obj, uint value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(long obj, long value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(ulong obj, ulong value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<sbyte> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<byte> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<short> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<ushort> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<int> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<uint> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<long> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<ulong> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(sbyte? obj, sbyte value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(byte? obj, byte value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(short? obj, short value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(ushort? obj, ushort value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(int? obj, int value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(uint? obj, uint value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(long? obj, long value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(ulong? obj, ulong value, string name, string msg = null) { if (obj > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<sbyte?> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<byte?> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<short?> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<ushort?> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<int?> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<uint?> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<long?> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }
        public static void AtMost(Optional<ulong?> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value > value) throw CreateAtMostException(name, msg, value); }

        private static ArgumentException CreateAtMostException<T>(string name, string msg, T value)
        {
            if (msg == null) return new ArgumentException($"Value must be at most {value}", name);
            else return new ArgumentException(msg, name);
        }

        public static void GreaterThan(sbyte obj, sbyte value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(byte obj, byte value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(short obj, short value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(ushort obj, ushort value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(int obj, int value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(uint obj, uint value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(long obj, long value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(ulong obj, ulong value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<sbyte> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<byte> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<short> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<ushort> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<int> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<uint> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<long> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<ulong> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(sbyte? obj, sbyte value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(byte? obj, byte value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(short? obj, short value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(ushort? obj, ushort value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(int? obj, int value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(uint? obj, uint value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(long? obj, long value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(ulong? obj, ulong value, string name, string msg = null) { if (obj <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<sbyte?> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<byte?> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<short?> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<ushort?> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<int?> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<uint?> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<long?> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }
        public static void GreaterThan(Optional<ulong?> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value <= value) throw CreateGreaterThanException(name, msg, value); }

        private static ArgumentException CreateGreaterThanException<T>(string name, string msg, T value)
        {
            if (msg == null) return new ArgumentException($"Value must be greater than {value}", name);
            else return new ArgumentException(msg, name);
        }

        public static void LessThan(sbyte obj, sbyte value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(byte obj, byte value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(short obj, short value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(ushort obj, ushort value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(int obj, int value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(uint obj, uint value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(long obj, long value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(ulong obj, ulong value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<sbyte> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<byte> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<short> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<ushort> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<int> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<uint> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<long> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<ulong> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(sbyte? obj, sbyte value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(byte? obj, byte value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(short? obj, short value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(ushort? obj, ushort value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(int? obj, int value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(uint? obj, uint value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(long? obj, long value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(ulong? obj, ulong value, string name, string msg = null) { if (obj >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<sbyte?> obj, sbyte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<byte?> obj, byte value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<short?> obj, short value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<ushort?> obj, ushort value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<int?> obj, int value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<uint?> obj, uint value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<long?> obj, long value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }
        public static void LessThan(Optional<ulong?> obj, ulong value, string name, string msg = null) { if (obj.IsSpecified && obj.Value >= value) throw CreateLessThanException(name, msg, value); }

        private static ArgumentException CreateLessThanException<T>(string name, string msg, T value)
        {
            if (msg == null) return new ArgumentException($"Value must be less than {value}", name);
            else return new ArgumentException(msg, name);
        }
    }
}
