using CV_Parser_using_NLP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CV_Parser_using_NLP.Engine
{
    class Parser
    {
        public string Directory { get; set; }

        static TrainingData trainingData;
        RequirementData requirementData;

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

        public void InitializeRequirementData(string skills, string experience, string education)
        {
            List<string> skillsListTemp = skills.ToUpper().Split(
                        new[] {","},
                        StringSplitOptions.None).ToList();

            List<string> skillsList = new List<string>();
            foreach(var skill in skillsListTemp)
            {
                skillsList.Add(skill.Trim());
            }

            List<string> experienceListTemp = experience.ToUpper().Split(
                        new[] { "\r\n", "\r", "\n", " ", "," },
                        StringSplitOptions.None).ToList();

            List<string> experienceList = new List<string>();
            foreach (var exp in experienceListTemp)
            {
                experienceList.Add(exp.Trim());
            }

            List<string> educationListTemp = education.ToUpper().Split(
                        new[] { "\r\n", "\r", "\n", " ", "," },
                        StringSplitOptions.None).ToList();

            List<string> educationList = new List<string>();
            foreach (var edu in educationListTemp)
            {
                educationList.Add(edu.Trim());
            }
            requirementData = new RequirementData(skillsList, experienceList, educationList);
        }


        public Queue<CVData> InitializeCVData(Dictionary<string, List<string>> EntireCVContent)
        {
            try
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
                    foreach (var item in cvData.Value)
                    {
                        CVDataInDictionary.Add(item);
                    }

                    for (int i = 0; i < CVDataInDictionary.Count; i++)
                    {
                        string item = CVDataInDictionary.ElementAt(i);
                        if (trainingData.SkillDictionary.Contains(item))
                        {
                            data.SkillDictionary.Add(item);
                        }

                        if (trainingData.ExperienceDictionary.Contains(CVDataInDictionary[i]))
                        {
                            var isNumeric = double.TryParse(CVDataInDictionary[i], out double n);
                            if (isNumeric)
                            {
                                if (CVDataInDictionary[i + 1].Equals("MONTH")
                                    || CVDataInDictionary[i + 1].Equals("MONTHS"))
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

                        if (trainingData.EducationDictionary.Contains(CVDataInDictionary[i]))
                        {
                            data.EducationDictionary.Add(CVDataInDictionary[i]);
                        }                        
                    }
                    CVDataQueue.Enqueue(data);                   
                }
                return CVDataQueue;
            }
            catch (Exception ex)
            {
                Helper.ShowError(ex.Message);
            }
            return null;
        }      

        public Dictionary<string, List<string>> GetPDFFilesData()
        {           
            Dictionary<string, List<string>> EntireCVData = Helper.GetPDFFilesData(Directory);
            if(EntireCVData != null)return EntireCVData;                  
            return null;            
        }

        public Dictionary<string, double> CompareCVDataToRequiredData(Queue<CVData> cvData)
        {
            try
            {
                Dictionary<string, double> scoreDictionary = new Dictionary<string, double>();
                foreach (var cvdata in cvData)
                {
                    double skillSimilarity= Helper.GetSimilarityPercentage(cvdata.SkillDictionary, requirementData.SkillDictionary);
                    double educationSimilarity = Helper.GetSimilarityPercentage(cvdata.EducationDictionary, requirementData.EducationDictionary);
                    double experienceSimilarity = Helper.GetSimilarityPercentage(cvdata.ExperienceDictionary, requirementData.ExperienceDictionary);
                    if (skillSimilarity != -1 && educationSimilarity != -1 && experienceSimilarity != -1)
                    {
                        double weightedSkillScore = skillSimilarity * 0.6;
                        double weightedEducationScore = educationSimilarity * 0.2;
                        double weightedExperienceScore = experienceSimilarity * 0.2;
                        double weightedFinalrankScore = weightedSkillScore + weightedEducationScore + weightedExperienceScore;
                        scoreDictionary.Add(cvdata.Name, weightedFinalrankScore);
                    }                   
                }
                return scoreDictionary;
            }
            catch(Exception ex)
            {
                Helper.ShowError(ex.Message);
            }
            return null;
        }

        public Dictionary<string, double> RankCVs(Dictionary<string, double> scores)
        {
            try
            {
                Dictionary<string, double> finalDictionary = new Dictionary<string, double>();

                var results = scores.ToList();
                results.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
                
                foreach(var item in results)
                {
                    var name = item.Key;
                    var score = item.Value;
                    var filename = name.Replace(@"C:\Windows\Temp\temp\", "");
                    var PDFFileName = filename.Replace(".txt", ".pdf");
                    finalDictionary.Add(PDFFileName, score);
                }
                return finalDictionary;
            }
            catch(Exception ex)
            {
                Helper.ShowError(ex.Message);
            }
            return null;
        }

        public void DisplayRankedCVs(Dictionary<string, double> rankedCVs, DataGridView table)
        {
            table.Rows.Clear();
            table.Refresh();
            var CVs= rankedCVs.Keys.ToList();
            for(int i=0; i< CVs.Count; i++)
            {
                table.Rows.Add();
                int index = Helper.GetEmptyRowIndex(table);
                table.Rows[index].Cells[0].Value = (i+1).ToString();
                table.Rows[index].Cells[1].Value = CVs[i];
            }
        }
    }
}
