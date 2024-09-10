using UnityEngine;
using TMPro;
using System;

public class ListButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textField;

    internal void SetLabel(string name, DateTime date)
    {
        textField.text = $"{name}\n{date.ToShortDateString()}";
    }
}