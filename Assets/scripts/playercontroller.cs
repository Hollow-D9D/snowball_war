﻿using System.Collections;
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
    [SerializeField] private EnemyManager enemy;


    /* Some Variables for snowball */
    [SerializeField] private GameObject projectile;
    [SerializeField] private float throwPower;
    /* Cooldown for shooting */
    [SerializeField] private bool isAvailable = true;
    [SerializeField] private float CooldownDuration = 0.5f;
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
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        /* Movement */
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            //_camera.transform.position = new Vector3(_joystick.Horizontal * _moveSpeed / 2, _rigidbody.velocity.y * 5, _joystick.Vertical * _moveSpeed / 2);

            campos = gameObject.transform.position + new Vector3(0, 18.4f, -12);
            _camera.transform.position = campos;

            fwd = transform.TransformDirection(Vector3.forward);
           
            // Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        }

        /* Shooting */
        if (isAvailable)
        {
            GameObject closest = enemy.getClosest(transform.position);
            if (closest)
            {
                Vector3 shootDir = closest.transform.position - transform.position;


                // 
                // hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                // Debug.Log("kpav");
                // Debug.Log("kpav enemy");
                /* Summoning Snowball. */
                GameObject Snowball = Instantiate(projectile, transform.position, transform.rotation);
                Snowball.GetComponent<ProjectileMovement>().Setup(shootDir.normalized);
//                Snowball.GetComponent<Rigidbody>().AddRelativeForce(transform.TransformDirection(Vector3.forward) * throwPower);

                /* Cooldown Coroutine */
                StartCoroutine(StartCooldown());
            }
        }
    }

    public IEnumerator StartCooldown()
    {
        isAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        isAvailable = true;
    }
    
}



