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
        }
    }

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

    IEnumerator create_room(List<string> parameters)
    {
        yield return null;
    }

    IEnumerator set_door(List<string> parameters)
    {
        yield return null;
    }
}
