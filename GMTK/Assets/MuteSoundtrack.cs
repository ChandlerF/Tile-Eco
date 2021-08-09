using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSoundtrack : MonoBehaviour
{
    private AudioSource SoundtrackAudio;
    private bool IsMuted = false;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Soundtrack");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        SoundtrackAudio = transform.GetComponent<AudioSource>();
    }
    public void MuteTheSoundtrack()
    {
        if (!IsMuted)
        {
            SoundtrackAudio.Pause();
            IsMuted = true;
        }
        else
        {
            SoundtrackAudio.Play();
            IsMuted = false;
        }
    }
}
