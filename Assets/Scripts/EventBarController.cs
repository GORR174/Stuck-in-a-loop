using System;
using UnityEngine;

public class EventBarController : MonoBehaviour
{
    [SerializeField] private MeshRenderer foregroundRenderer;
    [SerializeField] private MeshRenderer backgroundRenderer;
    [SerializeField] private GameObject foregroundObject;
    [SerializeField] private GameObject target;

    private void Update()
    {
        transform.position = target.transform.position + Vector3.up * 0.66f;
    }

    public void SetVisible(bool isVisible)
    {
        foregroundRenderer.enabled = isVisible;
        backgroundRenderer.enabled = isVisible;
    }

    public void SetProgress(float progress)
    {
        foregroundObject.transform.localScale = new Vector3(progress, 1, 1);
        
    }
}
