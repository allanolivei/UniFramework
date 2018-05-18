namespace UniFramework.Utility
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.Events;

    public class InvokeOnClick : MonoBehaviour
    {
        public BoolReference setCursorPos;
#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.ShowIf("ShowVariable")]
#endif
        public Vector2Variable cursorPos;
        public UnityEvent OnClick;

        private Camera cam;
        private Vector2 mousePos;

        private void Awake()
        {
            cam = Camera.main;
        }

        private void SetPos()
        {
            if (setCursorPos)
            {
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

                cursorPos.Value = mousePos;
            }
        }

        private void OnMouseDown()
        {
            SetPos();
            OnClick.Invoke();
        }

#if ODIN_INSPECTOR
        private bool ShowVariable()
        {
            return setCursorPos.Value;
        }
#endif
    }
}
