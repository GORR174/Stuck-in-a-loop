using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRoomRestart : MonoBehaviour
{
    [SerializeField] private bool isTriggered;
    [SerializeField] private GameObject box1;
    [SerializeField] private GameObject box2;

    private bool isEventStarted = false;

    void Update()
    {
        if (isTriggered && Input.GetButtonDown("Event"))
        {
            StartEvent();
        }
    }

    private void StartEvent()
    {
        box1.transform.localPosition = new Vector3(-3.069289f, -1.038147f, 4.881315f);
        box2.transform.localPosition = new Vector3(-2.069289f, -1.038147f, 4.881315f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            GameController.SetHelpText("Press 'E' to restart puzzle");
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
