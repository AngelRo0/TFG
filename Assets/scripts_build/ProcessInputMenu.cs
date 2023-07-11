using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.AI;

public class ProcessInputMenu : MonoBehaviour
{
    public GameObject walk;
    public GameObject wheelChair;
    public NavigationSystem navSys;
    public void ChangeMovement(int index)
    {
        if(index == 0)
        {
            //Walking movement
            walk.SetActive(true);
            wheelChair.SetActive(false);
            walk.transform.position = wheelChair.transform.position;

        }
        else if(index == 1)
        {
            //Wheelchair movement
            walk.SetActive(false);
            wheelChair.SetActive(true);
            wheelChair.transform.position = walk.transform.position;

        }
    }

    public void changeToWalk()
    {
        walk.SetActive(true);
        wheelChair.SetActive(false);
        walk.transform.position = wheelChair.transform.position;
    }

    public void changeToWheelChair()
    {
        walk.SetActive(false);
        wheelChair.SetActive(true);
        wheelChair.transform.position = walk.transform.position;
    }
}
