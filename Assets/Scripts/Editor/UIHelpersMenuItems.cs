using UnityEditor;
using UnityEngine;

public class UIHelpersMenuItems : Editor
{
    public const string CreationPath = "GameObject/UI/UIHelpers/";
    
    [MenuItem(CreationPath + "Linear Progress Bar")]
    public static void AddLinearProgressBar()
    {
        GameObject barObj = Instantiate(
            Resources.Load<GameObject>("UIHelpers/Progress Bar Linear"),
            Selection.activeGameObject.transform, false);
        barObj.name = "Progress Bar Linear";
    }
        
    [MenuItem(CreationPath + "Radial Progress Bar")]
    public static void AddRadialProgressBar()
    {
        GameObject barObj = Instantiate(
            Resources.Load<GameObject>("UIHelpers/Progress Bar Radial"),
            Selection.activeGameObject.transform, false);
        barObj.name = "Progress Bar Radial";
    }
}
