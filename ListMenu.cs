using UnityEngine;
using UnityEngine.UI;

public class ListMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransform scrollView, scrollContent, headBar;
    [SerializeField]
    private Button returnButton;
    [SerializeField]
    private GameObject listObject, previousMenu;
    [SerializeField]
    private float space;

    private void Start()
    {
        var headSpace = headBar.GetComponent<RectTransform>().sizeDelta.y;

        scrollView.sizeDelta = Manager.Canvas.sizeDelta - new Vector2(0, headSpace + space);
        scrollView.anchoredPosition = new Vector2(scrollContent.anchoredPosition.x, -(headSpace + space) / 2f);

        scrollContent.sizeDelta = new Vector2(scrollContent.sizeDelta.x, Mathf.Max(headSpace * Manager.Trainings.Count, scrollContent.sizeDelta.y));


        var headY = (Manager.Canvas.sizeDelta.y - headBar.sizeDelta.y) / 2f;
        headBar.anchoredPosition = new Vector2(headBar.anchoredPosition.x, headY);

        var y = (scrollContent.sizeDelta.y - headSpace) / 2f;

        foreach (var t in Manager.Trainings)
        {
            var instance = Instantiate(listObject, scrollContent);
            instance.GetComponent<ListButton>().SetLabel(t.Name, t.Date);

            var rect = instance.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, y);
            y -= rect.sizeDelta.y + space;
        } 

        returnButton.onClick.AddListener(() =>
        {
            Manager.Instance.ChangeWindow(previousMenu);
        });
    }
}