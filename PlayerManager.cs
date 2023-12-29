using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputmanager;
    PlayerLomotions playerlomotions;
    private void Awake()
    {
        inputmanager = GetComponent<InputManager>();
        playerlomotions = GetComponent<PlayerLomotions>();
    }
    private void Update()
    {
        inputmanager.handleAllinput();
    }

    private void FixedUpdate()
    {
        playerlomotions.handleAllmovement();
    }
}
