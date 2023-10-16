// TangBotDbContext.cs - TangBot.Next - Next version of TangBot for Nibiru
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
using Microsoft.EntityFrameworkCore;
using TangBot.Next.Application.Common.Interfaces;
using TangBot.Next.Domain.Constants;
using TangBot.Next.Domain.Enums;

namespace TangBot.Next.Persistence.Common;

/// <summary>
///     TangBot main database context
/// </summary>
public class TangBotDbContext : DbContext, ITangBotDbContext
{
    /// <inheritdoc />
    protected override void OnConfiguring([NotNull] DbContextOptionsBuilder optionsBuilder)
    {
        if (TangBotRuntimeEnvironment.Mode is RuntimeMode.Development)
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }

        base.OnConfiguring(optionsBuilder);
    }
}
