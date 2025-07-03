using TMPro;
using UnityEngine;

namespace Assets.Code.UI
{
    public class ScoreView : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _text;


        public void Reset()
        {
            UpdateScore(0);
        }


        public void UpdateScore(int newScore)
        {
            _text.SetText(newScore.ToString());
        }
    }
}