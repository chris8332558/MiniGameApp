using UnityEngine;
using UnityEngine.UIElements;

namespace Chris
{
    public abstract class PageContainer
    {
        protected VisualElement m_Root;
        protected bool m_IsShown;
        public bool IsShown => m_IsShown; 

        public PageContainer(VisualElement root)
        {
            m_Root = root;
        }

        public void Show()
        {
            m_Root.style.display = DisplayStyle.Flex;
            m_IsShown = true;
        }

        public void Hide()
        {
            m_Root.style.display = DisplayStyle.None;
            m_IsShown = false;
        }

    }
}
