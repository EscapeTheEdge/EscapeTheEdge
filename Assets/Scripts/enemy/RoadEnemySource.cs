using System;
using UnityEngine;
using Random = System.Random;

public class RoadEnemySource: MonoBehaviour
{
    [SerializeField] private GameObject enemyTemplate;
    [SerializeField] private float maxEnemyDistance = 20f;
    [SerializeField] private float enemySpeed = 20f;
    [SerializeField] private float initialEnemyOffset;

    private Vector3 enemyDirection;
    private bool initialied = false;

    private float nextEnemyTimer;
    private Random random = new();
    
    public void Initialize(Vector3 enemyDirection)
    {
        this.enemyDirection = enemyDirection;
        initialied = true;
    }

    void Start()
    {
        generateEnemyTimert();
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialied) return;

        nextEnemyTimer -= Time.deltaTime;
        if (nextEnemyTimer <= 0)
        {
            var enemy = Instantiate(enemyTemplate, transform);
            enemy.transform.localPosition = new Vector3() - (enemyDirection * initialEnemyOffset);
            enemy.GetComponent<Enemy>().Initialize(enemySpeed, enemyDirection, maxEnemyDistance);

            generateEnemyTimert();
        }
    }

    private void generateEnemyTimert()
    {
        nextEnemyTimer = (random.Next() % 400) / 100f + 2f;
    }
}