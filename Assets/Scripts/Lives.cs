using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public float playersLives = 4;
    public GameObject loseText;
    Rigidbody2D rigidbody2d;
    public Text livesText;
    public AudioSource musicSource;
    public AudioClip audioClip;
    AudioSource audioSource;
    public float timeLeft = 10.0f;
    public Text startText;
    public bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(2));
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource= GetComponent<AudioSource>();
        SetLivesText ();
    }

    // Update is called once per frame
    void Update()
    {
        if (started == true)
        {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        }
        if (timeLeft < 0)
        {
            Destroy(startText);
        }
        SetLivesText ();
        //Debug.Log(playersLives);
        if (playersLives <= 0)
        {
            GameObject.Find("player").GetComponent<PlayerScript>().pause = true;
            loseText.SetActive(true);
            PlaySound(audioClip);
        }
    }
        void SetLivesText()
    {
        livesText.text = "Lives: " + playersLives.ToString ();
    }
        public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }    
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        started = true;
    }
}
