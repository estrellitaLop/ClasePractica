using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class ConvertAsync : IRepository
    {
        private string _FileName;
        private StreamWriter? _fileWriter;
        private StreamReader? _fileReader;
        private FileStream _fileStream;
        


        public ConvertAsync(string fileName)
        {
            _FileName = fileName;
        }

        public async Task CloseFile()
        {
            await Task.Delay(100);
            try
            {
                _fileWriter?.Close();
                _fileReader?.Close();
            }
            catch (IOException) 
            {
                throw new IOException("Error al cerrar el archivo");
            }
        }

        public async Task Convert()
        {
            await Task.Delay(100);
            string file = _FileName.ToUpper();
        }

        public async Task OpenFile()
        {
            await Task.Delay(100);
            try 
            { 
                _fileStream= new FileStream(_FileName, FileMode.Open , FileAccess.Read);
                _fileReader= new StreamReader(_fileStream);
            } 
            catch(IOException) 
            {
                throw new IOException("Error al abrir el archivo");
            }
           
        }

        public async Task OpenOrCreateFile()
        {
            await Task.Delay(100);  
            try
            {
                _fileStream = new FileStream(_FileName, FileMode.OpenOrCreate, FileAccess.Write);
                _fileWriter = new StreamWriter(_fileStream);
            }
            catch(IOException)
            {
                throw new IOException("Error al abrir el archivo");
            }
        }

        public async Task ReadFile()
        {
            await Task.Delay(100);
            File.WriteAllText("Lectura.txt",_FileName);
        }
    }
}
