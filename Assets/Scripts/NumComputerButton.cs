using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumComputerButton : MonoBehaviour
{
    public string number = "0";
    public NumComputerPanel panel;

    private Sprite numSprite;

    private void Start()
    {
        numSprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }

    public void OnMouseDown()
    {
        panel.AddSymbol(number, numSprite);
    }
}
