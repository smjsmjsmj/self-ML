using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyML.Service
{
    public class ResolveData<T> where T : new()
    {
        public List<T> GetData(string path)
        {
            string[] para = null;
            string line = "";
            List<T> list = new List<T>();
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader r = new StreamReader(fs))
                {
                    while ((line = r.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }
                        line=line.Trim();
                        para = line.Split(',');                    
                        Type type = typeof(T);
                        var fields = type.GetProperties();
                        T t = new T();
                        for (var i = 0; i < 3; i++)
                        {
                            fields[i].SetValue(t, para[i]);
                        }
                        list.Add(t);
                    }
                }
            }
            return list;
        }
    }
}
