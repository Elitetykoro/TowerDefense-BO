using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> Points;
    private int targetPoint = 0;
    private float speed = 1f;
    public PointScript PointScript;

    private void Start()
    {
        Points = PointScript.Points;
    }
    void Update()
    {
        EnemyMoveTowardPoint();
    }
    void EnemyMoveTowardPoint()
    {
        if (Points.Count >= targetPoint)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.identity, Points[targetPoint].transform.rotation, 1);
            transform.position = Vector3.MoveTowards(transform.position, Points[targetPoint + 1].transform.position, speed * Time.deltaTime);
            if (transform.position == Points[targetPoint + 1].transform.position)
            {
                Debug.Log("you have arrived at point "+targetPoint);
                targetPoint++;
            }
            
        }
        if (Points[Points.Count-1].transform.position == transform.position)
        {
            Destroy(gameObject);
            Debug.Log("Finish!!");
        }
    }
}
