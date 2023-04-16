using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpPower = 5;
    public float lowWarn = -4;
    public float jumpBoost = 2.5f;
    public float step = 0.1f;
    public Text scoreOutput;
    int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //scoreOutput = GameObject.Find("Text")
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(step * Time.deltaTime, 0, 0); // 플레이어가 앞으로 감 !
        //transform.localScale += new Vector3(0, step * Time.deltaTime, 0); // 플레이어가 점점 키가 커짐 !
        if (Input.GetButtonDown("Jump"))
        {
            if (transform.position.y < lowWarn)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower * jumpBoost, 0);
                Debug.Log("Boost Jump");
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
                Debug.Log("Jump");
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void addScore(int s)
    {
        score += s;
        scoreOutput.text = "점수 : " + score;
    }
}
