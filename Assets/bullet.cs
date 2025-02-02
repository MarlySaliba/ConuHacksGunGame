using UnityEngine;
using UnityEngine.InputSystem;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    //private void Flip()
    //{
    //    if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
    //    {
    //        transform.Rotate(0, 180, 0);
    //    }
    //}
}
