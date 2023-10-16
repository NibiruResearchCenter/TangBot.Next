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

namespace TangBot.Next.Library.Dodo.Card.JsonExtension;

/// <summary>
///     用于标记接口实现组件的写入转换器
/// </summary>
/// <typeparam name="T"></typeparam>
[AttributeUsage(AttributeTargets.Interface)]
public sealed class InterfaceWriteConvertorAttribute<T> : JsonConverterAttribute where T : class
{
    /// <summary>
    ///
    /// </summary>
    public InterfaceWriteConvertorAttribute() : base(typeof(InterfaceWriteConverter<T>))
    {
    }
}
