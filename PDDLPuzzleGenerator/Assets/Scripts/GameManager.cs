using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ContentGenerator contentGenerator;
    void Start()
    {
        contentGenerator = GameObject.Find("ContentGenerator").GetComponent<ContentGenerator>();
        contentGenerator.GetRandomObjectOfType(ObjectTypes.Room);
    }
}
