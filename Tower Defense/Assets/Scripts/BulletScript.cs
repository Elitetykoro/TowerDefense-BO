using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject target;
    private Transform Parent;
    public float speed;
    public float damage;
    private Transform lastEnemyPosition;
    private TowerScript tower;
    
    void Start()
    {
        Parent = transform.parent.gameObject.transform;
        target = Parent.GetComponent<TowerScript>().targets[0].gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        speed = Parent.GetComponent<TowerScript>().bulletSpeed;
        damage = Parent.GetComponent<TowerScript>().bulletDamage;
        spriteRenderer.sprite = Parent.transform.parent.GetComponent<TowerPlacementScript>().currentBulletType;
    }

    void Update()
    {
        tower = Parent.GetComponent<TowerScript>();

        if (target == null)
        {
            Destroy(gameObject);
        }
        if (target == this)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position);
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 90));
            lastEnemyPosition = target.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == target.GetComponent<Collider2D>())
        {
            if (target.GetComponent<EnemyScript>().health < 0)
            {
                tower.targets.Remove(collision.gameObject);
                Destroy(gameObject);
            }
            collision.GetComponent<EnemyScript>().health -= damage;
            Destroy(gameObject);
        }
    }
}