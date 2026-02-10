using System;
using System.IO;

namespace Day5
{
    public class FileManager : IDisposable
    {
        private FileStream? _fileStream;
        private bool _disposed = false;

        public void OpenFile(string filePath)
        {
            _fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            Console.WriteLine($"Opened file: {filePath}");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _fileStream?.Dispose();
            }

            _disposed = true;
        }

        ~FileManager()
        {
            Dispose(false);
        }
    }
}
