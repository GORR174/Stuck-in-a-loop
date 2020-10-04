using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public List<Text> menuTexts;

    private string savedCurrent;
    private int currentId = 0;
    
    void Start()
    {
        savedCurrent = menuTexts[0].text;
        menuTexts[0].text = "> " + savedCurrent + " <";
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            switch (currentId)
            {
                case 0:
                    SceneManager.LoadScene("GameScene");
                    return;
                case 1:
                    Application.Quit();
                    return;
            }
        }
        
        if (!Input.GetButtonDown("Vertical"))
            return;
        
        var verticalInput = Input.GetAxis("Vertical");

        var nextId = (int) (currentId - verticalInput);
        
        if (nextId < 0)
            nextId = 0;
        if (nextId >= menuTexts.Count)
            nextId = menuTexts.Count - 1;

        if (currentId != nextId)
        {
            menuTexts[currentId].text = savedCurrent;
            savedCurrent = menuTexts[nextId].text;
            menuTexts[nextId].text = "> " + savedCurrent + " <";
            currentId = nextId;
        }
    }
}
