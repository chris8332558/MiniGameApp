using UnityEngine;

namespace Chris
{
    public enum GameType
    { 
        Type1, Type2, Type3
	}

    [CreateAssetMenu(menuName = "GameDataSO")]
    public class GameDataSO : ScriptableObject 
    {
        [SerializeField] int m_SceneIdx;
        [SerializeField] string m_ScenePath; // TODO: will use path instead of index
        [SerializeField] GameType m_GameType;
        [SerializeField] string m_Title;
        [SerializeField] int m_GameplayTime;
        [SerializeField] Sprite m_Icon;
        [TextArea(5, 8)][SerializeField] string m_Description;

        public int SceneIdx => m_SceneIdx;
        public string ScenePath => m_ScenePath;
        public string Title => m_Title;
        public float GamePlayTime => m_GameplayTime;
        public Sprite Icon => m_Icon;
        public string Description => m_Description;
        public GameType GameType => m_GameType;
    }
}
