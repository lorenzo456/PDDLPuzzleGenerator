using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("ShootCube"))
        {
            collision.transform.gameObject.GetComponent<ShootButton>().OnHit();
        }
        Debug.Log(collision.transform.name);
        Destroy(gameObject);
    }
}
