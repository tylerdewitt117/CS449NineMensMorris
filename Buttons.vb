Public Class Buttons


    Public theGame As New Gameplay
    Private potentialMill As New Mills



    'Changes made: 
    'Eliminated all button arrays and replaced them with dictionaries: one for the color of each button, and one for the mill status of each color
    'Buttons are now activated through the enableOrDisableButtons function, which takes an array and either enables or disables the buttons corresponding to the numbers in the array
    'Moved most of the functions and variables into either the Mills class or the new Gameplay class (formerly the gameOver class)
    'Fixed some other random things that needed to be fixed
    'The button handlers pretty much do the same thing as they did before
    'All that needs to be done now is the AI, and now that the class organization makes sense, that shouldn't be too difficult
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Handles mill if clicked when player is removing a piece after making a mill
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button1, 1)
            potentialMill.removeMill(1, 2, 3)
            potentialMill.removeMill(1, 10, 22)
            Return
        End If

        'When player clicks button during phase 2 as a piece that they want to move
        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button1, 1)
            Return
        End If

        'When player clicks button during phase 2 as a spot that they want to move the piece to
        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button1, 1)
            Dim result1 As Boolean = potentialMill.millCheck(Button1, Button2, Button3, 1, 2, 3)
            Dim result2 As Boolean = potentialMill.millCheck(Button1, Button10, Button22, 1, 10, 22)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                'Just locks all the buttons now - idk what to do to indicate to the players that the game is over
                Return
            End If
            theGame.newTurn()
        End If

        'If not all pieces are placed, do phase 1 placing function - else start phase 2 moving
        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button1, 1)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button1, Button2, Button3, 1, 2, 3)
                Dim result2 As Boolean = potentialMill.millCheck(Button1, Button10, Button22, 1, 10, 22)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If

        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.ForeColor = Color.Black
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button2, 2)
            potentialMill.removeMill(2, 1, 3)
            potentialMill.removeMill(2, 5, 8)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button2, 2)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button2, 2)
            Dim result1 As Boolean = potentialMill.millCheck(Button2, Button1, Button3, 2, 1, 3)
            Dim result2 As Boolean = potentialMill.millCheck(Button2, Button5, Button8, 2, 5, 8)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button2, 2)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button2, Button1, Button3, 2, 1, 3)
                Dim result2 As Boolean = potentialMill.millCheck(Button2, Button5, Button8, 2, 5, 8)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button3, 3)
            potentialMill.removeMill(3, 1, 2)
            potentialMill.removeMill(3, 15, 24)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button3, 3)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button3, 3)
            Dim result1 As Boolean = potentialMill.millCheck(Button3, Button1, Button2, 3, 1, 2)
            Dim result2 As Boolean = potentialMill.millCheck(Button3, Button15, Button24, 3, 15, 24)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button3, 3)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button3, Button1, Button2, 3, 1, 2)
                Dim result2 As Boolean = potentialMill.millCheck(Button3, Button15, Button24, 3, 15, 24)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button4, 4)
            potentialMill.removeMill(4, 5, 6)
            potentialMill.removeMill(4, 11, 19)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button4, 4)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button4, 4)
            Dim result1 As Boolean = potentialMill.millCheck(Button4, Button5, Button6, 4, 5, 6)
            Dim result2 As Boolean = potentialMill.millCheck(Button4, Button11, Button19, 4, 11, 19)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button4, 4)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button4, Button5, Button6, 4, 5, 6)
                Dim result2 As Boolean = potentialMill.millCheck(Button4, Button11, Button19, 4, 11, 19)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button5, 5)
            potentialMill.removeMill(5, 4, 6)
            potentialMill.removeMill(5, 2, 8)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button5, 5)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button5, 5)
            Dim result1 As Boolean = potentialMill.millCheck(Button5, Button4, Button6, 5, 4, 6)
            Dim result2 As Boolean = potentialMill.millCheck(Button5, Button2, Button8, 5, 2, 8)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button5, 5)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button5, Button4, Button6, 5, 4, 6)
                Dim result2 As Boolean = potentialMill.millCheck(Button5, Button2, Button8, 5, 2, 8)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button6, 6)
            potentialMill.removeMill(6, 4, 5)
            potentialMill.removeMill(6, 14, 21)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button6, 6)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button6, 6)
            Dim result1 As Boolean = potentialMill.millCheck(Button6, Button4, Button5, 6, 4, 5)
            Dim result2 As Boolean = potentialMill.millCheck(Button6, Button14, Button21, 6, 14, 21)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button6, 6)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button6, Button4, Button5, 6, 4, 5)
                Dim result2 As Boolean = potentialMill.millCheck(Button6, Button14, Button21, 6, 14, 21)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button7, 7)
            potentialMill.removeMill(7, 8, 9)
            potentialMill.removeMill(7, 12, 16)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button7, 7)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button7, 7)
            Dim result1 As Boolean = potentialMill.millCheck(Button7, Button8, Button9, 7, 8, 9)
            Dim result2 As Boolean = potentialMill.millCheck(Button7, Button12, Button16, 7, 12, 16)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button7, 7)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button7, Button8, Button9, 7, 8, 9)
                Dim result2 As Boolean = potentialMill.millCheck(Button7, Button12, Button16, 7, 12, 16)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button8, 8)
            potentialMill.removeMill(8, 7, 9)
            potentialMill.removeMill(8, 2, 5)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button8, 8)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button8, 8)
            Dim result1 As Boolean = potentialMill.millCheck(Button8, Button7, Button9, 8, 7, 9)
            Dim result2 As Boolean = potentialMill.millCheck(Button8, Button2, Button5, 8, 2, 5)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button8, 8)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button8, Button7, Button9, 8, 7, 9)
                Dim result2 As Boolean = potentialMill.millCheck(Button8, Button2, Button5, 8, 2, 5)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button9, 9)
            potentialMill.removeMill(9, 13, 18)
            potentialMill.removeMill(9, 7, 8)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button9, 9)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button9, 9)
            Dim result1 As Boolean = potentialMill.millCheck(Button9, Button7, Button8, 9, 7, 8)
            Dim result2 As Boolean = potentialMill.millCheck(Button9, Button13, Button18, 9, 13, 18)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button9, 9)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button9, Button7, Button8, 9, 7, 8)
                Dim result2 As Boolean = potentialMill.millCheck(Button9, Button13, Button18, 9, 13, 18)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button10, 10)
            potentialMill.removeMill(10, 11, 12)
            potentialMill.removeMill(10, 1, 22)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button10, 10)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button10, 10)
            Dim result1 As Boolean = potentialMill.millCheck(Button10, Button11, Button12, 10, 11, 12)
            Dim result2 As Boolean = potentialMill.millCheck(Button10, Button1, Button22, 10, 1, 22)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button10, 10)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button10, Button11, Button12, 10, 11, 12)
                Dim result2 As Boolean = potentialMill.millCheck(Button10, Button1, Button22, 10, 1, 22)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button11, 11)
            potentialMill.removeMill(11, 10, 12)
            potentialMill.removeMill(11, 4, 19)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button11, 11)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button11, 11)
            Dim result1 As Boolean = potentialMill.millCheck(Button11, Button10, Button12, 11, 10, 12)
            Dim result2 As Boolean = potentialMill.millCheck(Button11, Button4, Button19, 11, 4, 19)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button11, 11)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button11, Button10, Button12, 11, 10, 12)
                Dim result2 As Boolean = potentialMill.millCheck(Button11, Button4, Button19, 11, 4, 19)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button12, 12)
            potentialMill.removeMill(12, 10, 11)
            potentialMill.removeMill(12, 7, 16)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button12, 12)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button12, 12)
            Dim result1 As Boolean = potentialMill.millCheck(Button12, Button10, Button11, 12, 10, 11)
            Dim result2 As Boolean = potentialMill.millCheck(Button12, Button7, Button16, 12, 7, 16)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button12, 12)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button12, Button10, Button11, 12, 10, 11)
                Dim result2 As Boolean = potentialMill.millCheck(Button12, Button7, Button16, 12, 7, 16)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button13, 13)
            potentialMill.removeMill(13, 14, 15)
            potentialMill.removeMill(13, 9, 18)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button13, 13)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button13, 13)
            Dim result1 As Boolean = potentialMill.millCheck(Button13, Button14, Button15, 13, 14, 15)
            Dim result2 As Boolean = potentialMill.millCheck(Button13, Button9, Button18, 13, 9, 18)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button13, 13)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button13, Button14, Button15, 13, 14, 15)
                Dim result2 As Boolean = potentialMill.millCheck(Button13, Button9, Button18, 13, 9, 18)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button14, 14)
            potentialMill.removeMill(14, 13, 15)
            potentialMill.removeMill(14, 6, 21)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button14, 14)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button14, 14)
            Dim result1 As Boolean = potentialMill.millCheck(Button14, Button13, Button15, 14, 13, 15)
            Dim result2 As Boolean = potentialMill.millCheck(Button14, Button6, Button21, 14, 6, 21)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button14, 14)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button14, Button13, Button15, 14, 13, 15)
                Dim result2 As Boolean = potentialMill.millCheck(Button14, Button6, Button21, 14, 6, 21)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button15, 15)
            potentialMill.removeMill(15, 13, 14)
            potentialMill.removeMill(15, 3, 24)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button15, 15)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button15, 15)
            Dim result1 As Boolean = potentialMill.millCheck(Button15, Button13, Button14, 15, 13, 14)
            Dim result2 As Boolean = potentialMill.millCheck(Button15, Button3, Button24, 15, 3, 24)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button15, 15)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button15, Button13, Button14, 15, 13, 14)
                Dim result2 As Boolean = potentialMill.millCheck(Button15, Button3, Button24, 15, 3, 24)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button16, 16)
            potentialMill.removeMill(16, 17, 18)
            potentialMill.removeMill(16, 7, 12)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button16, 16)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button16, 16)
            Dim result1 As Boolean = potentialMill.millCheck(Button16, Button17, Button18, 16, 17, 18)
            Dim result2 As Boolean = potentialMill.millCheck(Button16, Button7, Button12, 16, 7, 12)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button16, 16)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button16, Button17, Button18, 16, 17, 18)
                Dim result2 As Boolean = potentialMill.millCheck(Button16, Button7, Button12, 16, 7, 12)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button17, 17)
            potentialMill.removeMill(17, 16, 18)
            potentialMill.removeMill(17, 20, 23)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button17, 17)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button17, 17)
            Dim result1 As Boolean = potentialMill.millCheck(Button17, Button16, Button18, 17, 16, 18)
            Dim result2 As Boolean = potentialMill.millCheck(Button17, Button20, Button23, 17, 20, 23)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button17, 17)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button17, Button16, Button18, 17, 16, 18)
                Dim result2 As Boolean = potentialMill.millCheck(Button17, Button20, Button23, 17, 20, 23)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button18, 18)
            potentialMill.removeMill(18, 16, 17)
            potentialMill.removeMill(18, 9, 13)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button18, 18)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button18, 18)
            Dim result1 As Boolean = potentialMill.millCheck(Button18, Button16, Button17, 18, 16, 17)
            Dim result2 As Boolean = potentialMill.millCheck(Button18, Button9, Button13, 18, 9, 13)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button18, 18)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button18, Button16, Button17, 18, 16, 17)
                Dim result2 As Boolean = potentialMill.millCheck(Button18, Button9, Button13, 18, 9, 13)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button19, 19)
            potentialMill.removeMill(19, 20, 21)
            potentialMill.removeMill(19, 4, 11)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button19, 19)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button19, 19)
            Dim result1 As Boolean = potentialMill.millCheck(Button19, Button20, Button21, 19, 20, 21)
            Dim result2 As Boolean = potentialMill.millCheck(Button19, Button4, Button11, 19, 4, 11)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button19, 19)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button19, Button20, Button21, 19, 20, 21)
                Dim result2 As Boolean = potentialMill.millCheck(Button19, Button4, Button11, 19, 4, 11)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button20, 20)
            potentialMill.removeMill(20, 19, 21)
            potentialMill.removeMill(20, 17, 23)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button20, 20)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button20, 20)
            Dim result1 As Boolean = potentialMill.millCheck(Button20, Button19, Button21, 20, 19, 21)
            Dim result2 As Boolean = potentialMill.millCheck(Button20, Button17, Button23, 20, 17, 23)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button20, 20)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button20, Button19, Button21, 20, 19, 21)
                Dim result2 As Boolean = potentialMill.millCheck(Button20, Button17, Button23, 20, 17, 23)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button21, 21)
            potentialMill.removeMill(21, 19, 20)
            potentialMill.removeMill(21, 6, 14)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button21, 21)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button21, 21)
            Dim result1 As Boolean = potentialMill.millCheck(Button21, Button19, Button20, 21, 19, 20)
            Dim result2 As Boolean = potentialMill.millCheck(Button21, Button6, Button14, 21, 6, 14)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button21, 21)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button21, Button19, Button20, 21, 19, 20)
                Dim result2 As Boolean = potentialMill.millCheck(Button21, Button6, Button14, 21, 6, 14)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button22, 22)
            potentialMill.removeMill(22, 23, 24)
            potentialMill.removeMill(22, 1, 10)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button22, 22)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button22, 22)
            Dim result1 As Boolean = potentialMill.millCheck(Button22, Button23, Button24, 22, 23, 24)
            Dim result2 As Boolean = potentialMill.millCheck(Button22, Button1, Button10, 22, 1, 10)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()

        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button22, 22)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button22, Button23, Button24, 22, 23, 24)
                Dim result2 As Boolean = potentialMill.millCheck(Button22, Button1, Button10, 22, 1, 10)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button23, 23)
            potentialMill.removeMill(23, 22, 24)
            potentialMill.removeMill(23, 17, 20)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button23, 23)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button23, 23)
            Dim result1 As Boolean = potentialMill.millCheck(Button23, Button22, Button24, 23, 22, 24)
            Dim result2 As Boolean = potentialMill.millCheck(Button23, Button17, Button20, 23, 17, 20)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button23, 23)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button23, Button22, Button24, 23, 22, 24)
                Dim result2 As Boolean = potentialMill.millCheck(Button23, Button17, Button20, 23, 17, 20)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If (potentialMill.isMillToHandle) Then
            potentialMill.handleMill(Button24, 24)
            potentialMill.removeMill(24, 22, 23)
            potentialMill.removeMill(24, 3, 15)
            Return
        End If

        If (theGame.toMoveStatus()) Then
            theGame.phaseTwoPlaceMid(Button24, 24)
            Return
        End If

        If (theGame.moveEnabledStatus()) Then
            theGame.phaseTwoPlaceEnd(Button24, 24)
            Dim result1 As Boolean = potentialMill.millCheck(Button24, Button22, Button23, 24, 22, 23)
            Dim result2 As Boolean = potentialMill.millCheck(Button24, Button3, Button15, 24, 3, 15)
            If (result1 Or result2) Then
                potentialMill.setUpMill()
            End If
            If theGame.stateOfGame() Then
                theGame.gameOver()
                Return
            End If
            theGame.newTurn()
        End If

        If (theGame.allPiecesPlacedStatus() = False) Then
            theGame.phaseOnePlace(Button24, 24)
            If (theGame.getTurnNum() > 4) Then
                Dim result1 As Boolean = potentialMill.millCheck(Button24, Button22, Button23, 24, 22, 23)
                Dim result2 As Boolean = potentialMill.millCheck(Button24, Button3, Button15, 24, 3, 15)
                If (result1 Or result2) Then
                    potentialMill.setUpMill()
                End If
            End If
            theGame.newTurn()
            If theGame.getTurnNum() = 19 Then
                theGame.allPlaced()
                theGame.phaseTwoPlaceInit()
            End If
        Else
            theGame.phaseTwoPlaceInit()
            Return
        End If

    End Sub



    Public Sub enableOrDisableButtons(ByRef arr() As Integer, ByVal mode As Boolean)

        'Takes an array to be either enabled or disabled, and a boolean to tell it whether to enable or disable the specified buttons
        'True for the second value causes the buttons in the array to be enabled, false causes them to be disabled

        For Each item As Integer In arr
            Select Case item
                Case 1
                    If (mode = False) Then
                        Button1.Enabled = False
                    Else
                        Button1.Enabled = True
                    End If
                Case 2
                    If (mode = False) Then
                        Button2.Enabled = False
                    Else
                        Button2.Enabled = True
                    End If
                Case 3
                    If (mode = False) Then
                        Button3.Enabled = False
                    Else
                        Button3.Enabled = True
                    End If
                Case 4
                    If (mode = False) Then
                        Button4.Enabled = False
                    Else
                        Button4.Enabled = True
                    End If
                Case 5
                    If (mode = False) Then
                        Button5.Enabled = False
                    Else
                        Button5.Enabled = True
                    End If
                Case 6
                    If (mode = False) Then
                        Button6.Enabled = False
                    Else
                        Button6.Enabled = True
                    End If
                Case 7
                    If (mode = False) Then
                        Button7.Enabled = False
                    Else
                        Button7.Enabled = True
                    End If
                Case 8
                    If (mode = False) Then
                        Button8.Enabled = False
                    Else
                        Button8.Enabled = True
                    End If
                Case 9
                    If (mode = False) Then
                        Button9.Enabled = False
                    Else
                        Button9.Enabled = True
                    End If
                Case 10
                    If (mode = False) Then
                        Button10.Enabled = False
                    Else
                        Button10.Enabled = True
                    End If
                Case 11
                    If (mode = False) Then
                        Button11.Enabled = False
                    Else
                        Button11.Enabled = True
                    End If
                Case 12
                    If (mode = False) Then
                        Button12.Enabled = False
                    Else
                        Button12.Enabled = True
                    End If
                Case 13
                    If (mode = False) Then
                        Button13.Enabled = False
                    Else
                        Button13.Enabled = True
                    End If
                Case 14
                    If (mode = False) Then
                        Button14.Enabled = False
                    Else
                        Button14.Enabled = True
                    End If
                Case 15
                    If (mode = False) Then
                        Button15.Enabled = False
                    Else
                        Button15.Enabled = True
                    End If
                Case 16
                    If (mode = False) Then
                        Button16.Enabled = False
                    Else
                        Button16.Enabled = True
                    End If
                Case 17
                    If (mode = False) Then
                        Button17.Enabled = False
                    Else
                        Button17.Enabled = True
                    End If
                Case 18
                    If (mode = False) Then
                        Button18.Enabled = False
                    Else
                        Button18.Enabled = True
                    End If
                Case 19
                    If (mode = False) Then
                        Button19.Enabled = False
                    Else
                        Button19.Enabled = True
                    End If
                Case 20
                    If (mode = False) Then
                        Button20.Enabled = False
                    Else
                        Button20.Enabled = True
                    End If
                Case 21
                    If (mode = False) Then
                        Button21.Enabled = False
                    Else
                        Button21.Enabled = True
                    End If
                Case 22
                    If (mode = False) Then
                        Button22.Enabled = False
                    Else
                        Button22.Enabled = True
                    End If
                Case 23
                    If (mode = False) Then
                        Button23.Enabled = False
                    Else
                        Button23.Enabled = True
                    End If
                Case 24
                    If (mode = False) Then
                        Button24.Enabled = False
                    Else
                        Button24.Enabled = True
                    End If
            End Select
        Next
    End Sub
End Class


