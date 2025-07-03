using Assets.Code.Common.Command;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using Assets.Code.ZOthers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class InGameMenuView : MonoBehaviour, InGameMenuMediator, EventObserver
    {

        [SerializeField] private Button _pauseButton;
        [SerializeField] private PauseMenuView _pauseMenuView;
        [SerializeField] private VictoryView _victoryView;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private Button _gameOverShowAdButton;
        private CommandQueue _commandQueue;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonPressed);
            _pauseMenuView.Configure(this);
            _victoryView.Configure(this);
            _gameOverView.Configure(this);
        }


        private void Start()
        {
            _commandQueue = ServiceLocator.Instance.GetService<CommandQueue>();
            HideAllMenus();

            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.Victory, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.GameOver, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.Victory, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.GameOver, this);
        }

        private void HideAllMenus()
        {
            _pauseMenuView.Hide();
            _victoryView.hide();
            _gameOverView.Hide();
        }

        private void OnPauseButtonPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Bloop");
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.PausePressed));

            _commandQueue.AddCommand(new PauseGameCommand());
            _pauseButton.interactable = false;
            _pauseMenuView.Show();
        }

        public void OnBackToMenuPressed()
        {
            ServiceLocator.Instance.GetService<AudioManager>().StopGameMusic();
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.ReturnToMainMenu));
            _commandQueue.AddCommand(new LoadSceneCommand("Menu"));
            ResumeGame();
        }


        public void OnResumeButton()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.PausePressed));
            _pauseMenuView.Hide();
            _pauseButton.interactable = true;
            ResumeGame();
        }


        public void ResumeGame()
        {
            _commandQueue.AddCommand(new ResumeGameCommand());
        }

        public void OnAdsPressed()
        {
            HideAllMenus();
            _gameOverShowAdButton.transform.parent.gameObject.SetActive(false);
            _commandQueue.AddCommand(new ContinueBattleCommand());
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.Victory)
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Victory");
                _victoryView.Show();
                return;
            }

            if (eventData.EventId == EventIds.GameOver)
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("GameOver");
                _gameOverView.Show();
                return;
            }
        }
    }
}