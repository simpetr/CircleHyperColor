using UnityEngine;

namespace Managers
{
    
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
        private static MatchRule _matchRule;
        //TODO Can be done with a simple string?
        private static GameObject _selectedMapPrefab;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public static void SetMatchRules(MatchRule rule) => _matchRule = rule;
        public static void SetMap(GameObject map) => _selectedMapPrefab = map;

        /// <summary>
        /// If match is classic return the same color, if the match is Complementary
        /// return the complementary color of @playerColor. So that the test can be done
        /// using an equality test in both cases.
        /// </summary>
        /// <param name="playerColor"></param>
        /// <returns>corrected color</returns>
        public static Color TransformColorBasedOnRules(Color playerColor)
        {
            if (_matchRule == MatchRule.Equal)
                return playerColor;
            if (_matchRule == MatchRule.Complementary)
            {
                return Color.white; //TODO convert color to complementary
            }

            return Color.black;
        }
    }
}