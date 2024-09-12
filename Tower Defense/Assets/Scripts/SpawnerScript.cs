using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] PointScript pointScript;
    //public int AmountofEnemies, SecondsBetweenWaves;
    void Start()
    {
        TextAsset textFile = Resources.Load<TextAsset>("waveInit");

        if (textFile != null) // Check if File is available
        {
            string[] lines = textFile.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries); // Splitting the textFile

            if (lines[0].Contains("green"))
            {
                Enemy.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (lines[0].Contains("red"))
            {
                Enemy.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else
        {
            Debug.LogError("Text file not found in Resources folder.");
        }

        StartCoroutine(Spawn());
    }
    private void Update()
    {
        transform.position = pointScript.Points[0].transform.position;
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Enemy, transform.position, pointScript.Points[0].transform.rotation);
        Enemy.GetComponent<EnemyScript>().PointScript = pointScript;
    }
}
