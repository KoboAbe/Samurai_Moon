using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour
{

    public TextMeshProUGUI storyScript;
    public TextMeshProUGUI buttonText;

    public int storyIndex;

// ---------------------------------------------------------------------------------------------
    void Start()
    {   
        storyIndex = 0;
        storyScript.text = "Hace muchos años el imperio Japones gobernaba todo el mundo,vivian en paz y armonía hasta que una raza extraña avanzada (Los Tori) llego del universo para conquistar el planeta, los samurai lucharon fervientemente para proteger su hogar"; 

    }

// ---------------------------------------------------------------------------------------------
    void Update()
    {
        if (storyIndex == 1){
            storyScript.text = "aunque hubo muchos muertos, los samurai lograron defender la tierra, y desde ese entonces reinaba la tranquilidad, trabajaron en armonía, construyeron alianzas y el camino parecía prometedor… hasta ahora."; 
        }else if (storyIndex == 2){
            storyScript.text = "Sin embargo Los Tori no se quedarían asi, años después de aquella batalla, los Tori regresarían a la tierra en busca de venganza, saquearon aldeas, destruyeron ciudades hasta acabar con cada uno de los samuráis."; 
        }else if (storyIndex == 3){
            storyScript.text = "En su paso por la tierra, los Tori robaron la armadura la cual representaba la victoria del pasado y con ella se llevarían el recuerdo de aquella victoria de los humanos. "; 
        }else if (storyIndex == 4){
            storyScript.text = "Seiten, un samurai veterano que estaba de excursión en las montañas, llega a su hogar, donde lo esperaba su esposa e hijos, pero al entrar a la aldea se encuentra con una escena que no querrá recordar nunca. "; 
        }else if (storyIndex == 5){
            storyScript.text = "Esta es la historia de Seiten, el samurai que viajo a la luna en busca de venganza."; 
            buttonText.text = "Continuar";
        }else if (storyIndex == 6){
            SceneManager.LoadScene(1);  
        }else if (storyIndex == 7){
            
        }
    }
// ---------------------------------------------------------------------------------------------
    public void storyUpdate(){
        storyIndex++;
    }
// ---------------------------------------------------------------------------------------------
// ---------------------------------------------------------------------------------------------

}
