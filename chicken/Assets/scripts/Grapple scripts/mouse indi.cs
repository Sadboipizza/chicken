using UnityEngine;
using UnityEngine.InputSystem;

public class mouseindi : MonoBehaviour
{

    private Vector3 posofmouse;
    public float mouseofspeed = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posofmouse = Input.mousePosition;
        posofmouse = Camera.main.ScreenToWorldPoint(posofmouse);
        transform.position = new Vector3(posofmouse.x, posofmouse.y, mouseofspeed);
    }
    public void Lookaround(InputAction.CallbackContext value)
    {
        Vector2 mousemovement = value.ReadValue<Vector2>();
        posofmouse += new Vector3(mousemovement.x, mousemovement.y, 0) * mouseofspeed;
        transform.position = new Vector3(posofmouse.x, posofmouse.y, mouseofspeed);
    }
}
