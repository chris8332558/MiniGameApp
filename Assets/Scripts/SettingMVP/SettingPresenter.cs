using UnityEngine;

namespace Chris
{
    public class SettingPresenter : MonoBehaviour
    {
        [SerializeField] AudioSettingSO m_AudioSettingSO;

        private void OnEnable()
        {
            // Initial setting
            SettingEvents.MasterSliderSet?.Invoke(m_AudioSettingSO.MasterVol);
            SettingEvents.SFXSliderSet?.Invoke(m_AudioSettingSO.SFXVol);
            SettingEvents.MusicSliderSet?.Invoke(m_AudioSettingSO.MusicVol);

            // Adjust by sliders
            // Not sure why this won't work and need to set in the AduioSettingSO
            //SettingEvents.MasterSliderChanged += OnMasterSliderChanged;
            //SettingEvents.SFXSliderChanged += OnSFXSliderChanged;
            //SettingEvents.MusicSliderChanged += OnMusicSliderChanged;
        }

        private void OnMasterSliderChanged(float newValue)
        {
            m_AudioSettingSO.MasterVol = newValue;
		}

        private void OnSFXSliderChanged(float newValue)
        {
            m_AudioSettingSO.SFXVol = newValue;
		}

        private void OnMusicSliderChanged(float newValue)
        {
            m_AudioSettingSO.MusicVol = newValue;
		}
    }
}
