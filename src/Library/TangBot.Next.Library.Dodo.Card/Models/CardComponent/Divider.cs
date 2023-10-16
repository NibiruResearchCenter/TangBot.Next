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

using System.Text.Json.Serialization;
using TangBot.Next.Library.Dodo.Card.Models.Enums;

namespace TangBot.Next.Library.Dodo.Card.Models.CardComponent;

/// <summary>
///     分割线
/// </summary>
public record Divider : ICardComponent
{
    /// <summary>
    ///     组件类型
    /// </summary>
    [JsonPropertyName("type")]
    public static CardComponentType Type => CardComponentType.Divider;
}
