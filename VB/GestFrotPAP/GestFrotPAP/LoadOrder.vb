﻿Imports System.Runtime.InteropServices
Public Module LoadOrder
    Private CentroEcranX As Integer = Form1.Width / 2
    Private CentroEcranY As Integer = Form1.Height / 2

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Public Sub Fade(ByVal Tipo As Integer) ' 0 para entrar 1 para sair Por em outro sitio? 
        Dim fade As Double
        If Tipo = 0 Then
            For fade = 0.0 To 1.1 Step 0.2
                Form1.Opacity = fade
                Form1.Refresh()
                Threading.Thread.Sleep(50)
            Next
        ElseIf Tipo = 1 Then
            For fade = 1.1 To 0.0 Step -0.3
                Form1.Opacity = fade
                Form1.Refresh()
                Threading.Thread.Sleep(50)
            Next
        End If
    End Sub



    Public Sub LoginPage()
        'Menu do topo com titulo / Por aqui o butão fechar
        Form1.LabelNomeProjeto.Text = "VecXP"
        Form1.LabelNomeProjeto.ForeColor = Color.White
        Form1.LabelNomeProjeto.Font = Fonte.GetInstance(10, FontStyle.Bold)
        Form1.LabelNomeProjeto.Top = (Form1.PnlMenuTop.Height - Form1.LabelNomeProjeto.Height) / 2
        Form1.LabelNomeProjeto.Left = 5

        'Login
        Form1.LoginPanel.Left = 0
        Form1.LoginPanel.Top = Form1.PnlMenuTop.Bottom
        Form1.LoginPanel.Height = Form1.Height - Form1.PnlMenuTop.Height
        Form1.LoginPanel.Width = Form1.Width
        'Talvez Criar outro botão ou mudar o atual
        Form1.BtnImagemLogin.Left = CentroEcranX - Form1.BtnImagemLogin.Width - 5
        Form1.BtnImagemRegistarEntrar.Left = CentroEcranX + 5
        Form1.BtnImagemLogin.Top = CentroEcranY + Form1.BtnImagemLogin.Height
        Form1.BtnImagemRegistarEntrar.Top = CentroEcranY + Form1.BtnImagemRegistarEntrar.Height

        Form1.TxtUser.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtPwd.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Form1.TxtUser.ForeColor = Color.White
        Form1.TxtPwd.ForeColor = Color.White

        Form1.TxtEmail.ForeColor = Color.White
        Form1.TxtUserReg.ForeColor = Color.White
        Form1.TxtPwdReg1.ForeColor = Color.White
        Form1.TxtPwdReg2.ForeColor = Color.White


        Form1.TxtUser.Left = CentroEcranX - (Form1.TxtUser.Width / 2)
        Form1.TxtPwd.Left = CentroEcranX - (Form1.TxtPwd.Width / 2)
        Form1.TxtUser.Top = Form1.PnlMenuTop.Bottom + 150
        Form1.TxtPwd.Top = Form1.TxtUser.Bottom + 10
        SendMessage(Form1.TxtUser.Handle, &H1501, 0, "Utilizador ou Email")
        SendMessage(Form1.TxtPwd.Handle, &H1501, 0, "Password")


        SendMessage(Form1.TxtEmail.Handle, &H1501, 0, "Email")
        SendMessage(Form1.TxtPwdReg1.Handle, &H1501, 0, "Password")
        SendMessage(Form1.TxtPwdReg2.Handle, &H1501, 0, "Repetir Password")
        SendMessage(Form1.TxtUserReg.Handle, &H1501, 0, "Utilizador")



        Form1.BtnImagemCancelar.Hide()
        Form1.BtnImagemRegistar.Hide()
        Form1.TxtEmail.Hide()
        Form1.TxtPwdReg1.Hide()
        Form1.TxtPwdReg2.Hide()
        Form1.TxtUserReg.Hide()
        Form1.TxtUser.Show()
        Form1.TxtPwd.Show()
    End Sub



    Public Sub MenuPrincipalPage() 'Depois do Login
        'User
        Form1.LblUserName.Visible = True  'Ao clickar abre um menu??
        Form1.LblUserName.Text = Form1.TxtUser.Text + "MUDAR" 'nome do Utilizador/ email/ idk possivelmente buscar nome e apelido á bd
        Form1.LblUserName.Font = Fonte.GetInstance(9, FontStyle.Bold)
        Form1.LblUserName.ForeColor = Color.White 'No futuro Opção para mudar?
        Form1.LblUserName.Top = (Form1.PnlMenuTop.Height - Form1.LblUserName.Height) / 2
        Form1.LblUserName.Left = Form1.Fechar.Right - Form1.LblUserName.Width - 20
        '
        'IDK
        Form1.LoginPanel.Hide()
    End Sub

    Public Sub RegistarPage()
        Form1.TxtUserReg.Show()
        Form1.TxtEmail.Show()
        Form1.TxtPwdReg1.Show()
        Form1.TxtPwdReg2.Show()
        Form1.TxtUser.Hide()
        Form1.TxtPwd.Hide()
        Form1.BtnImagemCancelar.Show()
        Form1.BtnImagemRegistar.Show()

        Form1.BtnImagemRegistar.Left = CentroEcranX - Form1.BtnImagemRegistar.Width - 5
        Form1.BtnImagemCancelar.Left = CentroEcranX + 5
        Form1.BtnImagemRegistar.Top = CentroEcranY + Form1.BtnImagemRegistar.Height
        Form1.BtnImagemCancelar.Top = CentroEcranY + Form1.BtnImagemCancelar.Height


        'Mudar txt para as de registo
        'mudar butoes registar e cancelar
        'etc



    End Sub

End Module
