using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> pointList;
    public PointScript pointScript;
    private int pointIndex;
    private float speed = 1f;
    public float health = 50;

    private void Start()
    {
        
        health = Random.Range(50,150);
        speed = Random.Range(0.1f, 2f);
        pointList = pointScript.points;
        pointIndex = 0;
    }
    void Update()
    {
        EnemyMoveTowardPoint();
        if (health <= 0)
        {
            Destroy(gameObject);
            Camera.main.transform.GetChild(0).transform.GetComponent<MoneyManagerScript>().money += 30;
        }// If health 0 == die
    }
    void EnemyMoveTowardPoint()
    {
        if (pointList.Count >= pointIndex)
        {
            if (pointList.Count > 0) // Move and look to next point
            {
                transform.rotation = Quaternion.Lerp(Quaternion.identity, pointList[pointIndex].transform.rotation, 1);
                transform.position = Vector3.MoveTowards(transform.position, pointList[pointIndex + 1].transform.position, speed * Time.deltaTime);
                if (transform.position == pointList[pointIndex + 1].transform.position) pointIndex++;
            }
        }
        if (pointList.Count >= 1)
        {
            if (pointList[pointList.Count - 1].transform.position == transform.position) // Finish
            {
                Destroy(gameObject);
                Camera.main.transform.GetChild(0).transform.GetComponent<MoneyManagerScript>().lives--;
            }
        }
        else Destroy(gameObject);
        
    }
}
