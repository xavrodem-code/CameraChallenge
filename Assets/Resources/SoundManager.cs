using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip _correct;
    public static AudioClip _wrong;
    static AudioSource _audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        _correct = Resources.Load<AudioClip>("correct");
        _wrong = Resources.Load<AudioClip>("wrong");
        _audioSrc = GetComponent<AudioSource>();
    }

    public static void Playsound()
    {
        _audioSrc.PlayOneShot(_correct);
    }

    public static void Playsound2()
    {
        _audioSrc.PlayOneShot(_wrong);
    }
}
