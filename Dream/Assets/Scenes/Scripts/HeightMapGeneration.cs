using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMapGeneration : MonoBehaviour
{
  Texture2D tex;
  public int pixWidth;
  public int pixHeight;
  public float xOrg;
  public float yOrg;
  public float scale =1.0f;
  public Color[] pix;
  private Renderer rend;
  private float range;
  private int resolution;
  float time;
  public bool flow;

  // Start is called before the first frame update
  void Start()
  { 
    Debug.Log("PixWidth:"+pixWidth);
    time = 0f;
    Debug.Log("PixHeight:"+pixWidth);
    rend = GetComponent<Renderer>();
    tex = new Texture2D(pixWidth,pixHeight);
    pix = new Color[tex.width*tex.height];
    //rend.material.EnableKeyword("_MAINTEX");
    //rend.material.SetTexture("_MainTex",tex);
    rend.material.mainTexture = tex;
    range = 40f;
    resolution = 256;
    yOrg=0.0f;
  }

  // Update is called once per frame
  void Update()
  {
    if(flow){
      yOrg += Time.deltaTime;
    }

      CalcNoise(0f,yOrg,resolution,range);
      rend.material.mainTexture = tex;
  }
  void CalcNoise(float xOffset, float yOffset,int resolution,float range){

    float stepSize = range / (resolution - 1); //separation between the sampling spots/locations
    float xIndex = xOffset; 
    float yIndex = yOffset;
    float sample;
    for (int k = 0; k < resolution; k++)
    {
      for (int i = 0; i < resolution; i++)
      {
        xIndex += stepSize;
        sample = Mathf.PerlinNoise(xIndex, yIndex);
        pix[k*tex.width +i] = new Color(sample,.2f,0,sample);
      }
      xIndex = xOffset;
      yIndex += stepSize;
    }
    tex.SetPixels(pix);
    tex.Apply();
  }


}
