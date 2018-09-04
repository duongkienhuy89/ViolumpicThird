using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {
    
    public tk2dUIItem btnPlay; 
    public tk2dUIItem btnRank;
    public tk2dUIItem btnBuyVip;
    public tk2dUIItem btnShare;
    public tk2dUIItem btnRate;

    void btnShare_OnClick()
    {
        ShareRate.Share();
        SoundManager.Instance.PlayAudioChoitiep();
    }

    void btnRate_OnClick()
    {
        ShareRate.Rate();
        SoundManager.Instance.PlayAudioChoitiep();
    }



    void btnBuyVip_OnClick()
    {
        PopUpController.instance.ShowBuyItem();
        PopUpController.instance.HideMainGame();
        SoundManager.Instance.PlayAudioChoitiep();
    }

    void btnRank_OnClick()
    {

        SoundManager.Instance.PlayAudioChoitiep();
        if (GameController.instance.vuotqua > 5)
        {
            SceneManager.LoadScene("Rank");
        }
        else
        {
            PopUpController.instance.HideMainGame();
            PopUpController.instance.ShowAdTriger();
        }
    }


    void btnPlay_OnClick()
    {
        PopUpController.instance.HideMainGame();
        PopUpController.instance.ShowLevel();
        SoundManager.Instance.PlayAudioChoitiep();

    }

    public void setData()
    {
        if (GameController.instance.vuotqua > 5)
        {
            btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doXepHang();
        }
        else
        {
            btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doQuangCao();
        }
    }

	// Use this for initialization
	void Start () {
        btnRank.OnClick += btnRank_OnClick;
        btnPlay.OnClick += btnPlay_OnClick;
        btnBuyVip.OnClick += btnBuyVip_OnClick;
        btnShare.OnClick += btnShare_OnClick;
        btnRate.OnClick += btnRate_OnClick;
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doVaoThi();      
        btnBuyVip.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doMuaVip();
        setData();
       
        if (GameController.instance.checkvip == 10)
        {
            btnBuyVip.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
