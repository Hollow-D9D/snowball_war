using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class playercontroller : MonoBehaviour
{
   
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 campos;
    
   

    
   
    private void Start() 
    { 

    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        var pos = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        /* Movement */
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);

            campos = gameObject.transform.position + new Vector3(0, 18.4f, -12);
            _camera.transform.position = campos;

            fwd = transform.TransformDirection(Vector3.forward);
           
        }

 
        
    }

    
}



