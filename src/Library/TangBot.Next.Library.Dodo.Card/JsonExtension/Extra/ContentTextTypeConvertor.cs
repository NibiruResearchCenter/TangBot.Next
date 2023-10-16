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

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TangBot.Next.Library.Dodo.Card.Models.Enums;

namespace TangBot.Next.Library.Dodo.Card.JsonExtension.Extra;

/// <summary>
///     文本类型转换器
/// </summary>
public class ContentTextTypeConvertor : JsonConverter<ContentTextType>
{
    /// <inheritdoc />
    public override ContentTextType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        return value switch
        {
            "plain-text" => ContentTextType.PlainText,
            "dodo-md" => ContentTextType.DodoMarkdown,
            _ => throw new JsonException("Invalid ContentTextType")
        };
    }

    /// <inheritdoc />
    public override void Write([NotNull] Utf8JsonWriter writer, ContentTextType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
