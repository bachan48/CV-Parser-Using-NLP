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

        public Parser(string Directory)
        {
            this.Directory = Directory;
        }

        public static void InitializeTrainingData()
        {
            List<string> SkillDictionary = new List<string>();
            List<string> ExperienceDictionary = new List<string>();
            List<string> EducationDictionary = new List<string>();
            Helper.AddDataFromResource(SkillDictionary, "skills");
            Helper.AddDataFromResource(ExperienceDictionary, "experience");
            Helper.AddDataFromResource(EducationDictionary, "education");
            trainingData = new TrainingData(SkillDictionary, ExperienceDictionary, EducationDictionary);
        }

        public void InitializeRequirementData(string skills, string education, string experience)
        {
            List<string> skillsList = skills.Split(new char[] { ',' }).ToList();
            List<string> educationList = education.Split(new char[] { ',' }).ToList();
            List<string> experienceList = experience.Split(new char[] { '\n' }).ToList();
            requirementData = new RequirementData(skillsList, educationList, experienceList);
        }


        public Queue<CVData> InitializeCVData(Dictionary<string, List<string>> EntireCVContent)
        {
            Queue<CVData> CVDataQueue = new Queue<CVData>();

            foreach (var cvData in EntireCVContent)
            {
                List<string> SkillDictionary = new List<string>();
                List<string> EducationDictionary = new List<string>();
                List<string> ExperienceDictionary = new List<string>();
                string name = cvData.Key;

                CVData data = new CVData(SkillDictionary, ExperienceDictionary, EducationDictionary, name);

                List<string> CVDataInDictionary = new List<string>();
                foreach(var item in cvData.Value)
                {
                    CVDataInDictionary.Add(item);
                }                
                
                for (int i= 0; i<CVDataInDictionary.Count; i++)
                {
                    string item = CVDataInDictionary.ElementAt(i);
                    if (trainingData.SkillDictionary.Contains(item))
                    {
                        data.SkillDictionary.Add(item);
                    }

                    if (trainingData.ExperienceDictionary.Contains(CVDataInDictionary[i]))
                    {
                        var isNumeric = int.TryParse(CVDataInDictionary[i], out int n);
                        if (isNumeric)
                        {
                            if (CVDataInDictionary[i + 1].Equals("MONTH")
                                || CVDataInDictionary[i + 1].Equals("MOTNHS"))
                            {
                                n = n / 12;
                                data.ExperienceDictionary.Add(n.ToString());
                            }
                            else if (CVDataInDictionary[i + 1].Equals("YEAR")
                                || CVDataInDictionary[i + 1].Equals("YEARS"))                                
                            {
                                data.ExperienceDictionary.Add(n.ToString());
                            }
                        }
                    }
                }
                CVDataQueue.Enqueue(data);

                Console.WriteLine("SKILLL TEST CV: "+name);
                foreach (var skill in data.SkillDictionary)
                {
                    Console.WriteLine(skill);
                }
                Console.WriteLine("EXPERIENCE TEST CV: "+name);
                foreach (var skill in data.ExperienceDictionary)
                {
                    Console.WriteLine(skill);
                }
            }
            return CVDataQueue;
        }

        public Dictionary<string, List<string>> GetPDFFilesData()
        {
            Dictionary<string, List<string>> EntireCVData= Helper.GetPDFFilesData(Directory);
            return EntireCVData;
        }

    }
}
