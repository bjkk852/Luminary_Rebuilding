using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviorObj
{
    // Start is called before the first frame update
    [SerializeField]
    public Animator animator;


    void Start()
    {
        animator.Play("Animate");
    }
    
    public void End()
    {
        GameManager.Resource.Destroy(gameObject);
    }
}
