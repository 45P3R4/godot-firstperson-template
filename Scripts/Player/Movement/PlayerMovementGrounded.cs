using Godot;
using System;

public partial class PlayerMovementGrounded : State
{
	
	public override void Enter()
	{
		Player.body.Velocity = Vector3.Zero;
		fsm.TransitionTo("PlayerMovementIdle");
	}
}
