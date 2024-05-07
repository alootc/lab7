using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public SaveMusic save_music;

    public AudioClip GetMusicRoom()
    {
        return save_music.music_room;

    }
}
