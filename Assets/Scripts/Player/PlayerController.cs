using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ArcheroClone
{
    public class PlayerController : MonoBehaviour, IController, IDragHandler, IPointerUpHandler
    { 
        public Action<Vector3> OnMove { get; set; }
        [SerializeField] 
        private RectTransform _rectTransform;
        private Vector2 _startPos;
        private float _size;
        private Vector3 _direction;
        private bool _isDrag;

        public void Awake()
        {
            _startPos = _rectTransform.anchoredPosition;
            _size = _rectTransform.sizeDelta.x;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _isDrag = true;

            var position = _rectTransform.anchoredPosition + eventData.delta;
            position = new Vector2(
                Mathf.Clamp(position.x, _startPos.x - _size, _startPos.x + _size),
                Mathf.Clamp(position.y, _startPos.y - _size, _startPos.y + _size));
            _rectTransform.anchoredPosition = position.normalized * _size;

            _direction = new Vector3(position.normalized.x, 0, position.normalized.y);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDrag = false;
            _rectTransform.anchoredPosition = _startPos;
            OnMove?.Invoke(Vector3.zero);
        }

        private void Update()
        {
            if (!_isDrag)
                return;

            OnMove?.Invoke(_direction);
        }
    }
}
