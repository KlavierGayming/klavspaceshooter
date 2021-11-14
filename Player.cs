using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	Vector2 vel = Vector2.Zero;
	int speed = 15;
	
	// laser packed scene, we use this for spawning the laser (not used here, used in Main.cs)
	PackedScene laser = (PackedScene)GD.Load("res://bulletlaser.tscn");
		
	bool inGameOver = false;

	public static int hp = 3;
	string turn = "";
	dynamic mainClass;
	//used for shot
	[Signal]
	public delegate void LaserShoot();


	public Player() {
		
	}
	

	public override void _Ready()
	{
		mainClass = new Shoot();
	}

	public override void _Process(float delta)
	{
		// this was used before im lazy to remove it
		if (!inGameOver) {
			//input code, uses += for slidey physics
			if (Input.IsActionPressed("ui_right"))
			{
				vel.x += speed;
				if (vel.x > 10000)
					vel.x = 10000;
			}
			else if (Input.IsActionPressed("ui_left"))
			{
				vel.x -= speed;
				if (vel.x < -10000)
					vel.x = -10000;
			}
			else
			{
				vel.x = 0;
			}		
			if (Input.IsActionJustPressed("ui_accept"))
			{
				if (Shoot.modeStr != "dodge") {
					shoot();
				}
			}
		} else {
			vel.x = 0;
		}
		//Checks if you're too far off screen and teleports you to the other side
		if (GlobalPosition.x > 800)
		{
			GlobalPosition = new Vector2(-200, GlobalPosition.y);
		}
		else if (GlobalPosition.x < -200)
		{
			GlobalPosition = new Vector2(700, GlobalPosition.y);
		}

		MoveAndSlide(vel);
	}
	private void shoot() {
		//Emits the signal so we can shoot from Main.cs so the bullet doesnt follow us
		EmitSignal(nameof(LaserShoot));
	}
	private void takeDamage(int damage) {
		//Takes damage, pretty obvious
		hp -= damage;
		if (hp <= 0) {
			//If health is lesser (or equal) to 0, removes this sprite and changed to game over menu
			QueueFree();
			GetTree().ChangeScene("res://GameOver.tscn");
		}
	}
}



