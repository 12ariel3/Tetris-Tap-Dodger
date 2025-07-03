using UnityEngine;

namespace Assets.Code.RecyclableObjects.PopUps
{
    [CreateAssetMenu(menuName = "PopUp/PopUpId", fileName = "PopUpId", order = 0)]
    public class PopUpId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}