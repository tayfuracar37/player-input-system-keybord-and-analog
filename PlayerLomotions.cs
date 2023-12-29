using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLomotions : MonoBehaviour
{
    Vector3 movedurations;
    Transform cameraObject;
    InputManager inputManager;
    Rigidbody PlayerRigitbody;
    public float movespeed = 7;
    public float rotationsspeed = 15f;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        PlayerRigitbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }
   private void HandleMovement()
    {
        movedurations = cameraObject.forward * inputManager.verticalinput;
        movedurations = movedurations + cameraObject.right * inputManager.horizontalinput;
        movedurations.Normalize();
        movedurations.y = 0;
        movedurations = movedurations * movespeed;


        Vector3 movevelocity = movedurations;
        PlayerRigitbody.velocity = movevelocity;
    }

    private void handlerotations()
    {
        Vector3 targetdiretions = Vector3.zero;
        targetdiretions = cameraObject.forward * inputManager.verticalinput;
        targetdiretions = targetdiretions + cameraObject.right * inputManager.horizontalinput;
        targetdiretions.Normalize();
        targetdiretions.y = 0;

        if (targetdiretions == Vector3.zero)
            targetdiretions = transform.forward;

        Quaternion targetrotations = Quaternion.LookRotation(targetdiretions);
        Quaternion playerrotations = Quaternion.Slerp(transform.rotation,targetrotations,rotationsspeed*Time.deltaTime);

        transform.rotation = playerrotations;
    }

    public void handleAllmovement()
    {
        HandleMovement();
        handlerotations();
    }
}
