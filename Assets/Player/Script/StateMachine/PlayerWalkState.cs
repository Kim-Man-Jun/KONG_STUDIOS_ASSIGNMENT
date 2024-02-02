using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(playerController player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("움직임 실행");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        Vector3 camforward = player.cam.transform.forward;
        Vector3 camRight = player.cam.transform.right;

        camforward.y = 0;
        camRight.y = 0;

        Vector3 camforwardRelative = player.zInput * camforward;
        Vector3 camRightRelative = player.xInput * camRight;

        Vector3 dir = camforwardRelative + camRightRelative;

        player.SetVelocity(dir.x * player.walkSpeed, dir.z * player.walkSpeed, player.rotateSpeed);
        
        if (player.xInput == 0 && player.zInput == 0)
        {
            player.stateMachine.ChangeState(player.idleState);
        }
    }
}
