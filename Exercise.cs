using System.Collections.Generic;
using UnityEngine;

public class Exercise
{
    public string Name { get; set; }
    public bool CountReps { get; set; }
    public bool CountTime { get; set; }
    public bool CountWeight { get; set; }
    public List<Set> Sets { get; private set; } = new();
    
    public Exercise(string name, bool countReps, bool countTime, bool countWeight, params Set[] sets)
    {
        CountReps = countReps;
        CountTime = countTime;
        CountWeight = countWeight;
        Name = name;
        Sets.AddRange(sets);
    }
}