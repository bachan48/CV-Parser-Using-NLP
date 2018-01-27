using System.Collections.Generic;

namespace CV_Parser_using_NLP.Data
{
    class TrainingData
    {
        public List<string> SkillDictionary { get; set; }
            = new List<string>();

        public List<string> ExperienceDictionary { get; set; }
            = new List<string>();

        public List<string> EducationDictionary { get; set; }
            = new List<string>();


        public TrainingData(List<string> SkillDictionary, 
            List<string> ExperienceDictionary,
            List<string> EducationDictionary)
        {
            this.SkillDictionary = SkillDictionary;
            this.ExperienceDictionary = ExperienceDictionary;
            this.EducationDictionary = EducationDictionary;
        }
    }
}
