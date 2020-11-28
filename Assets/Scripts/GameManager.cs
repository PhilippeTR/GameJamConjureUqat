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
    }
    void Start()
    {
        player = GameManager.FindObjectOfType<PlayerController>();
    }

    public PlayerController GetPlayerRef()
    {
        return player;
    }
}
