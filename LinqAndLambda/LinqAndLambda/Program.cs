using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndLambda
{
    class Program
    {
        static void Main(string[] args)
        {

            String[] sArray = new String[] 
            { "Jack", "Mario", "Caspar", "Mathon", "Harry", "Bob" };

            var sListByLinqSelect1 = (from s in sArray
                                      where s.StartsWith("C")
                                      select s).ToList();
            var sListByLinqSelect2 = sArray.Where(s => s.StartsWith("C")).ToList();

            var sListByLinqSelect3 = (from s in sArray
                                      where s.Length > 3
                                      orderby s.Length
                                      select s.Substring(3)).ToList();
            var sListByLinqSelect4 = sArray.Where(s => s.Length > 3)
                                            .OrderBy(s => s.Length)
                                            .Select(s => s.Substring(3)).ToList();

            var sListByLinqOrderby1 = (from s in sArray
                                       orderby s.Length
                                       select s).ToList();

            var sListByLinqGroupby1 = (from s in sArray
                                       group s by s.Length /*into testGroup
                                       select new { testGroup.Key,a = testGroup.Count()}*/
                                       ).ToList();

            String[] sNumberArray = new string[] { "2", "4", "356", "546", "123", "45653", "12312", "40404" };
            String[] sArray1 = new String[] { "Jack", "Mario", "Caspar", "Mathon", "Harry", "Bob" };

            var useLambda = sArray1.Where((s) => s.Length > 3).ToList();

            var joinKeyWordLinqTest = (from s1 in sNumberArray
                                       join s2 in sArray1
                                       on s1.GetType() equals "s".GetType()
                                       select s1).ToArray();

            //var unUseKeyWordLet = (from number in (from s in sNumberArray
            //                                       select Convert.ToInt32(s)).ToArray<Int32>()
            //                      where number>10
            //                      select number*((from numberTemp in 
            //                                            (from s in sNumberArray
            //                                             select Convert.ToInt32(s)).ToArray<Int32>()
            //                                       select numberTemp
            //                                             ).ToArray().Count())).ToArray();
            var numbers = (from s in sNumberArray
                           select Convert.ToInt32(s)).ToArray<Int32>();
            var numbersByLinq = (from number in numbers
                                 let countNumber = (from numberTemp in numbers
                                                    select numberTemp).ToArray().Count()
                                 where number > 10
                                 select number * countNumber).ToArray();

            var list1 = new List<LinqTest>() { new LinqTest() { data1 = 1, data2 = "123" },
                                                 new LinqTest() {data1 = 2,data2 = "234"},
                                                 new LinqTest() {data1 = 3,data2 = "345"}};
            var list2 = new List<LinqTest>() { new LinqTest() { data1 = 4, data2 = "456" },
                                                 new LinqTest() {data1 = 2,data2 = "234"},
                                                 new LinqTest() {data1 = 3,data2 = "345"}};
            var useJoinWithClass = (from linqTest1 in list1
                                    join linqTest2 in list2
                                        on linqTest1.data1 equals linqTest2.data1
                                    select linqTest1.data2).ToList();
            var useDoubleFrom = (from linqTest1 in list1
                                 from linqTest2 in list2
                                 where linqTest1.data1 > 1
                                 where linqTest2.data1 > 2
                                 select new
                                 {
                                     list1Data1 = linqTest1.data1,
                                     list2Data2 = linqTest2.data2
                                 }).ToList();

            String[] sArray2 = new string[] { "a", "b", "c", "d", "e" };
            const String testStr = "a";
            var listDeferredTest = sArray2.Where(s => s.ToString() != testStr);
            listDeferredTest = listDeferredTest.ToList();


        }
    }

    class LinqTest
    {
        public int data1 { get; set; }
        public String data2 { get; set; }
    }
}
