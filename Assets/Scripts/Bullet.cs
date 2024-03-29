using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Material _material;
    private Color _bulletColor;
    [SerializeField] private float _speed = 10f;

    private Action<Bullet> _removeBullet;

    // Start is called before the first frame update
    void Start()
    {
        //BUG $136 why _material is null in SetColor?
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
        transform.position += transform.forward * (Time.deltaTime * _speed);
    }

    public void Init(Action<Bullet> removeBullet)
    {
        _removeBullet = removeBullet;
        Debug.Log("SETUp");
    }

    public Color GetColor() => _bulletColor;

    public void SetColor(Color color)
    {
        _bulletColor = color;
        //_material.color = _bulletColor; //does not work
        GetComponent<Renderer>().material.color = color;
       
    }

    public void SetSpeed(float speed) => _speed = speed;

    private void OnTriggerEnter(Collider other)
    {
        //TODO particles
        if (!other.CompareTag("Player")) return;
        Invoke(nameof(RemoveBullet), 0.2f);
    }

    private void RemoveBullet()
    {
        _removeBullet(this);
    }
    
    
}