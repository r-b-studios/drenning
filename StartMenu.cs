using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject TrainingList;

    public void ViewTrainingList()
    {
        Manager.Instance.ChangeWindow(TrainingList);
    }
}