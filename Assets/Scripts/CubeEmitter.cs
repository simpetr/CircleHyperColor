using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CubeEmitter : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] int _cubeAmount = 20;
    private IObjectPool<GameObject> _objectPool;
    // Start is called before the first frame update
    void Start()
    {
        _objectPool = new ObjectPool<GameObject>(
            () => Instantiate(_prefabToSpawn),
            bullet => { bullet.gameObject.SetActive(true); },
            bullet => { bullet.gameObject.SetActive(false); },
            bullet => { Destroy(bullet.gameObject); }, false, _cubeAmount, _cubeAmount + 10);
        StartCoroutine(SpawnCube());
    }

    IEnumerator SpawnCube()
    {
        while (true)
        {
            
            var randomPosition = Random.insideUnitSphere * 2;
            var randomScale = Vector3.one * Random.Range(0.3f, 1f);
            var randomRotation = Vector3.one * Random.Range(-180, 180);
            var obj = _objectPool.Get();
            obj.transform.position = transform.position + randomPosition;
            obj.transform.localScale = randomScale;
            obj.transform.rotation = Quaternion.Euler(randomRotation);
            obj.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(100f,200f));
            StartCoroutine(ReturnCube(obj));
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    
    IEnumerator ReturnCube(GameObject cube)
    {
        yield return new WaitForSeconds(8f);
        _objectPool.Release(cube);
    }
}
