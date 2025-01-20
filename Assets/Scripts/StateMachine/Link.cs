using UnityEngine;
using System;

namespace Chris
{
    public class Link : ILink
    {
        State m_NextState;
        bool m_IsEnabled;

        public Link(State nextState)
        {
            m_NextState = nextState;
            m_IsEnabled = false;
        }

        // Enable this Link if anEvent is invoked
        // e.g. StartScreen invokes SceneEvents.StartButtonClicked, and the link from
        // StartScreenState to MenuScreenState will be enabled
        public Link(State nextState, ref Action anEvent)
        {
            m_NextState = nextState;
            anEvent += OnEventInvoked;
        }

        public void OnEventInvoked()
        {
            m_IsEnabled = true;
		}


        public bool Validate(out State nextState)
        {
            if (!m_IsEnabled)
            {
                nextState = null;
				return false;
			}

            nextState = m_NextState;
            return true;
        }

        public void Enable()
        {
            m_IsEnabled = true;
		}

        public void Disable()
        { 
            m_IsEnabled = false;
		}
    }
}
