using System.Collections;
using UnityEngine;

using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Ray2D jumpy;

    private float moveacc = 25f;
    public float  upindownspeed = 1.5f;   
    public float jumpcool = 1f;
    public float jumpraydistance = 1.1f;

    private float horizontaldirect;
    private float verticaldirect;
    public bool allowedtojump = true;
    public PlayerInput input;
    private Vector2 rawmovement;
    public mouseindi indi;


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

        
        jumpy.origin = transform.position - (Vector3.down / 1.5f);
        jumpy.direction = -transform.up;

    }




    public  void MoveCharacter(InputAction.CallbackContext value)
    {
        Vector2 movement = value.ReadValue<Vector2>();
        rawmovement = new Vector2(movement.x, movement.y);
        rb.linearVelocity = new Vector2(rawmovement.x * moveacc, (rb.linearVelocity.y / upindownspeed) );

    }
    public void Jump()
    {
       
        if (Physics2D.Raycast(jumpy.origin , jumpy.direction  , 0.2f)&& allowedtojump )
        {
            rb.AddForce(Vector2.up * jumpraydistance, ForceMode2D.Impulse);
            allowedtojump = false; 
            new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            StartCoroutine(ResetJump());
        }
        
           
           
        
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(jumpcool);
        allowedtojump = true;
    }
}
