using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI
{
    public class LoadNextScene : MonoBehaviour
    {
        public Button changeSceneButton;

        public string nextSceneName = "";
        // Start is called before the first frame update
        void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            changeSceneButton = root.Q<Button>("StartButton");
            changeSceneButton.clicked += LoadScene;
        }

        private void LoadScene()
        {
            GameDataManager.SetMatchRules(MatchRule.Equal);
            if(nextSceneName != "" )
               SceneManager.LoadScene(nextSceneName);
        }
    }
}
