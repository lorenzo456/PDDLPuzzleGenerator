using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected CharacterAbilities player;
    
    public virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<CharacterAbilities>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
}
