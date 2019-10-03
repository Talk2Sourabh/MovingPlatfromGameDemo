using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerBehaviour : MonoBehaviour
{
    CharacterController _charactrCtl;
    [SerializeField]
    float _speed = 3f;
    float _gravity = 0.4f;
    [SerializeField]
    float _jump = 10f;
    Vector3 _moveDirection = Vector3.zero;
    bool _doDoubleJump;
    int coinCount = 0;
    [SerializeField]
    UIManager _uiManager;
    [SerializeField]
    int _playerLifes = 3;
    void Start()
    {

        if (_uiManager == null)
        {
            Debug.LogError("Please Attach UI Manager");
        }
        else
        {
            _uiManager.UpdateLifeText(_playerLifes);
            _uiManager.UpdateCoinText(coinCount);
        }
        _charactrCtl = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        PlayerMovementAndJump();
    }

    void PlayerMovementAndJump()
    {
        if (_charactrCtl.isGrounded)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _doDoubleJump = true;
                _moveDirection.y = _jump;
            }
        }
        else if (!_charactrCtl.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _doDoubleJump)
            {
                _doDoubleJump = false;
                _moveDirection.y += _jump;
            }

        }
        _moveDirection.y -= _gravity;
        _charactrCtl.Move(_moveDirection * Time.deltaTime * _speed);
    }

    public void CollectCoins()
    {
        coinCount++;
        _uiManager.UpdateCoinText(coinCount);
    }

    public void DamageLife()
    {
        _playerLifes--;
        _uiManager.UpdateLifeText(_playerLifes);
        if(_playerLifes <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
  
}
