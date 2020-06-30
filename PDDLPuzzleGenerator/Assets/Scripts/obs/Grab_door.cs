using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_door : MonoBehaviour
{
    public List<platform_grab> platforms = new List<platform_grab>();
    public GameObject door;
    public void CheckPlatforms()
    {
        foreach(platform_grab platform in platforms)
        {
            if (!platform.taken)
            {
                return;
            }
        }

        Debug.Log("OPEN DOOR");
        door.SetActive(false);
    }
}
