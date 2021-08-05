﻿using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0;
    private float currentCameraRotationX = 0;
    private Vector3 thrusterForce = Vector3.zero;

    [SerializeField]
    private float cameraRotationLimit = 85f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    public void Rotate (Vector3 _rotation){
        rotation = _rotation;
    }

    public void RotateCamera (float _cameraRotationX){
        cameraRotationX = _cameraRotationX;
    }


    public void ApplyThruster(Vector3 _thrusterForce){
        thrusterForce = _thrusterForce;
    }

    public void Move (Vector3 _velocity){
        velocity = _velocity;
    }

    


    void PerformMovement (){
        if (velocity != Vector3.zero){
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if (thrusterForce != Vector3.zero){
            rb.AddForce (thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    void PerformRotation(){
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null){
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp (currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3 ( currentCameraRotationX, 0f, 0f);
        }
    }




}
