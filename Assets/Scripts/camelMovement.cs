using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camelMovement : MonoBehaviour
{
    public float startx;
    public float starty;
    public bool moveUp = false;
    public bool moveDown = false;
    public bool moveLeft = false;
    public bool moveRight = false;
    private float moveSpeed = .1f;
    public static bool hasBaby = false;
    public GameObject baby;
    private int camelID = 0;
    public static int gameMode = 1;

    public Rigidbody2D rb ;
    public Animator animator;

    public bool camelKidnap = false;

    Vector2 movement;

    void Start()
    {
        if(gameMode == 2)
        {
            moveSpeed = moveSpeed * 1.5f;
        }
        
        baby = GameObject.Find("Baby");
        startx = transform.position.x;
        starty = transform.position.y;
       
        if(startx > 0 && starty == 0){
            moveLeft = true;
        }
        else if(startx < 0 && starty == 0){
            moveRight = true;
        }
        else if(startx == 0 && starty > 0){
            moveDown = true;
        }
        else if(startx == 0 && starty < 0){
            moveUp = true;
        }
        animator.SetBool("MoveRight", moveRight);
        animator.SetBool("MoveLeft", moveLeft);
        animator.SetBool("MoveUp", moveUp);
        animator.SetBool("MoveDown", moveDown);
        camelID = Random.Range(0, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.FloorToInt(transform.position.x) == 9 && moveRight && HungerLevel.kidnapID == camelID)
        {
            SceneManager.LoadScene("Game Over");
        }
        else if (Mathf.FloorToInt(transform.position.x) == -9 && moveLeft && HungerLevel.kidnapID == camelID)
        {
            SceneManager.LoadScene("Game Over");
        }
        else if (Mathf.RoundToInt(transform.position.y) == 5 && moveUp && HungerLevel.kidnapID == camelID)
        {
            SceneManager.LoadScene("Game Over");
        }
        else if (Mathf.RoundToInt(transform.position.y) == -5 && moveDown && HungerLevel.kidnapID == camelID)
        {
            SceneManager.LoadScene("Game Over");
        }


        if (startx > 0 && starty == 0){
            movement.x = -10f;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else if(startx < 0 && starty == 0){
            movement.x = 10f;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else if(startx == 0 && starty > 0){
            movement.y = -10f;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else if(startx == 0 && starty < 0){
            movement.y = 10f;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Wolf")
        {
            if(hasBaby == true)
            {
                StartCoroutine(pickUpTimer());
            }
            RandomCamelSpawner.CurrentCamelAmount--;
            if (HungerLevel.kidnapID == camelID)
            {
                hasBaby = false;
                baby.SetActive(true);
            }
            playermovment.playerScore += 5;
            Destroy(this.gameObject);
        }
        else if (collider.gameObject.name == "Baby")
        {
            collider.gameObject.SetActive(false);
            moveSpeed = moveSpeed * 1.75f;
            HungerLevel.kidnapID = camelID;
            hasBaby = true;
        }
    }

    IEnumerator pickUpTimer()
    {
        yield return new WaitForSeconds(1);
    }



}
