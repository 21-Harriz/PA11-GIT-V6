using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public int score;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        if (transform.position.y >= 3.92)
        {
            transform.position = new Vector3(transform.position.x, 3.92f, transform.position.z);
        }
        else if (transform.position.y <= -3.98)
        {
            transform.position = new Vector3(transform.position.x, -3.98f, transform.position.z);
        }

        if (score >= 200)
        {
            SceneManager.LoadScene("GameWin");
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PassObstacle"))
        {
            score+=10;
            ScoreText.GetComponent<Text>().text = "Score : " + score;
        }
    }
}
