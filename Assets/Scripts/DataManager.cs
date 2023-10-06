using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public class HoleSizeClass{
        public Vector3 size;
    }

    private HoleSizeClass holeSizeData = new HoleSizeClass();

    public HoleSizeClass HoleSizeData => holeSizeData;


    int _Collectable;
    public int Collectable
    {
        get { _Collectable = PlayerPrefs.GetInt("Collectable"); return _Collectable; }
        set { _Collectable += value; PlayerPrefs.SetInt("Collectable", _Collectable); Events.OnCollectableChance?.Invoke(); }
    }

    private void Awake(){
        if(Instance == null){
            Instance =this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
