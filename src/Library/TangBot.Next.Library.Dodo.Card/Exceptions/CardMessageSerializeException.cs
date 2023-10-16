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

namespace TangBot.Next.Library.Dodo.Card.Exceptions;

/// <summary>
///     卡片消息序列化异常
/// </summary>
[SuppressMessage("Design", "CA1032:Implement standard exception constructors")]
public class CardMessageSerializeException : Exception
{
    /// <summary>
    ///     卡片消息序列化异常
    /// </summary>
    /// <param name="message"></param>
    public CardMessageSerializeException(string message) : base(message) { }
}
