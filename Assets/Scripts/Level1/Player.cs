using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player Movement and Animation
    private CharacterController _controller;
    private Animator _playerAnim;

    [SerializeField]
    private float _moveSpeed = 3f;
    [SerializeField]
    private float _rotationSpeed = 5f;
    private float _rotation = 0f;
    [SerializeField]
    private float _jumpSpeed = 200f;
    private float _gravity = 9.81f;
    #endregion

    private GameManager _gameManager;
    private UIManager _uiManager;
    private KeyCard _keyCard;

    private AudioSource _jumpSound;
    [SerializeField]
    private AudioClip _fallingSoundClip;

    public bool hasKeyCard = false;
    public bool playerRestart;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerAnim = GetComponent<Animator>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _jumpSound = GetComponent<AudioSource>();
        _keyCard = GameObject.Find("KeyCard").GetComponent<KeyCard>();

        playerRestart = false;
    }

    void Update()
    {
        Movement();
        if (transform.position.y < -2)
        {
            AudioSource.PlayClipAtPoint(_fallingSoundClip, transform.position, 1f);
            Damage();
        }
    }
       

    #region Methods
    #region Movement
    void Movement()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float walkInput = Input.GetAxis("Vertical");

        _rotation += rotationInput * _rotationSpeed;
        transform.eulerAngles = new Vector3(0f, _rotation, 0f);

        Vector3 moveDirection = new Vector3(0f, 0f, -walkInput);
        Vector3 velocity = moveDirection * _moveSpeed;

        if (_controller.isGrounded)
        {
            if (walkInput != 0f)
            {
                _playerAnim.SetBool("isWalking", true);
                _playerAnim.SetBool("Jumping_Forward", false);
                velocity = transform.TransformDirection(velocity);
                if (walkInput > 0f && Input.GetKeyDown(KeyCode.Space))
                {
                    _jumpSound.Play();
                    _playerAnim.SetBool("Jumping_Forward", true);
                    velocity.y = _jumpSpeed;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpSound.Play();
                _playerAnim.SetBool("isJumping", true);
                velocity.y = _jumpSpeed;
            }
            else
            {
                _playerAnim.SetBool("isWalking", false);
                _playerAnim.SetBool("isJumping", false);
                _playerAnim.SetBool("Jumping_Forward", false);
            }
            velocity.y -= _gravity;
            _controller.Move(velocity * Time.deltaTime);
        }
    }
    #endregion

    void Damage()
    {
        _gameManager.lives--;
        _uiManager.UpdateLives(_gameManager.lives);

        if (_gameManager.lives < 1)
        {
            Destroy(this.gameObject);
            _uiManager.UpdateLives(0);
            _uiManager.EnableGameOver();
            return;
        }
        
        Destroy(this.gameObject);
        _gameManager.StartSpawnPlayer();
        playerRestart = true;
        _uiManager.RemoveKeyCard();
        _keyCard.ShowKeyCard();
    }

    #endregion
}
