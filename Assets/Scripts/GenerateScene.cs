using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GenerateScene : MonoBehaviour
{

    public GameObject baseField;
    public GameObject smallTree;
    public GameObject bigTree;
    public GameObject cutTree;
    public GameObject movingPlatform;

    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(baseField, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void Generate(int level)
    {
        string sceneName = "Level-base";

        SceneManager.LoadScene(sceneName);
        GameObject newBase = GameObject.Instantiate(baseField, new Vector3(1, 1, 0), Quaternion.identity);
    }

}
