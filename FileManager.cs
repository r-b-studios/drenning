using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;
using System.Collections.Generic;

internal static class FileManager
{
    private static string Location => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\training_data";

    public static List<Training> GetTrainings()
    {
        var trainings = new List<Training>();

        if (Directory.Exists(Location))
        {
            foreach (var file in Directory.GetFiles(Location))
            {
                Debug.Log(file);

                try
                {
                    var xDoc = XDocument.Load(file);
                    var exercises = new List<Exercise>();

                    foreach (var ex in xDoc.Element("training").Elements("exercise"))
                    {
                        var sets = new List<Set>();

                        foreach (var s in ex.Elements("set"))
                        {
                            sets.Add(new Set(
                                float.Parse(s.Attribute("reps").Value),
                                float.Parse(s.Attribute("time").Value),
                                float.Parse(s.Attribute("weight").Value)
                            ));
                        }

                        exercises.Add(new Exercise(
                            ex.Attribute("name").Value,
                            bool.Parse(ex.Attribute("countReps").Value),
                            bool.Parse(ex.Attribute("countTime").Value),
                            bool.Parse(ex.Attribute("countWeight").Value),
                            sets.ToArray()
                        ));
                    }

                    var date = new DateTime(long.Parse(xDoc.Element("training").Attribute("date").Value));
                    var name = xDoc.Element("training").Attribute("name").Value;
                    var id = new Stack<string>(file.Split('\\')).Peek().Replace(".training", "");
                    trainings.Add(new Training(date, name, id, exercises.ToArray()));
                }
                catch (Exception ex)
                {
                    Debug.Log("!!!!! - - - " + ex.Message);
                }
            }
        }

        return trainings;
    }

    public static void SaveTrainings(List<Training> trainings)
    {
        foreach (var t in trainings)
        {
            try
            {
                var tn = new XElement("training",
                    new XAttribute("date", t.Date.Ticks),
                    new XAttribute("name", t.Name)
                );

                foreach (var e in t.Exercises)
                {
                    var en = new XElement("exercise",
                        new XAttribute("name", e.Name),
                        new XAttribute("countReps", e.CountReps),
                        new XAttribute("countTime", e.CountTime),
                        new XAttribute("countWeight", e.CountWeight)
                    );

                    foreach (var s in e.Sets)
                    {
                        en.Add(new XElement("set",
                            new XAttribute("reps", s.Reps),
                            new XAttribute("time", s.Time),
                            new XAttribute("weight", s.Weight)
                        ));
                    }

                    tn.Add(en);
                }

                new XDocument(tn).Save($@"{Location}\{t.Id}.training");
            }
            catch (Exception ex)
            {
                Debug.Log("!!!!! - - - " + ex.Message);
            }
        }
    }
}