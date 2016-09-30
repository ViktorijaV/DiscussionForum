using System;

namespace DiscussionForum.Services.Interfaces
{
    public interface IFileService
    {
        void SaveFile(string container, string filename, byte[] fileBuffer);
    }
}
