using Godot;
using System;

class WaveFunction
{
    private const float PI = (float)Math.PI;
    public float n { get; set; }
    public float l { get; set; }
    public float m { get; set; }

    public float[] X { get; set; }
    public float[] Y { get; set; }
    public float[] Z { get; set; }

    private float[,,] waveFunction;

    public WaveFunction(float[] x, float[] y, float[] z)
    {
        X = x;
        Y = y;
        Z = z;
        waveFunction = new float[X.Length, Y.Length, Z.Length];
    }

    public float[,,] GetWaveFunction()
    {
        int indexX = 0;
        int indexY = 0;
        int indexZ = 0;

        foreach (var x in X)
        {
            indexY = 0;
            foreach (var y in Y)
            {
                indexZ = 0;
                foreach (var z in Z)
                {
                    var r = Sqrt(x * x + y * y + z * z);
                    var theta = Acos(z / r);
                    float psi2 = Exp(-r) * Pow(1 - r, 2) * Pow(Cos(theta),2);

                    waveFunction[indexX, indexY, indexZ] = psi2;
                    indexZ++;
                }
                indexY++;
            }
            indexX++;
        }

        return waveFunction;
    }


    private float Sqrt(float number)
    {
        return (float)Math.Sqrt(number);
    }

    private float Exp(float number)
    {
        return (float)Math.Exp(number);
    }

    private float Pow(float number1, float number2)
    {
        return (float)Math.Pow(number1, number2);
    }
    private float Cos(float number)
    {
        return (float)Math.Cos(number);
    }
    private float Acos(float number)
    {
        return (float)Math.Acos(number);
    }



}

