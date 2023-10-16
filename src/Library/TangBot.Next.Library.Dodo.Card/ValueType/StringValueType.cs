// StringValueType.cs - TangBot.Next - Next version of TangBot for Nibiru
// Copyright (C) 2023 Nibiru Research Center and all contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>

using System.Diagnostics.CodeAnalysis;

namespace TangBot.Next.Library.Dodo.Card.ValueType;

/// <summary>
///     Represents a string value type.
/// </summary>
[SuppressMessage("Blocker Code Smell", "S3875:\"operator==\" should not be overloaded on reference types")]
public abstract class StringValueType
{
    private readonly string _value;

    /// <summary>
    ///     Initializes a new instance of the <see cref="StringValueType" /> class.
    /// </summary>
    /// <param name="value"></param>
    protected StringValueType(string value)
    {
        _value = value;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return _value;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is StringValueType value)
        {
            return Equals(value);
        }

        return false;
    }

    private bool Equals(StringValueType other)
    {
        return _value == other._value;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return _value.GetHashCode(StringComparison.InvariantCulture);
    }

    /// <summary>
    ///     Compares two <see cref="StringValueType" />s for equality.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(StringValueType? a, StringValueType? b)
    {
        return a is not null && b is not null && a.Equals(b);
    }

    /// <summary>
    ///     Compares two <see cref="StringValueType" />s for inequality.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(StringValueType? a, StringValueType? b)
    {
        return a is not null && b is not null && !a.Equals(b);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="StringValueType" /> to a string.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator string([NotNull] StringValueType value)
    {
        return value._value;
    }

    /// <summary>
    ///     Parses a <see cref="StringValueType" /> from a string.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? Parse<T>(string? value) where T : StringValueType, IStringValueType<T>
    {
        return T.SupportedValues.FirstOrDefault(supportedValue => supportedValue._value == value);
    }
}
