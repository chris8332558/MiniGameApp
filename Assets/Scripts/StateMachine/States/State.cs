using UnityEngine;
using System.Collections.Generic;

namespace Chris
{
    public abstract class State
    {
        protected List<ILink> m_Links = new();

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();

        public virtual bool ValidateLinks(out State nextState)
        {
            foreach (var link in m_Links)
            {
                var result = link.Validate(out nextState);
                if (result)
                    return true;
			}

            nextState = null;
            return false;
        }

        public virtual void AddLink(ILink link)
        {
            m_Links.Add(link);
        }

        public virtual void EnableLinks()
        {
            foreach (var link in m_Links)
                link.Enable();
		}

        public virtual void DisableLinks()
        {
            foreach (var link in m_Links)
                link.Disable();
		}
    }
}
