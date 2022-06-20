using System;
using UnityEngine;
using Random = System.Random;


public class PathEnemySource : MonoBehaviour
{
    [SerializeField] private GameObject enemyTemplate;
    [SerializeField] private float maxEnemyDistance = 40f;
    [SerializeField] private float minEnemySpeed;
    [SerializeField] private float maxEnemySpeed;

    private Vector3 enemyDirection;
    private float enemySpeed;
    private Random random = new();
    private float nextEnemyTimer;
    private Boolean initialized = false;

    public void Initialize(Vector3 newEnemyDirection)
    {
        enemyDirection = newEnemyDirection;
        initialized = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = random.Next() % (maxEnemySpeed - minEnemySpeed) + minEnemySpeed;
        generateEnemyTimert();
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized) return;

        nextEnemyTimer -= Time.deltaTime;
        if (nextEnemyTimer <= 0)
        {
            var enemy = Instantiate(enemyTemplate, transform);
            enemy.transform.localPosition = new Vector3();
            enemy.GetComponent<Enemy>().Initialize(enemySpeed, enemyDirection, maxEnemyDistance);

            generateEnemyTimert();
        }
    }

    private void generateEnemyTimert()
    {
        nextEnemyTimer = (random.Next() % 160) / 100f + 0.5f;
    }
}