using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentGenerator : MonoBehaviour
{
    Room lastRoom;
    bool first;
    bool north, west, east, south;
    public GameObject GetRandomObjectOfType(ObjectTypes objectType, string objectName, string subType = "", string parent = "")
    {
        if (objectType == ObjectTypes.Room)
        {
            GameObject temp = Resources.Load<GameObject>("Prefabs/Areas/Area" + Random.Range(0, 3));
            temp.name = objectName;
            if (!temp)
            {
                Debug.Log("FAILED TO FIND RANDOM OBJECT");
            }
            else
            {
                Instantiate(temp, ReturnDirectionOffset2(temp.GetComponent<Room>()), Quaternion.identity);
                temp.transform.position = new Vector3(temp.transform.position.x, 0, temp.transform.position.z);
                if(first == false)
                {
                    lastRoom = GameObject.Find("room1(Clone)").GetComponent<Room>(); 
                    first = true;
                }
                return temp;
            }
        }
        if (objectType == ObjectTypes.Element)
        {
            if (subType != "")
            {
                GameObject temp = Resources.Load<GameObject>("Prefabs/Elements/" + subType);
                if (!temp)
                {
                    Debug.Log("FAILED TO FIND RANDOM ELEMENT OBJECT");
                }
                else
                {
                    if (subType == "Door")
                    {
                        Instantiate(temp, new Vector3(0, 1, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(temp, GameObject.Find(parent + "(Clone)").GetComponent<Room>().elementPlacement.position, Quaternion.identity);
                    }
                    return temp;
                }
            }
        }
        return null;
    }

    public void CreateEasyLocation(string location, string obst1, string obst2)
    {
        CreateRandomObstacleOfType(location, obst1);
        CreateRandomObstacleOfType(location, obst2);
    }

    public void CreateMedLocation(string location, string obst1, string obst2, string obst3)
    {
        CreateRandomObstacleOfType(location, obst1);
        CreateRandomObstacleOfType(location, obst2);
        CreateRandomObstacleOfType(location, obst3);
    }

    public void CreateHardLocation(string location, string obst1, string obst2, string obst3, string obst4)
    {
        CreateRandomObstacleOfType(location, obst1);
        CreateRandomObstacleOfType(location, obst2);
        CreateRandomObstacleOfType(location, obst3);
        CreateRandomObstacleOfType(location, obst4);
    }

    public void CreateRandomObstacleOfType(string location, string type)
    {

        Transform room = GameObject.Find(location + "(Clone)").GetComponent<Room>().GetRandomEmptyObst().transform;
        if (type == "jump")
        {
            GameObject temp = Resources.Load<GameObject>("Prefabs/Obsticals/Jump/" + "Jump" + Random.Range(0, 3));
            Instantiate(temp, room.position, room.rotation);
        }
        else if (type == "grab")
        {
            GameObject temp = Resources.Load<GameObject>("Prefabs/Obsticals/Grab/" + "Grab" + Random.Range(0, 3));
            Instantiate(temp, room.position, room.rotation);
        }
        else if (type == "shoot")
        {
            GameObject temp = Resources.Load<GameObject>("Prefabs/Obsticals/Shoot/" + "Shoot" + Random.Range(0, 3));
            Instantiate(temp, room.position + new Vector3(0,1.5f,0), room.rotation);
        }
    }

    Vector3 ReturnDirectionOffset2(Room nextRoom)
    {

        Vector3 direction = Vector3.zero;
        if(first == false)
        {
            return Vector3.zero;
        }

        if (lastRoom.north && nextRoom.south)
        {
            direction = lastRoom.transform.position + new Vector3(
                lastRoom.transform.position.x,
                0,
                lastRoom.transform.position.z + (lastRoom.units * 2));
            nextRoom.south = false;
            lastRoom.north = false;
            north = true;
            return direction;

        }
        else if (lastRoom.east && nextRoom.west)
        {
            direction = lastRoom.transform.position + new Vector3(
            lastRoom.transform.position.x - (lastRoom.units * 2),
            0,
            lastRoom.transform.position.z);
            nextRoom.west = false;
            lastRoom.east = false;
            east = true;
            return direction;

        }
        else if (lastRoom.south && nextRoom.north)
        {
            direction = lastRoom.transform.position + new Vector3(
            lastRoom.transform.position.x,
            0,
            lastRoom.transform.position.z - (lastRoom.units * 2));
            nextRoom.north = false;
            lastRoom.south = false;
            south = true;
            return direction;

        }
        else if (lastRoom.west && nextRoom.east)
        {
            direction = lastRoom.transform.position + new Vector3(
            lastRoom.transform.position.x + (lastRoom.units * 2),
            0,
            lastRoom.transform.position.z);
            nextRoom.east = false;
            lastRoom.west = false;
            west = true;
            return direction;

        }

        if (!east)
        {
            direction = lastRoom.transform.position + new Vector3(
           lastRoom.transform.position.x - (lastRoom.units * 2),
           0,
           lastRoom.transform.position.z);
            nextRoom.west = false;
            lastRoom.east = false;
            east = true;
            return direction;
        }else if (!west)
        {
            direction = lastRoom.transform.position + new Vector3(
            lastRoom.transform.position.x + (lastRoom.units * 2),
            0,
            lastRoom.transform.position.z);
            nextRoom.east = false;
            lastRoom.west = false;
            return direction;
        }
        else if(!north)
        {
            direction = lastRoom.transform.position + new Vector3(
    lastRoom.transform.position.x,
    0,
    lastRoom.transform.position.z + (lastRoom.units * 2));
            nextRoom.south = false;
            lastRoom.north = false;
            north = true;
            return direction;
        }else if (!south)
        {
            direction = lastRoom.transform.position + new Vector3(
           lastRoom.transform.position.x,
           0,
           lastRoom.transform.position.z - (lastRoom.units * 2));
            nextRoom.north = false;
            lastRoom.south = false;
            south = true;
            return direction;
        }
        Debug.Log("NONE OF THE ABOVE");
        return direction;

    }

    Vector3 ReturnDirectionOffset(Room nextRoom)
    {
        int i = 0;
        Vector3 direction = Vector3.zero;
        if (lastRoom)
        {
            bool chosenDirection = false;
            while (!chosenDirection) {
                i++;                
                int randomDirection = Random.Range(0, 4);
                if (randomDirection == 0 && lastRoom.north && nextRoom.south)
                {
                    direction = lastRoom.transform.position + new Vector3(
                        lastRoom.transform.position.x,
                        0,
                        lastRoom.transform.position.z + (lastRoom.units * 2));
                    nextRoom.south = false;
                    lastRoom.north = false;
                    chosenDirection = true;

                }
                else if (randomDirection == 1 && lastRoom.east && nextRoom.west)
                {
                    direction = lastRoom.transform.position + new Vector3(
                    lastRoom.transform.position.x + (lastRoom.units * 2),
                    0,
                    lastRoom.transform.position.z);
                    nextRoom.west = false;
                    lastRoom.east = false;
                    chosenDirection = true;
                }
                else if (randomDirection == 2 && lastRoom.south && nextRoom.north)
                {
                    direction = lastRoom.transform.position + new Vector3(
                    lastRoom.transform.position.x,
                    0,
                    lastRoom.transform.position.z - (lastRoom.units * 2));
                    nextRoom.north = false;
                    lastRoom.south = false;
                    chosenDirection = true;
                }
                else if (randomDirection == 3 && lastRoom.west && nextRoom.east)
                {
                    direction = lastRoom.transform.position + new Vector3(
                    lastRoom.transform.position.x + (lastRoom.units * 2),
                    0,
                    lastRoom.transform.position.z);
                    nextRoom.east = false;
                    lastRoom.west = false;
                    chosenDirection = true;
                }

                if(i > 100)
                {
                    Debug.Log("ENTER FAILSAFE");
                    chosenDirection = true;
                }
            }
            lastRoom.RemoveDoor();
            nextRoom.RemoveDoor();
        }

        return direction;

    }
}
