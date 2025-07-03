using Assets.Code.Common.Events;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class BackgroundChooser : MonoBehaviour, EventObserver
    {
        [SerializeField] private Sprite _moonWalkerSprite;
        [SerializeField] private Sprite _atlansAbyssSprite;
        [SerializeField] private Sprite _villaSoldatiSprite;
        [SerializeField] private Sprite _raklionSprite;
        [SerializeField] private Sprite _acheronSprite;

        [SerializeField] private Image _backgroundPanelImage;


        // Use this for initialization
        void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.LastMapPlayedChanged, this);
            SetUpBackground();
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.LastMapPlayedChanged, this);
        }
        private void SetUpBackground()
        {
            var mapsAndLevelsSystem = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>();
            string _lastMapPlayed = mapsAndLevelsSystem.GetLastMapPlayed();

            switch (_lastMapPlayed)
            {
                case "Moon Walker":
                    _backgroundPanelImage.sprite = _moonWalkerSprite;
                    return;

                case "Atlans Abyss":
                    _backgroundPanelImage.sprite = _atlansAbyssSprite;
                    return;

                case "Villa Soldati":
                    _backgroundPanelImage.sprite = _villaSoldatiSprite;
                    return;

                case "Raklion":
                    _backgroundPanelImage.sprite = _raklionSprite;
                    return;

                case "Acheron":
                    _backgroundPanelImage.sprite = _acheronSprite;
                    return;
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.LastMapPlayedChanged)
            {
                SetUpBackground();
            }
        }

    }
}