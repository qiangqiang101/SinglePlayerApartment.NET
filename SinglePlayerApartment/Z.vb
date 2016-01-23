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

Public Class Z
    Inherits Script

    Public Sub New()
        Try
            SinglePlayerApartment.player = Game.Player
            playerPed = Game.Player.Character
            playerHash = SinglePlayerApartment.player.Character.Model.GetHashCode().ToString
            If playerHash = "225514697" Then
                playerName = "Michael"
            ElseIf playerHash = "-1692214353" Then
                playerName = "Franklin"
            ElseIf playerHash = "-1686040670" Then
                playerName = "Trevor"
            ElseIf playerHash = "1885233650" Or "-1667301416" Then
                playerName = "Player3"
            Else
                playerName = "None"
            End If
            If playerName = "Player3" Then
                playerCash = 1000000000
            Else
                playerCash = SinglePlayerApartment.player.Money
            End If

            uiLanguage = Game.Language.ToString

            If uiLanguage = "Chinese" Then
                ExitApt = "离開公寓"
                SellApt = "出售產業"
                EnterGarage = "進入車庫"
                AptOptions = "公寓選項"
                Garage = "車庫"
                GrgOptions = "管理車輛"
                GrgRemove = "刪除車輛"
                GrgRemoveAndDrive = "刪除並且駕駛離開"
                GrgMove = "重新排序"
                GrgSell = "出售車輛給改車王"
                GrgSelectVeh = "選擇車輛"
                GrgTooHot = "我們暫時不需要這輛車。"
                _Mechanic = "機械師"
                ChooseApt = "選擇公寓"
                ChooseVeh = "選擇車輛"
                ChooseVehDesc = "請求交付？"
                ReturnVeh = "返回所有車輛"
                AptStyle = "公寓樣式"
            Else
                ExitApt = "Exit Apartment"
                SellApt = "Sell Property"
                EnterGarage = "Enter Garage"
                AptOptions = "APARTMENT OPTIONS"
                Garage = " Garage"
                GrgOptions = "MANAGE VEHICLES"
                GrgRemove = "Remove Vehicle"
                GrgRemoveAndDrive = "Remove and exit Garage"
                GrgMove = "Rearrange Vehicle"
                GrgSell = "Sell Vehicle to LSC"
                GrgSelectVeh = "Select vehicle."
                GrgTooHot = "This vehicle is too hot to sell."
                _Mechanic = "Mechanic"
                ChooseApt = "SELECT APARTMENT"
                ChooseVeh = "SELECT VEHICLE FOR DELIVERY"
                ChooseVehDesc = "Request Delivery?"
                ReturnVeh = "Return all Vehicles"
                AptStyle = "Apartment Style"
            End If


            If ReadCfgValue("EclipseTower", settingFile) = "Enable" Then EclipseTower.CreateEclipseTower()
            If ReadCfgValue("3AltaStreet", settingFile) = "Enable" Then _3AltaStreet.Create3AltaStreet()
            If ReadCfgValue("4IntegrityWay", settingFile) = "Enable" Then _4IntegrityWay.Create4IntegrityWay()
            If ReadCfgValue("DelPerroHeights", settingFile) = "Enable" Then DelPerroHeight.CreateDelPerroHeight()
            If ReadCfgValue("RichardMajestic", settingFile) = "Enable" Then RichardMajestic.CreateRichardsMajestic()
            If ReadCfgValue("TinselTower", settingFile) = "Enable" Then TinselTower.CreateTinselTower()
            If ReadCfgValue("WeazelPlaza", settingFile) = "Enable" Then WeazelPlaza.CreateWeazelPlaza()
            If ReadCfgValue("DreamTower", settingFile) = "Enable" Then DreamTower.CreateDreamTower()
            If ReadCfgValue("VespucciBlvd", settingFile) = "Enable" Then VespucciBlvd.CreateVespucciBlvd()
            If ReadCfgValue("2044NorthConker", settingFile) = "Enable" Then NorthConker2044.CreateNorthConker2044()
            If ReadCfgValue("2862Hillcrest", settingFile) = "Enable" Then HillcrestAve2862.CreateHillcrestAve2862()
            If ReadCfgValue("2868Hillcrest", settingFile) = "Enable" Then HillcrestAve2868.CreateHillcrestAve2868()
            If ReadCfgValue("3655WildOats", settingFile) = "Enable" Then WildOats3655.CreateWildOats3655()
            If ReadCfgValue("2045NorthConker", settingFile) = "Enable" Then NorthConker2045.CreateNorthConker2045()
            If ReadCfgValue("2117MiltonRd", settingFile) = "Enable" Then MiltonRd2117.CreateMiltonRoad2117()
            If ReadCfgValue("2874Hillcrest", settingFile) = "Enable" Then HillcrestAve2874.CreateHillcrestAve2874()
            If ReadCfgValue("3677Whispymound", settingFile) = "Enable" Then Whispymound3677.CreateWhispymound3677()
            If ReadCfgValue("2113MadWayne", settingFile) = "Enable" Then MadWayne2113.CreateMadWayne2113()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Class
