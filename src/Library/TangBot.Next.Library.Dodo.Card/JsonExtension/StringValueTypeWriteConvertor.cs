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
using TangBot.Next.Library.Dodo.Card.ValueType;

namespace TangBot.Next.Library.Dodo.Card.JsonExtension;

/// <summary>
///     StringValueType 的 Json 转换器
/// </summary>
/// <typeparam name="T"></typeparam>
public class StringValueTypeWriteConvertor<T> : JsonConverter<T> where T : StringValueType, IStringValueType<T>
{
    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var str = reader.GetString();
        var val = StringValueType.Parse<T>(str);
        if (val is null)
        {
            throw new JsonException();
        }

        return val;
    }

    /// <inheritdoc />
    public override void Write([NotNull] Utf8JsonWriter writer, [NotNull] T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
