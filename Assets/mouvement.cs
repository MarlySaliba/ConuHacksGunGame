using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;
    private Vector2 moveInput;
    public SpriteRenderer theSR;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;


    private Transform firePoint;
    void start() { firePoint = GameObject.FindGameObjectWithTag("firepoint").transform; }
    //private bool m_FacingRight = true;

    //private void Flip()
    //{
    //    m_FacingRight = !m_FacingRight;
    //    transform.Rotate(0f, 180f, 0f);
    //}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        theRB.linearVelocity = new Vector3(moveInput.x * moveSpeed, theRB.linearVelocity.y, moveInput.y * moveSpeed);

        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }


        //if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //{
        //    theRB.linearVelocity += new Vector3(0f, jumpForce, 0f);
        //}
        //if (!theSR.flipX && moveInput.x < 0)
        //{
        //    theSR.flipX = true;

        //}
        //else if (theSR.flipX && moveInput.x > 0)
        //{
        //    theSR.flipX = false;

        //}

        if (moveInput.x < 0)
        {
            theSR.flipX = false;
            
         
        }
        else if (moveInput.x > 0)
        {
            theSR.flipX = true;
            //transform.Rotate(0, 180, 0);
            
           
        }






    }

}



