using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerButton : MonoBehaviour
{
    public bool isPressed = false;
    
    [SerializeField] private Material downMaterial;
    [SerializeField] private Material upMaterial;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnMouseDown()
    {
        isPressed = !isPressed;

        meshRenderer.material = isPressed ? downMaterial : upMaterial;
    }
}
