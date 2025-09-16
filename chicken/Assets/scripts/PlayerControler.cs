using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class PlayerControler : MonoBehaviour
  
{

    Ray jumpRay;
    
     public float jumpDistatnce = 1.1f;
     public float jumpHieght = 10f;

    Vector3 camereaOffset =  new Vector3 (0, 1, 0);
    private Rigidbody rb;
    float inputX;
    float inputY;
    public float speed = 50.0f;
    Camera playerCam;
    InputAction lookAxis;
    Vector2 cameraRotation = new Vector2(-10, 0);

    public int health = 5;
    public int maxhealth = 5;
   

    public float cameraYMaxMin = 90;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
        rb = GetComponent<Rigidbody>();
        playerCam = Camera.main;
        lookAxis = GetComponent<PlayerInput>().currentActionMap.FindAction("look");

        jumpRay = new Ray(transform.position, -transform.up);
    }

    // Update is called once per frame
    void Update()
    {

        if (health >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            

        Quaternion playerRotaion = Quaternion.identity;
        playerRotaion.y = playerCam.transform.rotation.y;
        playerRotaion.w = playerCam.transform.rotation.w;
        transform.rotation = playerRotaion;
       

        //movement sysyem
        Vector3 tempMove = rb.linearVelocity;
        tempMove.x = inputY * speed;
        tempMove.z = inputX * speed;

        rb.linearVelocity = (tempMove.x * transform.forward) + (tempMove.y * transform.up) + (tempMove.z * transform.right);
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -cameraYMaxMin, cameraYMaxMin);

        jumpRay.origin = transform.position;
        jumpRay.direction = -transform.up;

    }
    public void Move(InputAction.CallbackContext context) 
    {
        {
            Vector2 InputAxis = context.ReadValue<Vector2>();
            inputX = InputAxis.x;
            inputY = InputAxis.y;
        }
    }
    public void jump() 
    {

        if (Physics.Raycast(jumpRay, jumpDistatnce))
        {
            rb.AddForce(transform.up * jumpHieght, ForceMode.Impulse);
        }
          
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Killzone")
        {
            health = 0;
        }
       
        if ((other.tag == "health") && (health < maxhealth))
        {
            health++;
           
            other.gameObject.SetActive(false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hazard")
        {
            health -= 1;
        }
    }
}
