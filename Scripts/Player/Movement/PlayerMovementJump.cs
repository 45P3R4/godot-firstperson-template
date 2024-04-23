using Godot;
using System;

public partial class PlayerMovementJump : State
{

	[Export]
	float jumpEnegry = 5;

	public override void Enter()
	{
		Player.body.Velocity += Vector3.Up * jumpEnegry;
		Player.body.MoveAndSlide();

		if (!Player.body.IsOnFloor())
			fsm.TransitionTo("PlayerMovementInAir");
	}
}
