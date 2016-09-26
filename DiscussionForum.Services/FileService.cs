using DiscussionForum.Services.Interfaces;
using System.IO;

namespace DiscussionForum.Services
{
    public class FileService : IFileService
    {
        private string _rootPath;

        public FileService(string rootPath)
        {
            _rootPath = rootPath;
        }

        public void SaveFile(string container, string filename, byte[] fileBuffer)
        {
            if (!Directory.Exists(GetFullDirPath(container)))
                Directory.CreateDirectory(GetFullDirPath(container));
            
            var files = Directory.GetFiles(GetFullDirPath(container), Path.GetFileNameWithoutExtension(filename) + ".*");
            if (files.Length > 0)
            {
                foreach (var file in files)
                    File.Delete(file);
            }

            File.WriteAllBytes(GetFullFilePath(container, filename), fileBuffer);

        }

        private string GetFullDirPath(string containerName) =>
            $@"{_rootPath}{containerName}";

        private string GetFullFilePath(string containerName, string fileName) =>
            $@"{GetFullDirPath(containerName)}\{fileName}";
    }
}
