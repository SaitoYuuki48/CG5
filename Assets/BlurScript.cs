using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurScript : MonoBehaviour
{
    public Shader highLumiShader;
    public Shader blurShader;
    private Material highLumiMat;
    private Material blurMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        highLumiMat = new Material(highLumiShader);
        blurMat = new Material(blurShader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        RenderTexture highLumiTex = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);

        Graphics.Blit(source, highLumiTex, highLumiMat);
        Graphics.Blit(highLumiTex, destination, blurMat);
        RenderTexture.ReleaseTemporary(highLumiTex);
    }
}
