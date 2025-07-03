using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class EnergyView : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Slider _energySlider;
        [SerializeField] private SpriteRenderer _batterySpriteRenderer;
        [SerializeField] private Animator _batteryAnimator;


        public void UpdateEnergy(float newActualEnergy, float newMaxEnergy)
        {
            _text.SetText(newActualEnergy.ToString() + "/" + newMaxEnergy.ToString());
            _energySlider.maxValue = newMaxEnergy;
            _energySlider.value = newActualEnergy;

            if (newActualEnergy < newMaxEnergy)
            {
                _batteryAnimator.gameObject.SetActive(true);
                _batteryAnimator.gameObject.SetActive(true);
            }
            else
            {
                _batteryAnimator.gameObject.SetActive(false);
                _batteryAnimator.gameObject.SetActive(false);
            }
        }
    }
}