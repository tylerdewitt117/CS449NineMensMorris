Public Class Player
    Inherits Gameplay

    Private thirdPhase As Boolean = False
    Private toMove As Boolean = False
    Private moveEnabled As Boolean = False

    Public Sub phaseOnePlace(ByRef theButton As Button, ByVal buttonNum As Integer)

        'function for phase 1 piece placing - places a correctly colored piece on the board, disables it, incrememts number of corresponding pieces and adds button color to pieces dictionary

        theButton.BackColor = Color.White
        theButton.Enabled = False
        playerPieces += 1
        allPiecesDict(buttonNum) = "white"

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
        For Each Pair In allPiecesDict
            If (thirdPhase) Then
                If (Pair.Value = "empty") Then
                    enableArray(enableNum) = Pair.Key
                    enableNum += 1
                End If
            Else
                If (Pair.Value = "player") Then
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
        theButton.BackColor = Color.White
        allPiecesDict(buttonNum) = "player"

        theButton.Enabled = False
    End Sub

    Public Function toMoveStatus()
        Return toMove
    End Function

    Public Function moveEnabledStatus()
        Return moveEnabled
    End Function

    Public Function isThirdPhase()
        If (turnCounter > 18 And playerPieces <= 3) Then
            thirdPhase = True
            Return True
        End If
        Return False
    End Function
End Class
