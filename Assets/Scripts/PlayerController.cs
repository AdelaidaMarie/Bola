using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public TextMeshProUGUI scoreText;
    public GameObject winText;

    [Tooltip("Object to be instantiated")]
    public GameObject PrefabObject; //Object to be instantiated
    [Range(0, 40)]
    public int objectNumber;
    public Vector3 maxPosition;
    //Number score
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        GenerateObjects();
        rb = GetComponent<Rigidbody>();
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    //FixedUpdate is called once per fixed frame-rate frame
    void FixedUpdate()
    {
        //create a 3D movement
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //Apply force to the riggidbody
        rb.AddForce(movement * speed);
        if (objectNumber == count)
        {
            winText.SetActive(true);
        }
    }
    private void GenerateObjects()
    {


        //LOOP iterates creating new Game Object in game

        for (int i = 0; i < objectNumber; i++)
        {
            //take a number between 0 and the last array position

            //create an initial Position changing x,y,z
            Vector3 initialPosition = new Vector3(
                Random.Range(-9, 9),
                Random.Range(1, maxPosition.y),
                Random.Range(-9, 9)
                );
            
            
            Collider[] checkIfOverlaps = Physics.OverlapBox(initialPosition, PrefabObject.transform.localScale / 2, Quaternion.identity);
            do
            {
                initialPosition = new Vector3(Random.Range(-9, 9), 0.5f, Random.Range(-9, 9));

                checkIfOverlaps = Physics.OverlapBox(initialPosition, PrefabObject.transform.localScale / 2, Quaternion.identity);
            }
            while (checkIfOverlaps.Length > 0);
            //add and object to the game
            Instantiate(PrefabObject, initialPosition, Quaternion.identity);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            scoreText.text = "Score : " + (count * 10).ToString("000");
        }

    }

}

//private void GenerateObjects() {      
    //loop iterates creating new game Objects in the game
    //for (int i = 0; i < cont; i++)     {                 
    //create a inital position changing x,y,z
    //Vector3 initalPosition = new Vector3(Random.Range(-9, 9),0.5f, Random.Range(-9, 9));
