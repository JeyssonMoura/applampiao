using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dados {

    public int respostaSN, codigo;
    public string motivo;

    public Dados(int codigo, int respostaSN, string motivo)
    {
        this.codigo = codigo;
        this.respostaSN = respostaSN;
        this.motivo = motivo;
    }

}