using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentGenerator : MonoBehaviour
{
    public void GetRandomObjectOfType(ObjectTypes type)
    {
        if(type == ObjectTypes.Room)
        {
            GameObject temp = Resources.Load<GameObject>("Prefabs/Rooms/Room" + Random.Range(1, 4));
            if (!temp)
            {
                Debug.Log("FAILED TO FIND RANDOM OBJECT");
            }
            else
            {
                Instantiate(temp);
            }
        }
    }
}
