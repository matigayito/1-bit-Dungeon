using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private int health;
    private float distance;
    public float areax;
    public float areay;
    public float timeToMove;
    private float timeSinceMove;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        distance = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeSinceMove > timeToMove )
        { 
            RandomMovement();  
        }
    }

    void RandomMovement()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                if (CheckCollision(Vector3.up))
                {
                    transform.position += Vector3.up * distance;
                    
                }
                break;
            case 1:
                if (CheckCollision(Vector3.down))
                {
                    transform.position += Vector3.down * distance;
                    
                }
                break;
            case 2:
                if (CheckCollision(Vector3.right))
                {
                    transform.position += Vector3.right * distance;
                    
                }
                break;
            case 3:
                if (CheckCollision(Vector3.left))
                {
                    transform.position += Vector3.left * distance;
                }
                break;
        }
        timeSinceMove = Time.time;
    }
    
    private bool CheckCollision(Vector3 direction)
    {
        //TODO: YO
        //tiene que haber una forma de generalizar esto
        if (Physics.Raycast(transform.position, direction, 10))
        {
            Debug.Log("There is something in front of the object!");
            return false;
        }
        return true;
    }}
