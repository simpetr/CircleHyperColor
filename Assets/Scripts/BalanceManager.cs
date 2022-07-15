using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceManager : MonoBehaviour
{

    public static BalanceManager SharedInstance;
    private float _currentFireDistance;
    private float _currentDistanceBtwFire;
    private float _currentProbSameColor;

    private float _timeElapsed = .0f;
    private float _currentTime = .0f;
    private float _duration = 420f;


    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentFireDistance = Constants.MAX_FIRE_DISTANCE;
        _currentDistanceBtwFire = Constants.MAX_TIME_BTW_FIRE;
        _currentProbSameColor = Constants.MIN_FIRE_DISTANCE;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
}
