using Godot;
using System;

public partial class Main : Node

 
{
	[Export]
    private PackedScene creepScene;

	    private Vector2 screen_Size;
		private RandomNumberGenerator rng = new RandomNumberGenerator();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		        screen_Size = GetViewport().GetVisibleRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private Vector2 ObtenirPositionAleatoireDuJeu(){
	float x,y;
       
        switch (rng.RandiRange(0, 3)){
            case 0: // haut
                x = rng.RandfRange(0,screen_Size.X);
                y = 0;
                break;
            case 1: //bas
                x = rng.RandfRange(0,screen_Size.X);
                y = screen_Size.Y;
                break;
            case 2: // gauche
                x = 0;
                y = rng.RandfRange(0,screen_Size.Y);
                break;
            case 3: // droite
                x = screen_Size.X;
                y = rng.RandfRange(0,screen_Size.Y);
                break;
            default:
                x = 0;
                y = 0;
                break;
        }
        return new Vector2(x,y);
	}

	

	private void OnSpawnTimerTimeout(){
				GD.Print("Timeout !");

		Creep spawnedCreep = creepScene.Instantiate<Creep>();

		//BCP DE CODE

		AddChild(spawnedCreep);
		        spawnedCreep.Position = ObtenirPositionAleatoireDuJeu();
	}
}
