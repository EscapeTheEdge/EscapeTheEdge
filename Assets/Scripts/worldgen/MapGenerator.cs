using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject grassSegment;
    [SerializeField] private GameObject pathSegment;
    [SerializeField] private GameObject roadSegment;
    [SerializeField] private GameObject player;
    [SerializeField] private int generationMargin = 10;

    private PlayerMovement playerMovement;
    private int generatedUntil = 0;
    private int generatedSince = 0;
    private Queue<GameObject> currentMap = new();
    private int lastGeneratedIndex = -1;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.GetProgress() + generationMargin > generatedUntil)
        {
            GenerateNext();
        }

        if (playerMovement.GetProgress() - generationMargin > generatedSince)
        {
            RemoveLast();
        }
    }

    private void GenerateNext()
    {
        int templateIndex;
        do
        {
            templateIndex = Random.Range(0, 4);
        } while (templateIndex == lastGeneratedIndex);
        
        lastGeneratedIndex = templateIndex;
        
        GameObject template;
        int biomeWidth;
        
        switch(templateIndex)
        {
        case 0: 
        	template = pathSegment;
        	biomeWidth = Random.Range(1, 4);
        	break;
        case 1:
        	template = roadSegment;
        	biomeWidth = Random.Range(1, 4);
        	break;
        default:
        	template = grassSegment;
        	biomeWidth = Random.Range(2, 6);
        	break;
        };

        for (int i = 0; i < biomeWidth; i++)
        {
            var newObject = Instantiate(template, transform);
            newObject.transform.position = new Vector3(0, 0, generatedUntil + i + 1);
            newObject.GetComponent<MapInitializer>()?.Initialize();

            currentMap.Enqueue(newObject);
        }

        generatedUntil += biomeWidth;
    }

    private void RemoveLast()
    {
        Destroy(currentMap.Dequeue());
        generatedSince++;
    }
}
