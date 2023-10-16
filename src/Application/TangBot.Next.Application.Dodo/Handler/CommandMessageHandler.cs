// CommandMessageHandler.cs - TangBot.Next - Next version of TangBot for Nibiru
// Copyright (C) 2023 Nibiru Research Center and all contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>

using System.Diagnostics.CodeAnalysis;
using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Messages;
using Microsoft.Extensions.Logging;
using TangBot.Next.Application.Dodo.Abstract;

namespace TangBot.Next.Application.Dodo.Handler;

/// <summary>
///     Dodo Command Message Handler
/// </summary>
public class CommandMessageHandler : DodoEventHandlerBase
{
    private readonly ILogger<CommandMessageHandler> _logger;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"></param>
    public CommandMessageHandler(ILogger<CommandMessageHandler> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public override void ChannelMessageEvent<T>([NotNull] EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<T>>> input)
    {
        if (input.Data.EventBody.MessageBody is MessageBodyText text)
        {
            _logger.LogInformation("Command Message Handler Received: {Message}", text.Content);
        }
    }
}
