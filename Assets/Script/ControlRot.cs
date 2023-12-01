using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRot : MonoBehaviour
{
    public Camera _camera; 
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    public float sensitivityView = 2;
    public float minimumVert = -75.0f;
    public float maximumVert = 52.0f;
    public float minimumHor = -90.0f;
    public float maximumHor = 90.0f;
    public float minimumView = 20f;
    public float maximumView = 70f;

    private float _View = 70;
    private float _rotationY = 0;
    private float _rotationX = 0;
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            _rotationY += Input.GetAxis("Mouse X") * sensitivityHor;
            _rotationY = Mathf.Clamp(_rotationY, minimumHor, maximumHor);
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
            _View -= Input.GetAxis("Mouse Z") * sensitivityView;
            _View = Mathf.Clamp(_View, minimumView, maximumView);
            _camera.fieldOfView = _View;
    }
}
