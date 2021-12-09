using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Range(0, 24)] public float maxVelocity = 12.0f;//move left and right ceiling
    [Range(0, 24)] public float maxJumpVelocity = 20.0f;
    [SerializeField] private List<Transform> endPoints;

    public float speed = 0.1f;
    public float camelSpeed = 1.0f;
    public float jumpSpeed = 1.0f;

    private bool moveLeft, moveRight, moveUp, moveDown, jump;

    public static bool test = false;
    public bool isEnabled = true;
    public int camelRange = 5;
    public List<GameObject> camels;
    private float elapsedTime;
    private float desiredDuration = 100f;

    private Vector2 startPosition;
    int rand;

    //properties
    public bool MoveLeft
    {
        get { return moveLeft; }
        set { moveLeft = value; }
    }

    public bool MoveRight
    {
        get { return moveRight; }
        set { moveRight = value; }
    }

    public bool MoveUp
    {
        get { return moveUp; }
        set { moveUp = value; }
    }

    public bool MoveDown
    {
        get { return moveDown; }
        set { moveDown = value; }
    }


    void Awake()
    {
        Debug.Log(test);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (moveLeft)
        {
            transform.position = new Vector2(
                transform.position.x-speed,
                transform.position.y);
        }//end if

        if (moveRight)
        {
            transform.position = new Vector2(
                transform.position.x+speed,
                transform.position.y);
        }

        if (moveUp)
        {
            transform.position = new Vector2(
                transform.position.x,
                transform.position.y+speed);
        }

        if (moveDown)
        {
            transform.position = new Vector2(
                transform.position.x,
                transform.position.y - speed);
        }

        
    }//end method


    private void Update()
    {
        //StartCoroutine(WinTimer());
        rand = Random.Range(1, 50);
        //rand = 5;
        if(rand == camelRange && isEnabled)
        {
            //int camel = Random.Range(1, 5);
            //int camel = 1;
            int randomCamelStart = Random.Range(0, 4);

            //randomCamelStart = 0;

            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / desiredDuration;

            GameObject chosenCamel;

            chosenCamel = camels[randomCamelStart];

            startPosition = chosenCamel.transform.position;
            chosenCamel.transform.position = Vector2.Lerp(startPosition, endPoints[randomCamelStart].position, percent);
            if (chosenCamel.transform.position == endPoints[randomCamelStart].position)
            {
                SceneManager.LoadScene("Game Over");
            }


            /*
            if (randomCamelStart == 0)
            {
                //Debug.Log("Top");
                chosen = camels[0];

                startPosition = chosen.transform.position;
                chosen.transform.position = Vector2.Lerp(startPosition, endPoints[0].position, percent);
                if (chosen.transform.position == endPoints[0].position)
                {
                    SceneManager.LoadScene("Game Over");
                }
                
                
            }
            else if (randomCamelStart == 1)
            {
                //Debug.Log("Bottom");
                chosen = camels[1];
                startPosition = chosen.transform.position;
                chosen.transform.position = Vector2.Lerp(startPosition, endPoints[1].position, percent);
                if (chosen.transform.position == endPoints[1].position)
                {
                    SceneManager.LoadScene("Game Over");
                }
        }
            else if (randomCamelStart == 2)
            {
                //Debug.Log("Left");
                chosen = camels[2];
                startPosition = chosen.transform.position;
                chosen.transform.position = Vector2.Lerp(startPosition, endPoints[2].position, percent);
                if (chosen.transform.position == endPoints[2].position)
                {
                    SceneManager.LoadScene("Game Over");
                }

        }
            else if (randomCamelStart == 3)
            {
                //Debug.Log("Right");
                chosen = camels[3];
                startPosition = chosen.transform.position;
                chosen.transform.position = Vector2.Lerp(startPosition, endPoints[3].position, percent);
                if (chosen.transform.position == endPoints[3].position)
                {
                    SceneManager.LoadScene("Game Over");
                }

        }
            */
            //StartCoroutine(Timer());
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveUp = true;
        }
        else
        {
            moveUp = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDown = true;
        }
        else
        {
            moveDown = false;
        }

    }//end method

    IEnumerator Timer()
    { 
        isEnabled = false;
        yield return new WaitForSeconds(5);
        isEnabled = true;
    }
    IEnumerator WinTimer()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Victory");
    }

}//end class
