using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private Rigidbody _playerRigidBody;
    private float _prevPos;

    private void Start()
    {
        _playerRigidBody = Player.Singleton.Instance.GetComponent<Rigidbody>();
        _prevPos = _playerRigidBody.position.z;
    }

    void LateUpdate()
    {
        var tf = transform.position;
        var playerX = _playerRigidBody.position.z;
        tf.z += playerX - _prevPos;
        transform.position = tf;
        _prevPos = playerX;
    }
}
