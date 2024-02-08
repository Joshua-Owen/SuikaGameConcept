using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitController : MonoBehaviour
{
    SpriteRenderer _sprite;
    BoxCollider2D _boxCollider;

    public LayerMask targetLayer;
    // Start is called before the first frame update
    void Start()
    {
        
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.enabled = !_sprite.enabled;

        _boxCollider = GetComponent<BoxCollider2D>();
        _boxCollider.enabled = !_boxCollider.enabled;


    }

    public IEnumerator LimitCheckRoutine()
    {

        yield return new WaitForSeconds(1f);
        print("Check is on");
        _boxCollider.enabled = true;
        _sprite.enabled = true;
        //_boxCollider.enabled = !_boxCollider.enabled;
        //_sprite.enabled = !_sprite.enabled;

        StartCoroutine("DisableCheckRoutine");




    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Fruit"))
        {

            print("Fruit detected");

        }
    }

    public IEnumerator DisableCheckRoutine()
    {
        yield return new WaitForSeconds(0.01f);
        _boxCollider.enabled = false;
        _sprite.enabled = false;
        print("Checj is off");
    }
    // Update is called once per frame
    void Update()
    {

    }




}
