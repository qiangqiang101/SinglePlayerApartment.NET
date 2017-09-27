Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports INMNativeUI

Public Class Wardrobe
    Inherits Script

    Public Shared WardrobeVector As Vector3
    Public Shared WardrobeDistance As Single
    Public Shared DrawSpotLight As Boolean = False
    Public Shared WardrobeCam As Camera
    Public Shared WardrobeHead As Single
    Public Shared WardrobeScriptStatus As Integer = -1

    Public Shared Player0W, Player1W, Player2W, Player3_MW, Player3_FW As UIMenu
    Public Shared Outfit0, Suit0, FullSuit0, SuitJackets0, SuitPants0, SuitVests0, CasualJackets0, CasualJacketJackets0 As UIMenu
    Public Shared Outfit1, Suit1, FullSuit1, SuitJackets1, SuitJackersButtoned1, SuitPants1, SuitVests1, Ties1, CasualJackets1, CasualJacketJackets1 As UIMenu
    Public Shared Outfit2, Suit2, FullSuit2, SuitJackets2, SuitPants2 As UIMenu
    Public Shared Outfit3M, Earrings3M, Glasses3M, Hats3M, Chains3M As UIMenu
    Public Shared Outfit3F, Earrings3F, Glasses3F, Hats3F, Chains3F As UIMenu
    Public Shared CasualJacketTShirt0, Glasses0, SportsShades0, StreetShades0, Hoodies0, Jackets0, Pants0 As UIMenu
    Public Shared CasualJacketTShirt1, Earrings1, Glasses1, SportsShades1, StreetShades1, Hats1, CapsForward1, CapsBackward1, Hoodies1, Jackets1, Pants1 As UIMenu
    Public Shared Glasses2, SportsShades2, StreetShades2, CapsForward2, Hoodies2, Jackets2, Pants2 As UIMenu
    Public Shared Shoes0, Shirt0, Shorts0, TShirt0, TankTops0, Tops0, Glass0, PoloShirt0 As UIMenu
    Public Shared Shoes1, Shirt1, Shorts1, SmartShoes1, TShirt1, TankTops1, Tops1, Vest1 As UIMenu
    Public Shared Shoes2, Shirt2, Shorts2, SmartShoes2, TShirt2, TankTops2, Tops2, PoloShirt2 As UIMenu

    Public Shared _Outfits As New UIMenuItem("Outfits")
    Public Shared _Suits As New UIMenuItem("Suits")
    Public Shared _FullSuits As New UIMenuItem("Full Suits")
    Public Shared _SuitJackets As New UIMenuItem("Suit Jackets")
    Public Shared _SuitJacketsButtoned As New UIMenuItem("Suit Jackets, Buttoned")
    Public Shared _SuitPants As New UIMenuItem("Suit Pants")
    Public Shared _SuitVests As New UIMenuItem("Suit Vests")
    Public Shared _SuitTies As New UIMenuItem("Ties")
    Public Shared _CasualJackets As New UIMenuItem("Casual Jackets")
    Public Shared _OpenShirts As New UIMenuItem("Open Shirts")
    Public Shared _CasualJacketJackets As New UIMenuItem("Jackets")
    Public Shared _CasualJacketShirts As New UIMenuItem("Shirts")
    Public Shared _CasualJacketTShirts As New UIMenuItem("T-Shirts")
    Public Shared _Earrings As New UIMenuItem("Earrings")
    Public Shared _Glasses As New UIMenuItem("Glasses")
    Public Shared _Glass As New UIMenuItem("Glasses")
    Public Shared _SportsShades As New UIMenuItem("Sports Shades")
    Public Shared _StreetShades As New UIMenuItem("Street Shades")
    Public Shared _Hats As New UIMenuItem("Hats")
    Public Shared _HatsTrevor As New UIMenuItem("Hats")
    Public Shared _CapsForward As New UIMenuItem("Fitted Caps, Forward")
    Public Shared _CapsBackward As New UIMenuItem("Fitted Caps, Backward")
    Public Shared _Hoodies As New UIMenuItem("Hoodies")
    Public Shared _Jackets As New UIMenuItem("Jackets")
    Public Shared _Pants As New UIMenuItem("Pants")
    Public Shared _Shoes As New UIMenuItem("Shoes")
    Public Shared _Shirt As New UIMenuItem("Shirts")
    Public Shared _Shorts As New UIMenuItem("Shorts")
    Public Shared _SmartShoes As New UIMenuItem("Smart Shoes")
    Public Shared _TShirt As New UIMenuItem("T-Shirts")
    Public Shared _TankTops As New UIMenuItem("Tank Tops")
    Public Shared _Tops As New UIMenuItem("Tops")
    Public Shared _Vests As New UIMenuItem("Vests")
    Public Shared _PoloShirt As New UIMenuItem("Polo Shirt")
    Public Shared _Chains As New UIMenuItem("Chains")

    Public Shared _DrawSpotlight As New InstructionalButton(GTA.Control.Jump, "Spotlight")

    Public Shared FOutfits As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\outfits.cfg"
    Public Shared MOutfits As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\outfits.cfg"
    Public Shared TOutfits As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\outfits.cfg"
    Public Shared PMOutfits As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_M\outfits.cfg"
    Public Shared PFOutfits As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_F\outfits.cfg"
    Public Shared FFullSuits As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\fullsuits.cfg"
    Public Shared MFullSuits As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\fullsuits.cfg"
    Public Shared TFullSuits As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\fullsuits.cfg"
    Public Shared FSuitJackets As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\suitjackets.cfg"
    Public Shared MSuitJackets As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\suitjackets.cfg"
    Public Shared TSuitJackets As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\suitjackets.cfg"
    Public Shared FSuitJacketsButtoned As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\suitjacketsbuttoned.cfg"
    Public Shared FSuitPants As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\suitpants.cfg"
    Public Shared MSuitPants As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\suitpants.cfg"
    Public Shared TSuitPants As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\suitpants.cfg"
    Public Shared FSuitVests As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\suitvests.cfg"
    Public Shared MSuitVests As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\suitvests.cfg"
    Public Shared FTies As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\suitties.cfg"
    Public Shared FCasualJackets As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\casualjackets.cfg"
    Public Shared MCasualJackets As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\casualjackets.cfg"
    Public Shared FCasualTShirts As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\casualtshirts.cfg"
    Public Shared MCasualTShirts As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\casualtshirts.cfg"
    Public Shared FEarrings As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\earrings.cfg"
    Public Shared PMEarrings As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_M\earrings.cfg"
    Public Shared PFEarrings As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_F\earrings.cfg"
    Public Shared FSportsShades As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\sportsshades.cfg"
    Public Shared MSportsShades As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\sportsshades.cfg"
    Public Shared TSportsShades As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\sportsshades.cfg"
    Public Shared FStreetShades As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\streetshades.cfg"
    Public Shared MStreetShades As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\streetshades.cfg"
    Public Shared TStreetShades As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\streetshades.cfg"
    Public Shared FCapsForward As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\capsforward.cfg"
    Public Shared TCapsForward As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\capsforward.cfg"
    Public Shared FCapsBackward As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\capsbackward.cfg"
    Public Shared FHoodies As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\hoodies.cfg"
    Public Shared MHoodies As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\hoodies.cfg"
    Public Shared THoodies As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\hoodies.cfg"
    Public Shared FJackets As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\jackets.cfg"
    Public Shared MJackets As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\jackets.cfg"
    Public Shared TJackets As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\jackets.cfg"
    Public Shared FPants As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\pants.cfg"
    Public Shared MPants As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\pants.cfg"
    Public Shared TPants As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\pants.cfg"
    Public Shared FShoes As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\shoes.cfg"
    Public Shared MShoes As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\shoes.cfg"
    Public Shared TShoes As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\shoes.cfg"
    Public Shared FShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\shirt.cfg"
    Public Shared MShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\shirt.cfg"
    Public Shared TShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\shirt.cfg"
    Public Shared FShorts As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\shorts.cfg"
    Public Shared MShorts As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\shorts.cfg"
    Public Shared TShorts As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\shorts.cfg"
    Public Shared FSmartShoes As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\smartshoes.cfg"
    Public Shared TSmartShoes As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\smartshoes.cfg"
    Public Shared FTShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\tshirt.cfg"
    Public Shared MTShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\tshirt.cfg"
    Public Shared TTShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\tshirt.cfg"
    Public Shared FTankTops As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\tanktops.cfg"
    Public Shared MTankTops As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\tanktops.cfg"
    Public Shared TTankTops As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\tanktops.cfg"
    Public Shared FTops As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\tops.cfg"
    Public Shared MTops As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\tops.cfg"
    Public Shared TTops As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\tops.cfg"
    Public Shared FVests As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\vests.cfg"
    Public Shared MGlass As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\glasses.cfg"
    Public Shared PMGlass As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_M\glasses.cfg"
    Public Shared PFGlass As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_F\glasses.cfg"
    Public Shared MPoloShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\polo.cfg"
    Public Shared TPoloShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\polo.cfg"
    Public Shared PMHats As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_M\hats.cfg"
    Public Shared PFHats As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_F\hats.cfg"
    Public Shared PMChains As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_M\chains.cfg"
    Public Shared PFChains As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Player3_F\chains.cfg"

    Public Shared OutfitsParameters As String() = {"[name]", "[set1]", "[set2]"}
    Public Shared FullSuitsParameters As String() = {"[name]", "[set1]", "[set2]"}
    Public Shared SuitJacketsParameters As String() = {"[name]", "[set1]"}

    Public Shared _menuPool As MenuPool

    'Translate
    Public Shared __Clothing, __Outfits, __FullSuit, __SuitJacket, __SuitPants, __Glasses, __SuitVest, __Suits, __SportsShades, __StreetShades As String
    Public Shared __Hoodies, __Jackets, __Pants, __PoloShirts, __Shoes, __Shirts, __TShirts, __Shorts, __TankTops, __Tops, __SuitJacketbuttoned As String
    Public Shared __Ties, __Earrings, __Hats, __CapsForward, __CapsBackward, __SmartShoes, __Vests, __OpenShirts, __CasualJackets, __Chains As String

    Enum PedComponentsVars
        COMPONET_FACE = 0
        COMPONET_HEAD = 1
        COMPONET_HAIR = 2
        COMPONET_TORSO = 3
        COMPONET_LEGS = 4
        COMPONET_HANDS = 5
        COMPONET_FEET = 6
        COMPONET_EYES = 7
        COMPONET_ACCESSORIES = 8
        COMPONET_TASKS = 9
        COMPONET_TEXTURES = 10
        COMPONET_TORSO2 = 11
    End Enum

    Enum PedPropsVars
        PROP_HATS = 0
        PROP_GLASSES = 1
        PROP_EARS = 2
    End Enum

    Public Sub New()
        Try
            Translate()

            _menuPool = New MenuPool()

            'Michael Menu
            CreateMichaelWardrobe()
            ReadOutfit(Outfit0, "~b~" & __Outfits, Player0W, _Outfits, MOutfits)
            ReadSuitMichael()
            ReadFullSuit(FullSuit0, "~b~" & __FullSuit, Suit0, _FullSuits, MFullSuits)
            ReadJacket(SuitJackets0, "~b~" & __SuitJacket, Suit0, _SuitJackets, MSuitJackets)
            ReadPants(SuitPants0, "~b~" & __SuitPants, Suit0, _SuitPants, MSuitPants)
            ReadSuitVest(SuitVests0, "~b~" & __SuitVest, Suit0, _SuitVests, MSuitVests)
            ReadGlassesMichael()
            ReadShades(Glass0, "~b~" & __Glasses, Glasses0, _Glass, MGlass)
            ReadShades(SportsShades0, "~b~" & __SportsShades, Glasses0, _SportsShades, MSportsShades)
            ReadShades(StreetShades0, "~b~" & __StreetShades, Glasses0, _StreetShades, MStreetShades)
            ReadUpperbody(Hoodies0, "~b~" & __Hoodies, Player0W, _Hoodies, MHoodies)
            ReadUpperbody(Jackets0, "~b~" & __Jackets, Player0W, _Jackets, MJackets)
            ReadPants(Pants0, "~b~" & __Pants, Player0W, _Pants, MPants)
            ReadUpperbody(PoloShirt0, "~b~" & __PoloShirts, Player0W, _PoloShirt, MPoloShirt)
            ReadShoes(Shoes0, "~b~" & __Shoes, Player0W, _Shoes, MShoes)
            ReadCasualJacketMichael() 'Open Shirts
            ReadCasualJacketJacket(CasualJacketJackets0, "~b~" & __Shirts, CasualJackets0, _CasualJacketShirts, MCasualJackets)
            ReadCasualJacketTShirt(CasualJacketTShirt0, "~b~" & __TShirts, CasualJackets0, _CasualJacketTShirts, MCasualTShirts)
            ReadUpperbody(Shirt0, "~b~" & __Shirts, Player0W, _Shirt, MShirt)
            ReadPantsWithShoes(Shorts0, "~b~" & __Shorts, Player0W, _Shorts, MShorts)
            ReadUpperbody(TShirt0, "~b~" & __TShirts, Player0W, _TShirt, MTShirt)
            ReadUpperbody(TankTops0, "~b~" & __TankTops, Player0W, _TankTops, MTankTops)
            ReadUpperbody(Tops0, "~b~" & __Tops, Player0W, _Tops, MTops)

            'Franklin Menu
            CreateFranklinWardrobe()
            ReadOutfit(Outfit1, "~g~" & __Outfits, Player1W, _Outfits, FOutfits)
            ReadSuitFranklin()
            ReadFullSuit(FullSuit1, "~g~" & __FullSuit, Suit1, _FullSuits, FFullSuits)
            ReadJacket(SuitJackets1, "~g~" & __SuitJacket, Suit1, _SuitJackets, FSuitJackets)
            ReadJacket(SuitJackersButtoned1, "~g~" & __SuitJacketbuttoned, Suit1, _SuitJacketsButtoned, FSuitJacketsButtoned)
            ReadPants(SuitPants1, "~g~" & __SuitPants, Suit1, _SuitPants, FSuitPants)
            ReadSuitVest(SuitVests1, "~g~" & __SuitVest, Suit1, _SuitVests, FSuitVests)
            ReadSuitTie(Ties1, "~g~" & __Ties, Suit1, _SuitTies, FTies)
            ReadCasualJacketFranklin()
            ReadCasualJacketJacket(CasualJacketJackets1, "~g~" & __Jackets, CasualJackets1, _CasualJacketJackets, FCasualJackets)
            ReadCasualJacketTShirt(CasualJacketTShirt1, "~g~" & __TShirts, CasualJackets1, _CasualJacketTShirts, FCasualTShirts)
            ReadEarrings(Earrings1, "~g~" & __Earrings, Player1W, _Earrings, FEarrings)
            ReadGlassesFranklin()
            ReadShades(SportsShades1, "~g~" & __SportsShades, Glasses1, _SportsShades, FSportsShades)
            ReadShades(StreetShades1, "~g~" & __StreetShades, Glasses1, _StreetShades, FStreetShades)
            ReadHatsFranklin()
            ReadCaps(CapsForward1, "~g~" & __CapsForward, Hats1, _CapsForward, FCapsForward)
            ReadCaps(CapsBackward1, "~g~" & __CapsBackward, Hats1, _CapsBackward, FCapsBackward)
            ReadUpperbody(Hoodies1, "~g~" & __Hoodies, Player1W, _Hoodies, FHoodies)
            ReadUpperbody(Jackets1, "~g~" & __Jackets, Player1W, _Jackets, FJackets)
            ReadPants(Pants1, "~g~" & __Pants, Player1W, _Pants, FPants)
            ReadShoes(Shoes1, "~g~" & __Shoes, Player1W, _Shoes, FShoes)
            ReadUpperbody(Shirt1, "~g~" & __Shirts, Player1W, _Shirt, FShirt)
            ReadPants(Shorts1, "~g~" & __Shorts, Player1W, _Shorts, FShorts)
            ReadShoes(SmartShoes1, "~g~" & __SmartShoes, Player1W, _SmartShoes, FSmartShoes)
            ReadUpperbody(TShirt1, "~g~" & __TShirts, Player1W, _TShirt, FTShirt)
            ReadUpperbody(TankTops1, "~g~" & __TankTops, Player1W, _TankTops, FTankTops)
            ReadUpperbody(Tops1, "~g~" & __Tops, Player1W, _Tops, FTops)
            ReadVest(Vest1, "~g~" & __Vests, Player1W, _Vests, FVests)

            'Trevor Menu
            CreateTrevorWardrobe()
            ReadOutfit(Outfit2, "~o~" & __Outfits, Player2W, _Outfits, TOutfits)
            ReadSuitTrevor()
            ReadFullSuit(FullSuit2, "~o~" & __FullSuit, Suit2, _FullSuits, TFullSuits)
            ReadJacket(SuitJackets2, "~o~" & __SuitJacket, Suit2, _SuitJackets, TSuitJackets)
            ReadPants(SuitPants2, "~o~" & __SuitPants, Suit2, _SuitPants, TSuitPants)
            ReadGlassesTrevor()
            ReadShades(SportsShades2, "~o~" & __SportsShades, Glasses2, _SportsShades, TSportsShades)
            ReadShades(StreetShades2, "~o~" & __StreetShades, Glasses2, _StreetShades, TStreetShades)
            ReadCaps(CapsForward2, "~o~" & __Hats, Player2W, _HatsTrevor, TCapsForward)
            ReadUpperbody(Hoodies2, "~o~" & __Hoodies, Player2W, _Hoodies, THoodies)
            ReadUpperbody(Jackets2, "~o~" & __Jackets, Player2W, _Jackets, TJackets)
            ReadPants(Pants2, "~o~" & __Pants, Player2W, _Pants, TPants)
            ReadUpperbody(PoloShirt2, "~o~" & __PoloShirts, Player2W, _PoloShirt, TPoloShirt)
            ReadShoes(Shoes2, "~o~" & __Shoes, Player2W, _Shoes, TShoes)
            ReadUpperbody(Shirt2, "~o~" & __Shirts, Player2W, _Shirt, TShirt)
            ReadPantsWithShoes(Shorts2, "~o~" & __Shorts, Player2W, _Shorts, TShorts)
            ReadShoes(SmartShoes2, "~o~" & __SmartShoes, Player2W, _SmartShoes, TSmartShoes)
            ReadUpperbody(TShirt2, "~o~" & __TShirts, Player2W, _TShirt, TTShirt)
            ReadUpperbody(TankTops2, "~o~" & __TankTops, Player2W, _TankTops, TTankTops)
            ReadUpperbody(Tops2, "~o~" & __Tops, Player2W, _Tops, TTops)

            'Player3 Male Menu
            CreatePlayer3MWardrobe()
            ReadMPOutfit(Outfit3M, "~y~" & __Outfits, Player3_MW, _Outfits, PMOutfits)
            ReadShades(Glasses3M, "~y~" & __Glasses, Player3_MW, _Glass, PMGlass)
            ReadEarrings(Earrings3M, "~y~" & __Earrings, Player3_MW, _Earrings, PMEarrings)
            ReadCaps(Hats3M, "~y~" & __Hats, Player3_MW, _Hats, PMHats)
            ReadChains(Chains3M, "~y~" & __Chains， Player3_MW, _Chains, PMChains)

            'Player3 Female Menu
            CreatePlayer3WWardrobe()
            ReadMPOutfit(Outfit3F, "~y~" & __Outfits, Player3_FW, _Outfits, PFOutfits)
            ReadShades(Glasses3F, "~y~" & __Glasses, Player3_FW, _Glass, PFGlass)
            ReadEarrings(Earrings3F, "~y~" & __Earrings, Player3_FW, _Earrings, PFEarrings)
            ReadCaps(Hats3F, "~y~" & __Hats, Player3_FW, _Hats, PFHats)
            ReadChains(Chains3F, "~y~" & __Chains， Player3_FW, _Chains, PFChains)
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub MakeACamera()
        playerPed.Position = New Vector3(WardrobeVector.X, WardrobeVector.Y, WardrobeVector.Z - 1)
        playerPed.Heading = WardrobeHead
        WardrobeCam = New Camera(1)
        WardrobeCam = World.CreateCamera(playerPed.Position + playerPed.ForwardVector * 4, GameplayCamera.Rotation, 30)
        WardrobeCam.PointAt(playerPed)
        World.RenderingCamera = WardrobeCam
        DrawSpotLight = True
        Dim WardrobeScenario As String
        If ReadCfgValue("WardrobeScenario", settingFile) = "" Then WardrobeScenario = "WORLD_HUMAN_PROSTITUTE_HIGH_CLASS" Else WardrobeScenario = ReadCfgValue("WardrobeScenario", settingFile)
        Native.Function.Call(Hash.TASK_START_SCENARIO_IN_PLACE, playerPed, WardrobeScenario, 0, True)
        hideHud = True
    End Sub

    Public Sub CreateMichaelWardrobe()
        Try
            Player0W = New UIMenu("", "~b~" & __Clothing, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player0W.SetBannerType(Rectangle)
            Player0W.AddInstructionalButton(_DrawSpotlight)
            _menuPool.Add(Player0W)
            Player0W.AddItem(_Outfits)
            Player0W.AddItem(_Suits)
            Player0W.AddItem(_Glasses)
            Player0W.AddItem(_Hoodies)
            Player0W.AddItem(_Jackets)
            Player0W.AddItem(_Pants)
            Player0W.AddItem(_PoloShirt)
            Player0W.AddItem(_Shoes)
            Player0W.AddItem(_OpenShirts)
            Player0W.AddItem(_Shirt)
            Player0W.AddItem(_Shorts)
            Player0W.AddItem(_TShirt)
            Player0W.AddItem(_TankTops)
            Player0W.AddItem(_Tops)
            'Player0W.AddItem(_Masks)
            Player0W.RefreshIndex()
            AddHandler Player0W.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateFranklinWardrobe()
        Try
            Player1W = New UIMenu("", "~g~" & __Clothing, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player1W.SetBannerType(Rectangle)
            Player1W.AddInstructionalButton(_DrawSpotlight)
            _menuPool.Add(Player1W)
            Player1W.AddItem(_Outfits)
            Player1W.AddItem(_Suits)
            Player1W.AddItem(_CasualJackets)
            Player1W.AddItem(_Earrings)
            Player1W.AddItem(_Glasses)
            Player1W.AddItem(_Hats)
            Player1W.AddItem(_Hoodies)
            Player1W.AddItem(_Jackets)
            'Player1W.AddItem(_Masks)
            Player1W.AddItem(_Pants)
            Player1W.AddItem(_Shoes)
            Player1W.AddItem(_Shirt)
            Player1W.AddItem(_Shorts)
            Player1W.AddItem(_SmartShoes)
            Player1W.AddItem(_TShirt)
            Player1W.AddItem(_TankTops)
            Player1W.AddItem(_Tops)
            Player1W.AddItem(_Vests)
            Player1W.RefreshIndex()
            AddHandler Player1W.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateTrevorWardrobe()
        Try
            Player2W = New UIMenu("", "~o~" & __Clothing, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player2W.SetBannerType(Rectangle)
            Player2W.AddInstructionalButton(_DrawSpotlight)
            _menuPool.Add(Player2W)
            Player2W.AddItem(_Outfits)
            Player2W.AddItem(_Suits)
            Player2W.AddItem(_Glasses)
            Player2W.AddItem(_HatsTrevor)
            Player2W.AddItem(_Hoodies)
            Player2W.AddItem(_Jackets)
            Player2W.AddItem(_Pants)
            Player2W.AddItem(_PoloShirt)
            Player2W.AddItem(_Shoes)
            Player2W.AddItem(_Shirt)
            Player2W.AddItem(_Shorts)
            Player2W.AddItem(_SmartShoes)
            Player2W.AddItem(_TShirt)
            Player2W.AddItem(_TankTops)
            Player2W.AddItem(_Tops)
            'Player2W.AddItem(_Masks)
            Player2W.RefreshIndex()
            AddHandler Player2W.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreatePlayer3MWardrobe()
        Try
            Player3_MW = New UIMenu("", "~y~" & __Clothing, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player3_MW.SetBannerType(Rectangle)
            Player3_MW.AddInstructionalButton(_DrawSpotlight)
            _menuPool.Add(Player3_MW)
            Player3_MW.AddItem(_Outfits)
            Player3_MW.AddItem(_Glass)
            Player3_MW.AddItem(_Earrings)
            Player3_MW.AddItem(_Hats)
            Player3_MW.AddItem(_Chains)
            Player3_MW.RefreshIndex()
            AddHandler Player3_MW.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreatePlayer3WWardrobe()
        Try
            Player3_FW = New UIMenu("", "~y~" & __Clothing, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player3_FW.SetBannerType(Rectangle)
            Player3_FW.AddInstructionalButton(_DrawSpotlight)
            _menuPool.Add(Player3_FW)
            Player3_FW.AddItem(_Outfits)
            Player3_FW.AddItem(_Glass)
            Player3_FW.AddItem(_Earrings)
            Player3_FW.AddItem(_Hats)
            Player3_FW.AddItem(_Chains)
            Player3_FW.RefreshIndex()
            AddHandler Player3_FW.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadMPOutfit(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, OutfitsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf MPOutfitIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadOutfit(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, OutfitsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf OutfitIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadUpperbody(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf UpperbodyIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadShoes(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf ShoesIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadChains(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf ChainsIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCaps(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf CapsIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadShades(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf ShadesIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadEarrings(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf EarringIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCasualJacketTShirt(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf CasualTShirtIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitVest(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf SuitVestIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadPantsWithShoes(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf PantswithShoesIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadPants(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf PantsIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCasualJacketJacket(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf CasualJacketIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadJacket(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf SuitJacketIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadVest(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, FullSuitsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf VestIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitTie(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, FullSuitsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf TieIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadFullSuit(MenuCategory As UIMenu, Subtitle As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, FullSuitsParameters)
            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(format(i)("name"))
                MenuCategory.AddItem(item)
                With item
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf FullSuitIndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadHatsFranklin()
        Try
            Hats1 = New UIMenu("", "~g~" & __Hats, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Hats1.SetBannerType(Rectangle)
            _menuPool.Add(Hats1)
            Hats1.AddItem(_CapsForward)
            Hats1.AddItem(_CapsBackward)
            Hats1.RefreshIndex()
            Player1W.BindMenuToItem(Hats1, _Hats)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadGlassesMichael()
        Try
            Glasses0 = New UIMenu("", "~b~" & __Glasses, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Glasses0.SetBannerType(Rectangle)
            _menuPool.Add(Glasses0)
            Glasses0.AddItem(_Glass)
            Glasses0.AddItem(_SportsShades)
            Glasses0.AddItem(_StreetShades)
            Glasses0.RefreshIndex()
            Player0W.BindMenuToItem(Glasses0, _Glasses)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadGlassesFranklin()
        Try
            Glasses1 = New UIMenu("", "~g~" & __Glasses, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Glasses1.SetBannerType(Rectangle)
            _menuPool.Add(Glasses1)
            Glasses1.AddItem(_SportsShades)
            Glasses1.AddItem(_StreetShades)
            Glasses1.RefreshIndex()
            Player1W.BindMenuToItem(Glasses1, _Glasses)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadGlassesTrevor()
        Try
            Glasses2 = New UIMenu("", "~o~" & __Glasses, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Glasses2.SetBannerType(Rectangle)
            _menuPool.Add(Glasses2)
            Glasses2.AddItem(_SportsShades)
            Glasses2.AddItem(_StreetShades)
            Glasses2.RefreshIndex()
            Player2W.BindMenuToItem(Glasses2, _Glasses)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCasualJacketMichael()
        Try
            CasualJackets0 = New UIMenu("", "~b~" & __OpenShirts, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            CasualJackets0.SetBannerType(Rectangle)
            _menuPool.Add(CasualJackets0)
            CasualJackets0.AddItem(_CasualJacketJackets)
            CasualJackets0.AddItem(_CasualJacketTShirts)
            CasualJackets0.RefreshIndex()
            Player0W.BindMenuToItem(CasualJackets0, _OpenShirts)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCasualJacketFranklin()
        Try
            CasualJackets1 = New UIMenu("", "~g~" & __CasualJackets, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            CasualJackets1.SetBannerType(Rectangle)
            _menuPool.Add(CasualJackets1)
            CasualJackets1.AddItem(_CasualJacketJackets)
            CasualJackets1.AddItem(_CasualJacketTShirts)
            CasualJackets1.RefreshIndex()
            Player1W.BindMenuToItem(CasualJackets1, _CasualJackets)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitMichael()
        Try
            Suit0 = New UIMenu("", "~b~" & __Suits, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Suit0.SetBannerType(Rectangle)
            _menuPool.Add(Suit0)
            Suit0.AddItem(_FullSuits)
            Suit0.AddItem(_SuitJackets)
            Suit0.AddItem(_SuitPants)
            Suit0.AddItem(_SuitVests)
            Suit0.RefreshIndex()
            Player0W.BindMenuToItem(Suit0, _Suits)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitFranklin()
        Try
            Suit1 = New UIMenu("", "~g~" & __Suits, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Suit1.SetBannerType(Rectangle)
            _menuPool.Add(Suit1)
            Suit1.AddItem(_FullSuits)
            Suit1.AddItem(_SuitJackets)
            Suit1.AddItem(_SuitJacketsButtoned)
            Suit1.AddItem(_SuitPants)
            Suit1.AddItem(_SuitVests)
            Suit1.AddItem(_SuitTies)
            Suit1.RefreshIndex()
            Player1W.BindMenuToItem(Suit1, _Suits)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitTrevor()
        Try
            Suit2 = New UIMenu("", "~o~" & __Suits, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Suit2.SetBannerType(Rectangle)
            _menuPool.Add(Suit2)
            Suit2.AddItem(_FullSuits)
            Suit2.AddItem(_SuitJackets)
            Suit2.AddItem(_SuitPants)
            Suit2.RefreshIndex()
            Player2W.BindMenuToItem(Suit2, _Suits)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub MenuCloseHandler(sender As UIMenu)
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
        DrawSpotLight = False
        playerPed.Task.ClearAll()
        hideHud = False
        WardrobeScriptStatus = -1
    End Sub

    Public Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        sender.GoBack()
    End Sub

    Public Sub UpperbodyIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            If GetPlayerName() = "Franklin" Then
                Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
                Dim d3 As Integer = Set1(1).Trim
                Dim t3 As Integer = Set1(2).Trim

                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, 14, 0, 2) 'Acc
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, 0, 0, 2) 'Vest
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, 0, 0, 2) 'Logo
            Else
                Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
                Dim d3 As Integer = Set1(1).Trim
                Dim t3 As Integer = Set1(2).Trim

                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, 0, 0, 2) 'Acc
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, 0, 0, 2) 'Vest
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, 0, 0, 2) 'Logo
            End If

        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ShoesIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim d6 As Integer = Set1(1).Trim
            Dim t6 As Integer = Set1(2).Trim

            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, d6, t6, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CapsIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim d0 As Integer = Set1(1).Trim
            Dim t0 As Integer = Set1(2).Trim

            If d0 = -1 Then
                Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 0)
            Else
                Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 0, d0, t0, 2)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ChainsIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim d7 As Integer = Set1(1).Trim
            Dim t7 As Integer = Set1(2).Trim

            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 7, d7, t7, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ShadesIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim d1 As Integer = Set1(1).Trim
            Dim t1 As Integer = Set1(2).Trim

            If d1 = -1 Then
                Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 1)
            Else
                Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 1, d1, t1, 2)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub EarringIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim d2 As Integer = Set1(1).Trim
            Dim t2 As Integer = Set1(2).Trim

            If d2 = -1 Then
                Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 2)
            Else
                Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 2, d2, t2, 2)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CasualTShirtIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim d11 As Integer = Set1(1).Trim
            Dim t11 As Integer = Set1(2).Trim

            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11, t11, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub SuitVestIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            If GetPlayerName() = "Franklin" Then
                Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
                Dim d11 As Integer = Set1(1).Trim
                Dim t11 As Integer = Set1(2).Trim

                Dim d3 As Integer = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, 3)

                If Not d3 = 18 Or Not d3 = 23 Then
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11, t11, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, 18, 0, 2) 'upper
                Else
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11, t11, 2)
                End If
            Else
                Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
                Dim d11 As Integer = Set1(1).Trim
                Dim t11 As Integer = Set1(2).Trim

                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11, t11, 2)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub PantswithShoesIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim d4 As Integer = Set1(1).Trim
            Dim t4 As Integer = Set1(2).Trim
            Dim d6 As Integer = Set1(4).Trim
            Dim t6 As Integer = Set1(5).Trim

            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, d4, t4, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, d6, t6, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub PantsIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim d4 As Integer = Set1(1).Trim
            Dim t4 As Integer = Set1(2).Trim

            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, d4, t4, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CasualJacketIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim d3 As Integer = Set1(1).Trim
            Dim t3 As Integer = Set1(2).Trim
            Dim d11 As Integer = Set1(4).Trim
            Dim t11 As Integer = Set1(5).Trim

            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11, t11, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub SuitJacketIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            If GetPlayerName() = "Franklin" Then
                Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
                Dim d3 As Integer = Set1(1).Trim
                Dim t3 As Integer = Set1(2).Trim

                Dim d8 As Integer = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, 8)
                Dim d11 As Integer = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, 11)

                If Not d8 = 14 Or Not d8 = 15 Then
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, 14, 0, 2) 'Tie
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, 3, 0, 2) 'Vest
                Else
                    Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
                End If
            Else
                Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
                Dim d3 As Integer = Set1(1).Trim
                Dim t3 As Integer = Set1(2).Trim
                Dim d11 As Integer = Set1(4).Trim
                Dim t11 As Integer = Set1(5).Trim

                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11, t11, 2)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub VestIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim Set2() As String = sender.MenuItems(index).SubString2.Split("#"c)
            Dim d3 As Integer = Set1(1).Trim
            Dim t3 As Integer = Set1(2).Trim
            Dim d11_withouttie As Integer = Set1(4).Trim
            Dim t11_withouttie As Integer = Set1(5).Trim
            Dim d11_withtie As Integer = Set2(1).Trim
            Dim t11_withtie As Integer = Set2(2).Trim

            Dim d8 As Integer = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, 8)

            If Not d8 = 15 Then 'Got Tie
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11_withtie, t11_withtie, 2)
            Else 'No Tie
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11_withouttie, t11_withouttie, 2)
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub TieIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim Set2() As String = sender.MenuItems(index).SubString2.Split("#"c)
            Dim d8_withoutvest As Integer = Set1(1).Trim
            Dim t8_withoutvest As Integer = Set1(2).Trim
            Dim d8_withvest As Integer = Set2(1).Trim
            Dim t8_withvest As Integer = Set2(2).Trim

            Dim d3 As Integer = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, 3)
            Dim d11 As Integer = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, playerPed, 11)

            If Not d3 = 18 Or Not d3 = 23 Then
                'Do nothing
            ElseIf d11 = 5 'No Vest
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, d8_withoutvest, t8_withoutvest, 2)
            ElseIf d11 = 3 'With Vest
                Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, d8_withvest, t8_withvest, 2)
            Else
                'Do nothing
            End If
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub FullSuitIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim Set2() As String = sender.MenuItems(index).SubString2.Split("#"c)
            Dim d3 As Integer = Set1(1).Trim
            Dim t3 As Integer = Set1(2).Trim
            Dim d4 As Integer = Set1(4).Trim
            Dim t4 As Integer = Set1(5).Trim
            Dim d5 As Integer = Set1(7).Trim
            Dim t5 As Integer = Set1(8).Trim
            Dim d6 As Integer = Set1(10).Trim
            Dim t6 As Integer = Set1(11).Trim
            Dim d8 As Integer = Set2(1).Trim
            Dim t8 As Integer = Set2(2).Trim
            Dim d11 As Integer = Set2(4).Trim
            Dim t11 As Integer = Set2(5).Trim
            Dim d10 As Integer = Set2(7).Trim
            Dim t10 As Integer = Set2(8).Trim

            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, d4, t4, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 5, d5, t5, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, d6, t6, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, d8, t8, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11, t11, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, d10, t10, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OutfitIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim Set2() As String = sender.MenuItems(index).SubString2.Split("#"c)
            Dim d3 As Integer = Set1(1).Trim
            Dim t3 As Integer = Set1(2).Trim
            Dim d4 As Integer = Set1(4).Trim
            Dim t4 As Integer = Set1(5).Trim
            Dim d5 As Integer = Set1(7).Trim
            Dim t5 As Integer = Set1(8).Trim
            Dim d6 As Integer = Set1(10).Trim
            Dim t6 As Integer = Set1(11).Trim
            Dim d8 As Integer = Set1(13).Trim
            Dim t8 As Integer = Set1(14).Trim
            Dim d11 As Integer = Set1(16).Trim
            Dim t11 As Integer = Set1(17).Trim
            Dim d10 As Integer = Set1(19).Trim
            Dim t10 As Integer = Set1(20).Trim
            Dim d0 As Integer = Set2(1).Trim
            Dim t0 As Integer = Set2(2).Trim
            Dim d1 As Integer = Set2(4).Trim
            Dim t1 As Integer = Set2(5).Trim
            Dim d2 As Integer = Set2(7).Trim
            Dim t2 As Integer = Set2(8).Trim

            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, d3, t3, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, d4, t4, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 5, d5, t5, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, d6, t6, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, d8, t8, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, d11, t11, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 10, d10, t10, 2)
            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 0, d0, t0, 2)
            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 1, d1, t1, 2)
            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 2, d2, t2, 2)

            If d0 = -1 Then Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 0)
            If d1 = -1 Then Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 1)
            If d2 = -1 Then Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub MPOutfitIndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Set1() As String = sender.MenuItems(index).SubString1.Split("#"c)
            Dim Set2() As String = sender.MenuItems(index).SubString2.Split("#"c)
            Dim a_d1 As Integer = Set1(1).Trim
            Dim a_t1 As Integer = Set1(2).Trim
            Dim a_d3 As Integer = Set1(4).Trim
            Dim a_t3 As Integer = Set1(5).Trim
            Dim a_d4 As Integer = Set1(7).Trim
            Dim a_t4 As Integer = Set1(8).Trim
            Dim a_d6 As Integer = Set1(10).Trim
            Dim a_t6 As Integer = Set1(11).Trim
            Dim a_d7 As Integer = Set1(13).Trim
            Dim a_t7 As Integer = Set1(14).Trim
            Dim a_d8 As Integer = Set1(16).Trim
            Dim a_t8 As Integer = Set1(17).Trim
            Dim a_d9 As Integer = Set1(19).Trim
            Dim a_t9 As Integer = Set1(20).Trim
            Dim a_d11 As Integer = Set1(22).Trim
            Dim a_t11 As Integer = Set1(23).Trim
            Dim b_d0 As Integer = Set2(1).Trim
            Dim b_t0 As Integer = Set2(2).Trim
            Dim b_d1 As Integer = Set2(4).Trim
            Dim b_t1 As Integer = Set2(5).Trim
            Dim b_d2 As Integer = Set2(7).Trim
            Dim b_t2 As Integer = Set2(8).Trim

            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 1, a_d1, a_t1, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 3, a_d3, a_t3, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 4, a_d4, a_t4, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 6, a_d6, a_t6, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 7, a_d7, a_t7, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 8, a_d8, a_t8, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 9, a_d9, a_t9, 2)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, 11, a_d11, a_t11, 2)
            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 0, b_d0, b_t0, 2)
            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 1, b_d1, b_t1, 2)
            Native.Function.Call(Hash.SET_PED_PROP_INDEX, playerPed, 2, b_d2, b_t2, 2)
            If b_d1 = -1 Then Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 0)
            If b_d1 = -1 Then Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 1)
            If b_d2 = -1 Then Native.Function.Call(Hash.CLEAR_PED_PROP, playerPed, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
        If Not Game.IsLoading Then
            WardrobeDistance = World.GetDistance(playerPed.Position, WardrobeVector)

            If DrawSpotLight = True Then
                World.DrawSpotLightWithShadow(playerPed.Position + Vector3.WorldUp * 2 + Vector3.WorldNorth * 2, Vector3.WorldSouth + Vector3.WorldDown, Color.White, 10, 30, 100, 50, -1)
            End If

            'Control
            If Game.IsControlJustPressed(0, GTA.Control.Jump) AndAlso WardrobeDistance < 2.0 AndAlso (Player0W.Visible = True Or Player1W.Visible = True Or Player2W.Visible = True Or Player3_MW.Visible = True Or Player3_FW.Visible = True) Then
                If DrawSpotLight = False Then
                    DrawSpotLight = True
                Else
                    DrawSpotLight = False
                End If

            End If
            'End Control

            _menuPool.ProcessMenus()
        End If
    End Sub
End Class
