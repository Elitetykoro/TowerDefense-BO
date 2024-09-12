using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] PointScript pointScript;
    void Start()
    {
        transform.position = pointScript.Points[0].transform.position;
        StartCoroutine(Spawn());
    }
    private void Update()
    {

    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Enemy, transform.position, pointScript.Points[0].transform.rotation);
        Enemy.GetComponent<EnemyScript>().PointScript = pointScript;
    }
}
