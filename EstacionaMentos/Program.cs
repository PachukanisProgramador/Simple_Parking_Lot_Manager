using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionaMentos
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

                
            try
                {
                    
                    menu.Executar();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Algo de errado não está certo!\n\n{e}");
                    throw;
                }


        }
    }
}
