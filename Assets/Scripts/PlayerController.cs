using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.T; // Key for picking up an item
    public KeyCode throwKey = KeyCode.E; // Key for throwing an item
    public GameObject hand; // An object representing the location where the player holds items
    public float reachDistance = 4f; // Interaction distance
    public GameObject button;
    // Start is called before the first frame update
    private float[] timeTouchBegan;
    private bool[] touchDidMove;
    private float tapTimeThreshold = 0.2f;
    void Start()
    {
        timeTouchBegan = new float[10];
        touchDidMove = new bool[10];
    }
    private PickupableItem currentItem; // Link to the current item being picked up
    
    // Update is called once per frame
    void Update()
    {
        bool tap = false;
        Touch touch1=new Touch(); ;
        // Touches
        foreach (Touch touch in Input.touches)
        {
            int fingerIndex = touch.fingerId;

            if (touch.phase == TouchPhase.Began)
            {
                //Debug.Log("Finger #" + fingerIndex.ToString() + " entered!");
                timeTouchBegan[fingerIndex] = Time.time;
                touchDidMove[fingerIndex] = false;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                //Debug.Log("Finger #" + fingerIndex.ToString() + " moved!");
                touchDidMove[fingerIndex] = true;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                float tapTime = Time.time - timeTouchBegan[fingerIndex];
                //Debug.Log("Finger #" + fingerIndex.ToString() + " left. Tap time: " + tapTime.ToString());
                if (tapTime <= tapTimeThreshold && touchDidMove[fingerIndex] == false)
                {
                    //Debug.Log("Finger #" + fingerIndex.ToString() + " TAP DETECTED at: " + touch.position.ToString());
                    tap = true;
                    touch1 = touch;
                }
            }
        }
        //if (Input.GetKeyDown(pickupKey))
        if (tap && currentItem == null)
        {
            TryPickupItem(touch1);
        }

        //else if (Input.GetKeyDown(throwKey))
        //else if (tap && currentItem != null)
        //{
        //    if (currentItem != null)
        //    {
        //        // If we have an item, throw it away
        //        currentItem.Throw();
        //        currentItem = null; // We will reset the link because the item is no longer in hand
        //    }
        //}
    }

    void TryPickupItem(Touch touch)
    {
        // Check if the item is already holding
        if (currentItem != null)
        {
            Debug.Log("You already have the item in your hands.");
            return;
        }

        // Checking if there is a hand object
        if (hand == null)
        {
            Debug.LogError("Hand object is not assigned.");
            return;
        }
        Vector3 touchPosition = touch.position;
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        //Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        // Checking if the beam hits something
        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            // Checking if an object has a PickupableItem component
            var item = hit.collider.GetComponent<PickupableItem>();
            Debug.Log(item);
            if (item != null)
            {
                Debug.Log(item);
                // Calling the method for picking up an object
                item.PickUp(hand.transform);
                currentItem = item;
                button.SetActive(true);
            }
        }
    }
    public void throwItem()
    {
        if (currentItem != null)
        {
            // If we have an item, throw it away
            currentItem.Throw();
            currentItem = null; // We will reset the link because the item is no longer in hand
            button.SetActive(false);
        }
    }
}
