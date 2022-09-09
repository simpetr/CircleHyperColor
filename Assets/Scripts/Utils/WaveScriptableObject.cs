using UnityEngine;

namespace Utils
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Define Wave", order = 0)]
    public class WaveScriptableObject : ScriptableObject
    {
        public string waveName;
        public float waveDuration;
        public float shooterStartValue;
        public float shooterEndValue;
        public MathUtility.Ease waveTimeFunction;
        public bool isInfinite;
    }
}