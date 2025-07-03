using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class LevelExperienceView : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private Slider _experienceBar;


        public void UpdateLevel(int newLevel)
        {
            _level.SetText(newLevel.ToString());
        }

        public void UpdateActualLevelMaxExperience(int newMaxExperience)
        {
            _experienceBar.maxValue = newMaxExperience;
        }

        public void UpdateExperience(int newExperience)
        {
            _experienceBar.value = newExperience;
        }
    }
}