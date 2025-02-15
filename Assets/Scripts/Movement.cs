using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Joystick joystick;
    public Joystick joystick1;
    [SerializeField] private float Speed = 4f;
    [SerializeField] private float AngularSpeed=3f;
    [SerializeField] private float AngularSpeedCamera = 0.3f;
    [SerializeField] private Rigidbody rigidbodyComponent;
    [SerializeField] private GameObject camera;
    private Vector2 lastTouchPosition;
    private Rect joystickArea;
    // Start is called before the first frame update
    void Start()
    {
        joystickArea = new Rect(0, 0, 512, 512);
    }

    // Update is called once per frame
    void Update()
    {
        var forward=rigidbodyComponent.transform.forward;
        var right = rigidbodyComponent.transform.right;
        rigidbodyComponent.velocity = joystick.Horizontal * Speed*right+ joystick.Vertical * Speed*forward;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && (!joystickArea.Contains(touch.position)))
            {
                Vector2 delta = touch.position - lastTouchPosition;
                transform.Rotate(Vector3.up, delta.x * AngularSpeedCamera);
                camera.transform.Rotate(-delta[1] * AngularSpeedCamera, 0f, 0f, Space.Self);
                lastTouchPosition = touch.position;
            }
        }
    }
}
