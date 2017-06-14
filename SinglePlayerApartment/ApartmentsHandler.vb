Imports GTA

Public Class ApartmentsHandler
    Inherits Script

    Dim _3as As _3AltaStreet
    Dim _4iw As _4IntegrityWay
    Dim dph As DelPerroHeight
    Dim et As EclipseTower
    Dim rm As RichardMajestic
    Dim tt As TinselTower
    Dim wp As WeazelPlaza
    Dim ha2862 As HillcrestAve2862
    Dim ha2868 As HillcrestAve2868
    Dim ha2874 As HillcrestAve2874
    Dim mw2113 As MadWayne2113
    Dim mr2117 As MiltonRd2117
    Dim nc2044 As NorthConker2044
    Dim nc2045 As NorthConker2045
    Dim wm3677 As Whispymound3677
    Dim wo3655 As WildOats3655
    Dim bca As BayCityAve
    Dim bdp As BlvdDelPerro
    Dim ca As CougarAve
    Dim dt As DreamTower
    Dim ha As HangmanAve
    Dim llb0604 As LasLagunasBlvd0604
    Dim llb2143 As LasLagunasBlvd2143
    Dim mr0184 As MiltonRd0184
    Dim ps As PowerSt
    Dim pd4401 As ProcopioDr4401
    Dim pd4584 As ProcopioDr4584
    Dim pps As ProsperitySt
    Dim svs As SanVitasSt
    Dim smmd As SouthMoMiltonDr
    Dim srd0325 As SouthRockfordDrive0325
    Dim sa As SpanishAve
    Dim sr As SustanciaRd
    Dim tr As TheRoyale
    Dim gs As GrapeseedAve
    Dim pb As PaletoBlvd
    Dim srd0112 As SouthRockfordDr0112
    Dim vb As VespucciBlvd
    Dim za As ZancudoAve

    Public Sub New()
        _3as = New _3AltaStreet()
        _4iw = New _4IntegrityWay()
        dph = New DelPerroHeight()
        et = New EclipseTower()
        rm = New RichardMajestic()
        tt = New TinselTower()
        wp = New WeazelPlaza()
        ha2862 = New HillcrestAve2862()
        ha2868 = New HillcrestAve2868()
        ha2874 = New HillcrestAve2874()
        mw2113 = New MadWayne2113()
        mr2117 = New MiltonRd2117()
        nc2044 = New NorthConker2044()
        nc2045 = New NorthConker2045()
        wm3677 = New Whispymound3677()
        wo3655 = New WildOats3655()
        bca = New BayCityAve()
        bdp = New BlvdDelPerro()
        ca = New CougarAve()
        dt = New DreamTower()
        ha = New HangmanAve()
        llb0604 = New LasLagunasBlvd0604()
        llb2143 = New LasLagunasBlvd2143()
        mr0184 = New MiltonRd0184()
        ps = New PowerSt()
        pd4401 = New ProcopioDr4401()
        pd4584 = New ProcopioDr4584()
        pps = New ProsperitySt()
        svs = New SanVitasSt()
        smmd = New SouthMoMiltonDr()
        srd0325 = New SouthRockfordDrive0325()
        sa = New SpanishAve()
        sr = New SustanciaRd()
        tr = New TheRoyale()
        gs = New GrapeseedAve()
        pb = New PaletoBlvd()
        srd0112 = New SouthRockfordDr0112()
        vb = New VespucciBlvd()
        za = New ZancudoAve()
    End Sub

    Public Sub OnTick(o As Object, e As EventArgs) Handles Me.Tick
        Try
            'High End Apartments
            _3as.OnTick()
            _4iw.OnTick()
            dph.OnTick()
            et.OnTick()
            rm.OnTick()
            tt.OnTick()
            wp.OnTick()

            'Stilts Apartment
            ha2862.OnTick()
            ha2868.OnTick()
            ha2874.OnTick()
            mw2113.OnTick()
            mr2117.OnTick()
            nc2044.OnTick()
            nc2045.OnTick()
            wm3677.OnTick()
            wo3655.OnTick()

            'Medium Range Apartment
            bca.OnTick()
            bdp.OnTick()
            ca.OnTick()
            dt.OnTick()
            ha.OnTick()
            llb0604.OnTick()
            llb2143.OnTick()
            mr0184.OnTick()
            ps.OnTick()
            pd4401.OnTick()
            pd4584.OnTick()
            pps.OnTick()
            svs.OnTick()
            smmd.OnTick()
            srd0325.OnTick()
            sa.OnTick()
            sr.OnTick()
            tr.OnTick()

            'Low Range Apartment
            gs.OnTick()
            pb.OnTick()
            srd0112.OnTick()
            vb.OnTick()
            za.OnTick()
        Catch ex As Exception
            logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub OnAborted() Handles MyBase.Aborted
        'High End Apartments
        _3as.OnAborted()
        _4iw.OnAborted()
        dph.OnAborted()
        et.OnAborted()
        rm.OnAborted()
        tt.OnAborted()
        wp.OnAborted()

        'Stilts Apartment
        ha2862.OnAborted()
        ha2868.OnAborted()
        ha2874.OnAborted()
        mw2113.OnAborted()
        mr2117.OnAborted()
        nc2044.OnAborted()
        nc2045.OnAborted()
        wm3677.OnAborted()
        wo3655.OnAborted()

        'Medium Range Apartment
        bca.OnAborted()
        bdp.OnAborted()
        ca.OnAborted()
        dt.OnAborted()
        ha.OnAborted()
        llb0604.OnAborted()
        llb2143.OnAborted()
        mr0184.OnAborted()
        ps.OnAborted()
        pd4401.OnAborted()
        pd4584.OnAborted()
        pps.OnAborted()
        svs.OnAborted()
        smmd.OnAborted()
        srd0325.OnAborted()
        sa.OnAborted()
        sr.OnAborted()
        tr.OnAborted()

        'Low Range Apartment
        gs.OnAborted()
        pb.OnAborted()
        srd0112.OnAborted()
        vb.OnAborted()
        za.OnAborted()
    End Sub
End Class
