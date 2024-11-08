using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] PointScript pointScript;
    private int enemyIndex;
    private float time = 0;

    [Header("Spawner Attributes")]
    public float spawnDelay = 10;

    [Header("Enemy Attributes")]
    public float enemyHealth;
    public float enemySpeed;
    private void Update()
    {
        transform.position = pointScript.points[0].transform.position;
        time += Time.deltaTime;
        if (time > spawnDelay)
        {
            enemyHealth = Random.Range(1, 50);
            enemySpeed = Random.Range(1, 50);
            GameObject newEnemy = Instantiate(enemy, transform.position, pointScript.points[0].transform.rotation,transform);
            enemyIndex++;
            newEnemy.name = $"enemy{enemyIndex}";
            enemy.GetComponent<EnemyScript>().pointScript = pointScript;
            if (spawnDelay > 2) spawnDelay = spawnDelay * 0.75f; // Difficulty modifier
            time = 0;
        }
    }
}
