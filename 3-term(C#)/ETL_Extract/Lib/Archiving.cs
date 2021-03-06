﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ETL_Extract.Lib
{
    public static class Archiving
    {
        public static void Compress(string sourceFile, string compressedFile)
        {
            using FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate);
            using FileStream targetStream = File.Create(compressedFile);
            using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
            sourceStream.CopyTo(compressionStream);
        }

        public static void Decompress(string compressedFile, string targetFile)
        {
            using FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate);
            using FileStream targetStream = File.Create(targetFile);
            using GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress);
            decompressionStream.CopyTo(targetStream);
        }
    }
}
