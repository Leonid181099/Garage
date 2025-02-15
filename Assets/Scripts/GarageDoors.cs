using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoors
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsOpen(GameObject door, float angle)
    {
        if (angle-0.02f<door.transform.rotation.y && door.transform.rotation.y < angle+0.02)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OpenDoors(GameObject doorL, GameObject doorR)
    {
        OpenDoor(doorL, 0.85f);
        OpenDoor(doorR, -0.85f);
    }
    public void OpenDoor(GameObject door, float angle)
    {
        if (IsOpen(door,angle))
        {
            return;
        }
        else
        {
            Quaternion r =door.transform.rotation;
            if (angle - door.transform.rotation.y > 0)
            {
                r.y += 0.01f;
            }
            else
            {
                r.y -= 0.01f;
            }
            door.transform.rotation = r;
        }
    }
}
