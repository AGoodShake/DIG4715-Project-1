using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 transformPosition = new Vector3(0.0f,0.0f,0.0f);
    public float speed = 3;
    //private Lives playerController;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject playerObject = GameObject.FindWithTag("player");
        //if (playerObject != null)
        //{
            //playerController = playerObject.GetComponent<Lives>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ExecuteAfterTime(2));
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transformPosition, step);
            if(transform.position.y == 0.0f && transform.position.x == 0.0f)
            {
                //public int lives;
                //Lives player = GameObject.GetComponent<Lives>();
                //if (player != null)
                //{
                    //player.playersLives - 1;
                //}
                Destroy(gameObject);
                GameObject.Find("player").GetComponent<Lives>().playersLives -= 1;
            }
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.collider.tag == "Player")
     {
          Destroy(gameObject);
          //lives = lives - 1;  
          //SetLivesText();
     }
    }
}
