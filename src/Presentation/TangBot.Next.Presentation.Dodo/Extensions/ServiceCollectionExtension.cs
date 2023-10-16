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

using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Services;
using Microsoft.Extensions.Options;
using TangBot.Next.Domain.Constants;
using TangBot.Next.Domain.Enums;
using TangBot.Next.Presentation.Dodo.Constants;

namespace TangBot.Next.Presentation.Dodo.Extensions;

/// <summary>
///     Extension methods for <see cref="IServiceCollection" /> to register services
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    ///     Add Dodo Open API Service
    /// </summary>
    /// <param name="services"></param>
    public static void AddDodoOpenApiService(this IServiceCollection services)
    {
        services.AddSingleton(sp =>
        {
            var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<OpenApiService>();
            var options = new OpenApiOptions
            {
                BaseApi = DodoRuntimeEnvironment.DodoApiBaseUrl,
                ClientId = DodoRuntimeEnvironment.DodoApiClientId,
                Token = DodoRuntimeEnvironment.DodoApiToken,
                Log = s =>
                {
                    if (TangBotRuntimeEnvironment.Mode is RuntimeMode.Development)
                    {
                        logger.LogDebug("DodoOpenApi Log: {DodoOpenApiMessage}", s);
                    }
                    else if (DodoRuntimeEnvironment.DodoLogOpenApi)
                    {
                        logger.LogInformation("DodoOpenApi Log: {DodoOpenApiMessage}", s);
                    }
                }
            };
            return Options.Create(options);
        });

        services.AddSingleton<OpenApiService>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<OpenApiOptions>>();
            return new OpenApiService(options.Value);
        });
    }

    /// <summary>
    ///     Add Dodo Event Processor Service
    /// </summary>
    /// <param name="services"></param>
    public static void AddDodoEventProcessorService(this IServiceCollection services)
    {
        services.AddSingleton<DodoEventProcessor>();
    }
}
