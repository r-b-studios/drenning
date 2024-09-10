using UnityEngine;

public class Set
{
    public float Reps { get; set; }
    public float Time { get; set; }
    public float Weight { get; set; }

    public Set(float reps, float time, float weight)
    {
        Reps = reps;
        Time = time;
        Weight = weight;
    }
}