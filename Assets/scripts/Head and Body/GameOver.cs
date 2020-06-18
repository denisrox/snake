using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) //обработка коллизии с объектов
    {
        //!ПРИ СПАВНЕ ИЗ ХВОСТА ТЕПЕРЬ ТАКАЯ РЕАЛИЗАЦИЯ НЕ ПОДХОДИТ!
        //проверяем, объект, в который мы врезались имеет ли тэг "Body" и так же
        //проверяем, не является ли это первое тело, которое идёт за головой
        //т.к. эта тело всегда контактирует с головой
        if (other.gameObject.tag == "Body" )//&& other.gameObject.GetComponent<BodyLogic>().target!=gameObject)
        {
            GameOverFunc();                     
        }        
    }
    private void GameOverFunc()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/menu");
        //gameObject.GetComponent<HeadControl>().movementSpeed = 0;
        //Time.timeScale = 0.5f;
        //Time.fixedDeltaTime = Time.timeScale * 0.02f;    
        //transform.parent.GetComponent<HeadControl>().movementSpeed = 0; //Не ставить отрицательное значение (из-за moveDirection в HeadControl полетит вверх)
        //transform.parent.GetComponent<HeadControl>().transform.Rotate(UnityEngine.Random.value,UnityEngine.Random.value,0); 
    }
}
