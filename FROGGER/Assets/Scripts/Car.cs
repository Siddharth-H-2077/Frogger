using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]private float movespeed;
    [SerializeField] private GameObject GO;
    [SerializeField] private int Lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GO, Lifetime); ;
    }

    private void FixedUpdate()
    {
        //thanks to the messed up rotations for the cars
        transform.Translate(new Vector3(-1,0,0)*movespeed*Time.fixedDeltaTime);
    }


}
