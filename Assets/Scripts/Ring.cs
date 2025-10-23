using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
   //manual settings
   [Range(3, 360)]
   public int segments = 3;
   public float innerRadius = 0.7f;
   public float thickness = 0.5f;
   public Material ringMat;

   //cached references
   GameObject ring;
   Mesh ringMesh;
   MeshFilter ringMF;
   MeshRenderer ringMR;



   private void Start()
   {
      //create ring object
      ring = new GameObject(name + " Ring");
      ring.transform.parent = transform;
      ring.transform.localScale = Vector3.one;
      ring.transform.localPosition = Vector3.zero;
      ring.transform.localRotation = Quaternion.identity;
      ringMF = ring.AddComponent<MeshFilter>();
      ringMesh = ringMF.mesh;
      ringMR = ring.AddComponent<MeshRenderer>();
      ringMR.material = ringMat;


      //build ring mesh
      Vector3[] verticies = new Vector3[(segments + 1) * 2 * 2];
      int[] trinagles = new int[segments * 6 * 2];
      Vector2[] uv = new Vector2[(segments + 1) * 2 * 2];
      int halfway = (segments + 1) * 2;
      

      for (int i = 0; i < segments + 1; i++)
      {
         float progress = (float)i / (float)segments;
         float angle = Mathf.Deg2Rad * progress * 360;
         float x = Mathf.Sin (angle);
         float z = Mathf.Cos (angle);

         verticies[i * 2] = verticies[i * 2] = new Vector3(x, 0, z) * (innerRadius + thickness);
         verticies[i * 2 + 1] = verticies[i * 2 + 1 + halfway] = new Vector3(x, 0f, z) * innerRadius;
         uv[i * 2] = uv[i * 2] = new Vector2(progress, 0f);
         uv[i * 2 + 1] = uv[i * 2 + 1] = new Vector2(progress, 1f);

         if( i != segments)
         {
            trinagles[i * 12] = i * 2;
            trinagles[i * 12 + 1] = trinagles[i * 12 + 4] = (i + 1) * 2;
            trinagles[i * 12 + 2] = trinagles[i * 12 + 3] = i * 2 + 1;
            trinagles[i * 12 + 5] = (i + 1) * 2 + 1;
         }

      }

      ringMesh.vertices = verticies;
      ringMesh.triangles = trinagles;
      ringMesh.uv = uv;
      ringMesh.RecalculateNormals();







   }

 

}
