using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    GameObject mPlayer;
    
    NavMeshAgent mAgent;
    void Awake()
    {
        mAgent = GetComponent<NavMeshAgent>();
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        if (mPlayer != null)
        {
            mAgent.SetDestination(mPlayer.transform.position);
        }
    }

    public void SetPlayer(GameObject _player)
    {
        mPlayer = _player;
    }
}
