Public Class Buttons
    Private turnCounter As Integer = 0
    Private whitePieces As Integer = 1
    Private blackPieces As Integer = 1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button1.BackColor = Color.White
                Button1.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button1.BackColor = Color.Black
                Button1.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button2.BackColor = Color.White
                Button2.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button2.BackColor = Color.Black
                Button2.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button3.BackColor = Color.White
                Button3.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button3.BackColor = Color.Black
                Button3.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button4.BackColor = Color.White
                Button4.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button4.BackColor = Color.Black
                Button4.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button5.BackColor = Color.White
                Button5.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button5.BackColor = Color.Black
                Button5.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button6.BackColor = Color.White
                Button6.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button6.BackColor = Color.Black
                Button6.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button7.BackColor = Color.White
                Button7.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button7.BackColor = Color.Black
                Button7.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button8.BackColor = Color.White
                Button8.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button8.BackColor = Color.Black
                Button8.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button9.BackColor = Color.White
                Button9.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button9.BackColor = Color.Black
                Button9.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button10.BackColor = Color.White
                Button10.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button10.BackColor = Color.Black
                Button10.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button11.BackColor = Color.White
                Button11.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button11.BackColor = Color.Black
                Button11.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button12.BackColor = Color.White
                Button12.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button12.BackColor = Color.Black
                Button12.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button13.BackColor = Color.White
                Button13.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button13.BackColor = Color.Black
                Button13.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button14.BackColor = Color.White
                Button14.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button14.BackColor = Color.Black
                Button14.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button15.BackColor = Color.White
                Button15.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button15.BackColor = Color.Black
                Button15.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button16.BackColor = Color.White
                Button16.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button16.BackColor = Color.Black
                Button16.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button17.BackColor = Color.White
                Button17.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button17.BackColor = Color.Black
                Button17.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button18.BackColor = Color.White
                Button18.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button18.BackColor = Color.Black
                Button18.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button19.BackColor = Color.White
                Button19.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button19.BackColor = Color.Black
                Button19.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button20.BackColor = Color.White
                Button20.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button20.BackColor = Color.Black
                Button20.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button21.BackColor = Color.White
                Button21.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button21.BackColor = Color.Black
                Button21.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button22.BackColor = Color.White
                Button22.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button22.BackColor = Color.Black
                Button22.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button23.BackColor = Color.White
                Button23.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button9.BackColor = Color.Black
                Button9.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        turnCounter += 1
        'determines player turn and locks button for future use
        If turnCounter Mod 2 = 0 Then
            'when whitePieces gets to 9 no more pieces can be placed
            If whitePieces <= 9 Then
                Button24.BackColor = Color.White
                Button24.Enabled = False
                whitePieces += 1
            End If
        Else
            If blackPieces <= 9 Then
                Button24.BackColor = Color.Black
                Button24.Enabled = False
                blackPieces += 1
            End If
        End If
    End Sub

End Class