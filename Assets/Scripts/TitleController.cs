using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Event") || Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
