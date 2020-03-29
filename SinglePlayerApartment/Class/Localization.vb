Imports System.Runtime.CompilerServices
Imports GTA
Imports GTA.Native

Module Localization

    Public langFile As String = $"scripts\SinglePlayerApartment\Languages\{Game.Language.ToString}.cfg"

    Public ExitApt, SellApt, EnterGarage, AptOptions, Garage, GrgOptions, GrgRemove, GrgRemoveAndDrive, GrgMove, GrgSell, GrgSelectVeh, GrgTooHot, GrgPlate, GrgRename, GrgTransfer, _Mechanic, _Pegasus, ChooseApt As String
    Public ModernStyle, MoodyStyle, VibrantStyle, SharpStyle, MonochromeStyle, SeductiveStyle, RegalStyle, AquaStyle, ChooseVeh, ChooseVehDesc, ReturnVeh, AptStyle, _Phone, PegasusDeliver, PegasusDelete, CannotStore As String
    Public GrgFull, MechanicBill, EnterElevator, ExitGarage, ManageGarage, Maze, Fleeca, BOL, ForSale, PropPurchased, InsFundApartment, EnterApartment, SaveGame, ExitApartment, ChangeClothes, _EnterGarage As String
    Public Insurance1, Insurance2, Insurance3, Insurance4, MorsMutual, _Apartment, _Michael, _Franklin, _Trevor As String

    Public BennysOriginal, DockTease, ElitasTravel, LegendaryMotorsport, PedalToMetal, SouthernSA, WarstockCache, YourNew, InsFundVehicle As String

    Public _Bong, _Whiskey, _Wine, _Wheat, _Shower, _TVOn, _TVOff, _RadioSwitchStation, _TVChannel As String

    Public __Clothing, __Outfits, __FullSuit, __SuitJacket, __SuitPants, __Glasses, __SuitVest, __Suits, __SportsShades, __StreetShades As String
    Public __Hoodies, __Jackets, __Pants, __PoloShirts, __Shoes, __Shirts, __TShirts, __Shorts, __TankTops, __Tops, __SuitJacketbuttoned As String
    Public __Ties, __Earrings, __Hats, __CapsForward, __CapsBackward, __SmartShoes, __Vests, __OpenShirts, __CasualJackets, __Chains As String

    Public _Clothing, _Outfits, _FullSuit, _SuitJacket, _SuitPants, _Glasses, _SuitVest, _Suits, _SportsShades, _StreetShades As String
    Public _Hoodies, _Jackets, _Pants, _PoloShirts, _Shoes, _Shirts, _TShirts, _Shorts, _TankTops, _Tops, _SuitJacketbuttoned As String
    Public _Ties, _Earrings, _Hats, _CapsForward, _CapsBackward, _SmartShoes, _Vests, _OpenShirts, _CasualJackets, _Chains As String
    Public TranslateCompleted As Boolean = False

    Public Sub Translate()

        _Apartment = Game.GetGXTEntry("CELL_2630")
        ExitApt = Game.GetGXTEntry("MP_PROP_MENU2D")
        SellApt = ReadCfgValue("SellApt", langFile)
        EnterGarage = Game.GetGXTEntry("MP_PROP_GOGAR")
        AptOptions = Game.GetGXTEntry("MP_PROP_GEN1")
        Garage = $" {Game.GetGXTEntry("MP_PROP_GEN2B").ToLower.UppercaseFirstLetter}"
        GrgOptions = Game.GetGXTEntry("MP_MAN_VEH0").ToUpper
        GrgRemove = Game.GetGXTEntry("FMMC_REMVEH")
        GrgRemoveAndDrive = ReadCfgValue("GrgRemoveAndDrive", langFile)
        GrgMove = Game.GetGXTEntry("MP_MAN_VEH5")
        GrgSell = Game.GetGXTEntry("CMOD_SEL_0")
        GrgSelectVeh = Game.GetGXTEntry("MP_MAN_VEH3")
        GrgTooHot = Game.GetGXTEntry("collision_9ws2ssi").Replace("~z~", "")
        GrgPlate = Game.GetGXTEntry("CMOD_MOD_18_D").Replace(".", "")
        GrgRename = ReadCfgValue("GrgRename", langFile)
        GrgTransfer = ReadCfgValue("GrgTransfer", langFile)
        _Mechanic = Game.GetGXTEntry("CELL_180") 'CM_LABME1
        _Pegasus = Game.GetGXTEntry("OF_PA_MENUI_9")
        ChooseApt = Game.GetGXTEntry("MP_PROP_GEN2A")
        ModernStyle = Game.GetGXTEntry("PM_APT_VAR_0")
        MoodyStyle = Game.GetGXTEntry("PM_APT_VAR_1")
        VibrantStyle = Game.GetGXTEntry("PM_APT_VAR_2")
        SharpStyle = Game.GetGXTEntry("PM_APT_VAR_3")
        MonochromeStyle = Game.GetGXTEntry("PM_APT_VAR_4")
        SeductiveStyle = Game.GetGXTEntry("PM_APT_VAR_5")
        RegalStyle = Game.GetGXTEntry("PM_APT_VAR_6")
        AquaStyle = Game.GetGXTEntry("PM_APT_VAR_7")
        ChooseVeh = Game.GetGXTEntry("MPCT_PERVEH1")
        ChooseVehDesc = Game.GetGXTEntry("MPCT_PERVEHC")
        ReturnVeh = Game.GetGXTEntry("PIM_HSRET")
        AptStyle = Game.GetGXTEntry("PM_APT_TVARIANT")
        _Phone = Game.GetGXTEntry("INPUT_CELLPHONE_OPTION").ToUpper
        PegasusDeliver = Game.GetGXTEntry("MPCT_PERVEHC").Replace("?", "")
        PegasusDelete = Game.GetGXTEntry("FMMC_REMVEH")
        CannotStore = Game.GetGXTEntry("MP_PROP_IVD_VEH")
        GrgFull = Game.GetGXTEntry("CUST_GAR_FULL")
        MechanicBill = Game.GetGXTEntry("MP_PROP_MECH").Replace("~1~", "100")
        EnterElevator = Game.GetGXTEntry("MATC_DPADRIGHT")
        ExitGarage = Game.GetGXTEntry("TREA1_EXIT")
        ManageGarage = Game.GetGXTEntry("MP_MAN_VEH")
        Maze = Game.GetGXTEntry("EMSTR_52")
        Fleeca = Game.GetGXTEntry("EMSTR_55")
        BOL = Game.GetGXTEntry("EMSTR_58")
        ForSale = Game.GetGXTEntry("BLIP_373")
        PropPurchased = Game.GetGXTEntry("PROPR_PURCHASED")
        InsFundApartment = Game.GetGXTEntry("PI_BIK_HX8")
        EnterApartment = Game.GetGXTEntry("MATC_DPADRIGHT")
        SaveGame = Game.GetGXTEntry("SA_BED_IN")
        ExitApartment = Game.GetGXTEntry("TREA1_EXIT")
        ChangeClothes = Game.GetGXTEntry("WARD_TRIG").Replace("~a~", "~INPUT_CONTEXT~")
        _EnterGarage = Game.GetGXTEntry("MATC_DPADRIGHT")
        Insurance1 = Game.GetGXTEntry("collision_9ueydas")
        Insurance2 = Game.GetGXTEntry("collision_6gv8lu6")
        Insurance3 = Game.GetGXTEntry("collision_1s5wts")
        Insurance4 = Game.GetGXTEntry("collision_9yhz94a")
        MorsMutual = Game.GetGXTEntry("CELL_E_275")

        BennysOriginal = Game.GetGXTEntry("CMM_MOD_BOMT")
        DockTease = Game.GetGXTEntry("EMSTR_87")
        ElitasTravel = Game.GetGXTEntry("ELT_NAME")
        LegendaryMotorsport = Game.GetGXTEntry("EMSTR_80")
        PedalToMetal = Game.GetGXTEntry("EMSTR_467")
        SouthernSA = Game.GetGXTEntry("SSS_NAME")
        WarstockCache = Game.GetGXTEntry("CELL_E_273")
        YourNew = Game.GetGXTEntry("TXT_VEH_GARN")
        InsFundVehicle = Game.GetGXTEntry("PI_BIK_HX8")

        _Bong = Game.GetGXTEntry("SA_BONG2")
        _Whiskey = Game.GetGXTEntry("SA_WHSKY")
        _Wine = Game.GetGXTEntry("SA_WINE")
        _Shower = Game.GetGXTEntry("SA_SHWR_IN")
        _TVOn = Game.GetGXTEntry("TV_HLP1")
        _RadioSwitchStation = $"{Game.GetGXTEntry("MPRD_CTXT")}~n~{Game.GetGXTEntry("AM_H_RADIO1")}"
        _TVChannel = Game.GetGXTEntry("TV_HLP5").Replace("~INPUT_SCRIPT_RUP~", "~INPUT_VEH_RADIO_WHEEL~")

        _Michael = Game.GetGXTEntry("MICHAEL")
        _Franklin = Game.GetGXTEntry("PIM_FRANK") 'BLIP_211    EMSTR_6     BLIP_FRANKLIN       BLIP_210    CELL_103    CM_STOFRA    A3B_FRANK
        _Trevor = Game.GetGXTEntry("TREVOR")

        __Clothing = Game.GetGXTEntry("CSHOP_TITLE1")
        __Outfits = Game.GetGXTEntry("CSHOP_TITLE36")
        __FullSuit = Game.GetGXTEntry("CSHOP_TITLE125")
        __SuitJacket = Game.GetGXTEntry("CSHOP_TITLE46")
        __SuitPants = Game.GetGXTEntry("CSHOP_TITLE47")
        __Glasses = Game.GetGXTEntry("CSHOP_TITLE42")
        __SuitVest = Game.GetGXTEntry("CSHOP_TITLE50")
        __Suits = Game.GetGXTEntry("CSHOP_TITLE49")
        __SportsShades = Game.GetGXTEntry("CSHOP_TITLE70")
        __StreetShades = Game.GetGXTEntry("CSHOP_TITLE71")

        __Hoodies = Game.GetGXTEntry("CSHOP_TITLE5")
        __Jackets = Game.GetGXTEntry("CSHOP_TITLE2")
        __Pants = Game.GetGXTEntry("CSHOP_TITLE38")
        __PoloShirts = Game.GetGXTEntry("CSHOP_TITLE8")
        __Shoes = Game.GetGXTEntry("CSHOP_TITLE39")
        __Shirts = Game.GetGXTEntry("CSHOP_TITLE4")
        __TShirts = Game.GetGXTEntry("CSHOP_TITLE3")
        __Shorts = Game.GetGXTEntry("CSHOP_TITLE51")
        __TankTops = Game.GetGXTEntry("CSHOP_TITLE6")
        __Tops = Game.GetGXTEntry("CSHOP_TITLE37")
        __SuitJacketbuttoned = Game.GetGXTEntry("CSHOP_TITLE126")

        __Ties = Game.GetGXTEntry("CSHOP_TITLE81")
        __Earrings = Game.GetGXTEntry("CSHOP_TITLE74")
        __Hats = Game.GetGXTEntry("CSHOP_TITLE40")
        __CapsForward = Game.GetGXTEntry("CSHOP_TITLE131")
        __CapsBackward = Game.GetGXTEntry("CSHOP_TITLE132")
        __SmartShoes = Game.GetGXTEntry("CSHOP_TITLE48")
        __Vests = Game.GetGXTEntry("CSHOP_TITLE82")
        __OpenShirts = Game.GetGXTEntry("CSHOP_TITLE72")
        __CasualJackets = Game.GetGXTEntry("CSHOP_TITLE79")
        __Chains = Game.GetGXTEntry("CSHOP_TITLE115")

        _Clothing = Game.GetGXTEntry("CSHOP_ITEM1")
        _Outfits = Game.GetGXTEntry("CSHOP_ITEM36")
        _FullSuit = Game.GetGXTEntry("CSHOP_ITEM125")
        _SuitJacket = Game.GetGXTEntry("CSHOP_ITEM46")
        _SuitPants = Game.GetGXTEntry("CSHOP_ITEM47")
        _Glasses = Game.GetGXTEntry("CSHOP_ITEM42")
        _SuitVest = Game.GetGXTEntry("CSHOP_ITEM50")
        _Suits = Game.GetGXTEntry("CSHOP_ITEM49")
        _SportsShades = Game.GetGXTEntry("CSHOP_ITEM70")
        _StreetShades = Game.GetGXTEntry("CSHOP_ITEM71")

        _Hoodies = Game.GetGXTEntry("CSHOP_ITEM5")
        _Jackets = Game.GetGXTEntry("CSHOP_ITEM2")
        _Pants = Game.GetGXTEntry("CSHOP_ITEM38")
        _PoloShirts = Game.GetGXTEntry("CSHOP_ITEM8")
        _Shoes = Game.GetGXTEntry("CSHOP_ITEM39")
        _Shirts = Game.GetGXTEntry("CSHOP_ITEM4")
        _TShirts = Game.GetGXTEntry("CSHOP_ITEM3")
        _Shorts = Game.GetGXTEntry("CSHOP_ITEM51")
        _TankTops = Game.GetGXTEntry("CSHOP_ITEM6")
        _Tops = Game.GetGXTEntry("CSHOP_ITEM37")
        _SuitJacketbuttoned = Game.GetGXTEntry("CSHOP_ITEM126")

        _Ties = Game.GetGXTEntry("CSHOP_ITEM81")
        _Earrings = Game.GetGXTEntry("CSHOP_ITEM74")
        _Hats = Game.GetGXTEntry("CSHOP_ITEM40")
        _CapsForward = Game.GetGXTEntry("CSHOP_ITEM131")
        _CapsBackward = Game.GetGXTEntry("CSHOP_ITEM132")
        _SmartShoes = Game.GetGXTEntry("CSHOP_ITEM48")
        _Vests = Game.GetGXTEntry("CSHOP_ITEM82")
        _OpenShirts = Game.GetGXTEntry("CSHOP_ITEM72")
        _CasualJackets = Game.GetGXTEntry("CSHOP_ITEM79")
        _Chains = Game.GetGXTEntry("CSHOP_ITEM115")

        TranslateCompleted = True
    End Sub

    Public Sub TranslateClothes()
        If RequestAdditionTextFile() Then
            __Clothing = Game.GetGXTEntry("CSHOP_TITLE1")
            __Outfits = Game.GetGXTEntry("CSHOP_TITLE36")
            __FullSuit = Game.GetGXTEntry("CSHOP_TITLE125")
            __SuitJacket = Game.GetGXTEntry("CSHOP_TITLE46")
            __SuitPants = Game.GetGXTEntry("CSHOP_TITLE47")
            __Glasses = Game.GetGXTEntry("CSHOP_TITLE42")
            __SuitVest = Game.GetGXTEntry("CSHOP_TITLE50")
            __Suits = Game.GetGXTEntry("CSHOP_TITLE49")
            __SportsShades = Game.GetGXTEntry("CSHOP_TITLE70")
            __StreetShades = Game.GetGXTEntry("CSHOP_TITLE71")

            __Hoodies = Game.GetGXTEntry("CSHOP_TITLE5")
            __Jackets = Game.GetGXTEntry("CSHOP_TITLE2")
            __Pants = Game.GetGXTEntry("CSHOP_TITLE38")
            __PoloShirts = Game.GetGXTEntry("CSHOP_TITLE8")
            __Shoes = Game.GetGXTEntry("CSHOP_TITLE39")
            __Shirts = Game.GetGXTEntry("CSHOP_TITLE4")
            __TShirts = Game.GetGXTEntry("CSHOP_TITLE3")
            __Shorts = Game.GetGXTEntry("CSHOP_TITLE51")
            __TankTops = Game.GetGXTEntry("CSHOP_TITLE6")
            __Tops = Game.GetGXTEntry("CSHOP_TITLE37")
            __SuitJacketbuttoned = Game.GetGXTEntry("CSHOP_TITLE126")

            __Ties = Game.GetGXTEntry("CSHOP_TITLE81")
            __Earrings = Game.GetGXTEntry("CSHOP_TITLE74")
            __Hats = Game.GetGXTEntry("CSHOP_TITLE40")
            __CapsForward = Game.GetGXTEntry("CSHOP_TITLE131")
            __CapsBackward = Game.GetGXTEntry("CSHOP_TITLE132")
            __SmartShoes = Game.GetGXTEntry("CSHOP_TITLE48")
            __Vests = Game.GetGXTEntry("CSHOP_TITLE82")
            __OpenShirts = Game.GetGXTEntry("CSHOP_TITLE72")
            __CasualJackets = Game.GetGXTEntry("CSHOP_TITLE79")
            __Chains = Game.GetGXTEntry("CSHOP_TITLE115")

            _Clothing = Game.GetGXTEntry("CSHOP_ITEM1")
            _Outfits = Game.GetGXTEntry("CSHOP_ITEM36")
            _FullSuit = Game.GetGXTEntry("CSHOP_ITEM125")
            _SuitJacket = Game.GetGXTEntry("CSHOP_ITEM46")
            _SuitPants = Game.GetGXTEntry("CSHOP_ITEM47")
            _Glasses = Game.GetGXTEntry("CSHOP_ITEM42")
            _SuitVest = Game.GetGXTEntry("CSHOP_ITEM50")
            _Suits = Game.GetGXTEntry("CSHOP_ITEM49")
            _SportsShades = Game.GetGXTEntry("CSHOP_ITEM70")
            _StreetShades = Game.GetGXTEntry("CSHOP_ITEM71")

            _Hoodies = Game.GetGXTEntry("CSHOP_ITEM5")
            _Jackets = Game.GetGXTEntry("CSHOP_ITEM2")
            _Pants = Game.GetGXTEntry("CSHOP_ITEM38")
            _PoloShirts = Game.GetGXTEntry("CSHOP_ITEM8")
            _Shoes = Game.GetGXTEntry("CSHOP_ITEM39")
            _Shirts = Game.GetGXTEntry("CSHOP_ITEM4")
            _TShirts = Game.GetGXTEntry("CSHOP_ITEM3")
            _Shorts = Game.GetGXTEntry("CSHOP_ITEM51")
            _TankTops = Game.GetGXTEntry("CSHOP_ITEM6")
            _Tops = Game.GetGXTEntry("CSHOP_ITEM37")
            _SuitJacketbuttoned = Game.GetGXTEntry("CSHOP_ITEM126")

            _Ties = Game.GetGXTEntry("CSHOP_ITEM81")
            _Earrings = Game.GetGXTEntry("CSHOP_ITEM74")
            _Hats = Game.GetGXTEntry("CSHOP_ITEM40")
            _CapsForward = Game.GetGXTEntry("CSHOP_ITEM131")
            _CapsBackward = Game.GetGXTEntry("CSHOP_ITEM132")
            _SmartShoes = Game.GetGXTEntry("CSHOP_ITEM48")
            _Vests = Game.GetGXTEntry("CSHOP_ITEM82")
            _OpenShirts = Game.GetGXTEntry("CSHOP_ITEM72")
            _CasualJackets = Game.GetGXTEntry("CSHOP_ITEM79")
            _Chains = Game.GetGXTEntry("CSHOP_ITEM115")
        End If
    End Sub

    Public Function EnterApartmentHelp(ApartmentName As String) As String
        Dim helpText As String = Nothing
        Dim t As Char = EnterApartment.Last
        Dim EnterApartmen As String = EnterApartment.Substring(0, EnterApartment.Length - 1)
        Select Case Game.Language
            Case Language.American, Language.French, Language.German, Language.Italian, Language.Mexican, Language.Polish, Language.Portuguese, Language.Russian, Language.Spanish
                helpText = $"{EnterApartmen} {ApartmentName}{t}"
            Case Else
                helpText = $"{EnterApartmen}{ApartmentName}{t}"
        End Select
        Return helpText
    End Function

    Public Function ExitApartmentHelp(ApartmentName As String) As String
        Dim helpText As String = Nothing
        Dim t As Char = ExitApartment.Last
        Dim ExitApartmen As String = ExitApartment.Substring(0, ExitApartment.Length - 1)
        Select Case Game.Language
            Case Language.American, Language.French, Language.German, Language.Italian, Language.Mexican, Language.Polish, Language.Portuguese, Language.Russian, Language.Spanish
                helpText = $"{ExitApartmen} {ApartmentName}{t}"
            Case Else
                helpText = $"{ExitApartmen}{ApartmentName}{t}"
        End Select
        Return helpText
    End Function

    <Extension()>
    Public Function UppercaseFirstLetter(ByVal val As String) As String
        If String.IsNullOrEmpty(val) Then Return val
        Dim array() As Char = val.ToCharArray
        array(0) = Char.ToUpper(array(0))
        Return New String(array)
    End Function

    Public Function RequestAdditionTextFile(ByVal Optional timeout As Integer = 1000) As Boolean
        If Not Native.Function.Call(Of Boolean)(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, "clo_mnu", 9) Then
            Native.Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, 9, True)
            Native.Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, "clo_mnu", 9)
            Dim [end] As Integer = Game.GameTime + timeout

            If True Then
                While Game.GameTime < [end]
                    If Native.Function.Call(Of Boolean)(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, "clo_mnu", 9) Then Return True
                    Script.Yield()
                End While
                Return False
            End If
        End If

        Return True
    End Function

End Module
