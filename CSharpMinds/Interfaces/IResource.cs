﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Interfaces
{
    public interface IResource
    {
        string Name { get; set; }
        string FilePath { get; set; }
    }
}
