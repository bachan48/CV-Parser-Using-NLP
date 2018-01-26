using CV_Parser_using_NLP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Parser_using_NLP.Engine
{
    class Parser
    {
        public string Directory { get; set; }

        static TrainingData trainingData;
        static RequirementData requirementData;
        static CVData CVdata;

        public Parser(string Directory)
        {
            this.Directory = Directory;
        }

        public static void InitializeTrainingData()
        {
            List<Object> SkillDictionary = new List<Object>();
            List<Object> ExperienceDictionary = new List<Object>();
            List<Object> EducationDictionary = new List<Object>();
            Helper.AddDataFromResource(SkillDictionary, "skills");
            Helper.AddDataFromResource(ExperienceDictionary, "experience");
            Helper.AddDataFromResource(EducationDictionary, "education");
            trainingData = new TrainingData(SkillDictionary, ExperienceDictionary, EducationDictionary);
        }

        public static void InitializeRequirementData(string skills, string education, string experience)
        {
            List<string> skillsList = skills.Split(new char[] { ',' }).ToList();
            List<string> educationList = education.Split(new char[] { ',' }).ToList();
            List<string> experienceList = experience.Split(new char[] { '\n' }).ToList();
            requirementData = new RequirementData(skillsList, educationList, experienceList);
        }

        public static void InitializeCVData(string skills, string education, string experience)
        {
            List<string> skillsList = skills.Split(new char[] { ',' }).ToList();
            List<string> educationList = education.Split(new char[] { ',' }).ToList();
            List<string> experienceList = experience.Split(new char[] { '\n' }).ToList();
            CVdata = new CVData(skillsList, educationList, experienceList);
        }      

        public void GetPDFFiles()
        {
            Helper.GetPDFFilesPython(Directory);
        }
    }
}
