using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float jump = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorBiru;
    public Color colorKuning;
    public Color colorPink;
    public Color colorUngu;

    public static int score = 0;
    public Text scoreText;

    public GameObject[] circle;
    public GameObject colorChanger;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jump;
        }

        scoreText.text = score.ToString();

    }

    void OnTriggerEnter2D(Collider2D col)
    {        

        if(col.tag == "coin")
        {
            score++;
            Destroy(col.gameObject);
            int randomNumber = Random.Range(0, 2);
            if(randomNumber == 0)
                Instantiate(circle[0], new Vector2(transform.position.x, transform.position.y + 11f), transform.rotation);
            else 
                Instantiate(circle[1], new Vector2(transform.position.x, transform.position.y + 8f), transform.rotation);
            return;
        }

        if(col.tag == "colorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            Instantiate(colorChanger, new Vector2(transform.position.x, transform.position.y + 11f), transform.rotation);
            return; 
        }

        if(col.tag != currentColor)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0 : currentColor = "biru";
                sr.color = colorBiru;
                break;

            case 1 : currentColor = "kuning";
                sr.color = colorKuning;
                break;

            case 2 : currentColor = "pink";
                sr.color = colorPink;
                break;

            case 3 : currentColor = "ungu";
                sr.color = colorUngu;
                break;
        }   
    }
}
