using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void Update()
    {
        // Die if fallen from platform 
        if (transform.position.y < -1f)
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

    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        // GetComponent<MeshRenderer>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
