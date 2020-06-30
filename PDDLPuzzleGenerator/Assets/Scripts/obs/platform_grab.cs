using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_grab : MonoBehaviour
{
    public ColorTypes colorType;
    public bool taken;
    Renderer myRenderer;

    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (colorType == ColorTypes.Black)
        {
            myRenderer.material.color = Color.black;
        }
        else if (colorType == ColorTypes.Blue)
        {
            myRenderer.material.color = Color.blue;
        }
        else if (colorType == ColorTypes.Purple)
        {
            myRenderer.material.color = Color.cyan;
        }
    }
}
