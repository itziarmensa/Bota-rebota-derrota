using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 500f;
    private Animator animator;

    public int collisionCount = 0;

    private Rigidbody2D rb;

    public Text punt;

    private Vector2 touchOrigin = -Vector2.one;    //Used to store location of screen touch origin for mobile controls.


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        punt = GameObject.Find("Canvas/Text").GetComponent<Text>();

        Camera camera = Camera.main;

        float cameraHalfWidth = camera.orthographicSize * camera.aspect;
        float cameraHalfHeight = camera.orthographicSize;

        float x = camera.transform.position.x - cameraHalfWidth;
        float y = camera.transform.position.y - cameraHalfHeight;
        float positionY = y + 1f;

        // Asignamos la posición inicial al personaje
        transform.position = new Vector2(x, positionY);

        collisionCount = 0;

        punt.text = "Puntuación: " + collisionCount;
    }

    void Update()
    {


        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        float moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveY * moveSpeed);

        if (moveX != 0)
        {
            animator.SetTrigger("PlayerRun");

        }
        else if (moveY != 0)
        {

            animator.SetTrigger("PlayerJump");
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fantasma"))
        {

            collisionCount++;

            Destroy(collision.gameObject);

            punt.text = "Puntuación: " + collisionCount;

            if(collisionCount >= 10)
            {
                yield return new WaitForSeconds(0.9f);
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WinScene");
                while (!asyncLoad.isDone)
                {
                    yield return null;
                }
            }

            
        }
    }

}

