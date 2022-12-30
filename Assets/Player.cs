using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;
    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;

    void Start()
    {
        setRandomColor();
    }
         

    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.tag == "ColorChanger")
        {
            setRandomColor();
            Destroy(collider.gameObject);
            return;
        }


        if(collider.tag != currentColor)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void setRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
        }
    }
}
