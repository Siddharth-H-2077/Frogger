using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField]private GameObject[] arrayObjects;
    private int rand;
    public bool spawn; 
    [SerializeField]private float rateOfSpawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = true;
        //Spawn();
        StartCoroutine(KeepSpawning());
    }

    private int randomize()
    {
        rand= Random.Range(0,arrayObjects.Length);
        return rand;
    }

    private void Spawn()
    {
        GameObject Car = Instantiate(arrayObjects[randomize()], transform.position,transform.rotation);
    }


    IEnumerator KeepSpawning()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(1/rateOfSpawn);
            Spawn();
        }
    }
}
