using TMPro;
using UnityEngine;

namespace Assets.Code.UI
{
    public class GemsView : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _text;


        public void Reset()
        {
            UpdateGems(0);
        }


        public void UpdateGems(int newGems)
        {
            _text.SetText(newGems.ToString());
        }
    }
}