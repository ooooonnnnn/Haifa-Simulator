using System;
using TMPro;
using UnityEngine;

public class DisplayNumericValue : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private string format;
    [SerializeField] private MonoBehaviour source;

    private void OnValidate()
    {
        if (!source) return;
        if (source is not INumericProperty numericProperty)
        {
            Debug.LogWarning("Source doesn't implement INumericProperty");
            source = null;
            return;
        }

        if (!text) return;
        DisplayValue(numericProperty.GetNumericPropertyValue());
    }
    
    public void DisplayValue(float value)
    {
        text.text = string.Format(format, value);
    }
}
