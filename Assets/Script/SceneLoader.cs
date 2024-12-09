using System.Collections;
using Script.GameManager.Dungeon;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class SceneLoader : MonoBehaviour
    {
        public GameObject loaderUI;
        public Slider progressSlider;

        public static SceneLoader Instance { get; private set; }
        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void LoadScene(string sceneName)
        {
            progressSlider.gameObject.SetActive(true);
            loaderUI.gameObject.SetActive(true);
            StartCoroutine(LoadScene_Coroutine(sceneName));
        }

        // Start is called before the first frame update
        public IEnumerator LoadScene_Coroutine(string sceneName)
        {
            progressSlider.value = 0;
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            // asyncOperation.allowSceneActivation = false;
            if (asyncOperation != null) 
            {
                while (!asyncOperation.isDone)
                {
                    float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
                    progressSlider.value = progress;

                    // if (progress >= 0.9f)
                    // {
                    //     progressSlider.value = 1;
                    //     asyncOperation.allowSceneActivation = true;
                    // }
                    yield return null;

                }
                MapGenerator_Manager.Instance.CreateMap();
                progressSlider.gameObject.SetActive(false);
                loaderUI.gameObject.SetActive(false); 
            }
       

        }
    }
}
