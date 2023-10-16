// BaseAuditableEntity.cs - TangBot.Next - Next version of TangBot for Nibiru
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

namespace TangBot.Next.Domain.Entities.Common;

/// <summary>
///     Base entity with audit fields
/// </summary>
public abstract class BaseAuditableEntity : BaseEntity
{
    /// <summary>
    ///     The creation date of the entity
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    ///     The last modification date of the entity
    /// </summary>
    public DateTimeOffset LastModifiedAt { get; set; }

    /// <summary>
    ///     The deletion date of the entity
    /// </summary>
    public DateTimeOffset? DeletedAt { get; set; }

    /// <summary>
    ///     The user who created the entity
    /// </summary>
    public string CreatedBy { get; set; } = default!;

    /// <summary>
    ///     The user who last modified the entity
    /// </summary>
    public string LastModifiedBy { get; set; } = default!;

    /// <summary>
    ///     The user who deleted the entity
    /// </summary>
    public string? DeletedBy { get; set; }
}
