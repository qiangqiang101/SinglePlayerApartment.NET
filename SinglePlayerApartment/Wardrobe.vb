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

    Public Shared Outfits, Suits, FullSuits, SuitJackets, SuitJacketsButtoned, SuitPants, SuitVests, SuitTies, CasualJackets, OpenShirts, CasualJacketJackets As UIMenuItem
    Public Shared CasualJacketShirts, CasualJacketTShirts, Earrings, Glasses, Glass, SportsShades, StreetShades, Hats, HatsTrevor, CapsForward, CapsBackward As UIMenuItem
    Public Shared Hoodies, Jackets, Pants, Shoes, Shirt, Shorts, SmartShoes, TShirt, TankTops, Tops, Vests, PoloShirt, Chains As UIMenuItem

    Public Shared FOutfitsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\outfits.cfg"
    Public Shared MOutfitsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\outfits.cfg"
    Public Shared TOutfitsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\outfits.cfg"
    Public Shared PMOutfitsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_M\outfits.cfg"
    Public Shared PFOutfitsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_F\outfits.cfg"
    Public Shared FFullSuitsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\fullsuits.cfg"
    Public Shared MFullSuitsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\fullsuits.cfg"
    Public Shared TFullSuitsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\fullsuits.cfg"
    Public Shared FSuitJacketsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\suitjackets.cfg"
    Public Shared MSuitJacketsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\suitjackets.cfg"
    Public Shared TSuitJacketsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\suitjackets.cfg"
    Public Shared FSuitJacketsButtonedFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\suitjacketsbuttoned.cfg"
    Public Shared FSuitPantsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\suitpants.cfg"
    Public Shared MSuitPantsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\suitpants.cfg"
    Public Shared TSuitPantsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\suitpants.cfg"
    Public Shared FSuitVestsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\suitvests.cfg"
    Public Shared MSuitVestsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\suitvests.cfg"
    Public Shared FTiesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\suitties.cfg"
    Public Shared FCasualJacketsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\casualjackets.cfg"
    Public Shared MCasualJacketsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\casualjackets.cfg"
    Public Shared FCasualTShirtsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\casualtshirts.cfg"
    Public Shared MCasualTShirtsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\casualtshirts.cfg"
    Public Shared FEarringsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\earrings.cfg"
    Public Shared PMEarringsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_M\earrings.cfg"
    Public Shared PFEarringsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_F\earrings.cfg"
    Public Shared FSportsShadesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\sportsshades.cfg"
    Public Shared MSportsShadesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\sportsshades.cfg"
    Public Shared TSportsShadesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\sportsshades.cfg"
    Public Shared FStreetShadesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\streetshades.cfg"
    Public Shared MStreetShadesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\streetshades.cfg"
    Public Shared TStreetShadesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\streetshades.cfg"
    Public Shared FCapsForwardFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\capsforward.cfg"
    Public Shared TCapsForwardFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\capsforward.cfg"
    Public Shared FCapsBackwardFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\capsbackward.cfg"
    Public Shared FHoodiesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\hoodies.cfg"
    Public Shared MHoodiesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\hoodies.cfg"
    Public Shared THoodiesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\hoodies.cfg"
    Public Shared FJacketsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\jackets.cfg"
    Public Shared MJacketsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\jackets.cfg"
    Public Shared TJacketsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\jackets.cfg"
    Public Shared FPantsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\pants.cfg"
    Public Shared MPantsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\pants.cfg"
    Public Shared TPantsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\pants.cfg"
    Public Shared FShoesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\shoes.cfg"
    Public Shared MShoesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\shoes.cfg"
    Public Shared TShoesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\shoes.cfg"
    Public Shared FShirtFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\shirt.cfg"
    Public Shared MShirtFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\shirt.cfg"
    Public Shared TShirtFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\shirt.cfg"
    Public Shared FShortsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\shorts.cfg"
    Public Shared MShortsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\shorts.cfg"
    Public Shared TShortsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\shorts.cfg"
    Public Shared FSmartShoesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\smartshoes.cfg"
    Public Shared TSmartShoesFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\smartshoes.cfg"
    Public Shared FTShirtFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\tshirt.cfg"
    Public Shared MTShirtFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\tshirt.cfg"
    Public Shared TTShirtFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\tshirt.cfg"
    Public Shared FTankTopsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\tanktops.cfg"
    Public Shared MTankTopsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\tanktops.cfg"
    Public Shared TTankTopsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\tanktops.cfg"
    Public Shared FTopsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\tops.cfg"
    Public Shared MTopsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\tops.cfg"
    Public Shared TTopsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\tops.cfg"
    Public Shared FVestsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Franklin\vests.cfg"
    Public Shared MGlassFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\glasses.cfg"
    Public Shared PMGlassFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_M\glasses.cfg"
    Public Shared PFGlassFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_F\glasses.cfg"
    Public Shared MPoloShirtFile As String = "scripts\SinglePlayerApartment\Wardrobe\Michael\polo.cfg"
    Public Shared TPoloShirtFile As String = "scripts\SinglePlayerApartment\Wardrobe\Trevor\polo.cfg"
    Public Shared PMHatsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_M\hats.cfg"
    Public Shared PFHatsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_F\hats.cfg"
    Public Shared PMChainsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_M\chains.cfg"
    Public Shared PFChainsFile As String = "scripts\SinglePlayerApartment\Wardrobe\Player3_F\chains.cfg"

    Public Shared OutfitsParameters As String() = {"[gxt]", "[name]", "[set1]", "[set2]"}
    Public Shared FullSuitsParameters As String() = {"[gxt]", "[name]", "[set1]", "[set2]"}
    Public Shared SuitJacketsParameters As String() = {"[gxt]", "[name]", "[set1]"}

    Public Shared _menuPool As MenuPool

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

    Enum BannerType
        Michael
        Franklin
        Trevor
        Player3
    End Enum

    Public Sub New()
        Try
            _menuPool = New MenuPool()

            Outfits = New UIMenuItem(_Outfits)
            Suits = New UIMenuItem(_Suits)
            FullSuits = New UIMenuItem(_FullSuit)
            SuitJackets = New UIMenuItem(_SuitJacket)
            SuitJacketsButtoned = New UIMenuItem(_SuitJacketbuttoned)
            SuitPants = New UIMenuItem(_SuitPants)
            SuitVests = New UIMenuItem(_SuitVest)
            SuitTies = New UIMenuItem(_Ties)
            CasualJackets = New UIMenuItem(_CasualJackets)
            OpenShirts = New UIMenuItem(_OpenShirts)
            CasualJacketJackets = New UIMenuItem(_Jackets)
            CasualJacketShirts = New UIMenuItem(_Shirts)
            CasualJacketTShirts = New UIMenuItem(_TShirts)
            Earrings = New UIMenuItem(_Earrings)
            Glasses = New UIMenuItem(_Glasses)
            Glass = New UIMenuItem(_Glasses)
            SportsShades = New UIMenuItem(_SportsShades)
            StreetShades = New UIMenuItem(_StreetShades)
            Hats = New UIMenuItem(_Hats)
            HatsTrevor = New UIMenuItem(_Hats)
            CapsForward = New UIMenuItem(_CapsForward)
            CapsBackward = New UIMenuItem(_CapsBackward)
            Hoodies = New UIMenuItem(_Hoodies)
            Jackets = New UIMenuItem(_Jackets)
            Pants = New UIMenuItem(_Pants)
            Shoes = New UIMenuItem(_Shoes)
            Shirt = New UIMenuItem(_Shirts)
            Shorts = New UIMenuItem(_Shorts)
            SmartShoes = New UIMenuItem(_SmartShoes)
            TShirt = New UIMenuItem(_TShirts)
            TankTops = New UIMenuItem(_TankTops)
            Tops = New UIMenuItem(_Tops)
            Vests = New UIMenuItem(_Vests)
            PoloShirt = New UIMenuItem(_PoloShirts)
            Chains = New UIMenuItem(_Chains)

            'Michael Menu
            CreateMichaelWardrobe()
            ReadOutfit(Outfit0, __Outfits, Player0W, Outfits, MOutfitsFile, BannerType.Michael)
            ReadSuitMichael()
            ReadFullSuit(FullSuit0, __FullSuit, Suit0, FullSuits, MFullSuitsFile, BannerType.Michael)
            ReadJacket(SuitJackets0, __SuitJacket, Suit0, SuitJackets, MSuitJacketsFile, BannerType.Michael)
            ReadPants(SuitPants0, __SuitPants, Suit0, SuitPants, MSuitPantsFile, BannerType.Michael)
            ReadSuitVest(SuitVests0, __SuitVest, Suit0, SuitVests, MSuitVestsFile, BannerType.Michael)
            ReadGlassesMichael()
            ReadShades(Glass0, __Glasses, Glasses0, Glass, MGlassFile, BannerType.Michael)
            ReadShades(SportsShades0, __SportsShades, Glasses0, SportsShades, MSportsShadesFile, BannerType.Michael)
            ReadShades(StreetShades0, __StreetShades, Glasses0, StreetShades, MStreetShadesFile, BannerType.Michael)
            ReadUpperbody(Hoodies0, __Hoodies, Player0W, Hoodies, MHoodiesFile, BannerType.Michael)
            ReadUpperbody(Jackets0, __Jackets, Player0W, Jackets, MJacketsFile, BannerType.Michael)
            ReadPants(Pants0, __Pants, Player0W, Pants, MPantsFile, BannerType.Michael)
            ReadUpperbody(PoloShirt0, __PoloShirts, Player0W, PoloShirt, MPoloShirtFile, BannerType.Michael)
            ReadShoes(Shoes0, __Shoes, Player0W, Shoes, MShoesFile, BannerType.Michael)
            ReadCasualJacketMichael() 'Open Shirts
            ReadCasualJacketJacket(CasualJacketJackets0, __Shirts, CasualJackets0, CasualJacketShirts, MCasualJacketsFile, BannerType.Michael)
            ReadCasualJacketTShirt(CasualJacketTShirt0, __TShirts, CasualJackets0, CasualJacketTShirts, MCasualTShirtsFile, BannerType.Michael)
            ReadUpperbody(Shirt0, __Shirts, Player0W, Shirt, MShirtFile, BannerType.Michael)
            ReadPantsWithShoes(Shorts0, __Shorts, Player0W, Shorts, MShortsFile, BannerType.Michael)
            ReadUpperbody(TShirt0, __TShirts, Player0W, TShirt, MTShirtFile, BannerType.Michael)
            ReadUpperbody(TankTops0, __TankTops, Player0W, TankTops, MTankTopsFile, BannerType.Michael)
            ReadUpperbody(Tops0, __Tops, Player0W, Tops, MTopsFile, BannerType.Michael)

            'Franklin Menu
            CreateFranklinWardrobe()
            ReadOutfit(Outfit1, __Outfits, Player1W, Outfits, FOutfitsFile, BannerType.Franklin)
            ReadSuitFranklin()
            ReadFullSuit(FullSuit1, __FullSuit, Suit1, FullSuits, FFullSuitsFile, BannerType.Franklin)
            ReadJacket(SuitJackets1, __SuitJacket, Suit1, SuitJackets, FSuitJacketsFile, BannerType.Franklin)
            ReadJacket(SuitJackersButtoned1, __SuitJacketbuttoned, Suit1, SuitJacketsButtoned, FSuitJacketsButtonedFile, BannerType.Franklin)
            ReadPants(SuitPants1, __SuitPants, Suit1, SuitPants, FSuitPantsFile, BannerType.Franklin)
            ReadSuitVest(SuitVests1, __SuitVest, Suit1, SuitVests, FSuitVestsFile, BannerType.Franklin)
            ReadSuitTie(Ties1, __Ties, Suit1, SuitTies, FTiesFile, BannerType.Franklin)
            ReadCasualJacketFranklin()
            ReadCasualJacketJacket(CasualJacketJackets1, __Jackets, CasualJackets1, CasualJacketJackets, FCasualJacketsFile, BannerType.Franklin)
            ReadCasualJacketTShirt(CasualJacketTShirt1, __TShirts, CasualJackets1, CasualJacketTShirts, FCasualTShirtsFile, BannerType.Franklin)
            ReadEarrings(Earrings1, __Earrings, Player1W, Earrings, FEarringsFile, BannerType.Franklin)
            ReadGlassesFranklin()
            ReadShades(SportsShades1, __SportsShades, Glasses1, SportsShades, FSportsShadesFile, BannerType.Franklin)
            ReadShades(StreetShades1, __StreetShades, Glasses1, StreetShades, FStreetShadesFile, BannerType.Franklin)
            ReadHatsFranklin()
            ReadCaps(CapsForward1, __CapsForward, Hats1, CapsForward, FCapsForwardFile, BannerType.Franklin)
            ReadCaps(CapsBackward1, __CapsBackward, Hats1, CapsBackward, FCapsBackwardFile, BannerType.Franklin)
            ReadUpperbody(Hoodies1, __Hoodies, Player1W, Hoodies, FHoodiesFile, BannerType.Franklin)
            ReadUpperbody(Jackets1, __Jackets, Player1W, Jackets, FJacketsFile, BannerType.Franklin)
            ReadPants(Pants1, __Pants, Player1W, Pants, FPantsFile, BannerType.Franklin)
            ReadShoes(Shoes1, __Shoes, Player1W, Shoes, FShoesFile, BannerType.Franklin)
            ReadUpperbody(Shirt1, __Shirts, Player1W, Shirt, FShirtFile, BannerType.Franklin)
            ReadPants(Shorts1, __Shorts, Player1W, Shorts, FShortsFile, BannerType.Franklin)
            ReadShoes(SmartShoes1, __SmartShoes, Player1W, SmartShoes, FSmartShoesFile, BannerType.Franklin)
            ReadUpperbody(TShirt1, __TShirts, Player1W, TShirt, FTShirtFile, BannerType.Franklin)
            ReadUpperbody(TankTops1, __TankTops, Player1W, TankTops, FTankTopsFile, BannerType.Franklin)
            ReadUpperbody(Tops1, __Tops, Player1W, Tops, FTopsFile, BannerType.Franklin)
            ReadVest(Vest1, __Vests, Player1W, Vests, FVestsFile, BannerType.Franklin)

            'Trevor Menu
            CreateTrevorWardrobe()
            ReadOutfit(Outfit2, __Outfits, Player2W, Outfits, TOutfitsFile, BannerType.Trevor)
            ReadSuitTrevor()
            ReadFullSuit(FullSuit2, __FullSuit, Suit2, FullSuits, TFullSuitsFile, BannerType.Trevor)
            ReadJacket(SuitJackets2, __SuitJacket, Suit2, SuitJackets, TSuitJacketsFile, BannerType.Trevor)
            ReadPants(SuitPants2, __SuitPants, Suit2, SuitPants, TSuitPantsFile, BannerType.Trevor)
            ReadGlassesTrevor()
            ReadShades(SportsShades2, __SportsShades, Glasses2, SportsShades, TSportsShadesFile, BannerType.Trevor)
            ReadShades(StreetShades2, __StreetShades, Glasses2, StreetShades, TStreetShadesFile, BannerType.Trevor)
            ReadCaps(CapsForward2, __Hats, Player2W, HatsTrevor, TCapsForwardFile, BannerType.Trevor)
            ReadUpperbody(Hoodies2, __Hoodies, Player2W, Hoodies, THoodiesFile, BannerType.Trevor)
            ReadUpperbody(Jackets2, __Jackets, Player2W, Jackets, TJacketsFile, BannerType.Trevor)
            ReadPants(Pants2, __Pants, Player2W, Pants, TPantsFile, BannerType.Trevor)
            ReadUpperbody(PoloShirt2, __PoloShirts, Player2W, PoloShirt, TPoloShirtFile, BannerType.Trevor)
            ReadShoes(Shoes2, __Shoes, Player2W, Shoes, TShoesFile, BannerType.Trevor)
            ReadUpperbody(Shirt2, __Shirts, Player2W, Shirt, TShirtFile, BannerType.Trevor)
            ReadPantsWithShoes(Shorts2, __Shorts, Player2W, Shorts, TShortsFile, BannerType.Trevor)
            ReadShoes(SmartShoes2, __SmartShoes, Player2W, SmartShoes, TSmartShoesFile, BannerType.Trevor)
            ReadUpperbody(TShirt2, __TShirts, Player2W, TShirt, TTShirtFile, BannerType.Trevor)
            ReadUpperbody(TankTops2, __TankTops, Player2W, TankTops, TTankTopsFile, BannerType.Trevor)
            ReadUpperbody(Tops2, __Tops, Player2W, Tops, TTopsFile, BannerType.Trevor)

            'Player3 Male Menu
            CreatePlayer3MWardrobe()
            ReadMPOutfit(Outfit3M, __Outfits, Player3_MW, Outfits, PMOutfitsFile)
            ReadShades(Glasses3M, __Glasses, Player3_MW, Glass, PMGlassFile, BannerType.Player3)
            ReadEarrings(Earrings3M, __Earrings, Player3_MW, Earrings, PMEarringsFile, BannerType.Player3)
            ReadCaps(Hats3M, __Hats, Player3_MW, Hats, PMHatsFile, BannerType.Player3)
            ReadChains(Chains3M, __Chains， Player3_MW, Chains, PMChainsFile, BannerType.Player3)

            'Player3 Female Menu
            CreatePlayer3WWardrobe()
            ReadMPOutfit(Outfit3F, __Outfits, Player3_FW, Outfits, PFOutfitsFile)
            ReadShades(Glasses3F, __Glasses, Player3_FW, Glass, PFGlassFile, BannerType.Player3)
            ReadEarrings(Earrings3F, __Earrings, Player3_FW, Earrings, PFEarringsFile, BannerType.Player3)
            ReadCaps(Hats3F, __Hats, Player3_FW, Hats, PFHatsFile, BannerType.Player3)
            ReadChains(Chains3F, __Chains， Player3_FW, Chains, PFChainsFile, BannerType.Player3)
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub MakeACamera()
        RefreshGXT()
        playerPed.Position = New Vector3(WardrobeVector.X, WardrobeVector.Y, WardrobeVector.Z - 1)
        playerPed.Heading = WardrobeHead
        WardrobeCam = New Camera(1)
        WardrobeCam = World.CreateCamera(playerPed.Position + playerPed.ForwardVector * 4, GameplayCamera.Rotation, 30)
        WardrobeCam.PointAt(playerPed)
        World.RenderingCamera = WardrobeCam
        Native.Function.Call(Hash.TASK_START_SCENARIO_IN_PLACE, playerPed, WardrobeScenario, 0, True)
        hideHud = True
    End Sub

    Public Sub CreateMichaelWardrobe()
        Try
            Player0W = New UIMenu("", __Clothing)
            Player0W.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
            _menuPool.Add(Player0W)
            Player0W.AddItem(Outfits)
            Player0W.AddItem(Suits)
            Player0W.AddItem(Glasses)
            Player0W.AddItem(Hoodies)
            Player0W.AddItem(Jackets)
            Player0W.AddItem(Pants)
            Player0W.AddItem(PoloShirt)
            Player0W.AddItem(Shoes)
            Player0W.AddItem(OpenShirts)
            Player0W.AddItem(Shirt)
            Player0W.AddItem(Shorts)
            Player0W.AddItem(TShirt)
            Player0W.AddItem(TankTops)
            Player0W.AddItem(Tops)
            'Player0W.AddItem(Masks)
            Player0W.RefreshIndex()
            AddHandler Player0W.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateFranklinWardrobe()
        Try
            Player1W = New UIMenu("", __Clothing)
            Player1W.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
            _menuPool.Add(Player1W)
            Player1W.AddItem(Outfits)
            Player1W.AddItem(Suits)
            Player1W.AddItem(CasualJackets)
            Player1W.AddItem(Earrings)
            Player1W.AddItem(Glasses)
            Player1W.AddItem(Hats)
            Player1W.AddItem(Hoodies)
            Player1W.AddItem(Jackets)
            'Player1W.AddItem(Masks)
            Player1W.AddItem(Pants)
            Player1W.AddItem(Shoes)
            Player1W.AddItem(Shirt)
            Player1W.AddItem(Shorts)
            Player1W.AddItem(SmartShoes)
            Player1W.AddItem(TShirt)
            Player1W.AddItem(TankTops)
            Player1W.AddItem(Tops)
            Player1W.AddItem(Vests)
            Player1W.RefreshIndex()
            AddHandler Player1W.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateTrevorWardrobe()
        Try
            Player2W = New UIMenu("", __Clothing)
            Player2W.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            _menuPool.Add(Player2W)
            Player2W.AddItem(Outfits)
            Player2W.AddItem(Suits)
            Player2W.AddItem(Glasses)
            Player2W.AddItem(HatsTrevor)
            Player2W.AddItem(Hoodies)
            Player2W.AddItem(Jackets)
            Player2W.AddItem(Pants)
            Player2W.AddItem(PoloShirt)
            Player2W.AddItem(Shoes)
            Player2W.AddItem(Shirt)
            Player2W.AddItem(Shorts)
            Player2W.AddItem(SmartShoes)
            Player2W.AddItem(TShirt)
            Player2W.AddItem(TankTops)
            Player2W.AddItem(Tops)
            'Player2W.AddItem(Masks)
            Player2W.RefreshIndex()
            AddHandler Player2W.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreatePlayer3MWardrobe()
        Try
            Player3_MW = New UIMenu(Game.Player.Name, __Clothing)
            _menuPool.Add(Player3_MW)
            Player3_MW.AddItem(Outfits)
            Player3_MW.AddItem(Glass)
            Player3_MW.AddItem(Earrings)
            Player3_MW.AddItem(Hats)
            Player3_MW.AddItem(Chains)
            Player3_MW.RefreshIndex()
            AddHandler Player3_MW.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreatePlayer3WWardrobe()
        Try
            Player3_FW = New UIMenu(Game.Player.Name, __Clothing)
            _menuPool.Add(Player3_FW)
            Player3_FW.AddItem(Outfits)
            Player3_FW.AddItem(Glass)
            Player3_FW.AddItem(Earrings)
            Player3_FW.AddItem(Hats)
            Player3_FW.AddItem(Chains)
            Player3_FW.RefreshIndex()
            AddHandler Player3_FW.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadMPOutfit(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String)
        Try
            Dim format As New Reader(FileToRead, OutfitsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf MPOutfitIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadOutfit(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, OutfitsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf OutfitIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadUpperbody(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf UpperbodyIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadShoes(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf ShoesIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadChains(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf ChainsIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCaps(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf CapsIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadShades(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf ShadesIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadEarrings(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf EarringIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCasualJacketTShirt(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf CasualTShirtIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitVest(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf SuitVestIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadPantsWithShoes(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf PantswithShoesIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadPants(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf PantsIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCasualJacketJacket(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf CasualJacketIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadJacket(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, SuitJacketsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf SuitJacketIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadVest(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, FullSuitsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf VestIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitTie(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, FullSuitsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf TieIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadFullSuit(ByRef MenuCategory As UIMenu, ByRef Subtitle As String, ByRef MenuToBind As UIMenu, ByRef MenuItem As UIMenuItem, ByRef FileToRead As String, ByRef banner As BannerType)
        Try
            Dim format As New Reader(FileToRead, FullSuitsParameters)
            MenuCategory = New UIMenu("", Subtitle)
            Select Case banner
                Case BannerType.Michael
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
                Case BannerType.Franklin
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
                Case BannerType.Trevor
                    MenuCategory.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            End Select
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(Game.GetGXTEntry(format(i)("gxt")))
                MenuCategory.AddItem(item)
                With item
                    If .Text = "NULL" Then .Text = format(i)("name")
                    .SubString1 = format(i)("set1")
                    .SubString2 = format(i)("set2")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf FullSuitIndexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadHatsFranklin()
        Try
            Hats1 = New UIMenu("", __Hats)
            Hats1.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
            _menuPool.Add(Hats1)
            Hats1.AddItem(CapsForward)
            Hats1.AddItem(CapsBackward)
            Hats1.RefreshIndex()
            Player1W.BindMenuToItem(Hats1, Hats)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadGlassesMichael()
        Try
            Glasses0 = New UIMenu("", __Glasses)
            Glasses0.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
            _menuPool.Add(Glasses0)
            Glasses0.AddItem(Glass)
            Glasses0.AddItem(SportsShades)
            Glasses0.AddItem(StreetShades)
            Glasses0.RefreshIndex()
            Player0W.BindMenuToItem(Glasses0, Glasses)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadGlassesFranklin()
        Try
            Glasses1 = New UIMenu("", __Glasses)
            Glasses1.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
            _menuPool.Add(Glasses1)
            Glasses1.AddItem(SportsShades)
            Glasses1.AddItem(StreetShades)
            Glasses1.RefreshIndex()
            Player1W.BindMenuToItem(Glasses1, Glasses)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadGlassesTrevor()
        Try
            Glasses2 = New UIMenu("", __Glasses)
            Glasses2.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            _menuPool.Add(Glasses2)
            Glasses2.AddItem(SportsShades)
            Glasses2.AddItem(StreetShades)
            Glasses2.RefreshIndex()
            Player2W.BindMenuToItem(Glasses2, Glasses)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCasualJacketMichael()
        Try
            CasualJackets0 = New UIMenu("", __OpenShirts)
            CasualJackets0.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
            _menuPool.Add(CasualJackets0)
            CasualJackets0.AddItem(CasualJacketJackets)
            CasualJackets0.AddItem(CasualJacketTShirts)
            CasualJackets0.RefreshIndex()
            Player0W.BindMenuToItem(CasualJackets0, OpenShirts)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCasualJacketFranklin()
        Try
            CasualJackets1 = New UIMenu("", __CasualJackets)
            CasualJackets1.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
            _menuPool.Add(CasualJackets1)
            CasualJackets1.AddItem(CasualJacketJackets)
            CasualJackets1.AddItem(CasualJacketTShirts)
            CasualJackets1.RefreshIndex()
            Player1W.BindMenuToItem(CasualJackets1, CasualJackets)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitMichael()
        Try
            Suit0 = New UIMenu("", __Suits)
            Suit0.SetBannerType(New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Point.Empty, Size.Empty))
            _menuPool.Add(Suit0)
            Suit0.AddItem(FullSuits)
            Suit0.AddItem(SuitJackets)
            Suit0.AddItem(SuitPants)
            Suit0.AddItem(SuitVests)
            Suit0.RefreshIndex()
            Player0W.BindMenuToItem(Suit0, Suits)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitFranklin()
        Try
            Suit1 = New UIMenu("", __Suits)
            Suit1.SetBannerType(New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Point.Empty, Size.Empty))
            _menuPool.Add(Suit1)
            Suit1.AddItem(FullSuits)
            Suit1.AddItem(SuitJackets)
            Suit1.AddItem(SuitJacketsButtoned)
            Suit1.AddItem(SuitPants)
            Suit1.AddItem(SuitVests)
            Suit1.AddItem(SuitTies)
            Suit1.RefreshIndex()
            Player1W.BindMenuToItem(Suit1, Suits)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadSuitTrevor()
        Try
            Suit2 = New UIMenu("", __Suits)
            Suit2.SetBannerType(New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Point.Empty, Size.Empty))
            _menuPool.Add(Suit2)
            Suit2.AddItem(FullSuits)
            Suit2.AddItem(SuitJackets)
            Suit2.AddItem(SuitPants)
            Suit2.RefreshIndex()
            Player2W.BindMenuToItem(Suit2, Suits)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub MenuCloseHandler(sender As UIMenu)
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
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
            _menuPool.ProcessMenus()
        End If
    End Sub

    Private Shared Sub RefreshGXT()
        TranslateClothes()

        Outfits.Text = _Outfits
        Suits.Text = _Suits
        FullSuits.Text = _FullSuit
        SuitJackets.Text = _SuitJacket
        SuitJacketsButtoned.Text = _SuitJacketbuttoned
        SuitPants.Text = _SuitPants
        SuitVests.Text = _SuitVest
        SuitTies.Text = _Ties
        CasualJackets.Text = _CasualJackets
        OpenShirts.Text = _OpenShirts
        CasualJacketJackets.Text = _Jackets
        CasualJacketShirts.Text = _Shirts
        CasualJacketTShirts.Text = _TShirts
        Earrings.Text = _Earrings
        Glasses.Text = _Glasses
        Glass.Text = _Glasses
        SportsShades.Text = _SportsShades
        StreetShades.Text = _StreetShades
        Hats.Text = _Hats
        HatsTrevor.Text = _Hats
        CapsForward.Text = _CapsForward
        CapsBackward.Text = _CapsBackward
        Hoodies.Text = _Hoodies
        Jackets.Text = _Jackets
        Pants.Text = _Pants
        Shoes.Text = _Shoes
        Shirt.Text = _Shirts
        Shorts.Text = _Shorts
        SmartShoes.Text = _SmartShoes
        TShirt.Text = _TShirts
        TankTops.Text = _TankTops
        Tops.Text = _Tops
        Vests.Text = _Vests
        PoloShirt.Text = _PoloShirts
        Chains.Text = _Chains

        Player0W.Subtitle.Caption = __Clothing
        Player1W.Subtitle.Caption = __Clothing
        Player2W.Subtitle.Caption = __Clothing
        Player3_FW.Subtitle.Caption = __Clothing
        Player3_MW.Subtitle.Caption = __Clothing

        Outfit0.Subtitle.Caption = __Outfits
        Suit0.Subtitle.Caption = __Suits
        FullSuit0.Subtitle.Caption = __FullSuit
        SuitJackets0.Subtitle.Caption = __SuitJacket
        SuitPants0.Subtitle.Caption = __SuitPants
        SuitVests0.Subtitle.Caption = __SuitVest
        CasualJackets0.Subtitle.Caption = __CasualJackets
        CasualJacketJackets0.Subtitle.Caption = __Shirts
        Outfit1.Subtitle.Caption = __Outfits
        Suit1.Subtitle.Caption = __Suits
        FullSuit1.Subtitle.Caption = __FullSuit
        SuitJackets1.Subtitle.Caption = __SuitJacket
        SuitJackersButtoned1.Subtitle.Caption = __SuitJacketbuttoned
        SuitPants1.Subtitle.Caption = __SuitPants
        SuitVests1.Subtitle.Caption = __SuitVest
        Ties1.Subtitle.Caption = __Ties
        CasualJackets1.Subtitle.Caption = __CasualJackets
        CasualJacketJackets1.Subtitle.Caption = __Shirts
        Outfit2.Subtitle.Caption = __Outfits
        Suit2.Subtitle.Caption = __Suits
        FullSuit2.Subtitle.Caption = __FullSuit
        SuitJackets2.Subtitle.Caption = __SuitJacket
        SuitPants2.Subtitle.Caption = __SuitPants
        Outfit3M.Subtitle.Caption = __Outfits
        Earrings3M.Subtitle.Caption = __Earrings
        Glasses3M.Subtitle.Caption = __Glasses
        Hats3M.Subtitle.Caption = __Hats
        Chains3M.Subtitle.Caption = __Chains
        Outfit3F.Subtitle.Caption = __Outfits
        Earrings3F.Subtitle.Caption = __Earrings
        Glasses3F.Subtitle.Caption = __Glasses
        Hats3F.Subtitle.Caption = __Hats
        Chains3F.Subtitle.Caption = __Chains
        CasualJacketTShirt0.Subtitle.Caption = __TShirts
        Glasses0.Subtitle.Caption = __Glasses
        SportsShades0.Subtitle.Caption = __SportsShades
        StreetShades0.Subtitle.Caption = __StreetShades
        Hoodies0.Subtitle.Caption = __Hoodies
        Jackets0.Subtitle.Caption = __Jackets
        Pants0.Subtitle.Caption = __Pants
        CasualJacketTShirt1.Subtitle.Caption = __TShirts
        Earrings1.Subtitle.Caption = __Earrings
        Glasses1.Subtitle.Caption = __Glasses
        SportsShades1.Subtitle.Caption = __SportsShades
        StreetShades1.Subtitle.Caption = __StreetShades
        Hats1.Subtitle.Caption = __Hats
        CapsForward1.Subtitle.Caption = __CapsForward
        CapsBackward1.Subtitle.Caption = __CapsBackward
        Hoodies1.Subtitle.Caption = __Hoodies
        Jackets1.Subtitle.Caption = __Jackets
        Pants1.Subtitle.Caption = __Pants
        Glasses2.Subtitle.Caption = __Glasses
        SportsShades2.Subtitle.Caption = __SportsShades
        StreetShades2.Subtitle.Caption = __StreetShades
        CapsForward2.Subtitle.Caption = __CapsForward
        Hoodies2.Subtitle.Caption = __Hoodies
        Jackets2.Subtitle.Caption = __Jackets
        Pants2.Subtitle.Caption = __Pants
        Shoes0.Subtitle.Caption = __Shoes
        Shirt0.Subtitle.Caption = __Shirts
        Shorts0.Subtitle.Caption = __Shorts
        TShirt0.Subtitle.Caption = __TShirts
        TankTops0.Subtitle.Caption = __TankTops
        Tops0.Subtitle.Caption = __Tops
        Glass0.Subtitle.Caption = __Glasses
        PoloShirt0.Subtitle.Caption = __PoloShirts
        Shoes1.Subtitle.Caption = __Shoes
        Shirt1.Subtitle.Caption = __Shirts
        Shorts1.Subtitle.Caption = __Shorts
        SmartShoes1.Subtitle.Caption = __SmartShoes
        TShirt1.Subtitle.Caption = __TShirts
        TankTops1.Subtitle.Caption = __TankTops
        Tops1.Subtitle.Caption = __Tops
        Vest1.Subtitle.Caption = __Vests
        Shoes2.Subtitle.Caption = __Shoes
        Shirt2.Subtitle.Caption = __Shirts
        Shorts2.Subtitle.Caption = __Shorts
        SmartShoes2.Subtitle.Caption = __SmartShoes
        TShirt2.Subtitle.Caption = __TShirts
        TankTops2.Subtitle.Caption = __TankTops
        Tops2.Subtitle.Caption = __Tops
        PoloShirt2.Subtitle.Caption = __PoloShirts
    End Sub
End Class
