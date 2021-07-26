using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimalControllerScript : MonoBehaviour
{
    private Animator anim;

    public enum eAnimations{
        CowBull_Idle,
        CowBull_Eat,
        Birds_Idle,
        Birds_Eat,
        Pig_Idle,
        Pig_Eat,
        Rabbit_Idle,
        Rabbit_Eat,
        Rabbit_Run,
        Rabbit_Walk,
        Cat_SitIdle,
        Cat_SitStart,      



    }
    public eAnimations startingAnimation;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Rebind();
        anim.Play((System.Enum.GetName(typeof(eAnimations), startingAnimation)));
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }
}
