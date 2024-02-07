using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Create/PlayItem", fileName = "playItem")]
public class PlayItem : ScriptableObject
{
    [SerializeField] PlayFaseManager.Fase setNextFase;
    [SerializeField] JoyconInput.NextFaseKeyButton setNextFaseKeyButton;
    [SerializeField] bool setIsCursor;
    [SerializeField] bool setIsLoad;
    [SerializeField] string setLoadName;
    [SerializeField] Vector2 setCursorPos;
    public PlayFaseManager.Fase nextFase { get => setNextFase; }
    public JoyconInput.NextFaseKeyButton nextFaseKeyButton { get => setNextFaseKeyButton; }
    public bool isCursor { get => setIsCursor; }
    public bool isLoad { get => setIsLoad; }
    public string loadName { get => setLoadName; }
    public Vector2 cursorPos { get => setCursorPos; }
}
