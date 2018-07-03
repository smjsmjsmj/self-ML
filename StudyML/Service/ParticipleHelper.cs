using JiebaNet.Segmenter;
using StudyML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyML.Service
{
    public class ParticipleHelper
    {
        public List<Class> Participle(List<Class> list)
        {
            var segmenter = new JiebaSegmenter();
            list =list.Select(m=>
            {
                var dto = m;
                dto.Segment=segmenter.Cut(dto.ClassName, cutAll: true).ToList();
                return dto;
            }).ToList();
            return list;
        }

        public string Check(List<Class> list,string seg)
        {
            var segmenter = new JiebaSegmenter();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            var para= segmenter.Cut(seg, cutAll: true).ToList();
            int count = 0,maxcount=0;
            string subjectName = "";
            foreach (var item in list)
            {
                count = CheckSegment(item.Segment, para);
                if (count > maxcount)
                {
                    subjectName = item.SubjectName;
                    maxcount = count;
                }else if (count == maxcount)
                {
                    if (dictionary.ContainsKey(item.SubjectName))
                    {
                        var val=dictionary[item.SubjectName];
                        dictionary[item.SubjectName]=val + count;
                    }
                    else
                    {
                        dictionary.Add(item.SubjectName, count);
                    }
                }
            }

            return subjectName;
        }
        private int CheckSegment(List<string> list,List<string> segList)
        {
            int sum = 0;
            list.ForEach(m =>
            {
                segList.ForEach(q =>
                {
                    if (m == q)
                    {
                        sum++;
                    }
                });
            });
            return sum;
        }



    }
}
