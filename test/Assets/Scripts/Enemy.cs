using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;

    [SerializeField] private int health = 3;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player != null)
        {
            // เดินตรงเข้าหา Player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }

        if (health == 0) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<Player>().health -= 1;
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Bullet")){
            health -= 1; 
        }
    }
}