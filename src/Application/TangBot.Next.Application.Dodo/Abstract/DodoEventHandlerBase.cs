// DodoEventHandler.cs - TangBot.Next - Next version of TangBot for Nibiru
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

using DoDo.Open.Sdk.Services;

namespace TangBot.Next.Application.Dodo.Abstract;

/// <summary>
///     Dodo Abstract Event Handler
/// </summary>
public abstract class DodoEventHandlerBase : EventProcessService
{
    /// <inheritdoc />
    public sealed override void Connected(string message) { }

    /// <inheritdoc />
    public sealed override void Disconnected(string message) { }

    /// <inheritdoc />
    public sealed override void Reconnected(string message) { }

    /// <inheritdoc />
    public sealed override void Exception(string message) { }

    /// <inheritdoc />
    public sealed override void Received(string message)
    {
        // Ignored
    }
}
