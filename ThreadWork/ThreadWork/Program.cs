using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadWork
{
    class Program
    {
        static void Main(string[] args)
        {
            long i;
            String s = "123;456;789;987;654;321;456;789;456;987;654;123;456;987;456;321;22";
            List<String> tempLinq = (from S in s.Split(';').ToList()
                                     where S.StartsWith("1")
                                     where S.Length ==3
                                     where Int64.TryParse(S, out i)
                                     select S).ToList(); 
        }
    }
}
