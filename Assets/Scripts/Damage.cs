using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        if(!other.gameObject.CompareTag("Ground") && !other.gameObject.CompareTag("Collectable"))
        {
            if(other.transform.root.gameObject.TryGetComponent(out BossManager boss))
            {
                if(!boss.bossBloodTransform.gameObject.activeSelf)
                {
                    boss.bossBloodTransform.gameObject.SetActive(true);
                }

                Events.OnDamageBoss?.Invoke();

            }
            gameObject.SetActive(false);
        }
    }
}
