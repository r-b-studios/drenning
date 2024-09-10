using UnityEngine;
using System;

public class TrainingList : MonoBehaviour
{
    [SerializeField]
    private GameObject trainingMenu, listObject;

    private void Start()
    {
        var y = (scrollContent.sizeDelta.y - headSpace) / 2f;

        foreach (var t in Manager.Trainings)
        {
            var instance = Instantiate(listObject, scrollContent);
            instance.GetComponent<ListButton>().SetLabel(t.Name, t.Date);

            var rect = instance.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, y);
            y -= rect.sizeDelta.y + space;
        }
    }

    public void AddTraining()
    {
        var now = DateTime.Now;
        var trg = new Training(now, "Training am " + now.ToShortDateString(), now.Ticks.ToString());
        Manager.Trainings.Add(trg);

        FileManager.SaveTrainings(Manager.Trainings);

        Manager.Instance.ChangeWindow(trainingMenu);
    }
}