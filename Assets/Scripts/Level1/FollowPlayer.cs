using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;
    [SerializeField]
    private Camera _subCameraRight;
    [SerializeField]
    private Camera _subCameraBack;
    [SerializeField]
    private Camera _subCameraLeft;

    public Vector3 _offset;
    private Vector3 _playerPosition;
    private float _defaultY;
    private float? _smoothY;
    private bool moveCameraUp;

    private void Start()
    {
        _defaultY = _playerPosition.y;
        _mainCamera.enabled = true;
        _subCameraRight.enabled = false;
        _subCameraBack.enabled = false;
        _subCameraLeft.enabled = false;
    }
    private void Update()
    {
        var _player = FindObjectOfType<Player>();
        if (_player == null)
            return;

        _playerPosition = _player.transform.position;

        if (_smoothY != null)
        {
            if (moveCameraUp && _defaultY > _smoothY)
                _defaultY -= 0.03f;

            else if (!moveCameraUp && _defaultY < _smoothY)
                _defaultY += 0.03f;
        }

        transform.position = new Vector3(_playerPosition.x, _defaultY, _playerPosition.z) + _offset;

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (_mainCamera.enabled)
            {
                _mainCamera.enabled = false;
                _subCameraRight.enabled = true;
            }
            else if (_subCameraRight.enabled)
            {
                _subCameraRight.enabled = false;
                _subCameraBack.enabled = true;
            }
            else if (_subCameraBack.enabled)
            {
                _subCameraBack.enabled = false;
                _subCameraLeft.enabled = true;
            }
            else
            {
                _subCameraLeft.enabled = false;
                _mainCamera.enabled = true;
            }
        }
    }
    public void setDefaultY(float y)
    {
        _defaultY = y;
    }
    public void setSmoothY(float? y)
    {
        _smoothY = y;

        moveCameraUp = (_defaultY > y);
    }
}
