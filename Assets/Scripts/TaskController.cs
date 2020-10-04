using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskController : MonoBehaviour
{
    [SerializeField] private bool isTriggered;
    private GameObject playerObj;
    private GameObject eventBar;
    private EventBarController eventBarController;
    private PlayerController playerController;

    [SerializeField] private float eventCompleteTime = 3;
    private float eventTime = 0;
    
    public readonly float TimeToRefill = 90;
    public float lifeTime = 90;

    private bool isEventStarted = false;

    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        eventBar = GameObject.FindWithTag("EventBar");
        eventBarController = eventBar.GetComponent<EventBarController>();
        playerController = playerObj.GetComponent<PlayerController>();
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        
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
                eventTime += Time.deltaTime;
                if (eventTime >= eventCompleteTime)
                {
                    CompleteEvent();
                }
                else
                {
                    eventBarController.SetProgress(eventTime / eventCompleteTime);
                }
            }
        }
    }

    private void StartEvent()
    {
        eventBar.SetActive(true);
        isEventStarted = true;
        playerController.canMove = false;
        eventBarController.SetVisible(true);
        eventTime = 0f;
        GameController.SetHelpText("Press 'Esc' to cancel the action");
    }
    
    private void CompleteEvent()
    {
        isEventStarted = false;
        playerController.canMove = true;
        eventBarController.SetVisible(false);
        eventTime = 0f;
        lifeTime = TimeToRefill;
        GameController.SetHelpText(isTriggered ? "Press 'E' to cool the reactor" : "");
    }
    
    private void CancelEvent()
    {
        isEventStarted = false;
        playerController.canMove = true;
        eventBarController.SetVisible(false);
        eventTime = 0f;
        GameController.SetHelpText(isTriggered ? "Press 'E' to cool the reactor" : "");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            GameController.SetHelpText(isTriggered ? "Press 'E' to cool the reactor" : "");
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
