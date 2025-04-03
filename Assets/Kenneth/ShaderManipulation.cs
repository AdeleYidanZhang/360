using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShaderManipulation : MonoBehaviour
{
    public Material outlineCreator;
    public Texture2D interactible;
    public bool isInRange;

    private void Start()
    {
        outlineCreator.SetTexture("_MainTex", interactible);
    }

    private void Update()
    {
        if (isInRange)
        {
            outlineCreator.SetInt("_Outline", 1);
        }
        if (!isInRange)
        {
            outlineCreator.SetInt("_Outline", 0);
        }
    }
}
