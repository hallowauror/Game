using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag != currentColor)
        {
            Debug.Log("Game Over!");
        }

        if(col.tag == "colorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return; 
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
