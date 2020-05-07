using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody PlayerRigidbody;
    public int coinCount;
    public GameObject CoinText;


    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        // do Movement
        Movement();

        Win();
    }

    void Movement ()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinCount += 1;

            CoinText.GetComponent<Text>().text = "Coin : " + coinCount;
           
            Destroy(other.gameObject);
        }
    }

    void Win()
    {
        if(coinCount == 4)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}

