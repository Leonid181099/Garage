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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var forward=rigidbodyComponent.transform.forward;
        var right = rigidbodyComponent.transform.right;
        //rigidbodyComponent.velocity = new Vector3(joystick.Horizontal * Speed, rigidbodyComponent.velocity.y, joystick.Vertical * Speed);
        rigidbodyComponent.velocity = joystick.Horizontal * Speed*right+ joystick.Vertical * Speed*forward;
        rigidbodyComponent.angularVelocity = new Vector3(0f, joystick1.Horizontal * AngularSpeed, 0f);
        camera.transform.Rotate(-joystick1.Vertical * AngularSpeedCamera, 0f, 0f, Space.Self);
    }
}
