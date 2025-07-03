using Assets.Code.Common.Events;
using Assets.Code.Core;
using System.Collections;
using UnityEngine;

namespace Assets.Code.ZOthers
{
    public class LimitTransforms : MonoBehaviour
    {

        [SerializeField] private RectTransform _leftLimitTransform;
        [SerializeField] private RectTransform _rightLimitTransform;
        void Start()
        {
            StartCoroutine(SendLimitTransforms());
        }


        IEnumerator SendLimitTransforms()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new LimitTransformsEventData(
                                               _rightLimitTransform, _leftLimitTransform, GetInstanceID()));
        }
    }
}