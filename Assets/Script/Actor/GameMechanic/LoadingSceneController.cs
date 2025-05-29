// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class LoadingSceneController : MonoBehaviour
// {
//     public GameObject LoadingScene;
//     public GameObject ButtonChangeScene;
//     public Slider LoadingSlider;

//     public void LoadSceneBtn(string levelToLoad)
//     {
//         LoadingScene.SetActive(true);
//         StartCoroutine(LoadSceneASync(levelToLoad));
//     }
//     IEnumerator LoadSceneASync(string nameScene)
//     {
//         AsyncOperation loadOperation = SceneManager.LoadSceneAsync(nameScene);
//         loadOperation.allowSceneActivation = true;
//         while (!loadOperation.isDone)
//         {
//             float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
//             LoadingSlider.value = progressValue;
//             yield return null;
//         }
//         // LoadingSlider.value = 0f;
//         // Đợi dungeon scene xử lý nốt
//         // while (!LoadingProgressReporter.IsDone)
//         // {
//         //     float progressValue = Mathf.Clamp01(LoadingProgressReporter.CurrentProgress / 0.9f);
//         //     LoadingSlider.value = LoadingProgressReporter.CurrentProgress;
//         //     yield return null;
//         // }
//         // loadOperation.allowSceneActivation = true;

//         // LoadingSlider.value = 1f;
//     }


// }
