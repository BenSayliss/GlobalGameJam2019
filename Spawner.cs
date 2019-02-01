using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject AnimalInit;
    public GameObject AnimalNew;
    public GameObject NewForest;
    public GameObject NewDeer;

    private float AnimalOffset;

    private Vector3 InitialPos;
    private Vector3 forestOffset;

    public bool Spawned = true;

    void Start()
    {
        forestOffset.x = 51;
        forestOffset.y = 0;
        forestOffset.z = 0;
        AnimalInit = GameObject.Find("Animal");
        InitialPos = AnimalInit.GetComponent<Transform>().position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        AnimalOffset = (Random.Range(5, 13));

        if (collider.gameObject.CompareTag("Spawner"))
        {
            InitialPos = collider.transform.position;
            NewDeer = Instantiate(AnimalNew, new Vector3(AnimalOffset + InitialPos.x, InitialPos.y, InitialPos.z), Quaternion.identity);
            NewDeer.tag = "HitBox";

            if (collider.gameObject.name == "Spawner")
            {
                NewForest = GameObject.Find("DeerForest0");
                NewForest.GetComponent<Transform>().transform.position += forestOffset;
            }
            else if (collider.gameObject.name == "Spawner1")
            {
                NewForest = GameObject.Find("DeerForest");
                NewForest.GetComponent<Transform>().transform.position += forestOffset;
            }
            else if (collider.gameObject.name == "Spawner0")
            {
                NewForest = GameObject.Find("DeerForest1");
                NewForest.GetComponent<Transform>().transform.position += forestOffset;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
