using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class FooterBarView : MonoBehaviour
    {

        [SerializeField] RectTransform _transform;
        [SerializeField] CharacterPanelView _characterPanel;
        [SerializeField] PlayPanelView _playPanel;
        [SerializeField] private Image _playImageBackground;
        [SerializeField] UpgradesPanelView _upgradesPanel;
        [SerializeField] private Button _characterPanelButton;
        [SerializeField] private Button _mainPanelButton;
        [SerializeField] private Button _upgradePanelButton;
        [SerializeField] private Image _loadingImageBackground;

        public List<Button> buttons = new List<Button>();
        public bool ButtonOn = false;




        private void Awake()
        {
            _characterPanelButton.onClick.AddListener(MoveToCharacterPanel);
            _mainPanelButton.onClick.AddListener(MoveToMainPanel);
            _upgradePanelButton.onClick.AddListener(MoveToUpgradePanel);

            buttons.Add(_characterPanelButton);
            buttons.Add(_mainPanelButton);
            buttons.Add(_upgradePanelButton);
        }

        private void Start()
        {
            MoveToFirstMainPanel();
        }

        private void MoveToFirstMainPanel()
        {
            StartCoroutine(Move(new Vector2(0, 0), "Play"));
            MakeInteractableAllButtons();
            UnInteractButton(_mainPanelButton);
        }

        private void MoveToCharacterPanel()
        {
            MoveToPanel(new Vector2(0, 0), "Character");
            MakeInteractableAllButtons();
            UnInteractButton(_characterPanelButton);
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Sweep");
        }

        private void MoveToMainPanel()
        {
            MoveToPanel(new Vector2(0, 0), "Play");
            MakeInteractableAllButtons();
            UnInteractButton(_mainPanelButton);
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Sweep");
        }

        private void MoveToUpgradePanel()
        {
            MoveToPanel(new Vector2(0, 0), "Upgrades");
            MakeInteractableAllButtons();
            UnInteractButton(_upgradePanelButton);
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Sweep");
        }


        public void MakeInteractableAllButtons()
        {
            foreach (var button in buttons)
            {
                button.interactable = true;
            }
        }


        public void TurnAllPanelsOn()
        {
            _characterPanel.gameObject.SetActive(true);
            _playPanel.gameObject.SetActive(true);
            _playImageBackground.gameObject.SetActive(true);
            _upgradesPanel.gameObject.SetActive(true);
        }


        public void TurnAllPanelsOffExceptThis(string panelName)
        {
            switch (panelName)
            {
                case "Character":
                    _characterPanel.gameObject.SetActive(true);
                    _playPanel.gameObject.SetActive(false);
                    _upgradesPanel.gameObject.SetActive(false);
                    break;

                case "Play":
                    _characterPanel.gameObject.SetActive(false);
                    _playPanel.gameObject.SetActive(true);
                    _playImageBackground.gameObject.SetActive(true);
                    _upgradesPanel.gameObject.SetActive(false);
                    break;

                case "Upgrades":
                    _characterPanel.gameObject.SetActive(false);
                    _playPanel.gameObject.SetActive(false);
                    _upgradesPanel.gameObject.SetActive(true);
                    break;

                default:
                    break;
            }
        }

        public void TurnThisPanelOn(string panelName)
        {
            switch (panelName)
            {
                case "Character":
                    _characterPanel.gameObject.SetActive(true);
                    break;

                case "Play":
                    _playPanel.gameObject.SetActive(true);
                    _playImageBackground.gameObject.SetActive(true);
                    break;

                case "Upgrades":
                    _upgradesPanel.gameObject.SetActive(true);
                    break;

                default:
                    break;
            }
        }


        public void TurnAllOtherPanelsOff(string panelName)
        {
            switch (panelName)
            {
                case "Character":
                    _playPanel.gameObject.SetActive(false);
                    _upgradesPanel.gameObject.SetActive(false);
                    break;

                case "Play":
                    _characterPanel.gameObject.SetActive(false);
                    _upgradesPanel.gameObject.SetActive(false);
                    break;

                case "Upgrades":
                    _characterPanel.gameObject.SetActive(false);
                    _playPanel.gameObject.SetActive(false);
                    break;

                default:
                    break;
            }
        }

        public void UnInteractButton(Button button)
        {
            button.interactable = false;
        }

        public void MoveToPanel(Vector2 targetPos, string panelToTurnOn)
        {
            TurnThisPanelOn(panelToTurnOn);
            TurnAllOtherPanelsOff(panelToTurnOn);
            if (_loadingImageBackground.gameObject.activeSelf)
            {
                _loadingImageBackground.gameObject.SetActive(false);
            }
        }

        IEnumerator Move(Vector2 targetPos, string panelToTurnOn)
        {
            TurnAllPanelsOn();
            float step = 0;
            while (step < 1)
            {
                _transform.offsetMin = Vector2.Lerp(_transform.offsetMin, targetPos, step += Time.deltaTime);
                _transform.offsetMax = Vector2.Lerp(_transform.offsetMax, targetPos, step += Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            TurnAllPanelsOffExceptThis(panelToTurnOn);
            if (_loadingImageBackground.gameObject.activeSelf)
            {
                _loadingImageBackground.gameObject.SetActive(false);
            }
        }
    }
}