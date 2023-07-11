using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollower : MonoBehaviour
{
    //Objeto
    Transform transformGo;
    public GameObject playerCamera;
    public GameObject playerSpawn;

    //Player
    Transform playerTransform;
    Vector3 playerRot;
    Vector3 playerPos;

    //Valores anteriores
    //Vector3 oldPos;
    //Vector3 oldRot;

    //Configurables
    public float radio = 3;
    public float intervaloSeg = 0.5f;

    //Debug
    float contador = 0;

    void Start()
    {
        //Sacamos el transform del objeto para tenerlo guardado 
        transformGo = transform;

        //Guardamos la posición y la rotación en anteriores
        //oldPos = transformGo.localPosition;
        //oldRot = transformGo.eulerAngles;

        //Sacamos la posición y rotación del jugador y la guardamos
        playerTransform = playerCamera.transform;
    }

    void Update()
    {
        //Rotamos y movemos el objeto cada intervalos de tiempo
        //contador++;
        playerRot = playerCamera.transform.eulerAngles;
        playerPos = playerCamera.transform.position;
        //Debug.Log("Angulito: " + playerCamera.transform.eulerAngles.y);
        moveAndRotate(playerRot.y);
        
    }

    public void moveAndRotate(float degrees)
    {
        //Calculamos
        float newz = radio * Mathf.Cos(degrees * Mathf.Deg2Rad)  +  playerPos.z;
        float newx = radio * Mathf.Sin(degrees * Mathf.Deg2Rad)  +  playerPos.x;

        //Redondeamos
        if (newz < 0.001 && newz > -0.001) newz = 0;
        if (newx < 0.001 && newx > -0.001) newx = 0;
        //if(newx <0.1 && newx >  -0.1) Debug.Log(transformGo.eulerAngles.y);
        //Debug.Log("Newz = " + newz + " Newx = " + newx);

        //Asignamos la posición al objeto
        transformGo.localPosition = new Vector3(newx, transform.localPosition.y, newz);
        transformGo.eulerAngles = new Vector3(0, degrees, 0);
    }
}
