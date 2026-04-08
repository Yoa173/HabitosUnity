using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Habito
{
    public string nombreHabito;
    public int puntos;
    public bool completado;

    public Habito()
    {
        
    }
    public Habito(string nombreHabito, int puntos)
    {
        this.nombreHabito = nombreHabito;
        this.puntos = puntos;
        this.completado = false;
        
    }

}
