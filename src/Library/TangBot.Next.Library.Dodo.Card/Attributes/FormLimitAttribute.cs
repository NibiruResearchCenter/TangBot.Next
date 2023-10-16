// This file is a part of Dodo.Hosted project.
//
// Copyright (C) 2022 LiamSho and all Contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY

namespace TangBot.Next.Library.Dodo.Card.Attributes;

/// <summary>
///     设置长度限制
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public sealed class FormLimitAttribute : Attribute
{
    /// <summary>
    ///     设置长度限制
    /// </summary>
    /// <param name="minCharacters"></param>
    /// <param name="maxCharacters"></param>
    /// <param name="rows"></param>
    public FormLimitAttribute(int minCharacters, int maxCharacters, int rows = 1)
    {
        MaxCharacters = maxCharacters;
        MinCharacters = minCharacters;
        Rows = rows;
    }

    /// <summary>
    ///     最小字符数
    /// </summary>
    public int MinCharacters { get; }

    /// <summary>
    ///     最大字符数
    /// </summary>
    public int MaxCharacters { get; }

    /// <summary>
    ///     行数
    /// </summary>
    public int Rows { get; }
}
