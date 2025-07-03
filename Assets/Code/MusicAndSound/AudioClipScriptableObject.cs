using UnityEngine;

namespace Assets.Code.MusicAndSound
{
    [CreateAssetMenu(menuName = "Audio/AudioClipScriptableObject", fileName = "AudioClipScriptableObject")]
    public class AudioClipScriptableObject : ScriptableObject
    {
        [SerializeField] private string _audioName;
        [SerializeField] private AudioClip _audio;

        public string AudioName => _audioName;
        public AudioClip Audio => _audio;
    }
}