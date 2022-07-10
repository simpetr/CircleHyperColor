using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //TODO spawning particles
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Fire a bullet.
    /// Request the bullet to the BulletManager and set parameters
    /// </summary>
    void Fire()
    {
        Bullet bullet = BulletPoolingManager.SharedInstance.RequestBullet();
        
    }
    
}
