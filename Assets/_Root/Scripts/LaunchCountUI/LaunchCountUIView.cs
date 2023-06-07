using TMPro;
using UnityEngine;

namespace LaunchCountUI
{
    internal sealed class LaunchCountUIView : MonoBehaviour, ILaunchCountUIView
    {
        [SerializeField] TMP_Text _text;

        public TMP_Text Text => _text;
    }
}
