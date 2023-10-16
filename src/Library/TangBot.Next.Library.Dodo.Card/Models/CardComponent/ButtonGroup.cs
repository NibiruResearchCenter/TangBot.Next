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
using TangBot.Next.Library.Dodo.Card.Models.BaseComponent;
using TangBot.Next.Library.Dodo.Card.Models.Enums;

namespace TangBot.Next.Library.Dodo.Card.Models.CardComponent;

/// <summary>
///     按钮组
/// </summary>
public record ButtonGroup(List<Button> Buttons) : ICardComponent
{
    /// <summary>
    ///     按钮组
    /// </summary>
    /// <param name="buttons">按钮组件</param>
    public ButtonGroup(params Button[] buttons) : this(buttons.ToList())
    {
    }

    /// <summary>
    ///     组件类型
    /// </summary>
    [JsonPropertyName("type")]
    public static CardComponentType Type => CardComponentType.ButtonGroup;

    /// <summary>
    ///     按钮列表
    /// </summary>
    [JsonPropertyName("elements")]
    public List<Button> Buttons { get; set; } = Buttons;
}
