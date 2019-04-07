using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingPlatform : MonoBehaviour
{
    private bool _isRollingForward = false;
    private bool _isRollingRight = false;
    private bool _isRollingUp = false;
    private bool _isMoving = false;
    private bool _isOnPlatform = false;
    private float _moveSpeed = 1f;

    [SerializeField]
    private int _platformID; // 0 = move back and forth, 1 = move left and right, 2 = move up and down, 3 = move right and left
    [SerializeField]
    private Vector3 _startPosition;
    [SerializeField]
    private Vector3 _endPosition;


    private void Update()
    {
        var _player = FindObjectOfType<Player>();
        if (_player != null)
        {
            if (_isMoving)
            {
                if (_platformID == 0)
                    RollBackAndForth();

                else if (_platformID == 1)
                    RollRightAndLeft();

                else if (_platformID == 2)
                    RollUpAndDown();

                else if (_platformID == 3)
                    RollLeftAndRight();
            }
            else if (_player.playerRestart)
                DefaultReset();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isOnPlatform = true;
            Invoke("StartRolling", 1f);
            if (_platformID == 0)
                transform.GetComponent<Renderer>().material.color = Color.cyan;

            else if (_platformID == 1)
                transform.GetComponent<Renderer>().material.color = Color.yellow;

            else if (_platformID == 2)
                transform.GetComponent<Renderer>().material.color = Color.grey;

            else if (_platformID == 3)
                transform.GetComponent<Renderer>().material.color = Color.green;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isOnPlatform = false;
            FindObjectOfType<Player>().transform.parent = null;
            _isMoving = false;
        }
    }

    private void StartRolling()
    {
        _isMoving = true;
    }

    private void RollBackAndForth()
    {
        if (transform.position.z <= _startPosition.z)
            _isRollingForward = true;

        else if (transform.position.z > _endPosition.z)
            _isRollingForward = false;

        if (_isRollingForward)
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);
    }
    private void RollRightAndLeft()
    {
        if (transform.position.x <= _startPosition.x)
            _isRollingRight = true;

        else if (transform.position.x > _endPosition.x)
            _isRollingRight = false;

        if (_isRollingRight)
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }
    private void RollUpAndDown()
    {
        if (_isOnPlatform)
        {
            FindObjectOfType<Player>().transform.parent = transform;
            FindObjectOfType<FollowPlayer>().setDefaultY(transform.position.y);
        }

        if (transform.position.y <= _startPosition.y)
            _isRollingUp = true;

        else if (transform.position.y > _endPosition.y)
            _isRollingUp = false;

        if (_isRollingUp)
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }

    private void RollLeftAndRight()
    {
        if (transform.position.x >= transform.position.x)
            _isRollingRight = false;

        else if (transform.position.x < transform.position.x)
            _isRollingRight = true;

        if (!_isRollingRight)
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
    }
    private void DefaultReset()
    {
        transform.position = _startPosition;
        transform.GetComponent<Renderer>().material.color = Color.white;
    }

}
