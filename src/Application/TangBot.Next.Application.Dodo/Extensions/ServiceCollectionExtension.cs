// DodoServiceExtension.cs - TangBot.Next - Next version of TangBot for Nibiru
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

using Microsoft.Extensions.DependencyInjection;
using TangBot.Next.Application.Dodo.Abstract;
using TangBot.Next.Application.Dodo.Handler;

namespace TangBot.Next.Application.Dodo.Extensions;

/// <summary>
///     Extension methods for <see cref="IServiceCollection" /> to register services
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    ///     Add Dodo Open API Service
    /// </summary>
    /// <param name="services"></param>
    public static void AddEventHandlers(this IServiceCollection services)
    {
        services.AddScoped<DodoEventHandlerBase, CommandMessageHandler>();
    }
}
