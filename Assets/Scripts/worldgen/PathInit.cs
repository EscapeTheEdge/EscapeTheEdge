using UnityEngine;
using Random = System.Random;

public class PathInit : MonoBehaviour, MapInitializer
{
    [SerializeField] private GameObject enemySourceTemplate;
    [SerializeField] private Vector3 enemySourceRandomOffset;
    [SerializeField] private Vector3 enemySourceStaticOffset;

    public void Initialize()
    {
        var random = new Random();
        var randomOffset = random.Next() % 2 == 0 ? enemySourceRandomOffset : -enemySourceRandomOffset;
        var newSource = Instantiate(enemySourceTemplate, transform);
        newSource.transform.localPosition = randomOffset + enemySourceStaticOffset;
        newSource.GetComponent<PathEnemySource>().Initialize(-randomOffset.normalized);
    }
}