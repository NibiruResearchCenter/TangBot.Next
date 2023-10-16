// AuditableEntitySaveChangesInterceptor.cs - TangBot.Next - Next version of TangBot for Nibiru
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
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TangBot.Next.Application.Common.Interfaces;
using TangBot.Next.Domain.Constants;
using TangBot.Next.Domain.Entities.Common;

namespace TangBot.Next.Persistence.Common.Interceptors;

/// <summary>
///     EF Core interceptor for auditable entities
/// </summary>
public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IEventUserService _eventUserService;
    private readonly DateTimeOffset _currentTime = DateTimeOffset.UtcNow;

    /// <summary>
    /// </summary>
    /// <param name="eventUserService"></param>
    public AuditableEntitySaveChangesInterceptor(IEventUserService eventUserService)
    {
        _eventUserService = eventUserService;
    }

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

    private void UpdateEntities(DbContext? dbContext)
    {
        if (dbContext is null)
        {
            return;
        }

        foreach (var entry in dbContext.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = _eventUserService.UserId ?? SystemConstant.SystemUserId;
                entry.Entity.CreatedAt = _currentTime;
                entry.Entity.DeletedBy = null;
                entry.Entity.DeletedAt = null;
            }

            if (entry.State == EntityState.Deleted)
            {
                entry.Entity.DeletedBy = _eventUserService.UserId ?? SystemConstant.SystemUserId;
                entry.Entity.DeletedAt = _currentTime;
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || HasChangedOwnerEntities(entry))
            {
                entry.Entity.LastModifiedBy = _eventUserService.UserId ?? SystemConstant.SystemUserId;
                entry.Entity.LastModifiedAt = _currentTime;
            }
        }
    }

    private static bool HasChangedOwnerEntities(EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry is not null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}
