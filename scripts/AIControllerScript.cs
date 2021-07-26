using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControllerScript : MonoBehaviour
{
    private Animator anim;

    public enum eAIType
    {
        basic,
        WizardHarry,
        VietnameseWoman,
        Grunt,
        Gibberish1,
        Gibberish2,
        SurroundedByFools,


    }
    public eAIType nearSound;

    public enum eAnimations{
        Melee_OneHanded,
        Idle,
        Idle_HandOnHips,
        Idle_CrossedArms,
        Idle_SexyDance,
        Idle_LeaningAgaintWall,
        Walk,
        Run,
        CrouchIdle
    }

    public eAnimations startingAnimation;
    private string startAnimation;

    public GameObject[] walkTarget;
    int currentWalkTarget = 0;

    Transform currentTarget;

    private Transform starting_lookAtPoint;

    public bool lookAtPlayer = true;
    public bool walkRoute = false;
    public int startingPointer = 0;

    float nearAudioDelay;
    float nearAudioDelayMax = 4f;

    
    bool nearAudioDelayON = false;


    public bool GetLookAtPlayer()
    {
        return lookAtPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {      
        nearAudioDelay = nearAudioDelayMax;
        currentWalkTarget = startingPointer;
        anim = GetComponent<Animator>();
        startAnimation = System.Enum.GetName(typeof(eAnimations), startingAnimation);
        anim.Rebind();
        anim.Play(startAnimation);
       
       if(walkTarget != null)
       {

    
       if(walkTarget.Length > 0)
       {
           currentTarget = walkTarget[currentWalkTarget].transform;
           currentTarget.position = new Vector3(currentTarget.position.x, transform.position.y, currentTarget.position.z);


       }
       else
       {
           if(lookAtPlayer && !walkRoute)
           {
                GameObject emptyGO = new GameObject();
                Transform t = emptyGO.transform;
                t.position =  gameObject.transform.position+transform.forward;
                starting_lookAtPoint = t;
           }
       }
        transform.LookAt(currentTarget);
       }

        
    }

    public void PlayNearAudio()
    {
        if(!nearAudioDelayON)
        {
            nearAudioDelayON = true;

         
            string soundString = System.Enum.GetName(typeof(eAIType), nearSound);

            if(nearSound != eAIType.basic)
            {
                FindObjectOfType<AudioManager>().PlayClipAtPosition(soundString, gameObject.transform.position);
            }

            
        }
      
    }


    private void OnTriggerEnter(Collider col)
    {     

        if(col.gameObject.tag == "AIClose")
        {
            //close to another AI
            //StartIdle();
           
        }


        if(col.gameObject.tag == "pathTarget")
        {
            if(col.gameObject == null)
            {
                return;
            }
            if(col.gameObject == walkTarget[currentWalkTarget])
            {
                if(currentWalkTarget == walkTarget.Length -1)
                {
                    currentWalkTarget = 0;
                }
                else
                {
                    currentWalkTarget+=1;
                }
                currentTarget = walkTarget[currentWalkTarget].transform;

                LookAtTarget();

            }
        }
    }

      private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "AIClose")
        {
            //close to another AI
            StartWalking();
        }
    }


    public void LookAtPlayer(GameObject g)
    {
        if(lookAtPlayer)
        {
            GameObject emptyGO = new GameObject();
            Transform t = emptyGO.transform;
            t.position = new Vector3(g.transform.position.x, transform.position.y, g.transform.position.z);
            transform.LookAt(t);
        }
    }

    public void StartIdle()
    {
        if(walkRoute)
        {
            anim.Rebind();
            anim.Play("Idle");
        }
    }

    public void LookAtTarget()
    {
         transform.LookAt(currentTarget);
    }

    public void StartWalking()
    {      
        if(walkTarget.Length > 0)
        {            
            if(walkRoute)
            {
                if(anim != null)
                {
                    anim.Rebind();
                    transform.LookAt(walkTarget[currentWalkTarget].transform);
                    anim.Play(startAnimation);
                }
            }
            
        }  
        else
        {            
            transform.LookAt(starting_lookAtPoint);
        }
       
    }   

    // Update is called once per frame
    void Update()
    {
        if(nearAudioDelayON)
        {
            nearAudioDelay -= Time.deltaTime;
            if(nearAudioDelay < 0)
            {
                nearAudioDelayON = false;
                nearAudioDelay = nearAudioDelayMax;
            }

        }
      
    }
}
