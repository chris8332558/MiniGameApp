using UnityEngine;
using UnityEngine.Audio;

namespace Chris
{
    /// <summary>
    /// Work as a model in MVP. Listen to volume changed events 
    /// </summary>
    [CreateAssetMenu(menuName = "AudioSetting")]
    public class AudioSettingSO : ScriptableObject
    {
        [Header("Mixer")]
        [SerializeField] AudioMixer m_AudioMixer;

        [Header("Volume")]
        [SerializeField][Range(0f, 1f)] float m_MasterVol;
        [SerializeField][Range(0f, 1f)] float m_SFXVol;
        [SerializeField][Range(0f, 1f)] float m_MusicVol;

        [Header("SFX")]
        [SerializeField] AudioClip m_SuccessSound;
        [SerializeField] AudioClip m_FailSound;
        [SerializeField] AudioClip m_ClickButtonSound;

        // Attributes
        public AudioMixer AudioMixer => m_AudioMixer;
        public float MasterVol { get => m_MasterVol; set => m_MasterVol = value; }
        public float SFXVol { get => m_SFXVol; set => m_SFXVol = value; }
        public float MusicVol { get => m_MusicVol; set => m_MusicVol = value; }
        public AudioClip SuccessSound { get => m_SuccessSound; set => m_SuccessSound = value; }
        public AudioClip FailSound { get => m_FailSound; set => m_FailSound = value; }
        public AudioClip ClickButtonSound { get => m_ClickButtonSound; set => m_ClickButtonSound = value; }

        private void OnEnable()
        {
            SettingEvents.MasterSliderChanged += OnMasterSliderChanged;
            SettingEvents.SFXSliderChanged += OnSFXSliderChanged;
            SettingEvents.MusicSliderChanged += OnMusicSliderChanged;
        }

        private void OnDisable()
        {
            SettingEvents.MasterSliderChanged -= OnMasterSliderChanged;
            SettingEvents.SFXSliderChanged -= OnSFXSliderChanged;
            SettingEvents.MusicSliderChanged -= OnMusicSliderChanged;
        }

        private void OnMasterSliderChanged(float value)
        {
            m_MasterVol = value;
		}

        private void OnSFXSliderChanged(float value)
        { 
            m_SFXVol = value;
		}

        private void OnMusicSliderChanged(float value)
        { 
            m_MusicVol = value;
		}
    }
}
