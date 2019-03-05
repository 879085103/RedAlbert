using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BridgeDesignMode:MonoBehaviour
{
    void Start()
    {
        IRenderEngine renderEngine = new OpenGL();
        Sphere sphere = new Sphere(renderEngine);
        sphere.Draw();
        Cube cube = new Cube(renderEngine);
        cube.Draw();
        Capsule capsule = new Capsule(renderEngine);
        capsule.Draw();
    }
}
public class IFigure
{
    public string name;
    public IFigure(string name_, IRenderEngine renderEngine_)
    {
        name = name_;
        renderEngine = renderEngine_;
    }
    public IRenderEngine renderEngine;

    public void Draw()
    {
        renderEngine.Render(name);
    }
}

public class Sphere:IFigure
{
    public Sphere(IRenderEngine renderEngine ) : base("Sphere",renderEngine) { }
}

public class Cube:IFigure
{
    public Cube(IRenderEngine renderEngine) : base("Cube", renderEngine) { }
}

public class Capsule:IFigure
{
    public Capsule(IRenderEngine renderEngine) : base("Capsule",renderEngine) { }
}

public abstract class IRenderEngine
{
    public abstract void Render(string name);
}

public class OpenGL:IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("OpenGL绘制出来了" + name);
    }
}

public class DirectX:IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("DirectX绘制出来了" + name);
    }
}


