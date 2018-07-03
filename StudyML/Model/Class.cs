using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyML.Model
{
    public class Class
    {
        public Class()
        {

        }
        public string Number { set; get; }
        public string SubjectName { set; get; }

        public string ClassName { set; get; }

        public List<string> Segment { set; get; }
    }
}
