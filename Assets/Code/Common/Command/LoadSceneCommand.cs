using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using Assets.Code.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Code.Common.Command
{
    public class LoadSceneCommand : Command
    {
        private readonly string _sceneToLoad;

        public LoadSceneCommand(string sceneToLoad)
        {
            _sceneToLoad = sceneToLoad;
        }

        public async Task Execute()
        {
            var loadingScreen = ServiceLocator.Instance.GetService<LoadingScreen>();
            loadingScreen.Show();
            await LoadScene(_sceneToLoad);
            if (loadingScreen != null)
            {
                loadingScreen.Hide();
                if (_sceneToLoad == "Menu")
                {
                    ServiceLocator.Instance.GetService<AudioManager>().PlayMainMenuMusic("MainMenu");
                }
            }
        }

        private async Task LoadScene(string sceneName)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
            {
                await Task.Yield();
            }

            await Task.Yield();
        }
    }
}