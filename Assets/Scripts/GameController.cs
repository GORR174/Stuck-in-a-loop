using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIHelpText uiHelpText;
    private static UIHelpText staticHelpText;

    [SerializeField] private List<Teleport> teleport;
    
    void Start()
    {
        staticHelpText = uiHelpText;
        teleport[new System.Random().Next(teleport.Count)].isRight = true;
    }

    public static void SetHelpText(string text)
    {
        staticHelpText.helpText = text;
    }
}
