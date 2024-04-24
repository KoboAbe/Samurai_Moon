using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextAnimation : MonoBehaviour
{
    /* public Animator _animator; */
    private int levelToLoad;

    [SerializeField] TextMeshProUGUI textAnimation;
    [SerializeField] TextMeshProUGUI textButton;
    
    public FadeScript fadeScript;

    public string [] stringArray;

    int i = 0;
    int j = 1;
// ---------------------------------------------------------------------------------------------
    void Start()
    {
        fadeScript = FindObjectOfType<FadeScript>();
        
        stringArray [0] = "Hace muchos años el imperio Japones gobernaba todo el mundo,vivian en paz y armonía hasta que una raza extraña avanzada (Los Tori) llego del universo para conquistar el planeta, los samurai lucharon fervientemente para proteger su hogar";
        stringArray [1] = "aunque hubo muchos muertos, los samurai lograron defender la tierra, y desde ese entonces reinaba la tranquilidad, trabajaron en armonía, construyeron alianzas y el camino parecía prometedor… hasta ahora.";
        stringArray [2] = "Sin embargo Los Tori no se quedarían asi, años después de aquella batalla, los Tori regresarían a la tierra en busca de venganza, saquearon aldeas, destruyeron ciudades hasta acabar con cada uno de los samuráis.";
        stringArray [3] = "En su paso por la tierra, los Tori robaron la armadura la cual representaba la victoria del pasado y con ella se llevarían el recuerdo de aquella victoria de los humanos.";
        stringArray [4] = "Seiten, un samurai veterano que estaba de excursión en las montañas, llega a su hogar, donde lo esperaba su esposa e hijos, pero al entrar a la aldea se encuentra con una escena que no querrá recordar nunca.";
        stringArray [5] = "Esta es la historia de Seiten, el samurai que viajo a la luna en busca de venganza.";

        Endchek();
    }
// ---------------------------------------------------------------------------------------------
    public void Endchek(){
        if ( i <= stringArray.Length - 1 ){
            textAnimation.text = stringArray[ i ];

            StartCoroutine (TextVisible());
            
        }
    }
// ---------------------------------------------------------------------------------------------
    void Update(){

        Debug.Log (j);
        if ( j == 6){
            textButton.text = "Continuar";
        }
        if ( j == 7){
            fadeScript.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    } 
// ---------------------------------------------------------------------------------------------
    public void NextLine (){
        j++;
    }
// ---------------------------------------------------------------------------------------------
    private IEnumerator TextVisible(){

        textAnimation.ForceMeshUpdate();
        
        int textCount = textAnimation.textInfo.characterCount;
        int counter = 0;

        while (true){
            int visibleCount = counter % (textCount + 1);
            textAnimation.maxVisibleCharacters = visibleCount;

            if (visibleCount >= textCount){
                i ++;
                // Invoke ("Endchek", 0.5f);
                break;
            }
            counter += 1;

            yield return new WaitForSeconds (.02f);
        }
    }
// ---------------------------------------------------------------------------------------------
/*     public void FadeToNextLevel(int levelIndex){
        levelToLoad = levelIndex;
        _animator.SetTrigger("Fade_out");
    } */
// ---------------------------------------------------------------------------------------------
/*     public void fadeCompleted(){  
        SceneManager.LoadScene(1);
    } */
// ---------------------------------------------------------------------------------------------

}
