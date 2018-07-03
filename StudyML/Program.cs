using JiebaNet.Segmenter;
using StudyML.Model;
using StudyML.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudyML
{
    class Program
    {
        static void Main(string[] args)
        {
            string path=Path.Combine(Environment.CurrentDirectory, @"Data\data.txt");
            var list = new ResolveData<Class>().GetData(path);
            var p = new ParticipleHelper();
            list =p.Participle(list);
            Console.WriteLine(p.Check(list, "数据结构"));
            Console.ReadKey();
        }
    }
}
