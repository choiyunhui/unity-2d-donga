using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager를 싱글 톤 처리합니다.
    public static GameManager instance { get; set; }
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    public float noteSpeed;//전체 노트는 동일한 속도로 떨어져야하기에 총 관리
    
    public enum judges { NONE = 0, BAD, GOOD, PERFECT, MISS};


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
