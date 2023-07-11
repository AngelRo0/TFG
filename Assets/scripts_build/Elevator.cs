using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    //public int floor;
    private Transform playerTransform;
    private int selectedFloor, actualFloor;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("XR Origin").transform;
    }

    public void SelectFloor(int floor)
    {
        selectedFloor = floor;
        /*if(selectedFloor > actualFloor)
        {
            playerTransform.position += new Vector3(0, 6, 0);
        }
        else if(selectedFloor < actualFloor)
        {
            playerTransform.position -= new Vector3(0, 6, 0);
        }*/
        if(selectedFloor != actualFloor)
        {

        }
            playerTransform.position = new Vector3(playerTransform.position.x, (selectedFloor*3)+0.3f, playerTransform.position.z);
        actualFloor = selectedFloor;
        Debug.Log(selectedFloor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
