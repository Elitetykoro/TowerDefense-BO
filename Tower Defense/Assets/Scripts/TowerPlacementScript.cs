using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerPlacementScript : MonoBehaviour
{
    private int towerType;
    SpriteRenderer spriteRenderer;
    CircleCollider2D collision;
    public float range;
    public List<GameObject> targets;
    [SerializeField] private GameObject Bullet;
    private float time;
    private float bulletDelay;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collision = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        collision.radius = range;

        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].tag = "target";
        }

        if (towerType == 1) ArrowTower();
        if (towerType == 2) BombTower();
        if (towerType == 3) MiniGunTower();
        if (time > bulletDelay && towerType > 0 && targets != null)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity, transform);
            time = 0;
        }
    }
    private void ArrowTower()
    {
        spriteRenderer.color = new Color(0, 0, 1, 1);
        range = 3f;
        bulletDelay = 1f;
        time += Time.deltaTime;
        
    }
    private void BombTower()
    {
        spriteRenderer.color = new Color(0, 1, 0, 1);
        range = 2f;
        bulletDelay = 4f;
        time += Time.deltaTime;
        
    }
    private void MiniGunTower()
    {
        spriteRenderer.color = new Color(1, 1, 0, 1);
        range = 1f;
        bulletDelay = 0.5f;
        time += Time.deltaTime;
        
    }
    private void OnMouseDown()
    {
        towerType++;
        if (towerType >= 4 ) towerType = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (!collision.gameObject.CompareTag("target"))
        {
            targets.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            targets.Remove(collision.gameObject);
            collision.gameObject.tag = "Untagged";
        }
    }
}
