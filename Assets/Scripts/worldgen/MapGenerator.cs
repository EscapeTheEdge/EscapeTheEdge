using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject grassSegment;
    [SerializeField] private GameObject pathSegment;
    [SerializeField] private GameObject roadSegment;
    [SerializeField] private GameObject player;
    [SerializeField] private int generationMargin = 30;

    private PlayerMovement playerMovement;
    private int generatedUntil = -3;
    private int generatedSince = -3;
    private Queue<GameObject> currentMap = new();
    private int lastGeneratedIndex = -1;
    private const int GRASS_SEGMENT_INDEX = 0;
    private const int PATH_SEGMENT_INDEX = 1;
    private const int ROAD_SEGMENT_INDEX = 2;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        InitializeSegment(grassSegment, 3);
    }

    // Update is called once per frame
    void Update()
    {
    	if (playerMovement == null)
    		return;
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
        GameObject template = grassSegment;
        int biomeWidth = 0;

        switch (GetRandomTemplateIndex())
        {
            case PATH_SEGMENT_INDEX:
                template = pathSegment;
                biomeWidth = Random.Range(1, 4);
                break;
            case ROAD_SEGMENT_INDEX:
                template = roadSegment;
                biomeWidth = Random.Range(1, 3);
                break;
            case GRASS_SEGMENT_INDEX:
                template = grassSegment;
                biomeWidth = Random.Range(2, 4);
                break;
        }

        InitializeSegment(template, biomeWidth);
    }

    private int GetRandomTemplateIndex()
    {
        int templateIndex;
        do
        {
            templateIndex = Random.Range(0, 3);
        } while (templateIndex == lastGeneratedIndex);

        if (lastGeneratedIndex != GRASS_SEGMENT_INDEX && Random.Range(0, 2) % 2 == 0)
        {
            templateIndex = GRASS_SEGMENT_INDEX;
        }

        if (generatedUntil == 0)
        {
            templateIndex = GRASS_SEGMENT_INDEX;
        }

        lastGeneratedIndex = templateIndex;
        return templateIndex;
    }

    private void InitializeSegment(GameObject template, int biomeWidth)
    {
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