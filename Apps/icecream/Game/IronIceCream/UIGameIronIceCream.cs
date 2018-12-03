﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LitJson;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameIronIceCream : UIGameIceCream
{
    public UITopFoodToolBar uiTopFoodToolBar;//
    public UIPopSelectBar uiPopSelectBar;
    UITopFoodBar uiTopFoodBarPrefab;
    UITopFoodBar uiTopFoodBar;
    UITopFoodItem uiTopFoodItemPrefab;
    GameIronIceCream gameIronIceCreamPrefab;
    GameIronIceCream gameIronIceCream;

    UITopFoodItem uiCup;//倒液体的杯子
    public Button btnNext;
    void Awake()
    {
        LoadPrefab();

        ParseGuanka();
        AppSceneBase.main.UpdateWorldBg(AppRes.IMAGE_GAME_BG);
        uiPopSelectBar.gameObject.SetActive(false);
        uiTopFoodToolBar.gameObject.SetActive(false);
        //  btnNext.gameObject.SetActive(false);
        UpdateCup(0);
        //ShowFPS();
    }
    // Use this for initialization
    void Start()
    {
        UpdateGuankaLevel(GameManager.gameLevel);
    }
    // Update is called once per frame
    void Update()
    {


    }


    void LoadPrefab()
    {
        base.LoadPrefabBase();


        {
            GameObject obj = (GameObject)Resources.Load("App/Prefab/Game/UITopFoodBar");
            if (obj != null)
            {
                uiTopFoodBarPrefab = obj.GetComponent<UITopFoodBar>();
                uiTopFoodBar = (UITopFoodBar)GameObject.Instantiate(uiTopFoodBarPrefab);
                uiTopFoodBar.callBackDidClick = OnUITopFoodBarDidClick;
                RectTransform rctranPrefab = uiTopFoodBarPrefab.transform as RectTransform;
                //  AppSceneBase.main.AddObjToMainCanvas(uiGameTopBar.gameObject);
                uiTopFoodBar.transform.parent = this.transform;
                RectTransform rctran = uiTopFoodBar.transform as RectTransform;
                // 初始化rect
                rctran.offsetMin = rctranPrefab.offsetMin;
                rctran.offsetMax = rctranPrefab.offsetMax;

            }

        }


        {
            GameObject obj = (GameObject)Resources.Load("App/Prefab/Game/IronIceCream/GameIronIceCream");
            if (obj != null)
            {
                gameIronIceCreamPrefab = obj.GetComponent<GameIronIceCream>();
                gameIronIceCream = (GameIronIceCream)GameObject.Instantiate(gameIronIceCreamPrefab);
                gameIronIceCream.callBackDidUpdateStatus = OnGameIronIceCreamDidUpdateStatus;
                RectTransform rctranPrefab = gameIronIceCreamPrefab.transform as RectTransform;
                gameIronIceCream.transform.parent = GameViewController.main.objController.transform;
                AppSceneBase.main.AddObjToMainWorld(gameIronIceCream.gameObject);
                gameIronIceCream.transform.localPosition = new Vector3(0f, 0f, -1f);
                RectTransform rctran = gameIronIceCream.transform as RectTransform;
                // 初始化rect
                rctran.offsetMin = rctranPrefab.offsetMin;
                rctran.offsetMax = rctranPrefab.offsetMax;

            }

        }
        //cup
        {

            GameObject obj = PrefabCache.main.Load(UITopFoodItem.PREFAB_TopFoodItem);
            uiTopFoodItemPrefab = obj.GetComponent<UITopFoodItem>();
        }
    }

    public override void UpdateGuankaLevel(int level)
    {
        InitUI();
    }

    void UpdateCup(int idx)
    {
        if (uiCup == null)
        {
            uiCup = (UITopFoodItem)GameObject.Instantiate(uiTopFoodItemPrefab);
            uiCup.transform.parent = this.transform;
            uiCup.transform.localScale = new Vector3(1, 1, 1);
            uiCup.transform.localPosition = new Vector3(0, 0, 0);
            uiCup.callBackDidClick = OnUITopFoodItemDidClick;
            uiCup.gameObject.SetActive(false);
            uiCup.width = 320;
            uiCup.height = uiCup.width;
            uiCup.enableLock = false;
            RectTransform rctran = uiCup.GetComponent<RectTransform>();
            rctran.sizeDelta = new Vector2(uiCup.width, uiCup.height);
        }

        uiCup.index = idx;
        uiCup.UpdateItem();
        uiCup.ShowHand(true, true);

    }
    void InitUI()
    {

        gameIronIceCream.RunSetp(0);
        LayOut();


        OnUIDidFinish();
    }


    public override void LayOut()
    {
        float x = 0, y = 0, z = 0, w = 0, h = 0;
        float scalex = 0, scaley = 0, scale = 0;
        Vector2 sizeCanvas = AppSceneBase.main.sizeCanvas;


    }


    ColorItemInfo GetItemInfo()
    {
        int idx = GameManager.gameLevel;
        if (listGuanka == null)
        {
            return null;
        }
        if (idx >= listGuanka.Count)
        {
            return null;
        }
        ColorItemInfo info = listGuanka[idx] as ColorItemInfo;
        return info;
    }

    public override int GetGuankaTotal()
    {
        ParseGuanka();
        if (listGuanka != null)
        {
            return listGuanka.Count;
        }
        return 0;
    }

    public override void CleanGuankaList()
    {
        if (listGuanka != null)
        {
            listGuanka.Clear();
        }
    }

    public override int ParseGuanka()
    {
        int count = 0;

        if ((listGuanka != null) && (listGuanka.Count != 0))
        {
            return listGuanka.Count;
        }

        listGuanka = new List<object>();
        int idx = GameManager.placeLevel;
        string fileName = Common.GAME_RES_DIR + "/guanka/guanka_list" + idx + ".json";
        //FILE_PATH
        string json = FileUtil.ReadStringAsset(fileName);//((TextAsset)Resources.Load(fileName, typeof(TextAsset))).text;
        // Debug.Log("json::"+json);
        JsonData root = JsonMapper.ToObject(json);
        string strPlace = (string)root["place"];
        JsonData items = root["list"];
        for (int i = 0; i < items.Count; i++)
        {
            JsonData item = items[i];
            ColorItemInfo info = new ColorItemInfo();
            string strdir = Common.GAME_RES_DIR + "/image/" + strPlace;

            info.id = (string)item["id"];
            info.pic = strdir + "/draw/" + info.id + ".png";

            info.picmask = strdir + "/mask/" + info.id + ".png";
            info.colorJson = strdir + "/json/" + info.id + ".json";
            info.icon = strdir + "/thumb/" + info.id + ".png";

            //info.pic = info.picmask;

            // string filepath = GetFileSave(info);
            // info.fileSave = filepath;

            // string picname = (i + 1).ToString("d3");
            // info.pic = Common.GAME_RES_DIR + "/animal/draw/" + picname + ".png";
            // info.picmask = Common.GAME_RES_DIR + "/animal/mask/" + picname + ".png";
            // info.colorJson = Common.GAME_RES_DIR + "/animal/draw/" + picname + ".json";
            // info.icon = Common.GAME_RES_DIR + "/animal/thumb/" + picname + ".png";

            listGuanka.Add(info);
        }

        count = listGuanka.Count;

        // Debug.Log("ParseGame::count=" + count);
        return count;
    }

    public void OnGameIronIceCreamDidUpdateStatus(UIView ui, int status)
    {
        if (status == IronIceCreamStepBase.STATUS_Liquid_Finish)
        {
            if (gameIronIceCream.indexStep == GameIronIceCream.INDEX_STEP_CHAO)
            {
                uiCup.gameObject.SetActive(false);
            }
        }

        if (status == IronIceCreamStepBase.STATUS_STEP_END)
        {
            btnNext.gameObject.SetActive(true);
        }
    }
    public void OnUITopFoodBarDidClick(UITopFoodBar bar, UITopFoodItem item)
    {
        if (gameIronIceCream.indexStep == GameIronIceCream.INDEX_STEP_CHAO)
        {
            if (GameIronIceCream.status == IronIceCreamStepBase.STATUS_STEP_NONE)
            {
                UpdateCup(item.index);
                uiCup.transform.localRotation = Quaternion.Euler(0, 0, 0);
                uiCup.gameObject.SetActive(true);
                gameIronIceCream.ResetStep();
            }

        }
        if (gameIronIceCream.indexStep == GameIronIceCream.INDEX_STEP_WAN)
        {
            gameIronIceCream.OnUITopFoodItemDidClick(item);
        }
        if (gameIronIceCream.indexStep == GameIronIceCream.INDEX_STEP_ZHUANG)
        {
            uiPopSelectBar.UpdateItem();
        }
    }

    public void OnUIPopSelectBarDidClick(UIPopSelectBar bar, UITopFoodItem item)
    {
        if (gameIronIceCream.indexStep == GameIronIceCream.INDEX_STEP_ZHUANG)
        {
            gameIronIceCream.OnUITopFoodItemDidClick(item);
        }
    }

    public void OnUITopFoodItemDidClick(UITopFoodItem item)
    {
        Debug.Log("OnUITopFoodItemDidClick gameIronIceCream.indexStep=" + gameIronIceCream.indexStep);
        if (gameIronIceCream.indexStep == GameIronIceCream.INDEX_STEP_CHAO)
        {
            uiCup.transform.localRotation = Quaternion.Euler(0, 0, -45);
            uiCup.ShowHand(false, false);
            gameIronIceCream.OnUITopFoodItemDidClick(item);
        }

    }

    void DoBtnBack()
    {
        base.OnClickBtnBack();

    }

    public override void OnClickBtnBack()
    {
        DoBtnBack();
    }

    void OnUIViewAlertFinished(UIViewAlert alert, bool isYes)

    {

        // if (STR_KEYNAME_VIEWALERT_SAVE == alert.keyName)
        // {
        //     if (isYes)
        //     {
        //         DoBtnSave();
        //     }
        // }

    }

    void DoClickBtnStrawAlert()
    {
        // if (AppVersion.appCheckHasFinished && !Application.isEditor)
        // {
        //     if (isFirstUseStraw)
        //     {
        //         //show ad video
        //         AdKitCommon.main.ShowAdVideo();
        //     }
        //     else
        //     {
        //         DoClickBtnStraw();
        //     }
        // }
        // else
        // {
        //     DoClickBtnStraw();
        // }
    }

    public void OnClickBtnNext()
    {
        // btnNext.gameObject.SetActive(false);
        gameIronIceCream.OnNextStep();
        uiTopFoodBar.type = UITopFoodItem.Type.CUP;

        uiPopSelectBar.gameObject.SetActive(false);
        uiTopFoodToolBar.gameObject.SetActive(false);
        uiTopFoodBar.gameObject.SetActive(true);

        if (gameIronIceCream.indexStep == GameIronIceCream.INDEX_STEP_WAN)
        {
            uiTopFoodBar.type = UITopFoodItem.Type.WAN;
        }
        if (gameIronIceCream.indexStep == GameIronIceCream.INDEX_STEP_ZHUANG)
        {
            uiTopFoodBar.type = UITopFoodItem.Type.FOOD;
            uiPopSelectBar.gameObject.SetActive(true);
            uiTopFoodToolBar.gameObject.SetActive(true);
            UIPopSelectBar.indexFoodSort = 0;
            UIPopSelectBar.countFoodSort = IronIceCreamStepBase.countTopFoodSort[0];
            uiPopSelectBar.UpdateItem();
            UITopFoodItem item = uiPopSelectBar.GetItem(0);
            if (item != null)
            {
                // item.UpdateItem();
                OnUIPopSelectBarDidClick(uiPopSelectBar, item);
            }

        }

        if (gameIronIceCream.indexStep == GameIronIceCream.INDEX_STEP_CHI)
        {
            uiTopFoodBar.gameObject.SetActive(false);
        }

        uiTopFoodBar.UpdateType(uiTopFoodBar.type);
    }



    public override void AdVideoDidFail(string str)
    {
        ShowAdVideoFailAlert();
    }

    public override void AdVideoDidStart(string str)
    {

    }
    public override void AdVideoDidFinish(string str)
    {

    }
}
