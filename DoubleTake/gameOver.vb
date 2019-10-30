Public Class gameOver
    'determine if player 2 has won
    Public Function stateOfGame() As Boolean
        If Buttons.whitePieces = 2 Or Buttons.blackPieces = 2 Then
            Buttons.Button1.Enabled = False
            Buttons.Button2.Enabled = False
            Buttons.Button3.Enabled = False
            Buttons.Button4.Enabled = False
            Buttons.Button5.Enabled = False
            Buttons.Button6.Enabled = False
            Buttons.Button7.Enabled = False
            Buttons.Button8.Enabled = False
            Buttons.Button9.Enabled = False
            Buttons.Button10.Enabled = False
            Buttons.Button11.Enabled = False
            Buttons.Button12.Enabled = False
            Buttons.Button13.Enabled = False
            Buttons.Button14.Enabled = False
            Buttons.Button15.Enabled = False
            Buttons.Button16.Enabled = False
            Buttons.Button17.Enabled = False
            Buttons.Button18.Enabled = False
            Buttons.Button19.Enabled = False
            Buttons.Button20.Enabled = False
            Buttons.Button21.Enabled = False
            Buttons.Button22.Enabled = False
            Buttons.Button23.Enabled = False
            Buttons.Button24.Enabled = False
            Return True
        Else
            Return False
        End If
    End Function
End Class
