using Godot;
using System;

public class Camera : Godot.Camera
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    int count = 0;
    public override void _Process(float delta)
    {
        if(count % 1000 == 0)
            GD.Print(this.Translation.ToString());
        count++;

    }
}
