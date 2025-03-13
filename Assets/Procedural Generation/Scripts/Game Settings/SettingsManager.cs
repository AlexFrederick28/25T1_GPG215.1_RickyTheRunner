using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private int maxFramerate;

    private void Start()
    {
        SetFramerate();
    }

    private void SetFramerate()
    {
        Application.targetFrameRate = maxFramerate;
    }
}
