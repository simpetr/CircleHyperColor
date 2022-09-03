using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class WaveManager : MonoBehaviour
    {
        public static WaveManager SharedInstance;
        private List<GameObject> _fireLocation;
        [SerializeField] GameObject FirePointPrefab;
        // Start is called before the first frame update
        private void Awake()
        {
            SharedInstance = this;
        }

        void Start()
        {
            _fireLocation = new List<GameObject>();
            for(int i = 0; i < 8;i++)
            {
                _fireLocation.Add(Instantiate(FirePointPrefab));
            }
        }

        public void SetupFireLocations()
        {
            float angle = 0;
            foreach (var firePoint in _fireLocation)
            {
                float x = Mathf.Sin(Mathf.Deg2Rad * angle) * 10f;
                float y = Mathf.Cos(Mathf.Deg2Rad * angle) * 10f;
                firePoint.transform.localPosition = new Vector3(x, 1.5f, y);
                firePoint.transform.LookAt(new Vector3(0,1.5f,0));
                angle += 45;
            }
        }
        // Update is called once per frame
        void Update()
        {
        
        }

        public void StartWaveSequence()
        {
            Debug.Log("Start to fire");
        }


        private IEnumerator StartWave(float startReduction, float maxReduction, float totalDuration)
        {
            float elapsedTime = 0f;
            while (elapsedTime < totalDuration)
            {
                float value = Mathf.Lerp(startReduction, maxReduction, elapsedTime / totalDuration);
                elapsedTime += Time.deltaTime;
                yield return value;
            }
        }
    }
}
