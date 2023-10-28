using System;
using System.Runtime.Serialization.Json;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _platformSize = 10.9f;
    [SerializeField] private float _cursorSensivity;
    private Rigidbody _rigidbody;
    private float _initialMouse;
    private float _initialPos;
    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        _initialMouse = Input.mousePosition.x;
        _initialPos = _rigidbody.position.x;
        // var ray = _camera.ScreenPointToRay(Input.mousePosition);
        // if (Physics.Raycast(ray, out RaycastHit raycastHit))
        // {
        //     _initialMouse = raycastHit.point.x;
        // }
        // _initialPos = _rigidbody.position.x;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.forward * _movementSpeed;
        if (!Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) return;
        var position = _rigidbody.position;
        position = new Vector3(_initialPos + (Input.mousePosition.x - _initialMouse) * _cursorSensivity / Screen.width, position.y, position.z);
        // var ray = _camera.ScreenPointToRay(Input.mousePosition);
        // if (Physics.Raycast(ray, out RaycastHit raycastHit)){
        // position = new Vector3(_initialPos + raycastHit.point.x - _initialMouse, position.y,
        //     position.z);
        // }
        _rigidbody.position = position;
    }
}