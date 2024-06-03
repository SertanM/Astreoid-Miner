using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public bool isDeath;
    public SpriteRenderer mySR;
    public GameObject boost;
    public GameObject backBoost;
    private Rigidbody2D _myRg;
    private bool _thrusting;
    private float _turnDirection;
    private bool sPow = false;
    private bool _backThrusting;

    
    [HideInInspector]public float thrustSpeed = 1f;
    [HideInInspector]public float rotateSpeed = 0.1f;
    private bool keyW;
    private bool keyA;
    private bool keyS;
    private bool keyD;

    private void Awake()
    {
        _myRg = transform.GetComponent<Rigidbody2D>();
        mySR = transform.GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        _thrusting = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || keyW);


        if (_thrusting) boost.SetActive(true);
        else boost.SetActive(false);
        if(sPow) _backThrusting = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || keyS);
        if (_backThrusting) backBoost.SetActive(true);
        else backBoost.SetActive(false);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || keyA)
        {
            _turnDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || keyD)
        {
            _turnDirection = -1f;
        }
        else
        {
            _turnDirection = 0f;
        }

    }

    

    public void thrustSpeedUp(){
        thrustSpeed+=thrustSpeed/4;
    }

    public void rotateSpeedUp(){
        rotateSpeed+=rotateSpeed/4;
    }

    public void addS(){
        sPow = true;
    }

    private void FixedUpdate()
    {
        if (_thrusting) _myRg.AddForce(this.transform.up * thrustSpeed);
        if(_backThrusting) _myRg.AddForce(this.transform.up * thrustSpeed * -1f);
        if (_turnDirection != 0f) _myRg.AddTorque(_turnDirection * rotateSpeed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    { 
        if(coll.gameObject.tag == "Asteroid")
        {
            _myRg.velocity = Vector3.zero;
            _myRg.angularVelocity = 0f;

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

    public void setTrue(int myKey){
        switch(myKey){
            case 0:
                keyW=true;
                break;
            case 1:
                keyA=true;
                break;
            case 2:
                keyS=true;
                break;
            case 3:
                keyD=true;
                break;
        }
    }

    public void setFalse(int myKey){
        switch(myKey){
            case 0:
                keyW=false;
                break;
            case 1:
                keyA=false;
                break;
            case 2:
                keyS=false;
                break;
            case 3:
                keyD=false;
                break;
        }
    }
}
