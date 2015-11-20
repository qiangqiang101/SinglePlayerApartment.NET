Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Reflection
Imports System.Windows.Forms
Imports SinglePlayerApartment.SinglePlayerApartment
Imports PDMCarShopGUI

Public Class Wardrobe
    Inherits Script

    Public Shared playerHash As String
    Public Shared models() As String = {"player_zero", "player_one", "player_two"}
    Public Shared modelNames() As String = {"Michael", "Franklin", "Trevor"}
    Public Shared componentTypes() As String = {"Head", "Face", "Hair", "Shirt", "Pants", "Gadgets", "Boots", "Accessories", "Undershirt", "Heist Gadgets", "Logos", "Jackets"}
    Public Shared WardrobeVector As Vector3
    Public Shared WardrobeDistance As Single
    Public Shared DrawSpotLight As Boolean = False
    Public Shared WardrobeCam As Camera

    Public Shared Player0W, Player1W, Player2W As UIMenu
    Public Shared Shirt0, Pants0, Gloves0, Shoes0, Accessories0, Heist0, Logos0, InnerShirt0 As UIMenu
    Public Shared Shirt1, Pants1, Gloves1, Shoes1, Accessories1, Heist1, Logos1, InnerShirt1 As UIMenu
    Public Shared Shirt2, Pants2, Gloves2, Shoes2, Accessories2, Heist2, Logos2 As UIMenu

    Public Shared _Shirt As New UIMenuItem("Shirts")
    Public Shared _Pants As New UIMenuItem("Pants")
    Public Shared _Gloves As New UIMenuItem("Gloves")
    Public Shared _Shoes As New UIMenuItem("Shoes")
    Public Shared _Accessories As New UIMenuItem("Accessories")
    Public Shared _Heist As New UIMenuItem("Heist Gadgets")
    Public Shared _Logo As New UIMenuItem("Decals")
    Public Shared _InnerShirt As New UIMenuItem("Collars")

    Public Shared MAcessories As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\accessories.cfg"
    Public Shared MDecals As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\decals.cfg"
    Public Shared MGloves As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\gloves.cfg"
    Public Shared MHeistG As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\heist.cfg"
    Public Shared MInnershirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\innershirt.cfg"
    Public Shared MPants As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\pants.cfg"
    Public Shared MShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\shirt.cfg"
    Public Shared MShoes As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Michael\shoes.cfg"
    Public Shared FAcessories As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\accessories.cfg"
    Public Shared FDecals As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\decals.cfg"
    Public Shared FGloves As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\gloves.cfg"
    Public Shared FHeistG As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\heist.cfg"
    Public Shared FInnershirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\innershirt.cfg"
    Public Shared FPants As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\pants.cfg"
    Public Shared FShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\shirt.cfg"
    Public Shared FShoes As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Franklin\shoes.cfg"
    Public Shared TAcessories As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\accessories.cfg"
    Public Shared TDecals As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\decals.cfg"
    Public Shared TGloves As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\gloves.cfg"
    Public Shared THeistG As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\heist.cfg"
    Public Shared TPants As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\pants.cfg"
    Public Shared TShirt As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\shirt.cfg"
    Public Shared TShoes As String = Application.StartupPath & "\scripts\SinglePlayerApartment\Wardrobe\Trevor\shoes.cfg"
    Public Shared Parameters As String() = {"[component]", "[variable]", "[texture]"}

    Public Shared _menuPool As MenuPool

    Enum ComponentID
        Face = 0
        Mask = 1
        Haircut = 2
        Shirt = 3
        Pants = 4
        Gloves = 5
        Shoes = 6
        Eyes = 7
        Accessories = 8
        Heist = 9
        Logo = 10
        InnerShirt = 11
    End Enum

    Public Sub New()
        Try
            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            Else
                playerName = "None"
            End If

            AddHandler Tick, AddressOf OnTick
            AddHandler KeyDown, AddressOf OnKeyDown

            _menuPool = New MenuPool()
            'Create Menu below
            CreateMichaelWardrobe()
            CreateFranklinWardrobe()
            CreateTrevorWardrobe()

            ReadCategory(Shirt0, "~b~SHIRTS", "SHIRTS #", Player0W, _Shirt, MShirt, 3)
            ReadCategory(Shirt1, "~g~SHIRTS", "SHIRTS #", Player1W, _Shirt, FShirt, 3)
            ReadCategory(Shirt2, "~o~SHIRTS", "SHIRTS #", Player2W, _Shirt, TShirt, 3)
            ReadCategory(Pants0, "~b~PANTS", "PANTS #", Player0W, _Pants, MPants, 4)
            ReadCategory(Pants1, "~g~PANTS", "PANTS #", Player1W, _Pants, FPants, 4)
            ReadCategory(Pants2, "~o~PANTS", "PANTS #", Player2W, _Pants, TPants, 4)
            ReadCategory(Gloves0, "~b~GLOVES", "GLOVES #", Player0W, _Gloves, MGloves, 5)
            ReadCategory(Gloves1, "~g~GLOVES", "GLOVES #", Player1W, _Gloves, FGloves, 5)
            ReadCategory(Gloves2, "~o~GLOVES", "GLOVES #", Player2W, _Gloves, TGloves, 5)
            ReadCategory(Shoes0, "~b~SHOES", "SHOES #", Player0W, _Shoes, MShoes, 6)
            ReadCategory(Shoes1, "~g~SHOES", "SHOES #", Player1W, _Shoes, FShoes, 6)
            ReadCategory(Shoes2, "~o~SHOES", "SHOES #", Player2W, _Shoes, TShoes, 6)
            ReadCategory(Accessories0, "~b~ACCESSORIES", "ACCESSORIES #", Player0W, _Accessories, MAcessories, 8)
            ReadCategory(Accessories1, "~g~ACCESSORIES", "ACCESSORIES #", Player1W, _Accessories, FAcessories, 8)
            ReadCategory(Accessories2, "~o~ACCESSORIES", "ACCESSORIES #", Player2W, _Accessories, TAcessories, 8)
            ReadCategory(Heist0, "~b~HEIST GADGETS", "HEIST GADGETS #", Player0W, _Heist, MHeistG, 9)
            ReadCategory(Heist1, "~g~HEIST GADGETS", "HEIST GADGETS #", Player1W, _Heist, FHeistG, 9)
            ReadCategory(Heist2, "~o~HEIST GADGETS", "HEIST GADGETS #", Player2W, _Heist, THeistG, 9)
            ReadCategory(Logos0, "~b~DECALS", "DECALS #", Player0W, _Logo, MDecals, 10)
            ReadCategory(Logos1, "~g~DECALS", "DECALS #", Player1W, _Logo, FDecals, 10)
            ReadCategory(Logos2, "~o~DECALS", "DECALS #", Player2W, _Logo, TDecals, 10)
            ReadCategory(InnerShirt0, "~b~COLLARS", "COLLARS #", Player0W, _InnerShirt, MInnershirt, 11)
            ReadCategory(InnerShirt1, "~g~COLLARS", "COLLARS #", Player1W, _InnerShirt, FInnershirt, 11)
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub MakeACamera()
        WardrobeCam = New Camera(1)
        WardrobeCam = World.CreateCamera(playerPed.Position + playerPed.ForwardVector * 4, GameplayCamera.Rotation, 30)
        WardrobeCam.PointAt(playerPed)
        World.RenderingCamera = WardrobeCam
        DrawSpotLight = True
    End Sub

    Public Sub CreateMichaelWardrobe()
        Try
            Player0W = New UIMenu("", "~b~CLOTHING", New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player0W.SetBannerType(Rectangle)
            _menuPool.Add(Player0W)
            Player0W.AddItem(_Shirt)
            Player0W.AddItem(_Pants)
            Player0W.AddItem(_Gloves)
            Player0W.AddItem(_Shoes)
            Player0W.AddItem(_Accessories)
            Player0W.AddItem(_Heist)
            Player0W.AddItem(_Logo)
            Player0W.AddItem(_InnerShirt)
            Player0W.RefreshIndex()
            AddHandler Player0W.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateFranklinWardrobe()
        Try
            Player1W = New UIMenu("", "~g~CLOTHING", New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player1W.SetBannerType(Rectangle)
            _menuPool.Add(Player1W)
            Player1W.AddItem(_Shirt)
            Player1W.AddItem(_Pants)
            Player1W.AddItem(_Gloves)
            Player1W.AddItem(_Shoes)
            Player1W.AddItem(_Accessories)
            Player1W.AddItem(_Heist)
            Player1W.AddItem(_Logo)
            Player1W.AddItem(_InnerShirt)
            Player1W.RefreshIndex()
            AddHandler Player1W.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateTrevorWardrobe()
        Try
            Player2W = New UIMenu("", "~o~CLOTHING", New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            Player2W.SetBannerType(Rectangle)
            _menuPool.Add(Player2W)
            Player2W.AddItem(_Shirt)
            Player2W.AddItem(_Pants)
            Player2W.AddItem(_Gloves)
            Player2W.AddItem(_Shoes)
            Player2W.AddItem(_Accessories)
            Player2W.AddItem(_Heist)
            Player2W.AddItem(_Logo)
            Player2W.RefreshIndex()
            AddHandler Player2W.OnMenuClose, AddressOf MenuCloseHandler
        Catch ex As Exception
            logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub ReadCategory(MenuCategory As UIMenu, Subtitle As String, ItemName As String, MenuToBind As UIMenu, MenuItem As UIMenuItem, FileToRead As String, ComponentID As Integer)
        Try
            Dim format As New Reader(FileToRead, Parameters)

            MenuCategory = New UIMenu("", Subtitle, New Point(0, -107))
            Dim Rectangle = New UIResRectangle()
            Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
            MenuCategory.SetBannerType(Rectangle)
            _menuPool.Add(MenuCategory)
            For i As Integer = 0 To format.Count - 1
                Dim item As New UIMenuItem(ItemName & i)
                MenuCategory.AddItem(item)
                With item
                    .Model = format(i)("variable")
                    .Car = format(i)("texture")
                    .Price = format(i)("component")
                End With
            Next
            MenuCategory.RefreshIndex()
            MenuToBind.BindMenuToItem(MenuCategory, MenuItem)
            AddHandler MenuCategory.OnItemSelect, AddressOf ItemSelectHandler
            AddHandler MenuCategory.OnIndexChange, AddressOf IndexChangeHandler
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub MenuCloseHandler(sender As UIMenu)
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
        DrawSpotLight = False
    End Sub

    Public Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        sender.GoBack()
        'Try
        'Dim currDrawable As Integer = Native.Function.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION， playerPed, selectedItem.Price)
        'Dim currTexture As Integer = Native.Function.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, playerPed, selectedItem.Price)
        'If Native.Function.Call(Of Boolean)(Hash.IS_PED_COMPONENT_VARIATION_VALID, playerPed, sender.MenuItems(index).Price, currDrawable, currTexture) Then
        'Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, selectedItem.Price, selectedItem.Model, currTexture, 2)
        'End If
        'Catch ex As Exception
        'logger.Log(ex.Message & " " & ex.StackTrace)
        'End Try
    End Sub

    Public Sub IndexChangeHandler(sender As UIMenu, index As Integer)
        Try
            Dim Com As Integer = sender.MenuItems(index).Price
            Dim Var As Integer = CInt(sender.MenuItems(index).Model)
            Dim Tex As Integer = CInt(sender.MenuItems(index).Car)
            Native.Function.Call(Hash.SET_PED_COMPONENT_VARIATION, playerPed, Com, Var, Tex, 2)
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs)
        WardrobeDistance = World.GetDistance(playerPed.Position, WardrobeVector)

        If DrawSpotLight = True Then
            World.DrawSpotLightWithShadow(playerPed.Position + Vector3.WorldUp * 2 + Vector3.WorldNorth * 2, Vector3.WorldSouth + Vector3.WorldDown, Color.White, 10, 30, 100, 50, -1)
        End If

        _menuPool.ProcessMenus()
    End Sub

    Public Sub OnKeyDown(o As Object, e As KeyEventArgs)
        If Game.IsControlJustPressed(0, GTA.Control.Jump) AndAlso WardrobeDistance < 2.0 AndAlso DrawSpotLight = Not DrawSpotLight Then
            DrawSpotLight = True
        End If
    End Sub
End Class
