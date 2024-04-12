using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
 
    [SerializeField] private Transform pos;
    private PlayerInputs input=null;
    private Vector2 dir=Vector2.zero;
    [SerializeField] private Rigidbody rb = null;
    public float movespeed;
    //public bool safe;
    public bool reached;
    public bool dead;


    //setting up input manager
    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
        input = new PlayerInputs();
    }

    //subscribing to playerinputs
    private void OnEnable()
    {
        input.Enable();
        input.player.MovementHeld.performed += ctx => onHeld(ctx.ReadValue<Vector2>());

        input.player.Movement.performed += ctx => onMovement(ctx.ReadValue<Vector2>());
        input.player.Movement.canceled += ctx => onCancelMovement(ctx.ReadValue<Vector2>());
    }
    //unsubscribing from playerinputs

    private void onHeld(Vector2 val)
    {
        dir = Vector2.zero;
    }
    private void OnDisable()
    {
        input.Disable();
        input.player.Movement.performed -= ctx => onMovement(ctx.ReadValue<Vector2>());
        input.player.Movement.canceled -= ctx => onCancelMovement(ctx.ReadValue<Vector2>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cars")
        {
            dead = true;
            Debug.Log("Car-ed");
            respawn();
        }
        else
        {
            dead = false;          
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground"|| other.gameObject.tag == "Wood"|| other.gameObject.tag == "Turtle")
        {
            dead = false;
        }

        else if(dead==false&&other.gameObject.tag=="Finish")
        {
            reached = true;
            //Debug.Log("Reached");
            respawn();
        }
        else
        {
            dead = true;
            //Debug.Log("Watered-ed");
            respawn();
        }
    }
    private void onCancelMovement(Vector2 val)
    {
        dir = Vector2.zero;
    }

    private void onMovement(Vector2 val)
    {
        if (val.x != 0) dir.x = val.x;
        else if (val.y != 0) dir.y = val.y;

        transform.position = new Vector3(transform.position.x+dir.x, transform.position.y, transform.position.z + dir.y);
    }
    private void FixedUpdate()
    {
        //Debug.Log(dir);
        //rb.velocity = new Vector3(dir.x,0 , dir.y);
        
    }
 
    public void respawn() 
    {
        transform.position = pos.position;
    }
}
