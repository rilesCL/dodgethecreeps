using Godot;
using System;

public partial class Player : Area2D
{
	
	private float moveSpeed {get; set;} = 400;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 direction = Vector2.Zero;
		if(Input.IsActionPressed("move_right")){
			direction.X += 1;
		}
		if(Input.IsActionPressed("move_left")){
			direction.X -= 1;
		}
		if(Input.IsActionPressed("move_up")){
			direction.Y -= 1;
		}
		if(Input.IsActionPressed("move_down")){
			direction.Y += 1;
		}
		
		Position += direction * moveSpeed *(float)delta;
	}
}
