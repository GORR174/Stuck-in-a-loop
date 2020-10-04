using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalComputerController : MonoBehaviour
{
    [SerializeField] private bool isTriggered;
    [SerializeField] private NumComputerPanel panel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject computer;
    [SerializeField] private GameObject doors;
    [SerializeField] private TaskController task1;
    [SerializeField] private TaskController task2;
    private GameObject playerObj;
    private PlayerController playerController;

    private bool isEventStarted = false;

    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        playerController = playerObj.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isTriggered && Input.GetButtonDown("Event"))
        {
            StartEvent();
        }

        if (isEventStarted)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                CancelEvent();
            }
            else
            {
                if (panel.isCorrect)
                {
                    CompleteEvent();
                }
            }
        }
    }

    private void StartEvent()
    {
        computer.SetActive(true);
        isEventStarted = true;
        playerController.canMove = false;
        GameController.SetHelpText("Press 'Esc' to cancel the action");
    }
    
    private void CompleteEvent()
    {
        computer.SetActive(false);
        isEventStarted = false;
        playerController.canMove = true;
        audioSource.clip = audioClip;
        audioSource.Play();
        Destroy(doors);
        Destroy(task1);
        Destroy(task2);
        GameController.SetHelpText("Find the exit");
        Destroy(this);
    }
    
    private void CancelEvent()
    {
        panel.Reset();
        computer.SetActive(false);
        isEventStarted = false;
        playerController.canMove = true;
        GameController.SetHelpText(isTriggered ? "Press 'E' to open computer" : "");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            GameController.SetHelpText("Press 'E' to open computer");
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
