using System;

namespace OpenMcdf
{
    public interface ICFStream : ICFItem
    {
        /// <summary>
        /// Set the data associated with the stream object.
        /// </summary>
        /// <example>
        /// <code>
        ///    byte[] b = new byte[]{0x0,0x1,0x2,0x3};
        ///    CompoundFile cf = new CompoundFile();
        ///    CFStream myStream = cf.RootStorage.AddStream("MyStream");
        ///    myStream.SetData(b);
        /// </code>
        /// </example>
        /// <param name="data">Data bytes to write to this stream</param>
        void SetData(Byte[] data);

        /// <summary>
        /// Append the provided data to stream data.
        /// </summary>
        /// <example>
        /// <code>
        ///    byte[] b = new byte[]{0x0,0x1,0x2,0x3};
        ///    byte[] b2 = new byte[]{0x4,0x5,0x6,0x7};
        ///    CompoundFile cf = new CompoundFile();
        ///    CFStream myStream = cf.RootStorage.AddStream("MyStream");
        ///    myStream.SetData(b); // here we could also have invoked .AppendData
        ///    myStream.AppendData(b2);
        ///    cf.Save("MyLargeStreamsFile.cfs);
        ///    cf.Close();
        /// </code>
        /// </example>
        /// <param name="data">Data bytes to append to this stream</param>
        /// <remarks>
        /// This method allows user to create stream with more than 2GB of data, 
        /// appending data to the end of existing ones.
        /// Large streams (>2GB) are only supported by CFS version 4.
        /// Append data can also be invoked on streams with no data in order
        /// to simplify its use inside loops.
        /// </remarks>
        void AppendData(Byte[] data);

        /// <summary>
        /// Get the data associated with the stream object.
        /// </summary>
        /// <example>
        /// <code>
        ///     CompoundFile cf2 = new CompoundFile("AFileName.cfs");
        ///     CFStream st = cf2.RootStorage.GetStream("MyStream");
        ///     byte[] buffer = st.GetData();
        /// </code>
        /// </example>
        /// <returns>Array of byte containing stream data</returns>
        /// <exception cref="T:OpenMcdf.CFDisposedException">
        /// Raised when the owner compound file has been closed.
        /// </exception>
        Byte[] GetData();

        /// <summary>
        /// Get <paramref name="count"/> bytes associated with the stream object, starting from
        /// a provided <paramref name="offset"/>. When method returns, count will contain the
        /// effective count of bytes read.
        /// </summary>
        /// <example>
        /// <code>
        /// CompoundFile cf = new CompoundFile("AFileName.cfs");
        /// CFStream st = cf.RootStorage.GetStream("MyStream");
        /// int count = 8;
        /// // The stream is supposed to have a length greater than offset + count
        /// byte[] data = st.GetData(20, ref count);  
        /// cf.Close();
        /// </code>
        /// </example>
        /// <returns>Array of byte containing stream data</returns>
        /// <exception cref="T:OpenMcdf.CFDisposedException">
        /// Raised when the owner compound file has been closed.
        /// </exception>
        Byte[] GetData(long offset, ref int count);
    }
}