using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Core;
using Assets.Code.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class GameBackgroundView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private MapsConfiguration _mapsConfiguration;

        private MapConfiguration _mapConfiguration;

        void Start()
        {
            string lastMapPlayed = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().GetLastMapPlayed();

            _mapConfiguration = _mapsConfiguration.GetMapById(lastMapPlayed);
            _image.color = _mapConfiguration.BackgroundLevelColor;
        }
    }
}