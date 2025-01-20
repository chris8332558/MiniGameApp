using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Chris
{
    /// <summary>
    /// Helper class for loading scene by index or path. Use Events to communicate with other class
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        private Scene m_MainScene; // MainScene will remain active
        private Scene m_LastLoadedScene;

        private void Start()
        {
            m_MainScene = SceneManager.GetActiveScene();
        }

        private void OnEnable()
        {
            SceneEvents.LoadSceneByIndex += OnLoadSceneAdditively;
            SceneEvents.UnloadLastScene += OnUnloadLastLoadedScene;
        }

        private void OnDisable()
        {
            SceneEvents.LoadSceneByIndex -= OnLoadSceneAdditively;
            SceneEvents.UnloadLastScene -= OnUnloadLastLoadedScene;
        }

        private void OnLoadSceneAdditively(int idx)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(idx);
            Debug.Log("SceneLoader::OnLoadSceneAdditively: " + idx);
            Debug.Log("SceneLoader::OnLoadSceneAdditively: " + scenePath);
            StartCoroutine(LoadSceneAsync(idx));
		}

        private void OnUnloadLastLoadedScene()
        {
            StartCoroutine(UnloadLastScene());
		}

        IEnumerator LoadSceneAsync(int idx)
        { 
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(idx, LoadSceneMode.Additive);

            while (!asyncLoad.isDone)
            {
                Debug.Log("Loading progress: " + asyncLoad.progress);
                yield return null;
			}

            m_LastLoadedScene = SceneManager.GetSceneByBuildIndex(idx);
		}

        IEnumerator UnloadLastScene()
        { 
            if (!m_LastLoadedScene.IsValid())
            {
                Debug.Log("SceneLoader::OnUnLoadLastScene is not valid");
                yield break;
			}

            Debug.Log("SceneLoader::OnUnLoadLastScene: " + m_LastLoadedScene.buildIndex);
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(m_LastLoadedScene);
            while (!asyncUnload.isDone)
            {
                Debug.Log("Unloading progress: " + asyncUnload.progress);
                yield return null; 
			}
		}
    }
}
