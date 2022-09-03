using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public enum Map
    {
        Unity,
        Beach,
        Forest,
        City
    }
    public enum MatchRule
    {
        Equal,
        Complementary
    }
    /// <summary>
    /// Manage data between level match rule and map
    /// </summary>
    public class GameDataManager : MonoBehaviour
    {
        [SerializeField] private  List<GameObject> _mapPrefabs;
        public static MatchRule MatchRule { get; set; } = MatchRule.Equal;
        public static Map Map { get; set; } = Map.Unity;
        
        private static List<GameObject> _mapPrefabInternal;
        
        private float _elapsedTime = 0f;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            _mapPrefabInternal = _mapPrefabs;
            
        }
        
        public static GameObject GetCurrentMap()
        {
            return _mapPrefabInternal[(int)Map];
        }
        
        /// <summary>
        /// If match is classic return the same color, if the match is Complementary
        /// return the complementary color of @playerColor. So that the test can be done
        /// using an equality test in both cases.
        /// </summary>
        /// <param name="playerColor"></param>
        /// <returns>corrected color</returns>
        public static Color TransformColorBasedOnRules(Color playerColor)
        {
            if (MatchRule == MatchRule.Equal)
                return playerColor;
            if (MatchRule == MatchRule.Complementary)
            {
                return Color.white; //TODO convert color to complementary
            }

            return Color.black;
        }

        //
        // private void Update()
        // {
        //     if (_elapsedTime < 30)
        //     {
        //         var value = Mathf.Lerp(0, 2.5f, ease(_elapsedTime / 2f));
        //         Debug.Log(value);
        //         _elapsedTime += Time.deltaTime;
        //     }
        // }
        //
        // private float ease(float x)
        // {
        //     return x * x * x * x;
        // }
    }
}