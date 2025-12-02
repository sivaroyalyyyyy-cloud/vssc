#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Create2DSceneEditor
{
    [MenuItem("Tools/Adventure/Create 2D Scene")]
    public static void Create2DScene()
    {
        // Create new scene
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        scene.name = "Scene_2D";

        // Main Camera
        var camGO = new GameObject("Main Camera");
        var cam = camGO.AddComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = 6;
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = new Color(0.6f, 0.8f, 1f);
        cam.tag = "MainCamera";
        camGO.AddComponent<AudioListener>();

        // Player (with 2D components)
        var playerGO = new GameObject("Player");
        playerGO.transform.position = Vector3.zero;
        var sr = playerGO.AddComponent<SpriteRenderer>();
        // Leave sprite null so user can assign; set a temporary color
        sr.color = Color.white;
        var rb = playerGO.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        var col = playerGO.AddComponent<CircleCollider2D>();
        var playerScript = playerGO.AddComponent<Player2D>();
        playerGO.AddComponent<PlayerInteraction>();

        // Ground (simple platform)
        var ground = new GameObject("Ground");
        ground.transform.position = new Vector3(0, -2, 0);
        var gsr = ground.AddComponent<SpriteRenderer>();
        gsr.color = new Color(0.3f, 0.8f, 0.3f);
        var gcol = ground.AddComponent<BoxCollider2D>();
        gcol.size = new Vector2(20, 2);
        var gRb = ground.AddComponent<Rigidbody2D>();
        gRb.bodyType = RigidbodyType2D.Static;

        // Camera follow
        var camFollow = camGO.AddComponent<CameraFollow2D>();
        camFollow.target = playerGO.transform;
        camFollow.offset = new Vector3(0, 0, -10);

        // UI Canvas
        var canvasGO = new GameObject("Canvas");
        var canvas = canvasGO.AddComponent<UnityEngine.Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<UnityEngine.CanvasScaler>();
        canvasGO.AddComponent<UnityEngine.UI.GraphicRaycaster>();

        var infoGO = new GameObject("InfoText");
        infoGO.transform.SetParent(canvasGO.transform);
        var rect = infoGO.AddComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.95f);
        rect.anchorMax = new Vector2(0.5f, 0.95f);
        rect.anchoredPosition = Vector2.zero;
        rect.sizeDelta = new Vector2(400, 30);
        var text = infoGO.AddComponent<UnityEngine.UI.Text>();
        text.alignment = TextAnchor.MiddleCenter;
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.fontSize = 18;
        text.color = Color.black;

        var hud = canvasGO.AddComponent<HUD>();
        hud.infoText = text;

        // Example interactable
        var chest = new GameObject("Chest_Interactable");
        chest.transform.position = new Vector3(2, -1, 0);
        var chestSR = chest.AddComponent<SpriteRenderer>();
        chestSR.color = new Color(0.9f, 0.7f, 0.2f);
        var chestCol = chest.AddComponent<BoxCollider2D>();
        chestCol.isTrigger = true;
        var inter = chest.AddComponent<Interactable>();
        inter.interactionText = "Open Chest";

        // Add a simple script override to show HUD message on interact
        chest.AddComponent<ChestBehavior>();

        // Save scene
        string scenePath = "Assets/Scenes/Scene_2D.unity";
        System.IO.Directory.CreateDirectory("Assets/Scenes");
        EditorSceneManager.SaveScene(scene, scenePath);
        AssetDatabase.Refresh();

        EditorUtility.DisplayDialog("Adventure", "2D Scene created: Assets/Scenes/Scene_2D.unity", "OK");
    }
}

// Small helper behavior for the example chest
public class ChestBehavior : MonoBehaviour
{
    void Start() {}
    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player2D>();
        if (player != null)
        {
            var hud = FindObjectOfType<HUD>();
            if (hud != null) hud.ShowMessage("Press E to open the chest");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player2D>();
        if (player != null)
        {
            var hud = FindObjectOfType<HUD>();
            if (hud != null) hud.ShowMessage("");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player2D>();
        if (player != null && Input.GetKeyDown(KeyCode.E))
        {
            var hud = FindObjectOfType<HUD>();
            if (hud != null) hud.ShowMessage("You opened the chest!");
            Debug.Log("Chest opened");
            Destroy(gameObject);
        }
    }
}
#endif
