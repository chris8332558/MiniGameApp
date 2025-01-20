using UnityEngine;

namespace Chris
{
    public interface ILink
    {
        bool Validate(out State nextState);
        void Enable() { }
        void Disable() { }
    }
}
