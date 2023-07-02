using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    [SerializeField] private GameObject audioAvatar;
    [SerializeField] private bool doTurnoffAudioAvatar;
    public List<GameObject> offGameObjects=new List<GameObject>();
    public List<GameObject> onGameObjects = new List<GameObject>();
  
    private void Start()
    {
        Invoke(nameof(AnimDisable), audioAvatar.GetComponent<AudioSource>().clip.length);
        Invoke(nameof(Enable), audioAvatar.GetComponent<AudioSource>().clip.length + 0.5f);
        Invoke(nameof(Disable), audioAvatar.GetComponent<AudioSource>().clip.length + 0.5f);
        Invoke(nameof(offAudio), audioAvatar.GetComponent<AudioSource>().clip.length + 0.5f);
    }


    private void Disable()
    {
        for (int i = 0; i < offGameObjects.Count; i++)
        {
            offGameObjects[i].SetActive(false);
        }
    }

    private void Enable()
    {
        for (int i = 0; i < onGameObjects.Count; i++)
        {
            onGameObjects[i].SetActive(true);
            Debug.Log(onGameObjects[i].name);
        }
    }

    private void AnimDisable()
    {
        audioAvatar.GetComponent<Animator>().enabled = false;
    }

    private void offAudio()
    {
        if (doTurnoffAudioAvatar)
        {
            audioAvatar.SetActive(false);
        }
    }
}