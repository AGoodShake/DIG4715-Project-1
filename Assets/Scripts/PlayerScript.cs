using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject winText;
    AudioSource audioSource;
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public bool audio = false;
    public bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audio == true)
        {
            PlaySound(musicClipOne);
        }
        StartCoroutine(ExecuteAfterTime(12));
        GameObject Teleport1 = GameObject.Find ("TeleportLocation1");
        GameObject Teleport2 = GameObject.Find ("Teleport Location 2");
        GameObject Teleport3 = GameObject.Find ("Teleport Location 3");
        GameObject Teleport4 = GameObject.Find ("Teleport Location 4");
            if(Input.GetKeyDown(KeyCode.W) && pause == false)
        {
            Transform playerTransform1 = Teleport1.transform;
            transform.position = Teleport1.transform.position;
        }
        if(Input.GetKeyDown(KeyCode.A) && pause == false)
        {
            Transform playerTransform2 = Teleport2.transform;
            transform.position = Teleport2.transform.position;
        }
        if(Input.GetKeyDown(KeyCode.S) && pause == false) 
        {
            Transform playerTransform3 = Teleport3.transform;
            transform.position = Teleport3.transform.position;
        }
        if(Input.GetKeyDown(KeyCode.D) && pause == false)
        {
            Transform playerTransform4 = Teleport4.transform;
            transform.position = Teleport4.transform.position;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "enemy")
     {
          Destroy(collision.collider.gameObject);
          //lives = lives - 1;  
          //SetLivesText();
     }
    }
        IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (pause == false)
        {
        winText.SetActive(true);
        audio = true;
        }
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
