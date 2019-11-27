Public Class Gameplay
    Private turnCounter As Integer = 1
    Private turnColor As String = "black"

    Private whitePieces As Integer = 0
    Private blackPieces As Integer = 0

    Private gameIsOver As Boolean = False
    Private toMove As Boolean = False
    Private moveEnabled As Boolean = False
    Private allPiecesPlaced As Boolean = False
    Private thirdPhase As Boolean = False


    Private adjacentElements()() As Integer = {
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

    Public allPiecesDict As New Dictionary(Of Integer, String) From {{1, "empty"}, {2, "empty"}, {3, "empty"}, {4, "empty"}, {5, "empty"}, {6, "empty"}, {7, "empty"}, {8, "empty"}, {9, "empty"}, {10, "empty"}, {11, "empty"}, {12, "empty"}, {13, "empty"}, {14, "empty"}, {15, "empty"}, {16, "empty"}, {17, "empty"}, {18, "empty"}, {19, "empty"}, {20, "empty"}, {21, "empty"}, {22, "empty"}, {23, "empty"}, {24, "empty"}}

    Public Sub newTurn()
        'Changes turn, pretty straightforward
        If (turnColor = "white") Then
            turnColor = "black"
        Else
            turnColor = "white"
        End If
        turnCounter += 1
    End Sub

    Public Sub phaseOnePlace(ByRef theButton As Button, ByVal buttonNum As Integer)

        'function for phase 1 piece placing - places a correctly colored piece on the board, disables it, incrememts number of corresponding pieces and adds button color to pieces dictionary
        If (turnColor = "white") Then

            theButton.BackColor = Color.White
            theButton.Enabled = False
            whitePieces += 1
            allPiecesDict(buttonNum) = "white"

        Else

            theButton.BackColor = Color.Black
            theButton.Enabled = False
            blackPieces += 1
            allPiecesDict(buttonNum) = "black"

        End If
    End Sub

    Public Sub phaseTwoPlaceInit()

        'Sorry, this one's a bit complicated
        'If the game is in the third phase, then it enables all the empty spaces
        'If not, it enables all the player's pieces that have empty spaces adjacent to them (first disables all spaces, then enables correct spaces)
        Dim enableArray(24) As Integer
        Dim enableNum As Integer = 0
        Dim disableArray(24) As Integer
        Dim disableNum As Integer = 0

        For Each Pair In allPiecesDict
            disableArray(disableNum) = Pair.Key
            disableNum += 1
        Next
        If (turnColor = "white") Then
            For Each Pair In allPiecesDict
                If (thirdPhase) Then
                    If (Pair.Value = "empty") Then
                        enableArray(enableNum) = Pair.Key
                        enableNum += 1
                    End If
                Else
                    If (Pair.Value = "white") Then
                        For Each num In adjacentElements(Pair.Key - 1)
                            If (allPiecesDict(num) = "empty") Then
                                enableArray(enableNum) = Pair.Key
                                enableNum += 1
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
        Else
            For Each Pair In allPiecesDict
                If (thirdPhase) Then
                    If (Pair.Value = "empty") Then
                        enableArray(enableNum) = Pair.Key
                        enableNum += 1
                    End If
                Else
                    If (Pair.Value = "black") Then
                        For Each num In adjacentElements(Pair.Key - 1)
                            If (allPiecesDict(num) = "empty") Then
                                enableArray(enableNum) = Pair.Key
                                enableNum += 1
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
        End If
        If (enableNum = 0) Then
            gameIsOver = True
            stateOfGame()
            Return
        End If

        toMove = True

        Buttons.enableOrDisableButtons(disableArray, False)
        Buttons.enableOrDisableButtons(enableArray, True)
    End Sub

    Public Sub phaseTwoPlaceMid(ByRef theButton As Button, ByVal buttonNum As Integer)
        'Called after a player selects a piece to move
        'Enables the empty spaces adjacent to the piece that they selected, marks the selected button as empty
        '
        Dim enableArray(24) As Integer
        Dim enableNum As Integer = 0
        Dim disableArray(24) As Integer
        Dim disableNum As Integer = 0

        For Each num In adjacentElements(buttonNum - 1)
            If (allPiecesDict(num) = "empty") Then
                enableArray(enableNum) = num
                enableNum += 1
            End If
        Next

        For Each Pair In allPiecesDict
            If (Pair.Value = "black" Or Pair.Value = "white") Then
                disableArray(disableNum) = Pair.Key
                disableNum += 1
            End If
        Next

        Buttons.enableOrDisableButtons(enableArray, True)
        Buttons.enableOrDisableButtons(disableArray, False)
        toMove = False
        moveEnabled = True
        theButton.BackColor = Color.Empty
        allPiecesDict(buttonNum) = "empty"
    End Sub

    Public Sub phaseTwoPlaceEnd(ByRef theButton As Button, ByVal buttonNum As Integer)
        'Takes care of color changes and enabling/disabling for the move
        If (turnColor = "white") Then
            theButton.BackColor = Color.White
            allPiecesDict(buttonNum) = "white"
        Else
            theButton.BackColor = Color.Black
            allPiecesDict(buttonNum) = "black"
        End If
        theButton.Enabled = False
    End Sub

    Public Function getTurnNum()
        Return turnCounter
    End Function

    Public Function getTurnColor()
        Return turnColor
    End Function

    Public Function getWhitePiecesNum()
        Return whitePieces
    End Function

    Public Function getBlackPiecesNum()
        Return blackPieces
    End Function

    Public Sub removeWhitePiece()
        whitePieces -= 1
    End Sub

    Public Sub addWhitePiece()
        whitePieces += 1
    End Sub

    Public Sub removeBlackPiece()
        blackPieces -= 1
    End Sub

    Public Sub addBlackPiece()
        blackPieces += 1
    End Sub

    Public Sub gameOver()
        gameIsOver = True
    End Sub

    Public Function toMoveStatus()
        Return toMove
    End Function

    Public Function moveEnabledStatus()
        Return moveEnabled
    End Function

    Public Function allPiecesPlacedStatus()
        Return allPiecesPlaced
    End Function

    Public Sub allPlaced()
        allPiecesPlaced = True
    End Sub

    Public Function isThirdPhase()
        If (turnCounter > 18 And (whitePieces <= 3 Or blackPieces <= 3)) Then
            thirdPhase = True
            Return True
        End If
        Return False
    End Function

    'determine if game is over, disables all buttons
    Public Function stateOfGame() As Boolean
        If (whitePieces < 3 Or blackPieces < 3 Or gameIsOver) Then
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
