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
    [SerializeField] private Sprite Arrow;
    
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
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position);
        transform.rotation *= Quaternion.Euler(new Vector3(0,0,90));
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