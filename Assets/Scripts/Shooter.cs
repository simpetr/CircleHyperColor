using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Managers;
using UnityEngine;

[SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
public class Shooter : MonoBehaviour
{
    private Vector3 _position;
    private Quaternion _rotation;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Fire a bullet.
    /// Request the bullet to the BulletManager and set parameters
    /// </summary>
    public void Fire(Color bulletColor)
    {
        Bullet bullet = BulletPoolingManager.SharedInstance.RequestBullet();
        bullet.SetColor(bulletColor);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;;

    }
    
}
