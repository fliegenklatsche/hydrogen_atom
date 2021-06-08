using System;
using Godot;
using System.Linq;
using System.Collections.Generic;
class DensityMechanics
{
    public float[,,] WaveFunction { get; set; }
    public float[] X { get; set; }
    public float[] Y { get; set; }
    public float[] Z { get; set; }
    public float StepX { get; set; }
    public float StepY { get; set; }
    public float StepZ { get; set; }



    private float maxValue;

    private const int DENSITY = 20;

    public DensityMechanics(float[,,] waveFunction,
    float[] x,
    float[] y,
    float[] z,
    float stepX,
    float stepY,
    float stepZ)
    {
        X = x;
        Y = y;
        Z = z;

        WaveFunction = waveFunction;
        maxValue = WaveFunction.Cast<float>().Max();

        StepX = stepX;
        StepY = stepY;
        StepZ = stepZ;
    }
    public List<Vector3> GetPositions()
    {
        List<float> test = new List<float>();

        Random r = new Random();
        int indexX = 0;
        int indexY = 0;
        int indexZ = 0;

        List<Vector3> vec3List = new List<Vector3>();

        foreach (var x in X)
        {
            indexY = 0;
            foreach (var y in Y)
            {
                indexZ = 0;
                foreach (var z in Z)
                {
                    var waveValue = WaveFunction[indexX, indexY, indexZ];
                    var normalizedWaveValue = waveValue / maxValue;
                    int randomCount = (int)(normalizedWaveValue * DENSITY);

                    test.Add(normalizedWaveValue);

                    for (int i = 0; i < randomCount; i++)
                    {
                        float xRandom = (float)r.NextDouble() * StepX + (x - StepX / 2);
                        float yRandom = (float)r.NextDouble() * StepY + (y - StepY / 2);
                        float zRandom = (float)r.NextDouble() * StepZ + (z - StepZ / 2);

                        vec3List.Add(new Vector3(xRandom, zRandom, yRandom));
                    }

                    indexZ++;
                }
                indexY++;
            }
            indexX++;
        }
        GD.Print("Max value: ", test.Max(), " list length: ", test.Count);
        return vec3List;
    }
}