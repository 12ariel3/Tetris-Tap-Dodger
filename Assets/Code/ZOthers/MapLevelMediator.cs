using Assets.Code.Common.Events;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Core;
using Assets.Code.Enemies;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.ZOthers
{
    public class MapLevelMediator : MonoBehaviour
    {

        [SerializeField] private Button _mapButton;
        [SerializeField] private MapConfiguration _mapConfiguration;

        [SerializeField] private Image _mapLockedImage;
        [SerializeField] private Image _mapBackgroundImage;
        [SerializeField] private TextMeshProUGUI _mapNumberTextMesh;
        [SerializeField] private string _mapNumber;
        [SerializeField] private TMP_FontAsset _mapNumberFont;


        private void Awake()
        {
            _mapButton.onClick.AddListener(OnMapButtonPressed);
        }


        private void Start()
        {
            _mapBackgroundImage.sprite = _mapConfiguration.MapBackground;
            _mapNumberTextMesh.SetText(_mapNumber);
            _mapNumberTextMesh.font = _mapNumberFont;
            CheckIfIsUnlocked(_mapConfiguration.Id.Value);
        }


        private void CheckIfIsUnlocked(string mapId)
        {
            var serviceLocator = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>(); ;
            switch (mapId)
            {
                case "Moon Walker":
                    _mapLockedImage.gameObject.SetActive(false);
                    return;

                case "Atlans Abyss":
                    if (serviceLocator.IsMoonWalkerPassed())
                    {
                        _mapLockedImage.gameObject.SetActive(false);
                    }
                    else
                    {
                        _mapLockedImage.gameObject.SetActive(true);
                    }
                    return;

                case "Villa Soldati":
                    if (serviceLocator.IsAtlansAbyssPassed())
                    {
                        _mapLockedImage.gameObject.SetActive(false);
                    }
                    else
                    {
                        _mapLockedImage.gameObject.SetActive(true);
                    }
                    return;

                case "Raklion":
                    if (serviceLocator.IsVillaSoldatiPassed())
                    {
                        _mapLockedImage.gameObject.SetActive(false);
                    }
                    else
                    {
                        _mapLockedImage.gameObject.SetActive(true);
                    }
                    return;

                case "Acheron":
                    if (serviceLocator.IsRaklionPassed())
                    {
                        _mapLockedImage.gameObject.SetActive(false);
                    }
                    else
                    {
                        _mapLockedImage.gameObject.SetActive(true);
                    }
                    return;
            }
        }

        private void OnMapButtonPressed()
        {
            var mapsAndLevelsSystem = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>();
            mapsAndLevelsSystem.SaveLastMapPlayed(_mapConfiguration.Id.Value);
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.LastMapPlayedChanged));
        }
    }
}