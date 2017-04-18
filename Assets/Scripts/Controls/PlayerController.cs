﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Serialize Fields

    [SerializeField] private float _HorizontalCoeffcient;
    [SerializeField] private float _JumpCoefficient;

    #endregion

    #region Fields

    private Rigidbody _rigidbody;

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _HorizontalCoeffcient * Vector3.right, ForceMode.Force);
        if (Input.GetKeyDown(KeyCode.Space)) // A CHANGER
            _rigidbody.AddForce(Input.GetAxis("Jump") * _JumpCoefficient * Vector3.up, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        
    }

    #endregion

}