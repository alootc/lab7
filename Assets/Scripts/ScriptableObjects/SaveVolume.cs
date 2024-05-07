using UnityEngine;

[CreateAssetMenu(fileName = "save_volume", menuName = "Save volume")]
public class SaveVolume : ScriptableObject
{
    public float master_volumen;
    public float music_volume;
    public float sfx_volume;
}
