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
///     倒计时组件样式
/// </summary>
[StringValueTypeWriteConvertor<CountdownStyle>]
public class CountdownStyle : StringValueType, IStringValueType<CountdownStyle>
{
    /// <summary>
    ///     按天显示
    /// </summary>
    public static readonly CountdownStyle Day = new("day");

    /// <summary>
    ///     按小时显示
    /// </summary>
    public static readonly CountdownStyle Hour = new("hour");

    private CountdownStyle(string value) : base(value)
    {
    }

    /// <inheritdoc />
    public static IEnumerable<CountdownStyle> SupportedValues
    {
        get
        {
            yield return Day;
            yield return Hour;
        }
    }
}
