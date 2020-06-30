using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootWall : MonoBehaviour
{
    public List<ShootButton> shootButtons = new List<ShootButton>();
    public bool completed;

    private void Start()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            shootButtons.Add(gameObject.transform.GetChild(i).GetComponent<ShootButton>());
        }
    }

    public void ResetAll()
    {
        foreach(ShootButton shootButton in shootButtons)
        {
            shootButton.ResetButton();
        }
    }

}
