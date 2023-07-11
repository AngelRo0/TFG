using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TextSpeech;

public class VoiceController : MonoBehaviour
{
    string LANG_CODE = "en-US";

    private void Start()
    {
        Setup(LANG_CODE);
#if UNITY_ANDROID
        TextToSpeech.Instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.Instance.onDoneCallback = OnSpeakStop;


        #endif
    }

    void CheckPermission()
    {
        #if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
        #endif  
    }

    #region Text to Speech
    public void StartSpeaking(string str)
    {
        TextToSpeech.Instance.StartSpeak(str);
    }

    public void StopSpeaking()
    {
        TextToSpeech.Instance.StopSpeak();
    }

    private void OnSpeakStart()
    {
        Debug.Log("Empezamos a hablar...");
    }

    private void OnSpeakStop()
    {
        Debug.Log("Terminamos de hablar...");
    }
    #endregion

    private void Setup(string str)
    {
        TextToSpeech.Instance.Setting(str, 1, 1);
    }

}
