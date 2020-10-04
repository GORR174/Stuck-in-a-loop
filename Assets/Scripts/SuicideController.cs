using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuicideController : MonoBehaviour
{
    [SerializeField] private bool isTriggered;

    void Update()
    {
        if (isTriggered && Input.GetButtonDown("Event"))
        {
            StartEvent();
        }
    }

    private void StartEvent()
    {
        SceneManager.LoadScene("SuicideScene");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            GameController.SetHelpText("Press 'E' to commit suicide");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            GameController.SetHelpText("");
        }
    }
}
