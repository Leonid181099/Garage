using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetRigidbodyState(true);
        EnableGravity(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(Transform destination)
    {
        transform.SetParent(destination);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        SetRigidbodyState(true);
        EnableGravity(false);
    }

    public void Throw()
    {
        transform.SetParent(null);
        SetRigidbodyState(false);
        EnableGravity(true);
        rb.AddForce(transform.forward * 3f, ForceMode.Impulse);
    }

    private void SetRigidbodyState(bool state)
    {
        if (rb != null)
        {
            rb.isKinematic = state;
            rb.useGravity = !state;
            rb.collisionDetectionMode = state ? CollisionDetectionMode.Continuous : CollisionDetectionMode.Discrete;
        }
    }

    private void EnableGravity(bool state)
    {
        if (rb != null)
        {
            rb.useGravity = state;
        }
    }
}
