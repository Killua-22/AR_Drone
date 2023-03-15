using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{

    //defining a group of constants(states of drone)
    enum DroneState
    {
        DRONE_STATE_IDLE,
        DRONE_STATE_START_TAKINGOFF,
        DRONE_STATE_TAKINGOFF,
        DRONE_STATE_MOVING_UP,
        DRONE_STATE_FLYING,
    }


    DroneState _State;

    Animator _anim;

    Vector3 _Speed = new Vector3(0.0f, 0.0f, 0.0f);
    float angleY = 0.0f;
    public float _dronespeed = 2.0f;

    public bool isIdle()
    {
        return (_State == DroneState.DRONE_STATE_IDLE);
    }

    public void TakeOff()
    {
        _State = DroneState.DRONE_STATE_START_TAKINGOFF;
    }
    void Start()
    {
        _anim = GetComponent<Animator>();
        _State = DroneState.DRONE_STATE_IDLE;
    }

    public void Move(float _speedX, float _speedY, float _speedZ, float _rotateY)
    {
        _Speed.x = _speedX;
        _Speed.z = _speedZ;
        _Speed.y = _speedY;
        UpdateDrone(_rotateY);
    }

    // Update is called once per frame
    void UpdateDrone(float _rotateY)
    {
        switch (_State)
        {
            case DroneState.DRONE_STATE_IDLE:
                break;

            case DroneState.DRONE_STATE_START_TAKINGOFF:
                _anim.SetBool("TakeOff", true);
                _State = DroneState.DRONE_STATE_TAKINGOFF;
                break;

            case DroneState.DRONE_STATE_TAKINGOFF:
                if (_anim.GetBool("TakeOff") == false)
                {
                    _State = DroneState.DRONE_STATE_MOVING_UP;
                }
                break;

            case DroneState.DRONE_STATE_MOVING_UP:
                if(_anim.GetBool("MoveUp")==false)
                {
                    _State = DroneState.DRONE_STATE_FLYING;
                }
                break;
            case DroneState.DRONE_STATE_FLYING:
                //control drone tilt after buttons are pressed
                float angleZ = -30.0f * _Speed.x * 30.0f * Time.deltaTime;
                angleY += -30.0f * _rotateY * Time.deltaTime;
                float angleX = 30.0f * _Speed.z * 30.0f * Time.deltaTime;
                Vector3 rotation = transform.localRotation.eulerAngles;
                transform.localPosition += _Speed * _dronespeed * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(angleX, angleY, angleZ);

               
                break;
        }
        
        
    }

    public static explicit operator DroneController(GameObject v)
    {
        throw new NotImplementedException();
    }
}
