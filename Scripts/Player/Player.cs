using Godot;
using System;

public partial class Player : Node3D
{
	public Player Instance;

	public static CharacterBody3D body;

	public static float gravity = -0.3f;

	public override void _Ready()
	{
		body = GetNode<CharacterBody3D>("../CharacterBody3D");

		if (Instance != null)
		{
			QueueFree();
			return;
		}
		Instance = this;
	}
}
