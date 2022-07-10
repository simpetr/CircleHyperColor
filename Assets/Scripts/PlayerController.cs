using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Material _material;
    private Color _currentColor;
    
    [SerializeField] private int _numLife = 3;
    private int _currentNumLife;
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _currentColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color GetCurrentColor() => _currentColor;

    public void SetColor(Color color)
    { 
        _currentColor = color;
        _material.color = _currentColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet")) return;
 
        var bulletColor = other.gameObject.GetComponent<Bullet>().GetColor();
        var correctColor = GameManager.TransformColorBasedOnRules(_currentColor);
        if (correctColor !=  bulletColor)
        {
            //TODO if wrong color reduce life, update UI, particles
            _currentNumLife -= 1;
            if (_currentNumLife <= 0)
            {
                //TODO gameover
                return;
            }
              
        }
        //TODO else particles
    }
}
