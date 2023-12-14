using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private static MoneyManager _instance;

    public static MoneyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("MoneyManager");
                go.AddComponent<MoneyManager>();
                _instance = go.GetComponent<MoneyManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
        set
        {
            if (_instance == null) _instance = value;
        }
    }

    public UserData userData;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this) Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
