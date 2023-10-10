using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    [Tooltip("Object to be instantiated")]
    public GameObject PrefabObject; //Object to be instantiated
    [Range(0, 20)]
    public int objectNumber;
    public Vector3 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        GenerateObjects();
    }

    // Update is called once per frame
    void Update()
    {

        }
    
    private void GenerateObjects()
    {
 

        //LOOP iterates creating new Game Object in game

        for (int i = 0; i < objectNumber; i++)
        {
            //take a number between 0 and the last array position

            //create an initial Position changing x,y,z
            Vector3 initialPosition = new Vector3(
                Random.Range(-4, maxPosition.x),
                Random.Range(1, maxPosition.y),
                Random.Range(-4, maxPosition.z)
                );
            //add an object
            Instantiate(PrefabObject, initialPosition, Quaternion.identity);
       
        }
        
    }
}
