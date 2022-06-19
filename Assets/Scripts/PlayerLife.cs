using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void Update()
    {
        if (StaticClass.mapZ > StaticClass.playerZ)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Die if collided with an enemy
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Die if collided with an enemy
        if (other.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
    }

    void Die()
    {
        // GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<PlayerMovement>().enabled = false;
        // Invoke(nameof(ReloadLevel), 1.3f);
        SceneManager.LoadScene("Kill Scene");
    }
}
