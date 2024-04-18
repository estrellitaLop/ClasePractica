using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public interface IRepository
    {
        Task OpenOrCreateFile();
        Task OpenFile();
        Task Convert();
        Task CloseFile();
        Task ReadFile();
    }
}
