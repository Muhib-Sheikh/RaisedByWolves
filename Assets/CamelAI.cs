using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamelAI : MonoBehaviour
{
    private Vector3 destination;
    private Vector2 begin;
    private float elapsedTime;
    private float desiredDuration = 1000f;
    //private float percentComplete;

    private int randStartPos = RandomCamelSpawner.randomCamelStart;
    private Vector3 startPosition;
    [SerializeField] private List<Transform> endPoints;

    // Start is called before the first frame update
    void Start()
    {
        // starting place of camel
        begin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        elapsedTime += Time.deltaTime;
        float percentComplete = elapsedTime / duration;

        // linear movement
        transform.position = Vector2.Lerp(begin, destination, percentComplete);

        // "wrong way" starts fast then slows down
        //transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime);
        */


        elapsedTime += Time.deltaTime;
        //float percent = elapsedTime / desiredDuration;
        float percentComplete = elapsedTime / desiredDuration;

        //GameObject chosenCamel;

        //chosenCamel = camels[randomCamelStart];

        // start top
        if (randStartPos == 0)
            destination = new Vector3(0, -4);
        // start right
        else if (randStartPos == 1)
            destination = new Vector3(-9, 0);
        // start bottom
        else if (randStartPos == 2)
            destination = new Vector3(0, 4);
        // start left
        else
            destination = new Vector3(9, 0);

        startPosition = transform.position;
        transform.position = Vector3.Lerp(startPosition, destination, percentComplete);
        if (transform.position == destination)
        {
            Debug.Log("Game Over");
                
            //SceneManager.LoadScene("Game Over");
        }

    }
}
