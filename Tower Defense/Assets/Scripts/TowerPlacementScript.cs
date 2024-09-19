using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerPlacementScript : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D collision;
    private GameObject bowTurret;
    private int towerType;
    private float time;
    private float bulletDelay;
    private Vector3 offset = new Vector3(0, 0, 90f);
    [Header("Attributes")]
    public List<GameObject> targets;
    public float range;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collision = GetComponent<CircleCollider2D>();
        bowTurret = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        collision.radius = range;

        for (int i = 0; i < targets.Count; i++) targets[i].tag = "target"; // Add tag to target

        if (towerType == 1) ArrowTower(); // Work in progress (need to find better way for changing towers)
        else if (towerType == 2) BombTower();
        else if (towerType == 3) MiniGunTower();

        if (time > bulletDelay && towerType > 0 && targets.Count != 0)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity, transform);
            if (targets.Count > 0)
            {
                bowTurret.transform.rotation = Quaternion.LookRotation(Vector3.forward, targets[0].transform.position - bowTurret.transform.position);
                bowTurret.transform.rotation *= Quaternion.Euler(offset);
            }
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
