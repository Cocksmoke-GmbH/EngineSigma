﻿using EngineSigma.Core;
using EngineSigma.Core.Management;
using EngineSigma.Core.Rendering;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace EngineTest;

internal class GameImpl : Game
{
    public GameImpl(string windowTitle, int initialWindowWidth, int initialWindowHeight) : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
        _vertices = new[]
        
        {
            new Vertex(new Vector3( 0.5f,  0.5f, 0.0f), new Vector2(1.0f, 1.0f), Color4.DarkBlue),
            new Vertex(new Vector3( 0.5f, -0.5f, 0.0f), new Vector2(1.0f, 0.0f), Color4.Transparent),
            new Vertex(new Vector3(-0.5f, -0.5f, 0.0f), new Vector2(0.0f, 0.0f), Color4.Fuchsia),
            new Vertex(new Vector3(-0.5f,  0.5f, 0.0f), new Vector2(0.0f, 1.0f), Color4.Lime)
        };
        

        _indices = new uint[]
        {
            0, 1, 3, 1, 2, 3
        };
    }
    
    private IShader _shader = null!;
    private Texture _texture = null!;
    
    private IndexBuffer _indexBuffer = null!;
    private StaticVertexBuffer _vertexBuffer = null!;
    private VertexArray _vertexArray = null!;

    private readonly uint[] _indices;
    private readonly Vertex[] _vertices;

    protected override void Init()
    {
        
    }

    protected override void OnLoad()
    {
        var src = ShaderProgramSource.LoadFromFiles("Resources/Shaders/vertex.glsl", "Resources/Shaders/fragment.glsl");
        _shader = new Shader(src);

        _vertexBuffer = new StaticVertexBuffer(_vertices);
        //_vertexBuffer.BufferData(_vertices);
        _vertexArray = new VertexArray();
        _indexBuffer = new IndexBuffer(_indices);
        
        _texture = ResourceManager.LoadTexture("Resources/Sprites/wall.jpg");
        _texture.Use();
    }

    protected override void OnUpdate()
    {
        
    }

    protected override void OnRender()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.CornflowerBlue);
        
        _shader.Use();
        
        _vertexArray.Bind();
        _indexBuffer.Bind();
        _vertexBuffer.Bind();
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}