using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    InputSystem_Actions input;
    public float speed;
    public float rotateSpeed;
    public GameObject cam;
    float cameraPitch;

    Rigidbody rb;
    Vector3 dir;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        input = new InputSystem_Actions();
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //camara
        transform.Rotate(0, Mouse.current.delta.ReadValue().x * rotateSpeed, 0);

        cameraPitch = Mathf.Clamp(cameraPitch - Mouse.current.delta.ReadValue().y * rotateSpeed, -75f, 75f);
        cam.transform.localRotation = Quaternion.Euler(cameraPitch, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);        

        //wasd
        dir = input.Player.Move.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;

        dir = transform.TransformDirection(dir);

        //lock mouse
        if (Mouse.current.leftButton.isPressed)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = dir * speed;
        targetVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = targetVelocity;
    }


}
