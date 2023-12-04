using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    [SerializeField]
    bool _fruitIsInstantiated = true;

    [SerializeField]
    Transform _fruitPosition;
    [SerializeField]
    Rigidbody2D _fruitBody;
    private IEnumerator _dropFruitCoroutine;
    Controller _controller;
    
    // Start is called before the first frame update
    void Start()
    {
        _fruitIsInstantiated = true;
        _fruitPosition = GetComponent<Transform>();
        _fruitBody = GetComponent<Rigidbody2D>();
        _controller = FindObjectOfType<Controller>();

        if (transform.position.y < 3.5f)
        {
            _fruitIsInstantiated = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        DropFruit();
        if (_fruitIsInstantiated)
        {
            _fruitPosition.position = Controller.dropPosition;

        }
    }

    void DropFruit()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //_fruitBody.gravityScale = 1;        
            _fruitIsInstantiated = false;

            Controller.enabled = true;
            _controller.StartCoroutine("SpawnFruitRoutine");

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            _controller.tagNo = int.Parse(collision.gameObject.tag);
            _controller.upgradePosition = new Vector2(collision.transform.position.x, collision.transform.position.y);
            _controller.newFruit = "y";
            Destroy(this.gameObject);
            //_controller.NextFruit(/*upgradePosition, gameObject.tag*/);

        }
    }


}
