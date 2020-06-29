using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    public bool hasMasterKey;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            hasMasterKey = true;
        }

        if (other.gameObject.CompareTag("MasterDoor"))
        {
            if (hasMasterKey)
            {
                Debug.Log("GAME IS COMPLETED");
            }
        }
    }

}
