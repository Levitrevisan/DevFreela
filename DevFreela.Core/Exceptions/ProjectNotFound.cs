﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    public class ProjectNotFound : Exception
    {
        public ProjectNotFound() : base("Projeto não encontrado") { }
    }
}
