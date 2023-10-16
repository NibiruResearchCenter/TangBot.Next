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

using TangBot.Next.Library.Dodo.Card.JsonExtension;
using TangBot.Next.Library.Dodo.Card.ValueType;

namespace TangBot.Next.Library.Dodo.Card.Models.Enums;

/// <summary>
///     文本 + 模块 对齐方式
/// </summary>
[StringValueTypeWriteConvertor<TextWithModuleAlign>]
public class TextWithModuleAlign : StringValueType, IStringValueType<TextWithModuleAlign>
{
    /// <summary>
    ///     右对齐
    /// </summary>
    public static readonly TextWithModuleAlign Right = new("right");

    /// <summary>
    ///     左对齐
    /// </summary>
    public static readonly TextWithModuleAlign Left = new("left");

    private TextWithModuleAlign(string value) : base(value)
    {
    }

    /// <inheritdoc />
    public static IEnumerable<TextWithModuleAlign> SupportedValues
    {
        get
        {
            yield return Right;
            yield return Left;
        }
    }
}
