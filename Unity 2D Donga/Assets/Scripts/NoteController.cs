using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    // Start is called before the first frame update
    //하나의 노트에 대한 정보를 담는 노트 클래스를 정의
    class Note
    {
        public int noteType { get; set; }
        public int order { get; set; }
        public Note(int noteType, int order)
        {
            this.noteType = noteType;
            this.order = order;
        }
    }
    public GameObject[] Notes;

    private ObjectFooler noteObjectPooler;
    private List<Note> notes = new List<Note>();
    private float x, z, startY = 8.0f; //무조건 노트가 맨 위에서 떨어진다.
    private float beatInterval = 1.0f; //노트간의 시간 간격       
     
    void MakeNote(Note note)
    {
        GameObject obj = noteObjectPooler.getObject(note.noteType);
        //설정된 시작 라인으로 노트를 이동시킵니다.
        x = obj.transform.position.x;
        z = obj.transform.position.z;
        obj.transform.position = new Vector3(x, startY, z);
        obj.GetComponent<NotesBehaviour>().Initialize();
        obj.SetActive(true);
    }
    IEnumerator AwaitMakeNote(Note note)
    {
        int noteType = note.noteType;
        int order = note.order;
        yield return new WaitForSeconds(order * beatInterval);
        MakeNote(note);
    }

    void Start()
    {
        noteObjectPooler = gameObject.GetComponent<ObjectFooler>();
        notes.Add(new Note(1, 1));
        notes.Add(new Note(2, 2));
        notes.Add(new Note(3, 3));
        notes.Add(new Note(4, 4));
        notes.Add(new Note(1, 5));
        notes.Add(new Note(2, 6));
        notes.Add(new Note(3, 7));
        notes.Add(new Note(4, 8));
        //모든 노트를 정해진 시간에 출발하도록 설정
        for(int i=0; i<notes.Count; i++)
        {
            StartCoroutine(AwaitMakeNote(notes[i]));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
