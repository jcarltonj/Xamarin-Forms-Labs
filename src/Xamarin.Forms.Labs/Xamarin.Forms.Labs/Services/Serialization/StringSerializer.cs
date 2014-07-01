﻿using System.Diagnostics.CodeAnalysis;

namespace Xamarin.Forms.Labs.Services.Serialization
{
    /// <summary>
    /// The string serializer base class.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1124:DoNotUseRegions", Justification = "Reviewed. Suppression is OK here.")]
    public abstract class StringSerializer : ISerializer
    {
        #region ISerializer Members
        /// <summary>
        /// Gets the serialization format.
        /// </summary>
        /// <value>Serialization format.</value>
        public abstract SerializationFormat Format { get; }

        /// <summary>
        /// Cleans memory.
        /// </summary>
        public abstract void Flush();
        #endregion

        #region IByteSerializer Members

        byte[] IByteSerializer.Serialize<T>(T obj)
        {
            return (this as IStringSerializer).SerializeToBytes(obj);
        }

        public T Deserialize<T>(byte[] data)
        {
            return (this as IStringSerializer).DeserializeFromBytes<T>(data);
        }
        #endregion

        #region IStreamSerializer Members
        public void Serialize<T>(T obj, System.IO.Stream stream)
        {
            (this as IStringSerializer).SerializeToStream(obj, stream);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return (this as IStringSerializer).DeserializeFromStream<T>(stream);
        }
        #endregion

        #region IStringSerializer Members
        public abstract string Serialize<T>(T obj);

        public abstract T Deserialize<T>(string data);
        #endregion
    }
}
