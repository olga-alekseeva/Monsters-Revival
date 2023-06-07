using UnityEngine;

namespace Extension
{
    public static class ArrayExtension
    {
        public static T GetRandom<T>(this T[] list)
        {
            return list[Random.Range(0, list.Length)];
        }
    }
}
