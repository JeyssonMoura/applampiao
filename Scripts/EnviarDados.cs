using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnviarDados : MonoBehaviour
{
    //Aux
    private HUD AuxHUD;
    private Dados dados;
    private VerificaCodigo AuxVerificaCodigo;

    private int respostaSN;
    private string motivo;

    void Start()
    {
        AuxHUD = GameObject.Find("Canvas_HUD").GetComponent<HUD>();
        AuxVerificaCodigo = GameObject.FindGameObjectWithTag("VCodigo").GetComponent<VerificaCodigo>();
    }

    public void setRespostaSN(int _respostaSN)
    {
        respostaSN = _respostaSN;
    }

    public int getRespostaSN()
    {
        return respostaSN;
    }

    public void setMotivo(string _motivo)
    {
        motivo = _motivo;
    }

    public string getMotivo()
    {
        return motivo;
    }

    public void GerarJson()
    {
        if (AuxHUD.ctMotivo.text != "")
        {
            setMotivo(AuxHUD.ctMotivo.text);
            dados = new Dados(AuxVerificaCodigo.getCodigo(), getRespostaSN(), getMotivo());
            string passarDados = JsonUtility.ToJson(dados);
            print(passarDados);
            AuxHUD.abrirBoxAvisos(passarDados, 2);
            AuxHUD.boxForm.GetComponent<Canvas>().enabled = false;
            AuxHUD.boxForm.GetComponent<GraphicRaycaster>().enabled = false;
        } else
        {
            AuxHUD.abrirBoxAvisos("Preencha todos os campos.", 1);
        }
    }
}
