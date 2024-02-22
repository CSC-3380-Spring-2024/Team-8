using Godot;
using System;

public static class MetSysBridgeInterface
{
    public static Camera2D Camera;
    static GDScript bridgeScript = GD.Load<GDScript>("res://src/Scripts/MetSys/MetSysBridge.gd");
    static GodotObject bridge = (GodotObject)bridgeScript.New();
    public static void setCamera(Camera2D camera)
    {
        Camera = camera;
        bridge.Call("setCamera", camera);
    }
    public static void adjustCamera()
    {
        bridge.Call("adjustCamera");
    }
    public static void loadRoom(String path, Node parent)
    {
        bridge.Call("loadRoom", path);
    }
    public static void addModule(String moduleName)
    {
        bridge.Call("addModule", moduleName);
    }
    public static void initRoom()
    {
        bridge.Call("initRoom");
    }
    public static void resetState()
    {
        bridge.Call("resetState");
    }

}
