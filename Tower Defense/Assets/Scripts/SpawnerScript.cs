using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] PointScript pointScript;
    private float time = 0;
    public float spawnDelay = 1;
    void Start()
    { 
    }
    private void Update()
    {
        transform.position = pointScript.Points[0].transform.position;
        time += Time.deltaTime;
        if (time > spawnDelay)
        {
            GameObject newEnemy =  Instantiate(Enemy, transform.position, pointScript.Points[0].transform.rotation);
            newEnemy.name = "enemy";
            Enemy.GetComponent<EnemyScript>().PointScript = pointScript;
            if (spawnDelay > 2) spawnDelay = spawnDelay * 0.75f;
            time = 0;
        }
    }
}
