using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyAnimator : MonoBehaviour
{
    private Animator anim;

     

    private Transform currentTarget;   

    public GameObject EnemyScript;

    bool runToggle = false;
   

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

    public void ToggleRun()
    {
        runToggle = true;
    }
    
    public void LookAtObject(GameObject g)
    {
        transform.LookAt(g.transform);
    }

     

    public void PlayAnimation(string a)
    {
       
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        if(anim == null)
        {
            return;
        }
        anim.Rebind();
        anim.Play(a);
    }

    // Start is called before the first frame update
    void Start()
    {
        startAnimation = System.Enum.GetName(typeof(eAnimations), startingAnimation);
        anim = GetComponent<Animator>();
        anim.Rebind();
        anim.Play(startAnimation);
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
        {
            if(EnemyScript!=null)
            {
                EnemyScript.GetComponent<AIEnemyScript>().ChangeState();
            }


        }



       
    }
}
