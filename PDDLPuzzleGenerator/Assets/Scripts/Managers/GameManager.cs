using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ContentGenerator contentGenerator;
    public List<GameObject> listOfGameObjects = new List<GameObject>();
    public List<Action> actionList = new List<Action>();
    private int keyAmount = 0;

    public bool jump;
    public bool shoot;
    public bool grab;

    void Start()
    {
        contentGenerator = GameObject.Find("ContentGenerator").GetComponent<ContentGenerator>();
    }

    public void Initialize()
    {
        jump = false;
        shoot = false;
        grab = false;
        foreach (Action action in actionList)
        {
             StartCoroutine(action.actionName, action.actionParameters);
           // Debug.Log(action.actionName);
        }
    }
    
    IEnumerator create_room(List<string> parameters)
    {
        string locationName = parameters[0];
        Debug.Log("CREATE ROOM: " + locationName);
        contentGenerator.GetRandomObjectOfType(ObjectTypes.Room, locationName);
        yield return null;
    }

    IEnumerator set_door(List<string> parameters)
    {
        string locationName = parameters[0];
        Debug.Log("CREATE DOOR AT: " + locationName);
        contentGenerator.GetRandomObjectOfType(ObjectTypes.Element, "Door", "Door", locationName);
        yield return null;
    }

    IEnumerator set_key(List<string> parameters)
    {
        string locationName = parameters[0];
        Debug.Log("CREATE DOOR AT: " + locationName);
        contentGenerator.GetRandomObjectOfType(ObjectTypes.Element, "Key" + keyAmount, "Key", locationName);
        keyAmount++;
        yield return null;
    }

    IEnumerator set_player(List<string> parameters)
    {
       // string locationName = parameters[0];
       // Debug.Log("CREATE PLAYER AT: " + locationName);
        yield return null;
    }

    IEnumerator create_obs(List<string> parameters)
    {
        string abilityName = parameters[0];
        Debug.Log("Enable PLAYER ability: " + abilityName);
        if(abilityName == "jump")
        {
            jump = true;
        }else if(abilityName == "grab")
        {
            grab = true;
        }else if(abilityName == "shoot")
        {
            shoot = true;
        }
        yield return null;
    }

    IEnumerator set_meddifficulty(List<string> parameters)
    {
        string locationName = parameters[0];
        string abilityType1 = parameters[1];
        string abilityType2 = parameters[2];
        string abilityType3 = parameters[3];

        yield return null;
    }

    IEnumerator set_harddifficulty(List<string> parameters)
    {
        string locationName = parameters[0];
        string abilityType1 = parameters[1];
        string abilityType2 = parameters[2];
        string abilityType3 = parameters[3];
        string abilityType4 = parameters[4];

        yield return null;
    }

    IEnumerator set_easydifficulty(List<string> parameters)
    {
        string locationName = parameters[0];
        string abilityType1 = parameters[1];
        string abilityType2 = parameters[2];
        yield return null;
    }
}
