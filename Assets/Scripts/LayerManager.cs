using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    string[] layers = {"Default","nocollider"};


    private void OnTriggerEnter(Collider other){
        ChangeLayer(other,1);
    }
    private void OnTriggerExit(Collider other){
        ChangeLayer(other,0);
    }

    private void ChangeLayer(Collider other,int index){

        other.gameObject.layer = LayerMask.NameToLayer(layers[index]);

    }
}
