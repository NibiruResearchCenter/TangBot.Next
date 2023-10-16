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
///     指定字符串类型的值类型引用
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public sealed class StringValueTypeRefAttribute : Attribute
{
    /// <summary>
    ///     指定字符串类型的值类型引用
    /// </summary>
    /// <param name="type"></param>
    public StringValueTypeRefAttribute(Type type)
    {
        Type = type;
    }

    /// <summary>
    ///     值类型
    /// </summary>
    public Type Type { get; }
}
