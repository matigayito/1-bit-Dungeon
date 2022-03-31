using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public float movement;
    private bool inMovement;

    public int health;
    public int armor;
    public int damage;



    // Start is called before the first frame update
    void Start()
    {
        inMovement = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inMovement)
        {
            CheckKeys();
        }
    }

    private void CheckKeys()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 up = new Vector3(0, 1);
            if (CheckCollision(up))
            {
                transform.position += up*movement;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 down = new Vector3(0, -1);
            if (CheckCollision(down))
            {
                transform.position += down*movement;

            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {            
            Vector3 right = new Vector3(1, 0);
            if (CheckCollision(right))
            {
                transform.position += right*movement;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 left = new Vector3(-1, 0);
            if (CheckCollision(left))
            {
                transform.position += left*movement;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void CheckMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        inMovement = false;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().BattleMode(this.gameObject, collision.gameObject);
            Debug.Log("Entrando en COMBATE!!!");
        }
        if (collision.gameObject.CompareTag("Shop"))
        {
            Debug.Log("Entrando a la tienda...");
        }
    }
    public void ChangeCombat()
    {
        inMovement = false;
    }

}
