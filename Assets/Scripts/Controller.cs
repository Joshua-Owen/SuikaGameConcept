using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Vector2 dropPosition;

    [SerializeField]
    Rigidbody2D controller;

    [SerializeField]
    float leftLimit = -3.8f;
    [SerializeField]
    float rightLimit = 1.2f;
    [SerializeField]
    float _speed = 1.0f;

    [SerializeField]
    public Transform[] _fruitObject;

    [SerializeField]
    public static bool enabled = true;
    // Start is called before the first frame update
    FruitController fruitController;
    public string newFruit = "n";
    public int tagNo;
    public Vector2 upgradePosition;


    void Start()
    {
        controller = GetComponent<Rigidbody2D>(); 
        StartCoroutine("SpawnFruitRoutine");
        fruitController = FindObjectOfType<FruitController>();
    }

    // Update is called once per frame
    void Update()
    {
        DropBoundries();

       
        Movement();

        NextFruit();
        dropPosition = transform.position;



    }
    void DropBoundries()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), transform.position.y);
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector2(horizontalInput, 0);
        transform.Translate(direction * -_speed * Time.deltaTime);

    }




    IEnumerator SpawnFruitRoutine()
    {

        while (enabled)
        {
            print("f2");
 yield return new WaitForSeconds(1f);
            Instantiate(_fruitObject[UnityEngine.Random.Range(0, 2)], transform.position, Quaternion.identity);
           enabled = false;
            StopCoroutine("SpawnFruitRoutine");
        }
        

    }
    public void NextFruit(/*Vector2 posistion, String tag*/)
    {
        if(newFruit == "y")
        {
            newFruit = "n";
             Debug.Log("1");
            Instantiate(_fruitObject[tagNo +1],upgradePosition, Quaternion.identity);


        }
           
        

    }


}
