using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.ZOthers
{
    public class CameraFollowMediator : MonoBehaviour, EventObserver
    {
        Transform target;
        Vector3 offset;
        bool isFollow;
        [SerializeField] float smoothTime = 0.3f;
        Vector3 velocity = Vector3.zero;

        // Start is called before the first frame update
        void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.PlayerSpamedAndSendHisTransform, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.PlayerSpamedAndSendHisTransform, this);
        }

        private void FixedUpdate()
        {
            if (isFollow)
            {
                Vector3 targetPosition = target.position + offset;
                targetPosition.z = transform.position.z;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
        }

        public void Follow(Transform playerTransform)
        {
            target = playerTransform;
            offset = transform.position - target.position;
            isFollow = true;
        }

        public void UnFollow()
        {
            isFollow = false;
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PlayerSpamedAndSendHisTransform)
            {
                if (target == null)
                {
                    var playerSpamedAndSendHisTransformEventData = (PlayerSpamedAndSendHisTransformEventData)eventData;
                    Follow(playerSpamedAndSendHisTransformEventData.PlayerTransform);
                }
            }
        }
    }
}