﻿namespace EngiN95.Core.Rendering;

public class ShaderProgramSource
{
    public string VertexShaderSource;
    public string FragmentShaderSource;

    public ShaderProgramSource(string vertexShaderSource, string fragmentShaderSource)
    {
        VertexShaderSource = vertexShaderSource;
        FragmentShaderSource = fragmentShaderSource;
    }

    public static ShaderProgramSource LoadFromFiles(string vertexPath, string fragmentPath)
    {
        string vertexShader = File.ReadAllText(vertexPath);
        string fragmentShader = File.ReadAllText(fragmentPath);
        return new ShaderProgramSource(vertexShader, fragmentShader);
    }
}