Unity Adventure Module (2D + 3D)

Overview
- This repository contains a minimal scaffold for a Unity-based adventure module supporting both 2D and 3D prototypes.
- It includes starter C# scripts for a top-down 2D player and a simple 3D character controller, plus instructions to finish setup in the Unity Editor.

Where to open
- Open Unity Hub and create or "Add" a project at `c:\Users\my pc\OneDrive\Desktop\vssc\unity-adventure`.
- Or create a new Unity project and copy these `Assets` and `Packages` folders into it.

Quick start (Editor steps)
1. Open the project in Unity Editor (2020.3 LTS+ recommended).
2. Create two scenes: `Assets/Scenes/Scene_2D.unity` and `Assets/Scenes/Scene_3D.unity`.
3. For the 2D scene: create a `Player` GameObject, add a `Rigidbody2D` (set Body Type to Dynamic), add a `CircleCollider2D` (or Box), then attach `Assets/Scripts/Player2D.cs`.
4. For the 3D scene: create a `Player3D` GameObject (Capsule), add `CharacterController` component, attach `Assets/Scripts/Player3D.cs`, and add a `Camera` as child or scene camera.
5. Press Play and test movement.

Files added
- `Assets/Scripts/Player2D.cs` - top-down 2D movement script (Gizmo and inspector friendly).
- `Assets/Scripts/Player3D.cs` - 3D character controller using `CharacterController`.
- `Assets/Scripts/GameManager.cs` - small manager skeleton for mode switching and future expansion.
- `.gitignore` - Unity-friendly ignore patterns.

Next suggested steps
- I can automatically generate basic `.unity` scene text files, but they are editor-specific and easier to assemble inside Unity.
- I can add a simple UI, demo assets, or create an automated Editor script to produce starter scenes — tell me which you'd prefer.

If you want, I can now:
- Create a simple Editor script to auto-generate the two scenes and place player GameObjects programmatically, or
- Add more gameplay features (interaction, inventory, camera follow, switching between 2D/3D at runtime).

Tell me which next step you want me to implement.
