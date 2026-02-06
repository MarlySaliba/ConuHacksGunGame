using UnityEngine;
using UnityEngine.InputSystem;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody rb;

    void Start()
    {
        rb.linearVelocity = transform.right * speed;
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null )
        {
            enemy.TakeDamage(damage);
        }
        
        
        Destroy(gameObject);
    }
}
