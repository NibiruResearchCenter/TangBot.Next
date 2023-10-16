// DodoRuntimeEnvironment.cs - TangBot.Next - Next version of TangBot for Nibiru
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

namespace TangBot.Next.Presentation.Dodo.Constants;

/// <summary>
///     Dodo runtime environment
/// </summary>
[SuppressMessage("Design", "CA1056:URI-like properties should not be strings")]
public static class DodoRuntimeEnvironment
{
    /// <summary>
    ///     Dodo API base URL
    /// </summary>
    public static string DodoApiBaseUrl => Environment.GetEnvironmentVariable("TANGBOT_NEXT_DODO_API_BASE_URL") ?? "";

    /// <summary>
    ///     Dodo API client ID
    /// </summary>
    public static string DodoApiClientId => Environment.GetEnvironmentVariable("TANGBOT_NEXT_DODO_API_CLIENT_ID") ?? "";

    /// <summary>
    ///     Dodo API token
    /// </summary>
    public static string DodoApiToken => Environment.GetEnvironmentVariable("TANGBOT_NEXT_DODO_API_TOKEN") ?? "";

    /// <summary>
    ///     Dodo log API in log message
    /// </summary>
    public static bool DodoLogOpenApi => Environment.GetEnvironmentVariable("TANGBOT_NEXT_DODO_LOG_OPEN_API")?.ToUpperInvariant() == "TRUE";
}
