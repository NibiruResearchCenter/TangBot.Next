// RuntimeEnvironment.cs - TangBot.Next - Next version of TangBot for Nibiru
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

using TangBot.Next.Domain.Enums;

namespace TangBot.Next.Domain.Constants;

/// <summary>
///     Runtime environment
/// </summary>
public static class TangBotRuntimeEnvironment
{
    /// <summary>
    ///     Runtime mode, read from environment variable TANGBOT_NEXT_RUNTIME_MODE, defaults to Production
    /// </summary>
    public static RuntimeMode Mode => Enum.TryParse<RuntimeMode>(
        Environment.GetEnvironmentVariable("TANGBOT_NEXT_RUNTIME_MODE"),
        out var mode)
        ? mode
        : RuntimeMode.Production;
}
