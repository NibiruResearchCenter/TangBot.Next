// SoftDeleteEntitySaveChangesInterceptor.cs - TangBot.Next - Next version of TangBot for Nibiru
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
using Microsoft.EntityFrameworkCore.Diagnostics;
using TangBot.Next.Domain.Entities.Common;

namespace TangBot.Next.Persistence.Common.Interceptors;

/// <summary>
///     DbContext interceptor for soft delete entities
/// </summary>
public class SoftDeleteEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    /// <inheritdoc />
    public override int SavedChanges([NotNull] SaveChangesCompletedEventData eventData, int result)
    {
        UpdateEntities(eventData.Context);

        return base.SavedChanges(eventData, result);
    }

    /// <inheritdoc />
    public override ValueTask<int> SavedChangesAsync([NotNull] SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateEntities(DbContext? dbContext)
    {
        if (dbContext is null)
        {
            return;
        }

        var entries = dbContext.ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            entry.Entity.IsDeleted = entry.State switch
            {
                EntityState.Added => false,
                EntityState.Deleted => true,
                _ => entry.Entity.IsDeleted
            };
        }
    }
}
