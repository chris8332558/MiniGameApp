using UnityEngine;
using System.Collections.Generic;

namespace Chris
{
    public class DescriptionPresenter : MonoBehaviour
    {
        // Need to set the GameDataSO in correct order in the inspector
        [SerializeField] GameDataSO[] m_GameDataSOTypeOne;
        [SerializeField] GameDataSO[] m_GameDataSOTypeTwo;

        private void OnEnable()
        {
            DescriptionEvents.DescriptionChanged += OnDescriptionChanged;
        }

        private void OnDisable()
        {
            DescriptionEvents.DescriptionChanged -= OnDescriptionChanged; 
        }

        public void OnDescriptionChanged(GameType type, int idx)
        {
            GameDataSO game = null;
            switch (type)
            {
                case GameType.Type1:
                    game = m_GameDataSOTypeOne[idx];
                    break; 
                case GameType.Type2:
                    game = m_GameDataSOTypeTwo[idx];
                    break; 
			}

            if (game != null)
            {
                DescriptionEvents.GameTitleSet?.Invoke(game.Title);
                DescriptionEvents.GameplayTimeSet?.Invoke(game.GamePlayTime);
                DescriptionEvents.DescriptionSet?.Invoke(game.Description);
                DescriptionEvents.GameSceneIdxSet?.Invoke(game.SceneIdx);
                GameEvents.GameplayTimeSet?.Invoke(game.GamePlayTime);
            }
        }
    }
}
