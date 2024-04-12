using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishline : MonoBehaviour
{
    private bool active;
    [SerializeField] private Player player;
    [SerializeField] private GameObject GO;
    [SerializeField] private BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        GO.GetComponent<MeshRenderer>().enabled = false;
        active = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(active)
        {
            GO.GetComponent<MeshRenderer>().enabled = true;
            //active = false;
            GO.tag = "Cars";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
