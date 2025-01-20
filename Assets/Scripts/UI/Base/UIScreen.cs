using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Derived classes register to SceneEvents
/// </summary>
public abstract class UIScreen
{
    protected VisualElement m_RootElement;
    private bool m_IsTransparent;

    public bool IsTransparent => m_IsTransparent;

    public UIScreen(VisualElement rootElement, bool isTransparent)
    {
        m_RootElement = rootElement;
        m_IsTransparent = isTransparent;
	}

    public void SetRootElement(VisualElement root)
    {
        m_RootElement = root;
	}

    public string GetScreenName()
    {
        return m_RootElement.name;
	}

    public void Hide()
    {
        m_RootElement.style.display = DisplayStyle.None;
        Debug.Log("Hide " + m_RootElement.name);
	}

    public void Show()
    {
        // TODO: Add transition effect 
        m_RootElement.style.display = DisplayStyle.Flex;
        Debug.Log("Show " + m_RootElement.name);
	}
}
