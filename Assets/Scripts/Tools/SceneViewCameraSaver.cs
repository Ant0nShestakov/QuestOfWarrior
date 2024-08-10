using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class SceneViewCameraSaver
{
    private const string CameraPositionKey = "SceneViewCameraPosition";
    private const string CameraRotationKey = "SceneViewCameraRotation";

    public static Vector3 CameraPosition { get; private set; }
    public static Quaternion CameraRotation { get; private set; }

    static SceneViewCameraSaver()
    {
        SceneView.duringSceneGui += OnSceneGUI;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

        LoadCameraData();
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        if (SceneView.lastActiveSceneView != null)
        {
            CameraPosition = SceneView.lastActiveSceneView.camera.transform.position;
            CameraRotation = SceneView.lastActiveSceneView.camera.transform.rotation;
        }
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            if (SceneView.lastActiveSceneView != null)
            {
                CameraPosition = SceneView.lastActiveSceneView.camera.transform.position;
                CameraRotation = SceneView.lastActiveSceneView.camera.transform.rotation;
                SaveCameraData();
            }
        }
    }

    private static void SaveCameraData()
    {
        EditorPrefs.SetFloat(CameraPositionKey + "X", CameraPosition.x);
        EditorPrefs.SetFloat(CameraPositionKey + "Y", CameraPosition.y);
        EditorPrefs.SetFloat(CameraPositionKey + "Z", CameraPosition.z);

        EditorPrefs.SetFloat(CameraRotationKey + "X", CameraRotation.x);
        EditorPrefs.SetFloat(CameraRotationKey + "Y", CameraRotation.y);
        EditorPrefs.SetFloat(CameraRotationKey + "Z", CameraRotation.z);
        EditorPrefs.SetFloat(CameraRotationKey + "W", CameraRotation.w);
    }

    private static void LoadCameraData()
    {
        if (EditorPrefs.HasKey(CameraPositionKey + "X"))
        {
            float x = EditorPrefs.GetFloat(CameraPositionKey + "X");
            float y = EditorPrefs.GetFloat(CameraPositionKey + "Y");
            float z = EditorPrefs.GetFloat(CameraPositionKey + "Z");
            CameraPosition = new Vector3(x, y, z);
        }
        else
        {
            CameraPosition = Vector3.zero;
        }

        if (EditorPrefs.HasKey(CameraRotationKey + "X"))
        {
            float x = EditorPrefs.GetFloat(CameraRotationKey + "X");
            float y = EditorPrefs.GetFloat(CameraRotationKey + "Y");
            float z = EditorPrefs.GetFloat(CameraRotationKey + "Z");
            float w = EditorPrefs.GetFloat(CameraRotationKey + "W");
            CameraRotation = new Quaternion(x, y, z, w);
        }
        else
        {
            CameraRotation = Quaternion.identity;
        }
    }
}