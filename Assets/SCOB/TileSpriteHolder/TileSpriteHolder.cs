using UnityEngine;


[CreateAssetMenu(fileName = "TileSpriteType", menuName = "ScriptableObjects/TileSpriteTypeHolder")]
public class TileSpriteHolder : ScriptableObject
{
    [SerializeField] private Sprite[] upLeft;
    [SerializeField] private Sprite[] up;
    [SerializeField] private Sprite[] midLeft;
    [SerializeField] private Sprite[] mid;
    [SerializeField] private Sprite[] downLeft;
    [SerializeField] private Sprite[] down;
    
    

    public Sprite GetRandom(Sprite[] part)
    {
        var rand = Random.Range(0, part.Length + 1);
        return part[rand];
    }


    public Sprite[] UpLeft => upLeft;
    public Sprite[] Up => up;
    public Sprite[] MidLeft => midLeft;
    public Sprite[] Mid => mid;
    public Sprite[] DownLeft => downLeft;
    public Sprite[] DpLeft => down;
}