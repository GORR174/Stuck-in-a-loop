﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPanel : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, 0);
    }
}
