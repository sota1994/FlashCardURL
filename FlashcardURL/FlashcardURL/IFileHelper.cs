using System;
using System.Collections.Generic;
using System.Text;

namespace FlashcardURL
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
