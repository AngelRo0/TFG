using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionTest : MonoBehaviour
{
    public void Green()
    {
        GetComponent<Renderer>().transform.localScale = new Vector3(1f, 1f, 1f);
        GetComponent<Renderer>().material.color = Color.green;
        //Console.WriteLine("verde");
    }

    public void Magenta()
    {
        GetComponent<Renderer>().transform.localScale = new Vector3(4f, 4f, 4f);
        GetComponent<Renderer>().material.color = Color.magenta;
    }

    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
