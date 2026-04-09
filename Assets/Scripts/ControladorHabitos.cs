using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorHabitos : MonoBehaviour
{

public List<Habito> listaHabitos = new List<Habito>();

public TMP_InputField Input_habito;
public TMP_InputField Input_puntos;
public GameObject CasillaHabito;
public Transform Content;
string ruta;


    public void Awake()
    {
        ruta = Application.persistentDataPath + "/habitos.json";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        CargarJson();
        
        foreach (Habito h in listaHabitos){
            Debug.Log($"Hábito: {h.nombreHabito}, puntos: {h.puntos}, completado:{h.completado}");
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AgregarHabito()
    {
        
        
        int.TryParse(Input_puntos.text, out int puntos);

        if (Input_habito.text !="" && puntos != 0)
        {
            Habito habito = new Habito(Input_habito.text, puntos);
            listaHabitos.Add(habito);
            Debug.Log($"Añadido hábito \"{Input_habito.text}\", puntos: {puntos}");

            GameObject casilla = Instantiate(CasillaHabito, Content);
            casilla.GetComponentsInChildren<TMP_Text>()[0].text=Input_habito.text;
            casilla.GetComponentsInChildren<TMP_Text>()[1].text=$"+{puntos.ToString()}";
            GuardarEnJson();

         
            
            Input_habito.text ="";
            Input_puntos.text = "";
        }
    }

    public void GuardarEnJson()
{
    //Creamos una lista para enviar y le metemos la list ya creada.
    listadoHabitos lista = new listadoHabitos();
    lista.listadoJson = listaHabitos;
    //Convertir lista a Json
    String textoJson = JsonUtility.ToJson(lista);
    //EScribir texto en archivo
    System.IO.File.WriteAllText(ruta,textoJson);

    Debug.Log("Json Actualizado");
    
}

public void CargarJson()
    {
        if (System.IO.File.Exists(ruta))
        {
            string textoJson =System.IO.File.ReadAllText(ruta);
            listadoHabitos datosCargados = JsonUtility.FromJson<listadoHabitos>(textoJson);
            listaHabitos = datosCargados.listadoJson;

            foreach(Habito h in listaHabitos)
            {   GameObject casilla = Instantiate(CasillaHabito, Content);            
                casilla.GetComponentsInChildren<TMP_Text>()[0].text = h.nombreHabito;
                casilla.GetComponentsInChildren<TMP_Text>()[1].text = $"+{h.puntos}";
            }
        }
    }

    
}

//Clase auxiliar para el JSON
[System.Serializable]
public class listadoHabitos
{
    public List <Habito> listadoJson;
}


