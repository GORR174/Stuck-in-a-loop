using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform endPoint;
    public Transform startPoint;
    public bool isRight = false;

    [SerializeField] private bool isTriggered;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private GameObject playerObj;
    private PlayerController playerController;

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
    }

    private void StartEvent()
    {
        GameController.SetHelpText("");
        
        var playerPosition = playerObj.transform.position;
        if (isRight)
        {
            var position = endPoint.transform.position;
            playerObj.transform.position = new Vector3(position.x, position.y, playerPosition.z);
        }
        else
        {
            var position = startPoint.transform.position;
            playerObj.transform.position = new Vector3(position.x, position.y, playerPosition.z);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            GameController.SetHelpText("Press 'E' to teleport");
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
