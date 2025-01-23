using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private bool openDoor1;
    [SerializeField] private GameObject doorL;
    [SerializeField] private GameObject doorR;
    GarageDoors garageDoors1=new GarageDoors();

    // Start is called before the first frame update
    void Start()
    {
        openDoor1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor1)
        {
            garageDoors1.OpenDoors(doorL,doorR);
        }
    }
}
