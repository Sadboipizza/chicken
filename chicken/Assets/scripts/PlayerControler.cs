using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerControler : MonoBehaviour
  
{
    Vector3 camereaOffset =  new Vector3 (0, 1, 0);
    private Rigidbody rb;
    float inputX;
    float inputY;
    public float speed = 50.0f;
    Camera playerCam;
    InputAction lookAxis;
    Vector2 cameraRotation = new Vector2(-10, 0);
    public float xSensitivity = 0.2f;
    public float camRotationLimit = -90;
    public float ySensitivity = 0.2f;
    public float cameraYMaxMin = 90;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
        rb = GetComponent<Rigidbody>();
        playerCam = Camera.main;
        lookAxis = GetComponent<PlayerInput>().currentActionMap.FindAction("look");
    }

    // Update is called once per frame
    void Update()
    {


        //camera handle     
        playerCam.transform.position = transform.position + (camereaOffset);
        cameraRotation.x += lookAxis.ReadValue<Vector2>().x * xSensitivity;
        cameraRotation.y += lookAxis.ReadValue<Vector2>().y * ySensitivity;
        playerCam.transform.rotation = Quaternion.Euler(cameraRotation.y, cameraRotation.x, 0);
        transform.rotation = Quaternion.AngleAxis(cameraRotation.x,Vector3.up);

        //movement sysyem
        Vector3 tempMove = rb.linearVelocity;
        tempMove.x = inputY * speed;
        tempMove.z = inputX * speed;

        rb.linearVelocity = (tempMove.x * transform.forward) + (tempMove.y * transform.up) + (tempMove.z * transform.right);
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -cameraYMaxMin, cameraYMaxMin);


    }
    public void Move(InputAction.CallbackContext context) 
    {
        {
            Vector2 InputAxis = context.ReadValue<Vector2>();
            inputX = InputAxis.x;
            inputY = InputAxis.y;
        }
    }
}
