using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioSource[] sourses;

    void Start()
    {
        sourses = GetComponents<AudioSource>();
        sourses[0].Play();
    }
}
