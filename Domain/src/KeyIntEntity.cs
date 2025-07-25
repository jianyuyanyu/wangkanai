// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

namespace Wangkanai.Domain;

/// <summary>
/// Represents an abstract base class for entities that utilize an integer as their unique identifier.
/// This class extends the functionality of the generic <see cref="Entity{T}"/> class by explicitly
/// specifying <c>int</c> as the type parameter for the identifier.
/// </summary>
/// <remarks>
/// This class is commonly used in systems where entities have integer-based identifiers, which are
/// often generated by databases or other persistence mechanisms. Classes inheriting from
/// <see cref="KeyIntEntity"/> gain the capability to handle integer-based identifiers as well as
/// inherit the core functionality of <see cref="Entity{T}"/>.
/// </remarks>
public abstract class KeyIntEntity : Entity<int>;
