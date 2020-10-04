using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NumComputerPanel : MonoBehaviour
{
    public Transform target;
    public List<SpriteRenderer> passSprites;
    public Sprite starSprite;

    public string password = "";
    public string correctPassword = "2816";

    public bool isCorrect = false;

    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, 0);
    }

    public void AddSymbol(string symbol, Sprite symbolSprite)
    {
        if (isCorrect)
            return;
        passSprites[password.Length].sprite = symbolSprite;

        password += symbol;
        if (password.Length == correctPassword.Length)
        {
            if (password == correctPassword)
            {
                isCorrect = true;
            }
            else
            {
                Reset();
            }
        }
    }

    public void Reset()
    {
        passSprites.ForEach(spriteRenderer => spriteRenderer.sprite = starSprite);
        password = "";
    }
}
