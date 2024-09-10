using UnityEngine;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    internal static Manager Instance { get; private set; }
    internal static RectTransform Canvas { get; private set; }
    internal static List<Training> Trainings { get; private set; }
    private GameObject Window { get; set; }

    [SerializeField] 
    private GameObject startWindow;

    [SerializeField] 
    private RectTransform canvas;

    private void Start()
    {
        Trainings = FileManager.GetTrainings();
        Instance = this;
        Canvas = canvas;
        Window = Instantiate(startWindow, canvas);
    }

    internal void ChangeWindow(GameObject newWindow)
    {
        var w = Instantiate(newWindow, canvas);
        Destroy(Window);
        Window = w;
    }
}