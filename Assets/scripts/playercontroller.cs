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
    [SerializeField] private float ratio;

    // [SerializeField] private new Vector3 position;


    private void Start() 
    { 
        
        //_camera.transform.position = campos;
        //Debug.Log(campos);
        ratio = 100f;
    
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        var pos = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {

            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            //_camera.transform.position = new Vector3(_joystick.Horizontal * _moveSpeed / 2, _rigidbody.velocity.y * 5, _joystick.Vertical * _moveSpeed / 2);

            campos = gameObject.transform.position + new Vector3(0, 18.4f, -12);
            _camera.transform.position = campos;

            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, fwd, out hit, 100))

            {
                var ri = hit.collider.gameObject.GetComponent<Rigidbody>();

                // 
                // hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                // Debug.Log("kpav");
                if (hit.collider.tag == "enemy")
                {
                    if (hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.red)
                    {
                        //Destroy(hit.collider.gameObject);

                    }
                    // Debug.Log("kpav enemy");
                    ri.AddForce(-hit.normal * 2, ForceMode.Impulse);
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;

                }
            }

            // Ray ray = _camera.ScreenPointToRay(Input.mousePosition);




        }
    }
    
}



