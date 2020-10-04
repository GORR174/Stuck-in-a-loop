using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxButtonDoors : MonoBehaviour
{
    [SerializeField] private List<BoxButton> boxButtons;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private bool isDoorClosed = true;
    
    void Update()
    {
        if (boxButtons.Where(button => button.isTriggered).ToList().Count == boxButtons.Count)
        {
            if (isDoorClosed)
            {
                isDoorClosed = false;
                audioSource.clip = audioClip;
                audioSource.Play();
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (!isDoorClosed)
            {
                isDoorClosed = true;
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
}
