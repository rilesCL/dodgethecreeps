using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	private float moveSpeed {get; set;} = 400;
	// Called when the node enters the scene tree for the first time.
	private Vector2 _screenSize;
	public override void _Ready()
	{
		  _screenSize = GetViewportRect().Size;
        Position = new Vector2(_screenSize.X / 2, _screenSize.Y / 2);
		// Hide the mouse cursor
        Input.MouseMode = Input.MouseModeEnum.Hidden;

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

		AnimatedSprite2D animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		Position = new Vector2(
			Mathf.Clamp(Position.X, 0, _screenSize.X),
			Mathf.Clamp(Position.Y, 0, _screenSize.Y)
		);

		
        if (direction.X == 1)
        {
            animation.Play("walk_right");
            animation.FlipH = false;
        }
        if (direction.X == -1)
        {
            animation.Play("walk_right");
            animation.FlipH = true;
        }
        if (direction.Y == 1)
        {
            animation.Play("walk_up");
            animation.FlipV = true;
        }
        // Correction : condition Y au lieu de X pour la marche vers le haut
        if (direction.Y == -1)
        {
            animation.Play("walk_up");
            animation.FlipV = false;
        }

        if (direction.Length() == 0)
        {
            animation.Stop();
        }
	}
}
