using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulletScript : MonoBehaviour
{
    public GameObject target;
    private Transform Parent;
    public float speed;
    public float damage;
    
    void Start()
    {
        target = gameObject;
        Parent = transform.parent.gameObject.transform;
        target = Parent.GetComponent<TowerScript>().targets[0].gameObject;
        
        speed = Parent.GetComponent<TowerScript>().bulletSpeed;
        damage = Parent.GetComponent<TowerScript>().bulletDamage;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if (target.GetComponent<EnemyScript>()?.health < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyScript>().health -= damage;
        Destroy(gameObject);
    }
}