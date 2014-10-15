﻿using System;

namespace OpenMcdf
{
    public interface ICFStream : ICFItem
    {
        /// <summary>
        /// Set the data associated with the stream object.
        /// </summary>
        /// <param name="data">Data bytes to write to this stream</param>
        void SetData(Byte[] data);

        /// <summary>
        /// Append the provided data to stream data.
        /// </summary>
        /// <param name="data">Data bytes to append to this stream</param>
        void Append(Byte[] data);

        /// <summary>
        /// Get the data associated with the stream object.
        /// </summary>
        /// <returns>Array of byte containing stream data</returns>
        Byte[] GetData();

        int Read(byte[] buffer, long position, int count);
    }
}
