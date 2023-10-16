// DodoEventProcessor.cs - TangBot.Next - Next version of TangBot for Nibiru
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

using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Services;
using TangBot.Next.Application.Dodo.Abstract;

namespace TangBot.Next.Presentation.Dodo;

/// <summary>
///    Dodo Event Processor
/// </summary>
public class DodoEventProcessor : EventProcessService
{
    private readonly ILogger<DodoEventProcessor> _logger;
    private readonly DodoEventHandlerBase[] _eventHandlers;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="eventHandlers"></param>
    public DodoEventProcessor(ILogger<DodoEventProcessor> logger, DodoEventHandlerBase[] eventHandlers)
    {
        _logger = logger;
        _eventHandlers = eventHandlers;
    }

    /// <inheritdoc />
    public override void Connected(string message)
    {
        _logger.LogInformation("DodoEventProcessor {DodoEventType}: {DodoEventMessage}", nameof(Connected), message);
    }

    /// <inheritdoc />
    public override void Disconnected(string message)
    {
        _logger.LogInformation("DodoEventProcessor {DodoEventType}: {DodoEventMessage}", nameof(Disconnected), message);
    }

    /// <inheritdoc />
    public override void Reconnected(string message)
    {
        _logger.LogInformation("DodoEventProcessor {DodoEventType}: {DodoEventMessage}", nameof(Reconnected), message);
    }

    /// <inheritdoc />
    public override void Exception(string message)
    {
        _logger.LogError("DodoEventProcessor {DodoEventType}: {DodoEventMessage}", nameof(Exception), message);
    }

    /// <inheritdoc />
    public override void PersonalMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<T>>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.PersonalMessageEvent(input);
        }
    }

    /// <inheritdoc />
    public override void ChannelMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<T>>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.ChannelMessageEvent(input);
        }
    }

    /// <inheritdoc />
    public override void MessageReactionEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.MessageReactionEvent(input);
        }
    }

    /// <inheritdoc />
    public override void CardMessageButtonClickEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageButtonClick>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.CardMessageButtonClickEvent(input);
        }
    }

    /// <inheritdoc />
    public override void CardMessageFormSubmitEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageFormSubmit>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.CardMessageFormSubmitEvent(input);
        }
    }

    /// <inheritdoc />
    public override void CardMessageListSubmitEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageListSubmit>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.CardMessageListSubmitEvent(input);
        }
    }

    /// <inheritdoc />
    public override void ChannelVoiceMemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelVoiceMemberJoin>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.ChannelVoiceMemberJoinEvent(input);
        }
    }

    /// <inheritdoc />
    public override void ChannelVoiceMemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelVoiceMemberLeave>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.ChannelVoiceMemberLeaveEvent(input);
        }
    }

    /// <inheritdoc />
    public override void ChannelArticleEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelArticle>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.ChannelArticleEvent(input);
        }
    }

    /// <inheritdoc />
    public override void ChannelArticleCommentEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelArticleComment>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.ChannelArticleCommentEvent(input);
        }
    }

    /// <inheritdoc />
    public override void MemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.MemberJoinEvent(input);
        }
    }

    /// <inheritdoc />
    public override void MemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.MemberLeaveEvent(input);
        }
    }

    /// <inheritdoc />
    public override void MemberInviteEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberInvite>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.MemberInviteEvent(input);
        }
    }

    /// <inheritdoc />
    public override void GiftSendEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyGiftSend>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.GiftSendEvent(input);
        }
    }

    /// <inheritdoc />
    public override void IntegralChangeEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyIntegralChange>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.IntegralChangeEvent(input);
        }
    }

    /// <inheritdoc />
    public override void GoodsPurchaseEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyGoodsPurchase>> input)
    {
        foreach (var dodoEventHandlerBase in _eventHandlers)
        {
            dodoEventHandlerBase.GoodsPurchaseEvent(input);
        }
    }
}
