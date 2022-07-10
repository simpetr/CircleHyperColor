using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatchRule
{
    Equal,
    Complementary
}
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private static MatchRule _matchRules;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    
    void Start()
    {
        
    }

    public static void SetMatchRules(MatchRule rule) => _matchRules = rule;

    /// <summary>
    /// If match is classic return the same color, if the match is Complementary
    /// return the complementary color of @playerColor. So that the test can be done
    /// using an equality test in both cases.
    /// </summary>
    /// <param name="playerColor"></param>
    /// <returns>corrected color</returns>
    public static Color TransformColorBasedOnRules(Color playerColor)
    {
        if (_matchRules == MatchRule.Equal)
            return playerColor;
        if (_matchRules == MatchRule.Complementary)
        {
            return Color.white; //TODO convert color to complementary
        }

        return Color.black;
    }
    

    /*public bool CompareRule<T>(T a, T b)
    {
        if (matchRules == MatchRule.EQUAL)
        {
            return a.Equals(b);
        }
        return
    }*/
}
