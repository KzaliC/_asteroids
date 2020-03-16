using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private float _maxSpeed = 5f;
    private float _currentSpeed;
    private float _rotationSpeed = 190f;
    private bool _boostActive;

    public float _boosterSpeed = 8f;
    public float _shipScreenBoundary = 0.4f;
    private Camera _mainCamera;
    public SpriteRenderer _boostSprite;
    protected void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _boostActive = false;
        _currentSpeed = _maxSpeed;
        _boostSprite.enabled = false;
    }

    protected void Update()
    {
        if (Input.GetAxisRaw("Boost") > 0f)
        {
            _boostActive = true;
        }
        else
            _boostActive = false;

        if(_boostActive != true)
        {
            _boostSprite.enabled = false;
        }
        else if(_boostActive == true)
        {
            _boostSprite.enabled = true;
        }
        

        CheckSpeed();

        // rotates the ship
        Quaternion rotation = transform.rotation;

        float z = rotation.eulerAngles.z;

        z += Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;

        rotation = Quaternion.Euler(0, 0, z);

        transform.rotation = rotation;

        // moves the ship
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * _currentSpeed * Time.deltaTime, 0);

        pos += rotation * velocity;

        //restrict the player to the cameras view
        if(pos.y+_shipScreenBoundary > _mainCamera.orthographicSize)
        {
            pos.y = _mainCamera.orthographicSize - _shipScreenBoundary;
        }
        if (pos.y - _shipScreenBoundary < -_mainCamera.orthographicSize)
        {
            pos.y = -_mainCamera.orthographicSize + _shipScreenBoundary;
        }

        //calulate the screen space by screen ratio.
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrthographic = _mainCamera.orthographicSize * screenRatio;

        if(pos.x+_shipScreenBoundary > widthOrthographic)
        {
            pos.x = widthOrthographic - _shipScreenBoundary;
        }
        if(pos.x-_shipScreenBoundary < -widthOrthographic)
        {
            pos.x = -widthOrthographic + _shipScreenBoundary;
        }

        // update the players position
        transform.position = pos;
    }
    // checks if the boost is active or not if it is you can use it.
    protected void CheckSpeed()
    {
        if (_boostActive == true)
        {
            _currentSpeed = _maxSpeed + _boosterSpeed;
            Debug.Log(_currentSpeed + " boost");
        }
        else
            _currentSpeed = _maxSpeed;
        Debug.Log(_currentSpeed);
    }

}
