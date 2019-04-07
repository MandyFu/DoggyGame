using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private int _platFormID; // 0 = move back and forth, 1 = move left and right, 2 = move up and down, 
    [SerializeField]
    private Vector3 _startPosition;
    [SerializeField]
    private Vector3 _endPosition;

    private float _moveSpeed = 2f;
    private bool _isMovingToRight = false;
    private bool _isMovingForward = false;
    private bool _isMovingUp = false;
    private bool _isParent = false;

    private void Update()
    {
        if (_platFormID == 0) MoveBackAndForth();

        else if (_platFormID == 1) MoveLeftAndRight();

        else if (_platFormID == 2) MoveUpAndDown();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isParent = true;
            FindObjectOfType<Player>().transform.parent = transform;

            if (_platFormID == 0)
                transform.GetComponent<Renderer>().material.color = Color.cyan;

            else if (_platFormID == 1)
                transform.GetComponent<Renderer>().material.color = Color.yellow;

            else if (_platFormID == 2)
                transform.GetComponent<Renderer>().material.color = Color.grey;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isParent = false;
            FindObjectOfType<Player>().transform.parent = null;
            transform.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void MoveBackAndForth()
    {
        if (transform.position.z <= _startPosition.z)
            _isMovingForward = true;

        else if (transform.position.z > _endPosition.z)
            _isMovingForward = false;

        if (_isMovingForward)
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);

        else
            transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);
    }
    void MoveLeftAndRight()
    {
        if (transform.position.x <= _startPosition.x)
            _isMovingToRight = true;

        else if (transform.position.x > _endPosition.x)
            _isMovingToRight = false;

        if (_isMovingToRight)
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);

        else
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }
    void MoveUpAndDown()
    {
        if (_isParent)
            FindObjectOfType<FollowPlayer>().setDefaultY(transform.position.y);

        if (transform.position.y <= _startPosition.y)
            _isMovingUp = true;

        else if (transform.position.y > _endPosition.y)
            _isMovingUp = false;

        if (_isMovingUp)
            transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);

        else
            transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
    }
}
