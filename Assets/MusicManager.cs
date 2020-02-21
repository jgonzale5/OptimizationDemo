using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource source;

    public void PauseResume(bool pause)
    {
        if (pause)
            source.Pause();
        else
            source.Play();
    }
}
