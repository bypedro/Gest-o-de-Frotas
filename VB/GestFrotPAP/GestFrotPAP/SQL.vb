﻿Imports MySql.Data.MySqlClient
Module SQL
    Dim DB As String = "gestfrot"
    Dim ligacao As New MySqlConnection("Server=localhost;Database=" + DB + ";Uid=root;Pwd=;Connect timeout=30;") 'Criar form para configurar?
    Dim adapter As New MySqlDataAdapter
    Public Function Login(ByVal Utilizador As String, ByVal Password As String) As Boolean
        Dim max As MySqlCommand
        Dim User As Object
        Dim str As String
        If LCase(Utilizador).Contains(LCase("@")) Then
            Try 'Isto dáa
                If Utilizador.ToString <> "" Or Password.ToString <> "" Then
                    max = New MySqlCommand("select Password from Utilizador where Email='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str = Password Then
                        MsgBox("Password correta")
                        Return (True)
                        Exit Function
                    Else
                        MsgBox("Password errada")
                        Return (True)
                        Exit Function
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERRO")
            End Try
        Else
            Try 'Isto dáa
                If Utilizador.ToString <> "" Or Password.ToString <> "" Then
                    max = New MySqlCommand("select Password from Utilizador where Username='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str = Password Then
                        MsgBox("Password correta")
                        Return (True)
                        Exit Function
                    Else
                        MsgBox("Password errada")
                        Return (False)
                        Exit Function
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERRO")
            End Try
        End If
        Return (False)
    End Function



    Public Function Registar(ByVal Utilizador As String, ByVal Password1 As String, ByVal Password2 As String, ByVal Email As String, ByVal Morada As String, ByVal PrimeiroNome As String, ByVal Apelido As String) As Boolean
        'MsgBox(Utilizador)
        'MsgBox(Password1)
        'MsgBox(Password2)
        'MsgBox(Email)
        'MsgBox(Morada)
        'MsgBox(PrimeiroNome)
        'MsgBox(Apelido)
        Dim Comando As MySqlCommand
        Dim Objecto As Object

        Dim UtilizadorBD As String = ""
        Dim EmailBD As String = ""

        'Fazer isto para todos
        If Email = "" Then
            MsgBox("Necessita de um email")
            Return False
            Exit Function
        End If
        'VEr?
        If Password1 = "" Then
            MsgBox("Necessita de Password")
            Return False
            Exit Function
        End If

        If Password1 <> Password2 Then
            MsgBox("Passwords Não são iguais")
            Return False
            Exit Function
        End If
       

        'Procurar utilizador na base de dados
        Try
            Comando = New MySqlCommand("select Username from Utilizador where Username='" + Utilizador + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            UtilizadorBD = CType(Objecto, String)
            ligacao.Close()
        Catch ex As Exception
            MsgBox("ERRO UTILIZADOR")
        End Try
        'Procurar email na base de dados
        Try
            Comando = New MySqlCommand("select email from Utilizador where email='" + Email + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            EmailBD = CType(Objecto, String)
            ligacao.Close()
        Catch ex As Exception
            MsgBox("ERRO UTILIZADOR")
        End Try


        'BUGS AHEAD
        If EmailBD <> "" Then
            If Email = EmailBD Then 'IDK
                MsgBox("Email já existe")
                Return False
                Exit Function
            End If
        End If

        If UtilizadorBD <> "" Then
            If Utilizador = UtilizadorBD Then
                MsgBox("Utilizador já existe")
                Return False
                Exit Function
            End If
        End If





        Return (False)
    End Function

End Module