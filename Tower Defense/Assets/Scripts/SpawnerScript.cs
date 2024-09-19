using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] PointScript pointScript;
    private int enemyIndex;
    private float time = 0;

    [Header("Delay in between Enemies")]
    public float spawnDelay = 1;
    private void Update()
    {
        transform.position = pointScript.points[0].transform.position;
        time += Time.deltaTime;
        if (time > spawnDelay)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position, pointScript.points[0].transform.rotation);
            enemyIndex++;
            newEnemy.name = $"enemy{enemyIndex}";
            enemy.GetComponent<EnemyScript>().pointScript = pointScript;
            //if (spawnDelay > 2) spawnDelay = spawnDelay * 0.75f; // Difficulty modifier
            time = 0;
        }
    }
}
