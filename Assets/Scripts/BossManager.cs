using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{

    public Transform bossBloodTransform;
    [SerializeField] private Image bossBloodImage;
    [SerializeField] private Transform target;
    Animator bossAnimator;
    bool isDead,isWin;

    void Start()
    {
        Events.OnDamageBoss += onDamage;
        Events.OnMoveBoss += Move;
        bossAnimator = GetComponent<Animator>();
        isDead = false;

    }
    private void OnDisable()
    {
        Events.OnDamageBoss -= onDamage;
        Events.OnMoveBoss -= Move;
    }
    void Update()
    {
        if(!isDead && !isWin)
        {
            if(bossBloodTransform.gameObject.activeSelf)
            {
                bossBloodTransform.position = new Vector3(bossBloodTransform.position.x,bossBloodTransform.position.y,transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position,target.position,Time.deltaTime*1.5f);
            }
            if (transform.position.z>1.25f && transform.position.z < 1.75f){isWin=true; Events.OnGameFinish?.Invoke(false);}
        }
        
       
    }
    public void onDamage()
    {
        bossBloodImage.fillAmount-=0.1f;
        if (bossBloodImage.fillAmount.Equals(0f))
        {
            bossAnimator.enabled = false;
            isDead = true;
            Events.OnGameFinish?.Invoke(true);
        }
    }
    public void Move()
    {
        bossAnimator.SetBool("isMove", true);
    }

}
