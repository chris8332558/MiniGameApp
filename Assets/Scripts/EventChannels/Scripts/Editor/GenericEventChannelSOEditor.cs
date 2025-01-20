using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using System.Collections.Generic;

namespace Chris
{
    /// <summary>
    /// Create a ListView shos the subscribed linsteners in the scene. 
	/// Click each item to plin it in the Hierarchy.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [CustomEditor(typeof(GenericEventChannelSOEditor<>), true)]
    public abstract class GenericEventChannelSOEditor<T> : Editor
    {
        private GenericEventChannelSO<T> m_EventChannel;

        private Label m_ListenersLabel;
        private ListView m_ListenersListView;
        private Button m_RaiseEventButton;

        private void OnEnable()
        {
            // target: the object being inspected.
            if (m_EventChannel == null)
                m_EventChannel = target as GenericEventChannelSO<T>;
        }

        public override VisualElement CreateInspectorGUI()
        {
            // Create a root and add elements
            var root = new VisualElement();

            // Draw default elements in the inspector
            InspectorElement.FillDefaultInspector(root, serializedObject, this);

            //var spaceElement = new VisualElement();
            //spaceElement.style.marginBottom = 20;
            //root.Add(spaceElement);

            // Add a label
            m_ListenersLabel = new Label();
            m_ListenersLabel.text = "Listeners:";
            m_ListenersLabel.style.borderBottomWidth = 1;
            m_ListenersLabel.style.borderBottomColor = Color.gray;
            m_ListenersLabel.style.marginBottom = 2;
            root.Add(m_ListenersLabel);

            // Add a ListView to show Linteners
            m_ListenersListView = new ListView(GetListeners(), 20, MakeItem, BindItem);
            //m_ListenersListView = new ListView(GetListeners());
            root.Add(m_ListenersListView);

            // Add button to test event
            m_RaiseEventButton = new Button();
            m_RaiseEventButton.text = "Raise Event";
            m_RaiseEventButton.RegisterCallback<ClickEvent>(evt => m_EventChannel.InvokeEvent(default(T)));
            root.Add(m_RaiseEventButton);

            return root;
        }

        private VisualElement MakeItem()
        {
            var element = new VisualElement();
            var label = new Label();
            element.Add(label);
            return element;
		}

        private void BindItem(VisualElement element, int index)
        {
            List<MonoBehaviour> listeners = GetListeners();

            var item = listeners[index];

            Label label = (Label)element.ElementAt(0);
            label.text = GetListenerName(item);

            // Attach a ClickEvent to the label
            label.RegisterCallback<MouseDownEvent>(evt =>
            {
                // Ping the item in the Hierarchy
                EditorGUIUtility.PingObject(item.gameObject);
            });
		}

        private string GetListenerName(MonoBehaviour listener)
        {
            if (listener == null)
                return "<null>";

            string combinedName = listener.gameObject.name + " (" + listener.GetType().Name + ")";
            return combinedName;
		}

        // Get a list of MonoBehaviors that are listening to the event channel
        private List<MonoBehaviour> GetListeners()
        {
            List<MonoBehaviour> listeners = new();
            if (m_EventChannel == null || m_EventChannel.Event == null)
                return listeners;

            // Get all delegates subscripbed to the Event action
            var delegateSubscribers = m_EventChannel.Event.GetInvocationList();

            foreach (var subscriber in delegateSubscribers)
            {
                // Get the MonoBehavior associated with each delegate
                var componentListener = subscriber.Target as MonoBehaviour;

                // Append to the list and return
                if (!listeners.Contains(componentListener))
                    listeners.Add(componentListener);
			}

            return listeners;
		}
    }
}
