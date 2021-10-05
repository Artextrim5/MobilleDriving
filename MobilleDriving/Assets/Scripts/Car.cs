using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float speedIncrees = 0.1f;
    [SerializeField] float turnSpeed = 200f;
    SceneLouder sceneLouder;

    private int steerValue;
    

    // Start is called before the first frame update
    void Start()
    {
        sceneLouder = FindObjectOfType<SceneLouder>();
    }

    // Update is called once per frame
    void Update()
    {
        CarMoveForward();
        CarTurning();
    }

    private void CarTurning()
    {
        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
    }

    private void CarMoveForward()
    {
        movementSpeed += speedIncrees * Time.deltaTime;
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    public void Steer(int value)
    {
        steerValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            sceneLouder.LoudMainManu();
        }


    }


    

}
