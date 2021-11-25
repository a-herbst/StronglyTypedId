#if !STRONGLY_TYPED_ID_EXCLUDE_ATTRIBUTES
using System;

namespace StronglyTypedIds
{
    /// <summary>
    /// Place on partial structs to make the type a strongly-typed ID
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    [System.Diagnostics.Conditional("STRONGLY_TYPED_ID_USAGES")]
    internal sealed class StronglyTypedIdAttribute : Attribute
    {
        /// <summary>
        /// Make the struct a strongly typed ID
        /// </summary>
        /// <param name="backingType">The <see cref="Type"/> to use to store the strongly-typed ID value.
        /// If not set, uses <see cref="StronglyTypedIdDefaultsAttribute.BackingType"/>, which defaults to <see cref="StronglyTypedIdBackingType.Guid"/></param>
        /// <param name="converters">Converters to create for serializing/deserializing the strongly-typed ID value.
        /// If not set, uses <see cref="StronglyTypedIdDefaultsAttribute.Converters"/>, which defaults to <see cref="StronglyTypedIdConverter.NewtonsoftJson"/>
        /// and <see cref="StronglyTypedIdConverter.TypeConverter"/></param>
        /// <param name="implementations">Interfaces and patterns the strongly typed id should implement
        /// If not set, uses <see cref="StronglyTypedIdDefaultsAttribute.Implementations"/>, which defaults to <see cref="StronglyTypedIdImplementations.IEquatable"/>
        /// and <see cref="StronglyTypedIdImplementations.IComparable"/></param>
        public StronglyTypedIdAttribute(
            StronglyTypedIdBackingType backingType = StronglyTypedIdBackingType.Default,
            StronglyTypedIdConverter converters = StronglyTypedIdConverter.Default,
            StronglyTypedIdImplementations implementations = StronglyTypedIdImplementations.Default)
        {
            BackingType = backingType;
            Converters = converters;
            Implementations = implementations;
        }

        /// <summary>
        /// The <see cref="Type"/> to use to store the strongly-typed ID value
        /// </summary>
        public StronglyTypedIdBackingType BackingType { get; }

        /// <summary>
        /// JSON library used to serialize/deserialize strongly-typed ID value
        /// </summary>
        public StronglyTypedIdConverter Converters { get; }

        /// <summary>
        /// Interfaces and patterns the strongly typed id should implement
        /// </summary>
        public StronglyTypedIdImplementations Implementations { get; }
    }
}
#endif // STRONGLY_TYPED_ID_EXCLUDE_ATTRIBUTES