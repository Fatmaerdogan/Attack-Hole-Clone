using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform holeTransform;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private Transform firePlace;
    [SerializeField] private Transform Boss;
    [SerializeField] private GameObject[] CollectableList;

    void Start()
    {
        Events.OnAttackBoss += AttackBoss;
    }
    private void OnDisable()
    {
        Events.OnAttackBoss -= AttackBoss;
    }
    // Update is called once per frame
    void Update()
    {
        if(holeTransform.position.z < 1.5f){
              holeTransform.position = Vector3.MoveTowards(holeTransform.position,holeTransform.position + new Vector3(0f,0f,1f)
                , Time.deltaTime *2f);
        }
      
    }

    private void FireTheAmmo(GameObject collectableType,float minRandomX,float maxRandomY,float force,
        float minRandomVelocity,float maxRandomVelocity)
    {
        GameObject newBullet = Instantiate(collectableType,new Vector3(firePlace.position.x + Random.Range(minRandomX,maxRandomY),
            firePlace.position.y,firePlace.position.z),Quaternion.identity);

        Rigidbody ammoRb = newBullet.GetComponent<Rigidbody>();

        ammoRb.AddForce(transform.forward * force);

        ammoRb.velocity = new Vector3(0f,Random.Range(minRandomVelocity,maxRandomVelocity),0f);

        Events.OnMoveBoss?.Invoke();
    }
    public void AttackBoss()
    {
        FireTheAmmo(GetCollectable, -0.35f,0.35f,500f,5f,8f);
        DataManager.Instance.Collectable = -1;
    }
    public GameObject GetCollectable=>CollectableList[Random.Range(0, CollectableList.Length)];
}
