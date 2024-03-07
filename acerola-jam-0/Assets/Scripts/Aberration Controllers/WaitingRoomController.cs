using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaitingRoomController : MonoBehaviour
{
    public Animator room;
    private static Controls controller;

    bool looking = true;

    public string nextScene;

    void Awake()
    {
        room.speed = 0;
        controller = new Controls();
        controller.Player.SpaceHold.performed += ctx => {
            if (looking){
                room.speed = 1;
            }
        } ;
        controller.Player.SpaceHold.canceled += ctx => {
            if (looking){
                room.speed = 0;
            }
        } ;
        
        controller.Player.SpaceTap.performed += ctx => {
            if (!looking){
                room.speed = 1;
                Invoke("Continue", 10f);
            }
        } ;
    }

 
    void Continue(){
        room.Play("up");
        Invoke("NextScene", 3f);
    }

    void Update()
    {
        if (room.GetCurrentAnimatorClipInfo(0)[0].clip.name == "clock" && looking){
            room.speed = 0;
            looking = false;
        }
    }

    void NextScene()
    {
        GameManager.Instance.LoadScene(nextScene);
    }

    // Required for the input system.
    void OnEnable()
    {
        controller.Player.Enable();
    }

    void OnDisable()
    {
        controller.Player.Disable();
    }
}
