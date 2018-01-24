using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Parser_using_NLP.Data
{
    class RequirementData
    {
        public List<string> SkillDictionary { get; set; }
            = new List<string>();

        public List<string> ExperienceDictionary { get; set; }
            = new List<string>();

        public List<string> EducationDictionary { get; set; }
            = new List<string>();


        public RequirementData(List<string> SkillDictionary,
            List<string> ExperienceDictionary,
            List<string> EducationDictionary)
        {
            this.SkillDictionary = SkillDictionary;
            this.ExperienceDictionary = ExperienceDictionary;
            this.EducationDictionary = EducationDictionary;
        }
    }
}
