using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> Points;
    private int pointIndex;
    private float speed = 1f;
    public PointScript PointScript;
    public float health;

    private void Start()
    {
        Points = PointScript.Points;
        pointIndex = 0;
    }
    void Update()
    {
        EnemyMoveTowardPoint();
        if (health < 0) Destroy(gameObject);
    }
    void EnemyMoveTowardPoint()
    {
        if (Points.Count >= pointIndex)
        {
            //Debug.LogWarning(pointIndex);
            transform.rotation = Quaternion.Lerp(Quaternion.identity, Points[pointIndex].transform.rotation, 1);
            transform.position = Vector3.MoveTowards(transform.position, Points[pointIndex + 1].transform.position, speed * Time.deltaTime);
            if (transform.position == Points[pointIndex + 1].transform.position) pointIndex++;
            
        }
        if (Points[Points.Count-1].transform.position == transform.position)
        {
            Destroy(gameObject);
            Debug.Log("Finish!!");
        }
    }
}
