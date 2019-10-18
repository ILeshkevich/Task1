using System;
using System.Collections.Generic;

namespace MostModifiedFiles.Utilities
{
    public interface IVcs
    {
        List<string> Log();
    }
}