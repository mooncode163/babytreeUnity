
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppRes
{
    public const int GOLD_SHARE = 5;
    public const int GOLD_GUANKA = 3;
    public const int GOLD_COMMENT = 3;
    public const int GOLD_INIT_VALUE = 50;
    public const int GOLD_GUANKA_STEP = 4;

    public const int GOLD_CONSUME = 3;//消费

    public const string KEY_UNLOCK_PROP = "KEY_UNLOCK_PROP";//解锁道具数量
    //game name
    public const string GAME_IronIceCream = "IronIceCream";
    //color
    //f88816 248,136,22
    static public Color colorTitle = new Color(248 / 255f, 136 / 255f, 22 / 255f);

    //audio 
    public const string AUDIO_BTN_CLICK = "App/Audio/BtnClick";
    public const string AUDIO_PINTU_BLOCK_FINISH = "Audio/PintuBlockFinish";
    public const string AUDIO_WORD_OK = "App/Audio/word_ok";
    public const string AUDIO_WORD_FAIL = "App/Audio/word-failed";
    public const string AUDIO_LETTER_DRAG_1 = "App/Audio/letter-drag-1";
    public const string AUDIO_LETTER_DRAG_2 = "App/Audio/letter-drag-2";
    public const string AUDIO_LETTER_DRAG_3 = "App/Audio/letter-drag-3";
    public const string AUDIO_LETTER_DRAG_4 = "App/Audio/letter-drag-4";
    public const string AUDIO_SELECT = "App/Audio/select";
    public const string AUDIO_SUCCESS_1 = "App/Audio/success-1";
    public const string AUDIO_SUCCESS_2 = "App/Audio/success-2";


    //prefab  

    public const string PREFAB_GUANKA_CELL_ITEM = "App/Prefab/Guanka/UIGuankaCellItem";
    public const string PREFAB_CmdItem = "App/Prefab/CmdItem/UICmdItem";
    public const string PREFAB_SETTING = "App/Prefab/Setting/UISettingController";
    public const string PREFAB_MOREAPP_CELL_ITEM = "App/Prefab/MoreApp/UIMoreAppCellItem";

    //image
    public const string IMAGE_MOREAPP_BG = "App/UI/Setting/SettingBg";
    public const string IMAGE_UIVIEWALERT_BG_BOARD = "App/UI/Setting/SettingCellBgBlue";
    static public Vector4 borderUIViewAlertBgBoard = new Vector4(18f, 18f, 18f, 18f);
    public const string IMAGE_UIVIEWALERT_BG_BTN = "App/UI/Setting/SettingCellBgOringe";
    static public Vector4 borderUIViewAlertBgBtn = new Vector4(18f, 18f, 18f, 18);

    //trophy
    public const string IMAGE_ROOT_DIR_TROPHY = "App/UI/Game/Trophy";
    public const string IMAGE_TROPHY_CELL_BG = IMAGE_ROOT_DIR_TROPHY + "/CellBg";
    public const string IMAGE_TROPHY_BG1 = IMAGE_ROOT_DIR_TROPHY + "/Bg1";
    public const string IMAGE_TROPHY_BG2 = IMAGE_ROOT_DIR_TROPHY + "/Bg2";
    public const string IMAGE_TROPHY_Crown = IMAGE_ROOT_DIR_TROPHY + "/Crown";
    public const string IMAGE_TROPHY_Crown_small = IMAGE_ROOT_DIR_TROPHY + "/Crown_small";
    public const string IMAGE_TROPHY_ImageTitle_cn = IMAGE_ROOT_DIR_TROPHY + "/ImageTitle_cn";
    public const string IMAGE_TROPHY_ImageTitle_en = IMAGE_ROOT_DIR_TROPHY + "/ImageTitle_en";
    public const string IMAGE_TROPHY_ImageTips_cn = IMAGE_ROOT_DIR_TROPHY + "/ImageDetail_cn";
    public const string IMAGE_TROPHY_ImageTips_en = IMAGE_ROOT_DIR_TROPHY + "/ImageDetail_en";

    public const string IMAGE_TROPHY_Rotation_PREFIX = IMAGE_ROOT_DIR_TROPHY + "/Rotation/01_000";
    public const string IMAGE_TROPHY_LEVEL_PREFIX = IMAGE_ROOT_DIR_TROPHY + "/Level/";
    public const string IMAGE_TROPHY_Flower_PREFIX = IMAGE_ROOT_DIR_TROPHY + "/Flower/";
    public const string IMAGE_TROPHY_Star_PREFIX = IMAGE_ROOT_DIR_TROPHY + "/Star/";
    public const string IMAGE_TROPHY_Medal_PREFIX = IMAGE_ROOT_DIR_TROPHY + "/Medal/";
    public const string IMAGE_TROPHY_Cup_PREFIX = IMAGE_ROOT_DIR_TROPHY + "/Cup/";

    public const string IMAGE_HOME_BG = Common.GAME_DATA_DIR + "/startup.jpg";

    public const string IMAGE_GUANKA_BG = "App/UI/Guanka/GuankaBg";
    public const string IMAGE_GUANKA_ITEM_DOT0 = "App/UI/Guanka/dot0";
    public const string IMAGE_GUANKA_ITEM_DOT1 = "App/UI/Guanka/dot1";
    public const string IMAGE_GUANKA_CELL_BG = "App/UI/Guanka/guanka_cell_bg";
    public const string IMAGE_GUANKA_CELL_BG_LOCK = "App/UI/Guanka/guanka_cell_bg_lock";


    public const string IMAGE_COMMON_BG = "App/UI/Guanka/GuankaBg";
    public const string IMAGE_CELL_BG_BLUE = "App/UI/Setting/SettingCellBgBlue";
    public const string IMAGE_CELL_BG_ORINGE = "App/UI/Setting/SettingCellBgOringe";
    public const string IMAGE_CELL_BG_YELLOW = "App/UI/Setting/SettingCellBgYellow";
    static public Vector4 borderCellSettingBg = new Vector4(18f, 18f, 18f, 18f);

    public const string IMAGE_GAME_BG = IMAGE_HOME_BG;

    public const string IMAGE_HAND = "App/UI/Game/hand";


    //string 
    public const string SOURCE_NAVI_GUANKA = "SOURCE_NAVI_GUANKA";
    public const string SOURCE_NAVI_HISTORY = "SOURCE_NAVI_HISTORY";


}
