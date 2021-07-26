using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 
 public class Fade : MonoBehaviour {
     public float FadeRate;
     private Image image;
     private float targetAlpha;
     bool fadingIn = false;

     float myTeleportTimer = 2.5f;
     // Use this for initialization
     void Start () {
         this.image = this.GetComponent<Image>();
         if(this.image==null)
         {
             Debug.LogError("Error: No image on "+this.name);
         }
         this.targetAlpha = this.image.color.a;
        //FadeOut();
     }


     
     // Update is called once per frame
     void Update () {
         Color curColor = this.image.color;
         float alphaDiff = Mathf.Abs(curColor.a-this.targetAlpha);
         if (alphaDiff>0.0001f)
         {
             curColor.a = Mathf.Lerp(curColor.a,targetAlpha,this.FadeRate*Time.deltaTime);
             this.image.color = curColor;
         }

      

         if(myTeleportTimer < 0)
         {
             if(!fadingIn)
             {
                 fadingIn = true;
                    FadeIn();
             }
           
         }
         else
         {
             if(!fadingIn)
             {
                myTeleportTimer -= Time.deltaTime;

             }
         }
     }
 
     public void FadeOut()
     {
         this.targetAlpha = 0.0f;

     }
 
     public void FadeIn()
     {
         UnityEngine.Debug.Log("Fading In");
         this.targetAlpha = 1.0f;
     }
 }