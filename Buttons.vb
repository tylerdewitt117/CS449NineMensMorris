Public Class Buttons
    Private turnCounter As Integer = 1
    Public turnColor As String = "black"

    Public whitePieces As Integer = 1
    Public blackPieces As Integer = 1
    Private allPiecesPlaced As Boolean = False
    Public gameOver As Boolean = False

    Public currentWhiteMills(9) As Integer
    Public WhiteMillsNum As Integer = 0
    Public whitePiecesArr(9) As Integer
    Public whiteButtonsArr(9) As Button


    Public currentBlackMills(9) As Integer
    Public BlackMillsNum As Integer = 0
    Public blackPiecesArr(9) As Integer
    Public blackButtonsArr(9) As Button

    Public millToHandle = False

    Public buttons() As Button = {Button1, Button2}
    Dim adjacentElements()() As Integer = {
        New Integer() {2, 10},
        New Integer() {1, 3, 5},
        New Integer() {2, 15},
        New Integer() {5, 11},
        New Integer() {2, 4, 6, 8},
        New Integer() {5, 14},
        New Integer() {8, 12},
        New Integer() {5, 7, 9},
        New Integer() {8, 13},
        New Integer() {1, 11, 22},
        New Integer() {4, 10, 12, 19},
        New Integer() {7, 11, 16},
        New Integer() {9, 14, 18},
        New Integer() {6, 13, 15, 21},
        New Integer() {3, 24},
        New Integer() {12, 17},
        New Integer() {16, 18, 20},
        New Integer() {13, 17},
        New Integer() {11, 20},
        New Integer() {17, 19, 21, 23},
        New Integer() {14, 20},
        New Integer() {10, 23},
        New Integer() {20, 22, 24},
        New Integer() {15, 23}}

    Dim isGameOver As New gameOver
    Dim potentialMill As New Mills
    Dim gameIsOver As Boolean = False

    Dim toMove As Boolean = False
    Dim moveEnabled As Boolean = False
    Dim buttonToMove As Button
    Dim endgame As Boolean = False

    'Guys, I'm really sorry about the state of this, but I'm having a problem with the Button objects that I just can't figure out. I dealt with it for some of the functions, 
    'but not for the ones where I have to iterate through multiple buttons. Pointers would solve all my problems, but alas, VB doesn't have them. I tried to figure out ways to bullshit
    'pointers, but none of them really worked. It currently crashes when it tries to handle a mill because of this issue in the setUpMill() function - it's in a couple others too.
    'Worst case, we can probably make it work by going through and using each button individually when needed without an array, inside of the Buttons class. It would be ugly af but
    'it would probably work.
    'Also remember to delete these comments if you're the one to turn this in lol
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Handles mill if clicked when player is removing a piece after making a mill
        If (millToHandle) Then
            handleMill(Button1, 1)
            Return
        End If

        'When player clicks button during phase 2 as a piece that they want to move
        If (toMove) Then
            phaseTwoPlaceMid(Button1, 1)
            Return
        End If

        'When player clicks button during phase 2 as a spot that they want to move the piece to
        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button1)
        End If

        'If not all pieces are placed, do phase 1 placing function - else start phase 2 moving
        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button1)
        Else
            phaseTwoPlaceInit(Button1)
            Return
        End If

        'Check for possible mills for the button if applicable
        If (turnCounter > 4) Then
            millCheck1(Button1, Button2, Button3, 1, 2, 3)
            millCheck1(Button1, Button10, Button22, 1, 10, 22)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                'Just locks all the buttons now - idk what to do to indicate to the players that the game is over
                Return
            End If
        End If

        newTurn()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.ForeColor = Color.Black
        If (millToHandle) Then
            handleMill(Button2, 2)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button2, 2)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button2)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button2)
        Else
            phaseTwoPlaceInit(Button2)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button2, Button1, Button3, 2, 1, 3)
            millCheck1(Button2, Button5, Button8, 2, 5, 8)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If (millToHandle) Then
            handleMill(Button3, 3)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button3, 3)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button3)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button3)
        Else
            phaseTwoPlaceInit(Button3)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button3, Button1, Button2, 3, 1, 2)
            millCheck1(Button3, Button15, Button24, 3, 15, 24)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (millToHandle) Then
            handleMill(Button4, 4)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button4, 4)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button4)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button4)
        Else
            phaseTwoPlaceInit(Button4)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button4, Button5, Button6, 4, 5, 6)
            millCheck1(Button4, Button11, Button19, 4, 11, 19)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (millToHandle) Then
            handleMill(Button5, 5)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button5, 5)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button5)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button5)
        Else
            phaseTwoPlaceInit(Button5)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button5, Button4, Button6, 5, 4, 6)
            millCheck1(Button5, Button2, Button8, 5, 2, 8)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (millToHandle) Then
            handleMill(Button6, 6)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button6, 6)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button6)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button6)
        Else
            phaseTwoPlaceInit(Button6)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button6, Button4, Button5, 6, 4, 5)
            millCheck1(Button6, Button14, Button21, 6, 14, 21)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (millToHandle) Then
            handleMill(Button7, 7)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button7, 7)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button7)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button7)
        Else
            phaseTwoPlaceInit(Button7)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button7, Button8, Button9, 7, 8, 9)
            millCheck1(Button7, Button12, Button16, 7, 12, 16)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (millToHandle) Then
            handleMill(Button8, 8)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button8, 8)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button8)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button8)
        Else
            phaseTwoPlaceInit(Button8)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button8, Button7, Button9, 8, 7, 9)
            millCheck1(Button8, Button2, Button5, 8, 2, 5)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If (millToHandle) Then
            handleMill(Button9, 9)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button9, 9)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button9)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button9)
        Else
            phaseTwoPlaceInit(Button9)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button9, Button7, Button8, 9, 7, 8)
            millCheck1(Button9, Button13, Button18, 9, 13, 18)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If (millToHandle) Then
            handleMill(Button10, 10)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button10, 10)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button10)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button10)
        Else
            phaseTwoPlaceInit(Button10)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button10, Button11, Button12, 10, 11, 12)
            millCheck1(Button10, Button1, Button22, 10, 1, 22)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If (millToHandle) Then
            handleMill(Button11, 11)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button11, 11)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button11)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button11)
        Else
            phaseTwoPlaceInit(Button11)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button11, Button10, Button12, 11, 10, 12)
            millCheck1(Button11, Button4, Button19, 11, 4, 19)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If (millToHandle) Then
            handleMill(Button12, 12)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button12, 12)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button12)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button12)
        Else
            phaseTwoPlaceInit(Button12)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button12, Button10, Button11, 12, 10, 11)
            millCheck1(Button12, Button7, Button16, 12, 7, 16)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If (millToHandle) Then
            handleMill(Button13, 13)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button13, 13)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button13)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button13)
        Else
            phaseTwoPlaceInit(Button13)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button13, Button14, Button15, 13, 14, 15)
            millCheck1(Button13, Button9, Button18, 13, 9, 18)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If (millToHandle) Then
            handleMill(Button14, 14)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button14, 14)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button14)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button14)
        Else
            phaseTwoPlaceInit(Button14)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button14, Button13, Button15, 14, 13, 15)
            millCheck1(Button14, Button6, Button21, 14, 6, 21)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If (millToHandle) Then
            handleMill(Button15, 15)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button15, 15)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button15)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button15)
        Else
            phaseTwoPlaceInit(Button15)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button15, Button13, Button14, 15, 13, 14)
            millCheck1(Button15, Button3, Button24, 15, 3, 24)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If (millToHandle) Then
            handleMill(Button16, 16)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button16, 16)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button16)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button16)
        Else
            phaseTwoPlaceInit(Button16)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button16, Button17, Button18, 16, 17, 18)
            millCheck1(Button16, Button7, Button12, 16, 7, 12)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If (millToHandle) Then
            handleMill(Button17, 17)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button17, 17)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button17)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button17)
        Else
            phaseTwoPlaceInit(Button17)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button17, Button16, Button18, 17, 16, 18)
            millCheck1(Button17, Button20, Button23, 17, 20, 23)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If (millToHandle) Then
            handleMill(Button18, 18)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button18, 18)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button18)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button18)
        Else
            phaseTwoPlaceInit(Button18)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button18, Button16, Button17, 18, 16, 17)
            millCheck1(Button18, Button9, Button13, 18, 9, 13)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If (millToHandle) Then
            handleMill(Button19, 19)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button19, 19)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button19)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button19)
        Else
            phaseTwoPlaceInit(Button19)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button19, Button20, Button21, 19, 20, 21)
            millCheck1(Button19, Button4, Button11, 19, 4, 11)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If (millToHandle) Then
            handleMill(Button20, 20)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button20, 20)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button20)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button20)
        Else
            phaseTwoPlaceInit(Button20)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button20, Button19, Button21, 20, 19, 21)
            millCheck1(Button20, Button17, Button23, 20, 17, 23)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If (millToHandle) Then
            handleMill(Button21, 21)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button21, 21)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button21)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button21)
        Else
            phaseTwoPlaceInit(Button21)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button21, Button19, Button20, 21, 19, 20)
            millCheck1(Button21, Button6, Button14, 21, 6, 14)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        If (millToHandle) Then
            handleMill(Button22, 22)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button22, 22)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button22)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button22)
        Else
            phaseTwoPlaceInit(Button22)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button22, Button23, Button24, 22, 23, 24)
            millCheck1(Button22, Button1, Button10, 22, 1, 10)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        If (millToHandle) Then
            handleMill(Button23, 23)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button23, 23)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button23)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button23)
        Else
            phaseTwoPlaceInit(Button23)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button23, Button22, Button24, 23, 22, 24)
            millCheck1(Button23, Button17, Button20, 23, 17, 20)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If (millToHandle) Then
            handleMill(Button24, 24)
            Return
        End If

        If (toMove) Then
            phaseTwoPlaceMid(Button24, 24)
            Return
        End If

        If (moveEnabled) Then
            phaseTwoPlaceEnd(Button24)
        End If

        If (allPiecesPlaced = False) Then
            phaseOnePlace(Button24)
        Else
            phaseTwoPlaceInit(Button24)
            Return
        End If


        If (turnCounter > 4) Then
            millCheck1(Button24, Button22, Button23, 24, 22, 23)
            millCheck1(Button24, Button3, Button15, 24, 3, 15)
        End If

        'determine if all pieces have been placed
        If turnCounter = 18 Then
            allPiecesPlaced = True
        End If

        ' determine if the game has ended
        If allPiecesPlaced Then
            If isGameOver.stateOfGame() Then
                gameIsOver = True
                Return
            End If
        End If

        newTurn()
    End Sub

    Private Sub phaseOnePlace(ByRef theButton As Button)

        'function for phase 1 piece placing - places a correctly colored piece on the board, disables it, incrememts number of corresponding pieces and adds button# to corersponding array
        If (turnColor = "white") Then

            theButton.BackColor = Color.White
            theButton.Enabled = False
            whitePieces += 1
            whitePiecesArr(whitePieces) = 1

        Else

            theButton.BackColor = Color.Black
            theButton.Enabled = False
            blackPieces += 1
            blackPiecesArr(blackPieces) = 1

        End If
    End Sub

    Private Sub phaseTwoPlaceInit(ByRef theButton As Button)

        'Wow sorry this one is pretty fucky - I'm trying to enable all the player's pieces but changed it and forgot to make it actually work
        If (turnColor = "white") Then
            For Each button As Integer In whitePiecesArr
                theButton.Enabled = True
            Next
            toMove = True
        Else
            For Each button As Integer In blackPiecesArr
                theButton.Enabled = True
            Next
            toMove = True
        End If
    End Sub

    Private Function millCheck1(ByRef Button1 As Button, ByRef Button2 As Button, ByRef Button3 As Button, ByVal button1Int As Integer, ByVal button2Int As Integer, ByVal button3Int As Integer)
        Dim isThereMill As Boolean = potentialMill.isMill(Button1, Button2, Button3, button1Int, button2Int, button3Int)

        'Checks for mill, saves buttons #s involved, puts them into array of mills
        If (potentialMill.getButton1Int() > -1) Then
            millToHandle = True

            Dim buttonOneInt As Integer = potentialMill.getButton1Int()
            Dim buttonTwoInt As Integer = potentialMill.getButton2Int()
            Dim buttonThreeInt As Integer = potentialMill.getButton3Int()


            If (turnColor = "white") Then
                If (Array.IndexOf(currentWhiteMills, buttonOneInt) > -1) Then
                    currentWhiteMills(WhiteMillsNum) = buttonOneInt
                    WhiteMillsNum += 1
                End If
                If (Array.IndexOf(currentWhiteMills, buttonTwoInt) > -1) Then
                    currentWhiteMills(WhiteMillsNum) = buttonTwoInt
                    WhiteMillsNum += 1
                End If
                If (Array.IndexOf(currentWhiteMills, buttonThreeInt) > -1) Then
                    currentWhiteMills(WhiteMillsNum) = buttonThreeInt
                    WhiteMillsNum += 1
                End If
            Else
                If (Array.IndexOf(currentBlackMills, buttonOneInt) > -1) Then
                    currentBlackMills(BlackMillsNum) = buttonOneInt
                    BlackMillsNum += 1
                End If
                If (Array.IndexOf(currentBlackMills, buttonTwoInt) > -1) Then
                    currentBlackMills(BlackMillsNum) = buttonTwoInt
                    BlackMillsNum += 1
                End If
                If (Array.IndexOf(currentBlackMills, buttonThreeInt) > -1) Then
                    currentBlackMills(WhiteMillsNum) = buttonThreeInt
                    BlackMillsNum += 1
                End If
            End If
        End If
        Return isThereMill

    End Function



    Private Sub newTurn()
        'Changes turn, pretty straightforward
        If (turnColor = "white") Then
            turnColor = "black"
        Else
            turnColor = "white"
        End If
        turnCounter += 1
    End Sub

    Private Sub handleMill(ByRef theButton As Button, ByVal buttonNum As Integer)
        'Removes opponent's piece, removes piece from corresponding array
        theButton.BackColor = Color.Empty
        theButton.Enabled = True

        If turnColor = "white" Then
            Dim index = Array.IndexOf(whitePiecesArr, buttonNum)
            whitePiecesArr = whitePiecesArr.Where(Function(s) s <> whitePiecesArr(index)).ToArray
            whitePieces -= 1
        Else
            Dim index = Array.IndexOf(blackPiecesArr, buttonNum)
            blackPiecesArr = blackPiecesArr.Where(Function(s) s <> blackPiecesArr(index)).ToArray
            blackPieces -= 1

        End If
        potentialMill.tearDownMill(buttons)
        millToHandle = False
    End Sub

    Private Sub phaseTwoPlaceMid(ByRef theButton As Button, ByVal buttonNum As Integer)
        'This one needs to be fixed, since it gets an error saying that the object wasn't initialized or whatever. Tried to figure out how to solve that without pointers
        'but have thus far been unsuccessful
        Dim i As Integer
        Dim numEnabled As Integer = 0
        For i = 0 To 23
            'Disables player's buttons
            If (endgame = False) Then
                If (buttons(i).Enabled = True AndAlso Array.IndexOf(adjacentElements(buttonNum), i) = -1) Then
                    buttons(i).Enabled = False
                End If
            End If
            If (buttons(i).Enabled = True) Then
                numEnabled += 1
            End If
        Next
        'Ends game if no buttons are enabled at all (player can't move) - maybe move this to another function?
        If (numEnabled = 0) Then
            isGameOver.stateOfGame()
            gameIsOver = True
            Return

        End If
        toMove = False
        moveEnabled = True
        buttonToMove = theButton
    End Sub

    Private Sub phaseTwoPlaceEnd(ByRef theButton As Button)
        'Takes care of color changes and enabling/disabling for the move
        buttonToMove.BackColor = Color.Empty
        buttonToMove.Enabled = True
        If (turnColor = "white") Then
            theButton.BackColor = Color.White
        Else
            theButton.BackColor = Color.Black
        End If
        theButton.Enabled = False
    End Sub
End Class


