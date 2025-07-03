using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class CharacterPanelView : MonoBehaviour
    {

        [SerializeField] private Button _statsInfoPanelButton;
        [SerializeField] private StatsInfoView _statsInfoPanel;
        [SerializeField] private SelectedSwordView _selectedSwordPanel;

        private void Awake()
        {
            _statsInfoPanelButton.onClick.AddListener(OnStatsInfoPanelButtonPressed);
        }

        private void Start()
        {
            HideAllMenus();
        }

        private void HideAllMenus()
        {
            _statsInfoPanel.Hide();
            _selectedSwordPanel.HideFirst();
        }

        private void OnStatsInfoPanelButtonPressed()
        {
            _statsInfoPanel.Show();
        }
    }
}