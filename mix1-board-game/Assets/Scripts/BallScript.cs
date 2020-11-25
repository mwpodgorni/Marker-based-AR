using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject ground;

    public GameObject spawnPoint;

    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.AddForce(new Vector3(0,0,-15));
        
        if (transform.position.y < ground.transform.position.y - 10)
        {
            transform.position = spawnPoint.transform.position;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "JackRightPaddle" || other.collider.tag == "JackLeftPaddle" ||
            other.collider.tag == "QueenRightPaddle"|| other.collider.tag == "QueenLeftPaddle"||
            other.collider.tag == "KingRightPaddle" || other.collider.tag == "KingLeftPaddle" ||
            other.collider.tag == "AceRightPaddle"  || other.collider.tag == "AceLeftPaddle")
        {
            // _rigidbody.AddForce(new Vector3(0,0,2500));
            _rigidbody.AddExplosionForce(2400, this.transform.position, 1);
        }
    }
}
