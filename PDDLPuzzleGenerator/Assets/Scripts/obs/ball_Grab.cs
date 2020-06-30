using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_Grab : MonoBehaviour
{
    Vector3 startPosition;
    Transform originalParent;
    public ColorTypes colorType;
    public bool grabable = true;
    public bool completed;
    public Grab_door door;
    Renderer myRenderer;

    private void Start()
    {
        originalParent = transform.parent;
        startPosition = transform.position;
        myRenderer = gameObject.transform.GetChild(0).GetComponent<Renderer>();
    }
    public void ResetBall()
    {
        transform.parent = originalParent;
        transform.position = startPosition;
        grabable = true;
    }

    void Completed(GameObject other)
    {
        completed = true;
        grabable = false;
        transform.parent = null;
        other.GetComponent<platform_grab>().taken = true;
        transform.parent = other.transform;
        door.CheckPlatforms();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("HITTING PLATFORM");
            if (other.gameObject.GetComponent<platform_grab>().colorType == colorType
                    && other.gameObject.GetComponent<platform_grab>().taken == false)
                {
                    Completed(other.gameObject);
                }
        }
    }

    private void Update()
    {
        if(colorType == ColorTypes.Black)
        {
            myRenderer.material.color = Color.black;
        }
        else if(colorType == ColorTypes.Blue)
        {
            myRenderer.material.color = Color.blue;
        }
        else if(colorType == ColorTypes.Purple)
        {
            myRenderer.material.color = Color.cyan;
        }
    }
}
