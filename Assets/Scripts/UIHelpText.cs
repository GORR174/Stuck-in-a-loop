using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelpText : MonoBehaviour
{
    [SerializeField] private Text text; 
    [SerializeField] private Text text2;
    public string helpText;
    
    void Update()
    {
        if (text.text != helpText)
        {
            text.text = helpText;
            text2.text = helpText;
        }
    }
}
