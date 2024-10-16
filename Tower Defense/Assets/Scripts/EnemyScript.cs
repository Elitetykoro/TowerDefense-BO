using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> pointList;
    public PointScript pointScript;
    private int pointIndex;
    private float speed = 1f;
    public float health = 50;

    private void Start()
    {
        
        health = 50;
        pointList = pointScript.points;
        pointIndex = 0;
    }
    void Update()
    {
        
        EnemyMoveTowardPoint();
        if (health < 0)
        {
            Destroy(gameObject);
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
        if (pointList[pointList.Count-1].transform.position == transform.position) // Finish
        {
            Destroy(gameObject);
        }
    }
}
