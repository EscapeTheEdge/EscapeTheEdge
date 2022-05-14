using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatfrom : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player"){
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player"){
            collision.gameObject.transform.SetParent(null);
        }
    }
}
