using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<ObsWaypoint> obstWaypoints = new List<ObsWaypoint>();
    public GameObject obsPlacements;
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

    private void Start()
    {
        for(int i = 0; i < obsPlacements.transform.childCount; i++)
        {
            obstWaypoints.Add(obsPlacements.transform.GetChild(i).GetComponent<ObsWaypoint>());
        }
    }

    public ObsWaypoint GetRandomEmptyObst()
    {

        for(int i = 0; i < obstWaypoints.Count; i++)
        {
            if(obstWaypoints[i].taken == false)
            {
                obstWaypoints[i].taken = true;
                return obstWaypoints[i];
            }
        }

        Debug.Log("FOUND NO EMPTY OBST");
        return obstWaypoints[0];

    }
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
