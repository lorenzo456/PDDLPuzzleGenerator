using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAbilities : MonoBehaviour
{
    public bool hasMasterKey;
    public bool dead;
    public bool canShoot = true;
    public bool canGrab = true;

    private void Start()
    {
        if (canShoot)
        {
            GameObject.Find("Reticle").GetComponent<Image>().enabled = true;
        }
    }

    private void Update()
    {
        if (canShoot && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("ShootCube"))
                {
                    hit.transform.gameObject.GetComponent<ShootButton>().OnHit();
                }
            }
        }

        if(canGrab && Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("pickup"))
                {
                    if (hit.transform.gameObject.GetComponent<ball_Grab>().grabable)
                    {
                        hit.transform.gameObject.GetComponent<ball_Grab>().grabable = false;
                        hit.transform.gameObject.transform.parent = Camera.main.transform;
                    }
                    else
                    {
                        hit.transform.gameObject.GetComponent<ball_Grab>().ResetBall();
                    }
                }
            }
        }
    }

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

        if (other.gameObject.CompareTag("Death"))
        {
                Debug.Log("DEAD");
        }
    }

}
