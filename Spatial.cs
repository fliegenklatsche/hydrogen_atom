using Godot;
using System;


public class Spatial : Godot.Spatial
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    int xLength;
    int yLength;
    int zLength;

    private float Linspace(out float[] X, float xmin, float xmax, int number)
    {
        float step = Math.Abs(xmax - xmin) / number;

        X = new float[number];

        for (int i = 0; i < number; i++)
        {
            X[i] = xmin + i * step;
        }

        return step;
    }

    public override void _Ready()
    {
        var pointInstance = ResourceLoader.Load<PackedScene>("res://Point.tscn");

        float[] X;
        float[] Y;
        float[] Z;

        float stepX = Linspace(out X, -100, 100, 100);
        float stepY = Linspace(out Y, -100, 100, 100);
        float stepZ = Linspace(out Z, -100, 100, 100);

        WaveFunction wave = new WaveFunction(X,Y,Z);
        wave.X = X;
        wave.Y = Y;
        wave.Z = Z;


        DensityMechanics densityMechanics = new DensityMechanics(wave.GetWaveFunction(),
        X, Y, Z,
        stepX, stepY, stepZ);


        var vec3List = densityMechanics.GetPositions();

        foreach (var vec3 in vec3List)
        {
            Point point = (Point)pointInstance.Instance();
            point.Translation = vec3;
            point.Scale = new Vector3(0.1f, 0.1f, 0.1f);
            AddChild(point);

        }

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }
}
