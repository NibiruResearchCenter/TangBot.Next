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
///     设置表单输入框信息
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public sealed class FormAttribute : Attribute
{
    /// <summary>
    ///     设置表单输入框信息
    /// </summary>
    /// <param name="title"></param>
    /// <param name="placeholder"></param>
    public FormAttribute(string title, string? placeholder = null)
    {
        Title = title;
        Placeholder = placeholder;
    }

    /// <summary>
    ///     表单标题
    /// </summary>
    public string Title { get; }

    /// <summary>
    ///     表单占位符
    /// </summary>
    public string? Placeholder { get; }
}
