using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    InputSystem_Actions input;
    public float speed;
    public float rotateSpeed;
    public GameObject cam;
    float cameraPitch;

    void Start()
    {
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
        Vector3 dir = input.Player.Move.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;

        //transform.position += transform.forward * dir.z * speed * Time.deltaTime;
        //transform.position += transform.right * dir.x * speed * Time.deltaTime;

        //wasd alternativa (optimizada, dir necesita Vector3)
        dir = transform.TransformDirection(dir);
        transform.position += dir * speed * Time.deltaTime;
    }
}
