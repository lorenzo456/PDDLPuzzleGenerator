using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ContentGenerator contentGenerator;
    public List<GameObject> listOfGameObjects = new List<GameObject>();
    public List<Action> actionList = new List<Action>();

    void Start()
    {
        contentGenerator = GameObject.Find("ContentGenerator").GetComponent<ContentGenerator>();
    }

    public void Initialize()
    {
        foreach (Action action in actionList)
        {
             StartCoroutine(action.actionName, action.actionParameters);
           // Debug.Log(action.actionName);
        }
    }
    /*
    IEnumerator add_element(List<string> parameters)
    {

        string element1 = parameters[0];
        string element2 = parameters[1];
        string location = parameters[2];

        //Create location
        GameObject tempLocation = contentGenerator.GetRandomObjectOfType(ObjectTypes.Room, location);
        listOfGameObjects.Add(tempLocation);
        GameObject tempElement = contentGenerator.GetRandomObjectOfType(ObjectTypes.Element, element1, element1.Remove(element1.Length - 1, 1));
        //Create element1 
        listOfGameObjects.Add(tempElement);
        Debug.Log(tempElement.name);
        GameObject.Find(tempElement.name + "(Clone)").transform.position = GameObject.Find(tempLocation.name + "(Clone)").GetComponent<Room>().elementPlacement.position;

        yield return null;
    }
    */

    IEnumerator create_room(List<string> parameters)
    {
        string locationName = parameters[0];
        contentGenerator.GetRandomObjectOfType(ObjectTypes.Room, locationName);
        yield return null;
    }

    IEnumerator set_door(List<string> parameters)
    {
        string locationName = parameters[0];
        Debug.Log(locationName);
        contentGenerator.GetRandomObjectOfType(ObjectTypes.Element, "Door", "Door", locationName);
        yield return null;
    }

    IEnumerator set_key(List<string> parameters)
    {
        yield return null;
    }

    IEnumerator set_player(List<string> parameters)
    {
        yield return null;
    }

    IEnumerator create_obs(List<string> parameters)
    {
        yield return null;
    }

    IEnumerator set_meddifficulty(List<string> parameters)
    {
        yield return null;
    }

    IEnumerator set_harddifficulty(List<string> parameters)
    {
        yield return null;
    }

    IEnumerator set_easydifficulty(List<string> parameters)
    {
        yield return null;
    }
}
