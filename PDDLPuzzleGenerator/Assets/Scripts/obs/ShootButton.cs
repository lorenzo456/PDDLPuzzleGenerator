using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour
{
    public bool green;
    public bool completed;
    public ShootButton previousButton;
    public ShootButton nextButton;
    ShootWall shootWall;
    Renderer myRenderer;

    public void Start()
    {
        shootWall = GetComponentInParent<ShootWall>();
        myRenderer = GetComponent<Renderer>();
        myRenderer.material.color = Color.red;
        if (previousButton == null)
        {
            myRenderer.material.color = Color.green;
            green = true;
        }
    }

    public void ResetButton()
    {
        green = false;
        completed = false;
        myRenderer.material.color = Color.red;
        if (previousButton == null)
        {
            myRenderer.material.color = Color.green;
            green = true;
        }
    }

    public void ResetAll()
    {
        shootWall.ResetAll();
    }

    public void OnHit()
    {
        if (green)
        {
            green = false;
            completed = true;
            if (nextButton)
            {
                nextButton.green = true;
                nextButton.myRenderer.material.color = Color.green;
                myRenderer.material.color = Color.black;
            }
            else
            {
                shootWall.completed = true;
                shootWall.gameObject.SetActive(false);
            }
        }
        else
        {
            shootWall.ResetAll();
        }
    }
}
