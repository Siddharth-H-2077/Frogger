using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] private GameObject GO;
    [SerializeField] private int Lifetime;

    private bool yN;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(GO, Lifetime);
        if (GO.tag == "Turtle")
        {
            StartCoroutine(OnOff());
        }    
    }

    private void destroy()
    {
        Destroy(GO);
    }

    private void FixedUpdate()
    {
        //thanks to the messed up rotations for the cars
        transform.Translate(new Vector3(-1, 0, 0) * movespeed * Time.fixedDeltaTime);
        
        if(GO.transform.position.x<-11 ||
           GO.transform.position.x>11
                                       )
        {
            destroy();
        }
    }
    IEnumerator OnOff()
    {
        while (true)
        {
            GO.GetComponent<BoxCollider>().enabled = false;
            GO.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.3f);

            GO.GetComponent<BoxCollider>().enabled = true;
            GO.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }

}
