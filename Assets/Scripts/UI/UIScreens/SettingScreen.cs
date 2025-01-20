using UnityEngine;
using UnityEngine.UIElements;

namespace Chris
{
    /// <summary>
    /// Work as a view in MVP
    /// </summary>
    public class SettingScreen : UIScreen
    {
        Slider m_MasterVolSlider;
        Slider m_SFXVolSlider;
        Slider m_MusicVolSlider;
        Button m_CloseButton;

        public SettingScreen(VisualElement root, bool isTransparent = false): base(root, isTransparent)
        {
            m_MasterVolSlider = m_RootElement.Q<Slider>("setting__master-vol-slider");	    
            m_SFXVolSlider = m_RootElement.Q<Slider>("setting__sfx-vol-slider");	    
            m_MusicVolSlider = m_RootElement.Q<Slider>("setting__music-vol-slider");
            m_CloseButton = m_RootElement.Q<Button>("setting__close-button");

            // Initial setting
            SettingEvents.MasterSliderSet += OnMasterSliderSet;
            SettingEvents.SFXSliderSet += OnSFXSliderSet;
            SettingEvents.MusicSliderSet += OnMusicSliderSet;

            // Setting by the sliders
            m_MasterVolSlider.RegisterCallback<ChangeEvent<float>>(OnMasterSliderChanged);
            m_SFXVolSlider.RegisterCallback<ChangeEvent<float>>(OnSFXSliderChanged);
            m_MusicVolSlider.RegisterCallback<ChangeEvent<float>>(OnMusicSliderChanged);

            m_CloseButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);
		}

        private void OnMasterSliderChanged(ChangeEvent<float> evt)
        {
            SettingEvents.MasterSliderChanged.Invoke(evt.newValue);
		}
        
        private void OnSFXSliderChanged(ChangeEvent<float> evt)
        {
            SettingEvents.SFXSliderChanged.Invoke(evt.newValue);
		}

        private void OnMusicSliderChanged(ChangeEvent<float> evt)
        {
            SettingEvents.MusicSliderChanged.Invoke(evt.newValue);
		}

        private void OnSFXSliderSet(float value)
        {
            m_SFXVolSlider.value = value;
		}
        
        private void OnMusicSliderSet(float value)
        {
            m_MusicVolSlider.value = value;
		}

        private void OnMasterSliderSet(float value)
        { 
            m_MasterVolSlider.value = value;
		}

        private void OnCloseButtonClicked(ClickEvent evt)
        {
            Debug.Log("Close Button Clicked");
            UIEvents.CloseScreen?.Invoke();
		}
    }
}
