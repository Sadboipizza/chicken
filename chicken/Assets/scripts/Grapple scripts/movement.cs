using UnityEngine;

using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Ray2D jumpy;

    private float moveacc = 10f;
    public float  upindownspeed = 5f;   
    public float jumpcool = 1f;
    public float jumpraydistance = 1.1f;

    private float horizontaldirect;
    private float verticaldirect;
    public bool allowedtojump = true;
    public PlayerInput input;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpy = new Ray2D(transform.position, Vector2.up );
        input = GetComponent<PlayerInput>();


    }

    // Update is called once per frame
    private void Update()
    {
        horizontaldirect = GetInput().x;
        
        jumpy.origin = transform.position - (Vector3.down / 1.5f);
        jumpy.direction = -transform.up;

    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void MoveCharacter()
    {
        rb.AddForce(new Vector2(horizontaldirect, 0f) * moveacc);

    }
    public void Jump()
    {
        if (Physics2D.Raycast(jumpy.origin , jumpy.direction  , 0.2f))
        {
            rb.AddForce(Vector2.up * jumpraydistance, ForceMode2D.Impulse);
            allowedtojump = false; 

        }
        
           
           
        
    }

}
