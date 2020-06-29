using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentGenerator : MonoBehaviour
{
    Room lastRoom;
    public GameObject GetRandomObjectOfType(ObjectTypes objectType, string objectName,string subType = "")
    {
        if(objectType == ObjectTypes.Room)
        {            
            GameObject temp = Resources.Load<GameObject>("Prefabs/Rooms/Area" + Random.Range(0, 3));
            temp.name = objectName;
            if (!temp)
            {
                Debug.Log("FAILED TO FIND RANDOM OBJECT");
            }
            else
            {
                Instantiate(temp,ReturnDirectionOffset(temp.GetComponent<Room>()), Quaternion.identity);
                temp.transform.position = new Vector3(temp.transform.position.x, 0,temp.transform.position.z);
                lastRoom = temp.GetComponent<Room>();
                return temp;
            }
        }
        if(objectType == ObjectTypes.Element)
        {
            if(subType != "")
            {
                GameObject temp = Resources.Load<GameObject>("Prefabs/Elements/" + subType);
                if (!temp)
                {
                    Debug.Log("FAILED TO FIND RANDOM ELEMENT OBJECT");
                }
                else
                {
                    Instantiate(temp, Vector3.zero, Quaternion.identity);
                    return temp;
                }
            }
        }
        return null;
    }

    Vector3 ReturnDirectionOffset(Room nextRoom)
    {
        Vector3 direction = Vector3.zero;
        if (lastRoom)
        {

                int randomDirection = Random.Range(0, 3);
                if (randomDirection == 0 && lastRoom.north)
                {
                    direction = lastRoom.transform.position + new Vector3(
                        lastRoom.transform.position.x,
                        0,
                        lastRoom.transform.position.z + (lastRoom.units * 2));
                        nextRoom.south = false;
                        lastRoom.north = false;

                }
                else if (randomDirection == 1 && lastRoom.east)
                {
                    direction = lastRoom.transform.position + new Vector3(
                    lastRoom.transform.position.x + (lastRoom.units * 2),
                    0,
                    lastRoom.transform.position.z);
                    nextRoom.west = false;
                    lastRoom.east = false;
                }
                else if (randomDirection == 2 && lastRoom.south)
                {
                    direction = lastRoom.transform.position + new Vector3(
                    lastRoom.transform.position.x,
                    0,
                    lastRoom.transform.position.z - (lastRoom.units * 2));
                    nextRoom.north = false;
                    lastRoom.south = false;
                }
                else if (randomDirection == 3 && lastRoom.west)
                {
                    direction = lastRoom.transform.position + new Vector3(
                    lastRoom.transform.position.x + (lastRoom.units * 2),
                    0,
                    lastRoom.transform.position.z);
                    nextRoom.east = false;
                    lastRoom.west = false;
                }
            lastRoom.RemoveDoor();
            nextRoom.RemoveDoor();
        }

        return direction;

    }
}
