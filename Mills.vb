Public Class Mills

    Private button1Int As Integer = -1
    Private button2Int As Integer = -1
    Private button3Int As Integer = -1

    Private whiteMillsNum As Integer = 0
    Private blackMillsNum As Integer = 0

    Private whiteMillsDict As New Dictionary(Of Integer, Boolean) From {{1, False}, {2, False}, {3, False}, {4, False}, {5, False}, {6, False}, {7, False}, {8, False}, {9, False}, {10, False}, {11, False}, {12, False}, {13, False}, {14, False}, {15, False}, {16, False}, {17, False}, {18, False}, {19, False}, {20, False}, {21, False}, {22, False}, {23, False}, {24, False}}
    Private blackMillsDict As New Dictionary(Of Integer, Boolean) From {{1, False}, {2, False}, {3, False}, {4, False}, {5, False}, {6, False}, {7, False}, {8, False}, {9, False}, {10, False}, {11, False}, {12, False}, {13, False}, {14, False}, {15, False}, {16, False}, {17, False}, {18, False}, {19, False}, {20, False}, {21, False}, {22, False}, {23, False}, {24, False}}

    Private possibleMills(,,) As Integer = {{{1, 2, 3}, {1, 10, 22}}, {{2, 1, 3}, {2, 5, 8}}, {{3, 1, 2}, {3, 15, 24}}, {{4, 5, 6}, {4, 11, 19}}, {{5, 4, 6}, {5, 2, 8}}, {{6, 4, 5}, {6, 14, 21}}, {{7, 8, 9}, {7, 12, 16}}, {{8, 7, 9}, {8, 2, 5}}, {{9, 13, 18}, {9, 7, 8}}, {{10, 11, 12}, {10, 1, 22}}, {{11, 10, 12}, {11, 4, 19}}, {{12, 10, 11}, {12, 7, 16}}, {{13, 14, 15}, {13, 9, 18}}, {{14, 13, 15}, {14, 6, 21}}, {{15, 13, 14}, {15, 3, 24}}, {{16, 17, 18}, {16, 7, 12}}, {{17, 16, 18}, {17, 20, 23}}, {{18, 16, 17}, {18, 9, 13}}, {{19, 20, 21}, {19, 4, 11}}, {{20, 19, 21}, {20, 17, 23}}, {{21, 19, 20}, {21, 6, 14}}, {{22, 23, 24}, {22, 1, 10}}, {{23, 22, 24}, {23, 17, 20}}, {{24, 22, 23}, {24, 3, 15}}}

    Private millToHandle = False

    Public Function isMill(ByVal buttonIntOne As Integer, ByVal buttonIntTwo As Integer, ByVal buttonIntThree As Integer)
        Dim isAMill As Boolean = False
        'Checks to see if the potential mill buttons are a mill
        'I can probably implement this and millCheck() more efficiently, but I'll save that for later

        If (Buttons.theGame.getTurnColor() = "white") Then
            If (Buttons.theGame.allPiecesDict(buttonIntOne) = "white" AndAlso Buttons.theGame.allPiecesDict(buttonIntTwo) = "white" AndAlso Buttons.theGame.allPiecesDict(buttonIntThree) = "white") Then

                button1Int = buttonIntOne
                button2Int = buttonIntTwo
                button3Int = buttonIntThree
                isAMill = True
            End If
        Else
            If (Buttons.theGame.allPiecesDict(buttonIntOne) = "black" AndAlso Buttons.theGame.allPiecesDict(buttonIntTwo) = "black" AndAlso Buttons.theGame.allPiecesDict(buttonIntThree) = "black") Then

                button1Int = buttonIntOne
                button2Int = buttonIntTwo
                button3Int = buttonIntThree
                isAMill = True
            End If
        End If
        'All values are -1 if it isn't a mill
        If (isAMill = False) Then
            button1Int = -1
            button2Int = -1
            button3Int = -1
        End If
        Return isAMill
    End Function



    Public Function millCheck(ByRef Button1 As Button, ByRef Button2 As Button, ByRef Button3 As Button, ByVal buttonOneInt As Integer, ByVal buttonTwoInt As Integer, ByVal buttonThreeInt As Integer)
        Dim isThereMill As Boolean = isMill(buttonOneInt, buttonTwoInt, buttonThreeInt)

        'Checks for mill, saves buttons #s involved, puts them into corresponding dictionary of mills
        If (button1Int > -1) Then
            millToHandle = True


            If (Buttons.theGame.getTurnColor() = "white") Then
                If (whiteMillsDict(button1Int) = False) Then
                    whiteMillsDict(button1Int) = True
                    whiteMillsNum += 1
                End If
                If (whiteMillsDict(button2Int) = False) Then
                    whiteMillsDict(button2Int) = True
                    whiteMillsNum += 1
                End If
                If (whiteMillsDict(button3Int) = False) Then
                    whiteMillsDict(button3Int) = True
                    whiteMillsNum += 1
                End If
            Else
                If (blackMillsDict(button1Int) = False) Then
                    blackMillsDict(button1Int) = True
                    blackMillsNum += 1
                End If
                If (blackMillsDict(button2Int) = False) Then
                    blackMillsDict(button2Int) = True
                    blackMillsNum += 1
                End If
                If (blackMillsDict(button3Int) = False) Then
                    blackMillsDict(button3Int) = True
                    blackMillsNum += 1
                End If
            End If
        End If
        Return isThereMill

    End Function

    Public Sub setUpMill()
        'Enables and disables the proper buttons so that a player who just formed a mill can pick an opponent's piece to remove

        Dim enableArray(24) As Integer
        Dim enableSize As Integer = 0
        Dim disableArray(24) As Integer
        Dim disableSize As Integer = 0

        'First enables all of the opponent's pieces, disables the rest
        If Buttons.theGame.getTurnColor() = "white" Then
            For Each Pair In Buttons.theGame.allPiecesDict
                If (Pair.Value = "black") Then
                    enableArray(enableSize) = Pair.Key
                    enableSize += 1
                Else
                    disableArray(disableSize) = Pair.Key
                    disableSize += 1
                End If
            Next

            'If not all of the opponent's pieces are in a mill, disable the ones that are currently in a mill
            If (enableSize <> blackMillsNum) Then
                For Each Pair In blackMillsDict
                    disableArray(disableSize) = Pair.Key
                    disableSize += 1
                Next
            End If
        Else
            For Each Pair In Buttons.theGame.allPiecesDict
                If (Pair.Value = "white") Then
                    enableArray(enableSize) = Pair.Key
                    enableSize += 1
                Else
                    disableArray(disableSize) = Pair.Key
                    disableSize += 1
                End If
            Next
            If (enableSize <> whiteMillsNum) Then
                For Each Pair In whiteMillsDict
                    If (Pair.Value = True) Then
                        disableArray(disableSize) = Pair.Key
                        disableSize += 1
                    End If

                Next
            End If
        End If
        'enable and disable the proper buttons
        Buttons.enableOrDisableButtons(enableArray, True)
        Buttons.enableOrDisableButtons(disableArray, False)
    End Sub

    Public Sub handleMill(ByRef theButton As Button, ByVal buttonNum As Integer)
        'After a player clicks the opponent's piece to remove after making a mill, the piece is made empty again
        'Change button's background color and enable it
        theButton.BackColor = Color.Empty
        theButton.Enabled = True

        'Update button's status in the pieces dictionary, decrement the white pieces variable, and check to see if the piece removal puts the game in the third phase
        If Buttons.theGame.getTurnColor() = "white" Then

            Buttons.theGame.allPiecesDict(buttonNum) = "empty"
            Buttons.theGame.removeWhitePiece()
            Buttons.theGame.isThirdPhase()
        Else

            Buttons.theGame.allPiecesDict(buttonNum) = "empty"
            Buttons.theGame.removeBlackPiece()
            Buttons.theGame.isThirdPhase()

        End If
        'Calls the tearDownMill() function automatically
        tearDownMill()
        millToHandle = False
    End Sub

    Public Sub tearDownMill()
        ''Disables the opponent's pieces and enables the empty spaces
        Dim enableArray(24) As Integer
        Dim enableSize As Integer = 0
        Dim disableArray(24) As Integer
        Dim disableSize As Integer = 0

        If Buttons.theGame.getTurnColor() = "black" Then
            For Each Pair In Buttons.theGame.allPiecesDict
                If (Pair.Value = "white") Then
                    disableArray(disableSize) = Pair.Key
                    disableSize += 1
                ElseIf (Pair.Value = "empty" AndAlso Buttons.theGame.allPiecesPlacedStatus() = False) Then
                    enableArray(enableSize) = Pair.Key
                    enableSize += 1
                End If
            Next
        Else
            For Each Pair In Buttons.theGame.allPiecesDict
                If (Pair.Value = "black") Then
                    disableArray(disableSize) = Pair.Key
                    disableSize += 1
                ElseIf (Pair.Value = "empty" AndAlso Buttons.theGame.allPiecesPlacedStatus() = False) Then
                    enableArray(enableSize) = Pair.Key
                    enableSize += 1
                End If
            Next
        End If
        Buttons.enableOrDisableButtons(disableArray, False)
        If (Buttons.theGame.allPiecesPlacedStatus() = False) Then
            Buttons.enableOrDisableButtons(enableArray, True)
        End If
    End Sub

    Public Function isMillToHandle()
        'Returns boolean on whether a button was clicked after the opponent made a mill
        Return millToHandle
    End Function

    Public Sub removeMill(ByVal num1 As Integer, ByVal num2 As Integer, ByVal num3 As Integer)
        'If a player's piece was previously in a mill and was removed, then all pieces involved are removed from the corresponding mill dictionary
        'Also takes into account whether the pieces are in a separate mill (were in a double mill)
        Dim result As Boolean = isMill(num1, num2, num3)
        If (result = False) Then
            If (Buttons.theGame.getTurnColor() = "white") Then
                whiteMillsDict(num1) = False
                If (isMill(num2, possibleMills(num2, 0, 1), possibleMills(num2, 0, 2)) = False And isMill(num2, possibleMills(num2, 1, 1), possibleMills(num2, 1, 2)) = False) Then
                    whiteMillsDict(num2) = False
                End If
                If (isMill(num3, possibleMills(num3, 0, 1), possibleMills(num3, 0, 2)) = False And isMill(num3, possibleMills(num3, 1, 1), possibleMills(num3, 1, 2)) = False) Then
                    whiteMillsDict(num3) = False
                End If
            Else
                blackMillsDict(num1) = False
                If (isMill(num2, possibleMills(num2, 0, 1), possibleMills(num2, 0, 2)) = False And isMill(num2, possibleMills(num2, 1, 1), possibleMills(num2, 1, 2)) = False) Then
                    blackMillsDict(num2) = False
                End If
                If (isMill(num3, possibleMills(num3, 0, 1), possibleMills(num3, 0, 2)) = False And isMill(num3, possibleMills(num3, 1, 1), possibleMills(num3, 1, 2)) = False) Then
                    blackMillsDict(num3) = False
                End If
            End If
        End If
    End Sub

End Class
