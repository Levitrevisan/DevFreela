using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    internal class ProjectAlreadyStarted : Exception
    {
        public ProjectAlreadyStarted() : base ("O Projeto já foi iniciado")
        {
            
        }
    }
}
