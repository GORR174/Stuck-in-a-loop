using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    [SerializeField] private bool isTriggered;
    [SerializeField] private List<ComputerButton> rightButtons;
    [SerializeField] private List<ComputerButton> allButtons;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject computer;
    [SerializeField] private GameObject doors;
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
                if (rightButtons.Count(button => button.isPressed) == rightButtons.Count && allButtons.Count(button => button.isPressed) == rightButtons.Count)
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
        
        foreach (var computerButton in allButtons.Where(button => button.isPressed))
        {
            computerButton.OnMouseDown();
        }
    }
    
    private void CompleteEvent()
    {
        computer.SetActive(false);
        isEventStarted = false;
        playerController.canMove = true;
        audioSource.clip = audioClip;
        audioSource.Play();
        Destroy(doors);
        GameController.SetHelpText("");
        Destroy(this);
    }
    
    private void CancelEvent()
    {
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
