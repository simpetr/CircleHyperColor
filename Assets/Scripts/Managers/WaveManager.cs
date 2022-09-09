using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;
using Random = UnityEngine.Random;
// ReSharper disable InconsistentNaming

namespace Managers
{
    public class WaveManager : MonoBehaviour
    {
        public static WaveManager sharedInstance;
        private List<GameObject> _fireLocation;
        [FormerlySerializedAs("FirePointPrefab")] [SerializeField] 
        private GameObject _firePointPrefab;

        [SerializeField] private List<WaveScriptableObject> _gameWaves;
        
        //TODO $138 temporary move to scriptableObject
        private float _waveElapsedTime;
        private bool _isWaveActive = false;
        private int _currentWaveIndex = 0;
        private float _waveStartInterval;
        private float _waveEndInterval;
        private float _waveDuration;
        // Start is called before the first frame update
        private void Awake()
        {
            sharedInstance = this;
        }

        void Start()
        {
            _fireLocation = new List<GameObject>();
            for(int i = 0; i < 8;i++)
            {
                _fireLocation.Add(Instantiate(_firePointPrefab));
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
            if (_isWaveActive)
            {
                _waveElapsedTime += Time.deltaTime;
                if (_waveElapsedTime >= _gameWaves[_currentWaveIndex].waveDuration)
                {
                    StopCurrentWave();
                }
            }
        }

        public void StartWaveSequence()
        {
            Debug.Log("Start to fire");
            RequestFire();
            StartWave();
        }

        private void StartWave()
        {
            
            _waveElapsedTime = 0;
            _waveStartInterval = _gameWaves[_currentWaveIndex].shooterStartValue;
            _waveEndInterval = _gameWaves[_currentWaveIndex].shooterEndValue;
            _waveDuration = _gameWaves[_currentWaveIndex].waveDuration;
                _isWaveActive = true;
            Invoke(nameof(WaveInterval),_waveStartInterval);
        }

        private void StopCurrentWave()
        {
            _isWaveActive = false;
            _waveElapsedTime = 0f;
            _currentWaveIndex++;
            //TODO check if all waves end
            CancelInvoke(nameof(WaveInterval));
        }

        private void WaveInterval()
        {
            if (_isWaveActive)
            {
                float newInterval = Mathf.Lerp(_waveStartInterval, _waveEndInterval , _waveElapsedTime / _waveDuration);
                Debug.Log(newInterval);
                float randomness = GetRandomVariation();
                RequestFire();
                Invoke(nameof(WaveInterval),newInterval-randomness);
            }
        }
        
        private float ease(float x)
        {
            return x * x * x * x;
        }
        private float GetRandomVariation() => 0f;

        //
        // private IEnumerator StartWave(float startReduction, float maxReduction, float totalDuration)
        // {
        //     float elapsedTime = 0f;
        //     while (elapsedTime < totalDuration)
        //     {
        //         float value = Mathf.Lerp(startReduction, maxReduction, elapsedTime / totalDuration);
        //         elapsedTime += Time.deltaTime;
        //     }
        // }

        private void RequestFire()
        {
            //TODO temporary random point and fixed color
            _fireLocation[Random.Range(0, _fireLocation.Count - 1)].GetComponent<Shooter>().Fire(Color.red);
        }
        
        
    }
}
