// AuditLog.cs - TangBot.Next - Next version of TangBot for Nibiru
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

using TangBot.Next.Domain.Entities.Common;
using TangBot.Next.Domain.Enums;

namespace TangBot.Next.Domain.Entities.Audit;

/// <summary>
///     The audit log entity
/// </summary>
public class AuditLog
{
    /// <summary>
    ///     The operation operator
    /// </summary>
    public required string Operator { get; set; }

    /// <summary>
    ///     The time of this change
    /// </summary>
    public required DateTimeOffset OperationTime { get; set; }

    /// <summary>
    ///     The API request track id
    /// </summary>
    public required string OperationTrackId { get; set; }

    /// <summary>
    ///     The entity that the operator modified
    /// </summary>
    public required Guid ModifiedEntityId { get; set; }

    /// <summary>
    ///     The entity type name
    /// </summary>
    /// <remarks>
    ///     We do not use <see cref="BaseAuditableEntity"/> type here. That will make
    ///     the database schema more chaotic. Just the name of the entity is OK.
    /// </remarks>
    public required string EntityName { get; set; }

    /// <summary>
    ///     The entity changed type
    /// </summary>
    public required EntityChangedType ChangedType { get; set; }
}
