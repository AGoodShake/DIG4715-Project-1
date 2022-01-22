using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(2));
        StartCoroutine(ExecuteAfterTime(12));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        musicSource.clip = musicClipOne;
        musicSource.Play();
        musicSource.loop = true;
    }
    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        musicSource.clip = musicClipOne;
        musicSource.Stop();
    }
        public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
