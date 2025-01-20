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
        [SerializeField] GameType m_GameType;
        [SerializeField] string m_Title;
        [SerializeField] Sprite m_Icon;
        [TextArea(5, 8)][SerializeField] string m_Discription;
    }
}
