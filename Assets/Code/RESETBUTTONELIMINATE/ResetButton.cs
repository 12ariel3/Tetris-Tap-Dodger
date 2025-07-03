using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.RESETBUTTONELIMINATE
{
    public class ResetButton : MonoBehaviour
    {

        [SerializeField] Button _resetUpgradesButton;

        private void Awake()
        {
            _resetUpgradesButton.onClick.AddListener(ResetAllUpgrades);
        }

        private void ResetAllUpgrades()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}