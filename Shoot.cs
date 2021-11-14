using Godot;
using System;

public class Shoot : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	string turn = "";
	PackedScene laser = (PackedScene)GD.Load("res://bulletlaser.tscn");
	int score = 0;
	public Sprite heart1;
	public Sprite heart2;
	public Sprite heart3;
	dynamic hpClass = new Player();
	Texture ass = (Texture)GD.Load("res://heart.png");
	public static string modeStr;

	public Shoot() {
		
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		int[] xeses = new int[3] {405, 450, 495};
		heart1 = new Sprite();
		heart1.Position = new Vector2(xeses[0], 49);
		heart1.Texture = ass;
		heart1.GlobalScale = new Vector2(4, 4);
		AddChild(heart1);
		
		heart2 = new Sprite();
		heart2.Position = new Vector2(xeses[1], 49);
		heart2.Texture = ass;
		heart2.GlobalScale = new Vector2(4, 4);
		AddChild(heart2);
		
		heart3 = new Sprite();
		heart3.Position = new Vector2(xeses[2], 49);
		heart3.Texture = ass;
		heart3.GlobalScale = new Vector2(4, 4);
		AddChild(heart3);
		
		var file = new File();
		file.Open("user://mode.txt", File.ModeFlags.ReadWrite);
		modeStr = file.GetAsText();
		file.Close();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (Player.hp == 3)
		{
				heart3.Visible = true;
				heart2.Visible = true;
				heart1.Visible = true;
		} else if (Player.hp == 2) {
				heart3.Visible = false;
				heart2.Visible = true;
				heart1.Visible = true;
		} else if (Player.hp == 1) {
				heart3.Visible = false;
				heart2.Visible = false;
				heart1.Visible = true;
		} else if (Player.hp == 0) {
				heart3.Visible = false;
				heart2.Visible = false;
				heart1.Visible = false;
		}
	}
	private void _on_KinematicBody2D_LaserShoot()
	{
		Area2D l = (Area2D)laser.Instance();
		l.Position = GetNode<Position2D>("KinematicBody2D/Muzzle" + turn).GlobalPosition+new Vector2(80, -200);
		AddChild(l);
		if (turn == " 2")
			turn = "";
		else
			turn = " 2";
	}
	private void add_score()
	{
		score += 10;
		dynamic thing = GetNode<RichTextLabel>("ScoreLabel");
		thing.Text = "Score: " + score.ToString();
		if (modeStr != "infinite") {
			if (score >= 1500)
			{
				GetTree().ChangeScene("res://YouWin.tscn");
			}
		}
	}
}



