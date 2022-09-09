using UnityEngine;

namespace Utils
{
    public static class MathUtility
    {
        // https://easings.net/it#
        public enum Ease
        {
            Linear,
            EaseInSin,
            EaseOutSin,
            EaseInQuart,
            EaseInQuint
        }

        public delegate float EaseFunction(float value);
        
        public static float Linear(float value) => value;
        
        public static float EaseInSin(float value) => 1 - Mathf.Cos((value * Mathf.PI) / 2);

        public static float EaseOutSin(float value) => Mathf.Sin((value * Mathf.PI) / 2);
        
        public static float EaseInQuart(float value) => value * value * value * value;
        
        public static float EaseInQuint(float value) => value * value * value * value * value;

        public static EaseFunction GetEaseFunctionByName(Ease name)
        {
            switch (name)
            {
                case Ease.Linear: return Linear;
                case Ease.EaseInSin: return EaseInSin;
                case Ease.EaseOutSin: return EaseOutSin;
                case Ease.EaseInQuart: return EaseInQuart;
                case Ease.EaseInQuint: return EaseInQuint;
                default: return Linear;
            }
        }
        
    }
}