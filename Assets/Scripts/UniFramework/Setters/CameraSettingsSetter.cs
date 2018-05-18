namespace UniFramework.Setters
{
    using UnityEngine;

    [AddComponentMenu("Setter/Other/Camera Settings Setter")]
    public class CameraSettingsSetter : Setter
    {
        public Camera cam;
        [Space]
        public CamSettings[] settings;

        public override void Set()
        {
            float currentRatio = Screen.currentResolution.width / (float)Screen.currentResolution.height;

            for (int i = 0; i < settings.Length; i++)
            {
                if (settings[i].platform == Application.platform && Mathf.Approximately(currentRatio, settings[i].GetRatio()))
                {
                    if (settings[i].setFieldOfView)
                        cam.fieldOfView = settings[i].fieldOfView;

                    if (settings[i].setSize)
                        cam.orthographicSize = settings[i].size;
                }
            }
        }

        [System.Serializable]
        public struct CamSettings
        {
            public AspectRatio ratio;
            public RuntimePlatform platform;

#if ODIN_INSPECTOR
            [Space]
            [Sirenix.OdinInspector.HorizontalGroup("FoV")]
            public bool setFieldOfView;
            [Space]
            [Sirenix.OdinInspector.ShowIf("setFieldOfView")]
            [Sirenix.OdinInspector.HideLabel]
            [Sirenix.OdinInspector.HorizontalGroup("FoV")]
            public float fieldOfView;
            [Sirenix.OdinInspector.HorizontalGroup("Size")]
            public bool setSize;
            [Sirenix.OdinInspector.ShowIf("setSize")]
            [Sirenix.OdinInspector.HideLabel]
            [Sirenix.OdinInspector.HorizontalGroup("Size")]
            public float size;
#else
            [Space]
            public bool setFieldOfView;
            public float fieldOfView;
            public bool setSize;
            public float size;
#endif

            public float GetRatio()
            {
                switch (ratio)
                {
                    case AspectRatio.Ratio16x9:
                        return 16f / 9;
                    case AspectRatio.Ratio16x10:
                        return 16f / 10;
                    case AspectRatio.Ratio5x4:
                        return 5f / 4;
                    case AspectRatio.Ratio4x3:
                        return 4f / 3;
                    default:
                        return 1;
                }
            }
        }

        [System.Serializable]
        public enum AspectRatio
        {
            Ratio16x9,
            Ratio16x10,
            Ratio5x4,
            Ratio4x3
        }
    }
}
