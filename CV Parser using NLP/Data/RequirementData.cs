using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Parser_using_NLP.Data
{
    class RequirementData
    {
        public List<Object> SkillDictionary { get; set; }
            = new List<Object>();

        public List<Object> ExperienceDictionary { get; set; }
            = new List<Object>();

        public List<Object> EducationDictionary { get; set; }
            = new List<Object>();


        public RequirementData(List<Object> SkillDictionary,
            List<Object> ExperienceDictionary,
            List<Object> EducationDictionary)
        {
            this.SkillDictionary = SkillDictionary;
            this.ExperienceDictionary = ExperienceDictionary;
            this.EducationDictionary = EducationDictionary;
        }
    }
}
