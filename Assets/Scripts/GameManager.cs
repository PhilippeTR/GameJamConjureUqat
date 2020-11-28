using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    private PlayerController player;

    private void Awake()
    {
        instance = this;
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        
    }

    public PlayerController GetPlayerRef()
    {
        return player;
    }
}
