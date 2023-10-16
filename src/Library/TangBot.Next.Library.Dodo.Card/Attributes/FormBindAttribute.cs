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
///     设置 ID
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public sealed class FormBindAttribute : Attribute
{
    /// <summary>
    ///     设置 ID
    /// </summary>
    /// <param name="id"></param>
    public FormBindAttribute(string id)
    {
        Id = id;
    }

    /// <summary>
    ///     ID
    /// </summary>
    public string Id { get; }
}
