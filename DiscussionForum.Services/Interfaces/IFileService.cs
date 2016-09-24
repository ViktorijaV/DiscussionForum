using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum.Services.Interfaces
{
    public interface IFileService
    {
        void SaveFile(string container, string filename, byte[] fileBuffer);
    }
}
