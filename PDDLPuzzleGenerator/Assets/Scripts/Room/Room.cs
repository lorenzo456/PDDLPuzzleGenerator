using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool north;
    public bool east;
    public bool south;
    public bool west;

    public Door northDoor;
    public Door eastDoor;
    public Door southDoor;
    public Door westDoor;

    public float units = 5;
    public Transform elementPlacement;

    public void RemoveDoor()
    {

        //if (!north)
        //{
        //    northDoor.SetActive(false);
        //}

        //if (!east)
        //{
        //    eastDoor.SetActive(false);
        //}

        //if (!south)
        //{
        //    southDoor.SetActive(false);
        //}

        //if (!west)
        //{
        //    westDoor.SetActive(false);
        //}
    }
}
