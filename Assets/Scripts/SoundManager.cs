using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>, ISoundtrack
{
    public ISoundtrack Soundtrack;
    public AudioSource audioSource;
    public AudioMixerGroup mixerGroup;

    public AudioClip[] audioClipList;

    private void Start()
    {
        audioSource.outputAudioMixerGroup = mixerGroup;
        PlaySound(ISoundtrack.Soundtype.SurfaceST);

    }
    public void PlaySound(ISoundtrack.Soundtype sound)
    {
        AudioSource.PlayClipAtPoint(audioClipList[(int) sound], transform.position);
    }

    public void MakeSound(ISoundtrack.Soundtype sound)
    {
        Soundtrack.MakeSound(sound);
    }
     
}
