using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using TMPro;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject _presser;
    private bool _isPresed;

    private string text;

    //private int contador = 0;
    //private int contador2 = 0;

    public GameObject voiceGameobject;
    private VoiceController voice;
    
    private void Start()
    {
        _isPresed = false;

        //Cojemos el texto que tiene como hijo el boton
        text = transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;

        //TTS
        voice = voiceGameobject.GetComponent<VoiceController>();
    }

    //Si la mano toca el boton y se puede presionar, se pulsa
    private void OnTriggerEnter(Collider other)
    {
        if(!_isPresed)
        {
            pressButton(other);
        }
    }

    //Acción de pulsar el boton
    public void pressButton(Collider other)
    {
        //button.transform.localPosition = new Vector3(0, 0.003f, 0);
        _presser = other.gameObject;
        onPress.Invoke();
        _isPresed = true;
        transform.parent.GetComponent<PanelOptions>().writeOnBar(text);
    }

    //Si la mano suelta el boton, se suelta
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == _presser)
        {
            releaseButton(other);
        }
    }

    //Acción de soltar el boton
    public void releaseButton(Collider other)
    {
        //button.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
        _presser = null;
        onRelease.Invoke();
        _isPresed = false;
    }

    //Crea una esfera (forma visual de ver que el boton funciona)
    public void spawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        sphere.transform.localPosition = new Vector3(20, 2, -6);
        sphere.AddComponent<Rigidbody>();
        sphere.AddComponent<SphereCollider>();
    }


    //Se pulsa el boton cada segundo
    private void Update()
    {
        /*
        contador++;
        contador2++;

        if(contador >= 288)
        {
            pressButton(new Collider());
            contador = 0;
            transform.parent.GetComponent<PanelOptions>().writeOnBar(text);
            //Debug.Log(text);
        }
        */

        /*
        if(contador2 >= 500)
        {
            voice.StartSpeaking("Potato");
            contador2 = 0;
        }
        */

        /*
        if(contador2 >= 420)
        {
            contador2 = 0;
            transform.parent.GetComponent<PanelOptions>().cleanBar();
        }
        */
    }
}
