using UnityEngine;
using System.Collections.Generic;
using System;

internal class Training
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }
    public List<Exercise> Exercises { get; private set; } = new();

    public Training(DateTime date, string name, string id, params Exercise[] exercises)
    {
        Date = date;
        Name = name;
        Id = id;
        Exercises.AddRange(exercises);
    }
}