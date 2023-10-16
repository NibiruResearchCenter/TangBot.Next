// DodoHosted.cs - TangBot.Next - Next version of TangBot for Nibiru
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

using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Services;

namespace TangBot.Next.Presentation.Dodo;

/// <summary>
///     Dodo Hosted Service
/// </summary>
public class DodoHosted : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;

    private readonly OpenEventService _openEventService;
    private Task? _dodoEventReceiverTask;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="applicationLifetime"></param>
    /// <param name="openApiService"></param>
    /// <param name="dodoEventProcessor"></param>
    public DodoHosted(
        IHostApplicationLifetime applicationLifetime,
        OpenApiService openApiService,
        DodoEventProcessor dodoEventProcessor)
    {
        _applicationLifetime = applicationLifetime;

        _openEventService = new OpenEventService(openApiService, dodoEventProcessor, new OpenEventOptions
        {
            IsAsync = true,
            IsReconnect = true
        });
    }

    /// <inheritdoc />
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _applicationLifetime.ApplicationStarted.Register(StartListener);

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _openEventService.StopReceiveAsync();

        if (_dodoEventReceiverTask is not null)
        {
            await _dodoEventReceiverTask;
        }
    }

    private void StartListener()
    {
        _dodoEventReceiverTask = _openEventService.ReceiveAsync();
    }
}
