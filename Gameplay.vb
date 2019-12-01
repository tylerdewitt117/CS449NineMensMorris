Public Class Gameplay
    Protected turnCounter As Integer = 1
    Protected turnName As String = "player"

    Protected playerPieces As Integer = 0
    Protected aiPieces As Integer = 0

    Protected gameIsOver As Boolean = False
    Protected allPiecesPlaced As Boolean = False



    Protected adjacentElements()() As Integer = {
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
        If (turnName = "player") Then
            turnName = "ai"
        Else
            turnName = "player"
        End If
        turnCounter += 1
    End Sub


    Public Function getTurnNum()
        Return turnCounter
    End Function

    Public Function getTurnName()
        Return turnName
    End Function

    Public Function getPlayerPiecesNum()
        Return playerPieces
    End Function

    Public Function getAiPiecesNum()
        Return aiPieces
    End Function

    Public Sub removePlayerPiece()
        playerPieces -= 1
    End Sub

    Public Sub addPlayerPiece()
        playerPieces += 1
    End Sub

    Public Sub removeAiPiece()
        aiPieces -= 1
    End Sub

    Public Sub addAiPiece()
        aiPieces += 1
    End Sub

    Public Sub gameOver()
        gameIsOver = True
    End Sub

    Public Function allPiecesPlacedStatus()
        Return allPiecesPlaced
    End Function

    Public Sub allPlaced()
        allPiecesPlaced = True
    End Sub

    'determine if game is over, disables all buttons
    Public Function stateOfGame() As Boolean
        If (playerPieces < 3 Or aiPieces < 3 Or gameIsOver) Then
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
