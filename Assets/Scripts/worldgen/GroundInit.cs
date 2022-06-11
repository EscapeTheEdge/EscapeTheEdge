using System.Linq;
using UnityEngine;
using Random = System.Random;

public class GroundInit : MonoBehaviour, MapInitializer
{
    [SerializeField] private GameObject treeTemplate = GameObject.Find("Tree_4");
    [SerializeField] private Vector3 treeOffset = new Vector3(0, 1, 0);

    public void Initialize()
    {
        var random = new Random();
        var numberOfTrees = random.Next(8);
        var treePositions = Enumerable.Range(0, 20)
            .ToList()
            .OrderBy(_ => random.Next())
            .Take(numberOfTrees);

        foreach (var treePosition in treePositions)
        {
            var newTree = GameObject.Instantiate(treeTemplate, transform);
            newTree.transform.localPosition = new Vector3(10f - treePosition, 0f, 0f) + treeOffset;
        }
    }

    void Update()
    {
    }
    
    void Start()
    {
    	treeTemplate = GameObject.Find("Tree_4");
    }
}
