using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testStringFormat
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
               String a =  String.Format("{0},{1}", "d", "c", "v");
               Console.WriteLine(a);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
