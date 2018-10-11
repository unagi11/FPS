using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class fpsDisplay : MonoBehaviour
{
    private Text FrameText;
    float deltaTime = 0.0f;

    private void Start()
    {
        FrameSetting30fps();
        FrameText = GetComponent<Text>();
        GetComponent<Button>().onClick.AddListener(FrameChange);
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }
    
    void FrameChange()
    {
        if (QualitySettings.vSyncCount == 1)
            FrameSetting30fps();
        else
            FrameSetting60fps();
    }

    public void FrameSetting60fps()
    {
        QualitySettings.vSyncCount = 1;
    }

    public void FrameSetting30fps()
    {
        QualitySettings.vSyncCount = 2;
    }

    void OnGUI()
    {
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        FrameText.GetComponent<Text>().text = text; 
    }
}