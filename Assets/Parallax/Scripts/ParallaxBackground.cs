using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [Header("Background Components")]
    [SerializeField] private GameObject[] backgrounds;

    [Space]
    [Header("Trigger")]
    [Tooltip("This object sends backgrounds to the movePosition")]
    [SerializeField] private GameObject frameDetection;
    [Tooltip("Backgrounds will reset to this value along the X value")]
    public float movePosition;
        
    [SerializeField] private float[] speed;

    private void Update()
    {
        AllBackgrounds();
    }

    private void MoveBackground(Transform background, float speed)
    {
        Vector3 moveDirectionOne = new Vector3(-21f - background.position.x, 0, 0).normalized;
        
        background.position += speed * Time.deltaTime * moveDirectionOne;   
    }

    private void AllBackgrounds()
    {
        // Selects prefab from Array [number] , the transform, then the speed arraay [number]
        MoveBackground(backgrounds[0].transform, speed[0]);
        MoveBackground(backgrounds[1].transform, speed[0]);
        MoveBackground(backgrounds[2].transform, speed[1]);
        MoveBackground(backgrounds[3].transform, speed[1]);
        MoveBackground(backgrounds[4].transform, speed[2]);
        MoveBackground(backgrounds[5].transform, speed[2]);
        MoveBackground(backgrounds[6].transform, speed[3]);
        MoveBackground(backgrounds[7].transform, speed[3]);
        MoveBackground(backgrounds[8].transform, speed[4]);
        MoveBackground(backgrounds[9].transform, speed[5]);
        MoveBackground(backgrounds[10].transform, speed[6]);
        MoveBackground(backgrounds[11].transform, speed[7]);
        MoveBackground(backgrounds[12].transform, speed[7]);
    }

}
