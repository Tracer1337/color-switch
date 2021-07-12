using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerColor : MonoBehaviour
{
    [System.Serializable]
    public class CustomColor
    {
        public Color color;
        public string tag;
    }
    
    public CustomColor[] colors;

    private SpriteRenderer sr;
    [HideInInspector]
    public CustomColor activeColor;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void PickRandomColor()
    {
        var prevColor = activeColor;
        while (prevColor == activeColor)
        {
            activeColor = colors[Random.Range(0, colors.Length)];
        }
        sr.color = activeColor.color;
    }
}
