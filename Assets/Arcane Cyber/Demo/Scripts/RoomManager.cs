using UnityEngine;


public sealed class RoomManager : MonoBehaviour {
    
    private GameObject[] rooms;
    private int activeRoom = 0;

    private void Awake() {
        rooms = new GameObject[transform.childCount];
        for (int i = 0; i < rooms.Length; i++)
            rooms[i] = transform.GetChild(i).gameObject;

        if (rooms.Length != 0)
            Debug.Log(rooms.Length + " room initialized");
        else
            Debug.LogError("Critical error! There is no attached room.");
    }

    private void Start() {
        ChangeRoom(0);
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            NextRoom();
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            PreviousRoom();
    }

    public void NextRoom() {
        if (activeRoom != rooms.Length - 1)
            ChangeRoom(activeRoom + 1);
        else
            ChangeRoom(0);
    }

    public void PreviousRoom() {
        if (activeRoom > 0)
            ChangeRoom(activeRoom - 1);
        else
            ChangeRoom(rooms.Length - 1);
    }

    private void ChangeRoom(int roomID) {
        activeRoom = roomID;

        for (int i = 0; i < rooms.Length; i++) {
            if (i == roomID)
                rooms[i].SetActive(true);
            else
                rooms[i].SetActive(false);
        }
    }

}