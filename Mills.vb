Public Class Mills

    Private button1Int As Integer = -1
    Private button2Int As Integer = -1
    Private button3Int As Integer = -1

    Private playerMillsNum As Integer = 0
    Private aiMillsNum As Integer = 0

    Private playerMillsDict As New Dictionary(Of Integer, Boolean) From {{1, False}, {2, False}, {3, False}, {4, False}, {5, False}, {6, False}, {7, False}, {8, False}, {9, False}, {10, False}, {11, False}, {12, False}, {13, False}, {14, False}, {15, False}, {16, False}, {17, False}, {18, False}, {19, False}, {20, False}, {21, False}, {22, False}, {23, False}, {24, False}}
    Private aiMillsDict As New Dictionary(Of Integer, Boolean) From {{1, False}, {2, False}, {3, False}, {4, False}, {5, False}, {6, False}, {7, False}, {8, False}, {9, False}, {10, False}, {11, False}, {12, False}, {13, False}, {14, False}, {15, False}, {16, False}, {17, False}, {18, False}, {19, False}, {20, False}, {21, False}, {22, False}, {23, False}, {24, False}}

    Private possibleMills(,,) As Integer = {{{1, 2, 3}, {1, 10, 22}}, {{2, 1, 3}, {2, 5, 8}}, {{3, 1, 2}, {3, 15, 24}}, {{4, 5, 6}, {4, 11, 19}}, {{5, 4, 6}, {5, 2, 8}}, {{6, 4, 5}, {6, 14, 21}}, {{7, 8, 9}, {7, 12, 16}}, {{8, 7, 9}, {8, 2, 5}}, {{9, 13, 18}, {9, 7, 8}}, {{10, 11, 12}, {10, 1, 22}}, {{11, 10, 12}, {11, 4, 19}}, {{12, 10, 11}, {12, 7, 16}}, {{13, 14, 15}, {13, 9, 18}}, {{14, 13, 15}, {14, 6, 21}}, {{15, 13, 14}, {15, 3, 24}}, {{16, 17, 18}, {16, 7, 12}}, {{17, 16, 18}, {17, 20, 23}}, {{18, 16, 17}, {18, 9, 13}}, {{19, 20, 21}, {19, 4, 11}}, {{20, 19, 21}, {20, 17, 23}}, {{21, 19, 20}, {21, 6, 14}}, {{22, 23, 24}, {22, 1, 10}}, {{23, 22, 24}, {23, 17, 20}}, {{24, 22, 23}, {24, 3, 15}}}

    Private millToHandle = False

    Public Function isMill(ByVal buttonIntOne As Integer, ByVal buttonIntTwo As Integer, ByVal buttonIntThree As Integer)
        Dim isAMill As Boolean = False
        'Checks to see if the potential mill buttons are a mill
        'I can probably implement this and millCheck() more efficiently, but I'll save that for later

        If (Buttons.theGame.allPiecesDict(buttonIntOne) = "player" AndAlso Buttons.theGame.allPiecesDict(buttonIntTwo) = "player" AndAlso Buttons.theGame.allPiecesDict(buttonIntThree) = "player") Then

            button1Int = buttonIntOne
            button2Int = buttonIntTwo
            button3Int = buttonIntThree
            isAMill = True

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

            If (playerMillsDict(button1Int) = False) Then
                playerMillsDict(button1Int) = True
                playerMillsNum += 1
            End If
            If (playerMillsDict(button2Int) = False) Then
                playerMillsDict(button2Int) = True
                playerMillsNum += 1
            End If
            If (playerMillsDict(button3Int) = False) Then
                playerMillsDict(button3Int) = True
                playerMillsNum += 1
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
        For Each Pair In Buttons.theGame.allPiecesDict
            If (Pair.Value = "ai") Then
                enableArray(enableSize) = Pair.Key
                enableSize += 1
            Else
                disableArray(disableSize) = Pair.Key
                disableSize += 1
            End If
        Next

        'If not all of the opponent's pieces are in a mill, disable the ones that are currently in a mill
        If (enableSize <> aiMillsNum) Then
                For Each Pair In aiMillsDict
                    disableArray(disableSize) = Pair.Key
                    disableSize += 1
                Next
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

        Buttons.theGame.allPiecesDict(buttonNum) = "empty"
        Buttons.theGame.removePlayerPiece()
        Buttons.theAI.thirdPhaseCheck()


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


        For Each Pair In Buttons.theGame.allPiecesDict
                If (Pair.Value = "ai") Then
                    disableArray(disableSize) = Pair.Key
                    disableSize += 1
                ElseIf (Pair.Value = "empty" AndAlso Buttons.theGame.allPiecesPlacedStatus() = False) Then
                    enableArray(enableSize) = Pair.Key
                    enableSize += 1
                End If
            Next
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
            aiMillsDict(num1) = False
            If (isMill(num2, possibleMills(num2, 0, 1), possibleMills(num2, 0, 2)) = False And isMill(num2, possibleMills(num2, 1, 1), possibleMills(num2, 1, 2)) = False) Then
                aiMillsDict(num2) = False
            End If
                If (isMill(num3, possibleMills(num3, 0, 1), possibleMills(num3, 0, 2)) = False And isMill(num3, possibleMills(num3, 1, 1), possibleMills(num3, 1, 2)) = False) Then
                aiMillsDict(num3) = False
            End If

            End If
    End Sub

    Public Function isMillAI(ByVal spaceNum As Integer, ByVal player As String)
        Dim numMills As Integer = 0
        Dim i As Integer
        For i = 0 To 1 Step 1
            If (player = "ai") Then
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) = "ai" AndAlso Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) = "ai" AndAlso Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) = "ai") Then
                    numMills += 1
                    aiMillsDict(possibleMills(spaceNum - 1, i, 0)) = True
                    aiMillsDict(possibleMills(spaceNum - 1, i, 1)) = True
                    aiMillsDict(possibleMills(spaceNum - 1, i, 2)) = True
                End If
            Else
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) = "player" AndAlso Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) = "player" AndAlso Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) = "player") Then
                    numMills += 1
                    playerMillsDict(possibleMills(spaceNum - 1, i, 0)) = True
                    playerMillsDict(possibleMills(spaceNum - 1, i, 1)) = True
                    playerMillsDict(possibleMills(spaceNum - 1, i, 2)) = True
                End If
            End If
        Next
        Return numMills
    End Function

    Public Function isAlmostMill(ByVal spaceNum As Integer, ByVal player As String)
        Dim numAlmostMills As Integer = 0
        Dim i As Integer
        For i = 0 To 1 Step 1
            If (player = "ai") Then
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) = "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) = "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) <> "ai") Then
                    numAlmostMills += 1
                End If
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) = "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) <> "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) = "ai") Then
                    numAlmostMills += 1
                End If
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) <> "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) = "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) = "ai") Then
                    numAlmostMills += 1
                End If
            Else
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) = "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) = "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) <> "player") Then
                    numAlmostMills += 1
                End If
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) = "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) <> "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) = "player") Then
                    numAlmostMills += 1
                End If
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) <> "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) = "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) = "player") Then
                    numAlmostMills += 1
                End If
            End If
        Next
        Return numAlmostMills
    End Function

    Public Function isAlmostAlmostMill(ByVal spaceNum As Integer, ByVal player As String)
        Dim numAlmostMills As Integer = 0
        Dim i As Integer
        For i = 0 To 1 Step 1
            If (player = "ai") Then
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) = "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) <> "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) <> "ai") Then
                    numAlmostMills += 1
                End If
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) <> "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) <> "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) = "ai") Then
                    numAlmostMills += 1
                End If
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) <> "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) = "ai" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) <> "ai") Then
                    numAlmostMills += 1
                End If
            Else
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) = "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) <> "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) <> "player") Then
                    numAlmostMills += 1
                End If
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) <> "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) <> "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) = "player") Then
                    numAlmostMills += 1
                End If
                If (Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 0)) <> "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 1)) = "player" And Buttons.theGame.allPiecesDict(possibleMills(spaceNum - 1, i, 2)) <> "player") Then
                    numAlmostMills += 1
                End If
            End If
        Next
        Return numAlmostMills
    End Function

    Public Sub aiMillCheck(ByVal spaceNum)
        Dim numMills As Integer = isMillAI(spaceNum, "ai")
        Dim i As Integer
        Dim highestPriorityButton As Integer
        Dim highestPriorityNum As Double = 0
        Dim numInMill = 0
        If (numMills > 0) Then
            For i = 1 To 24 Step 1
                If (Buttons.theGame.allPiecesDict(i) = "player" And isMillAI(i, "player") = 0) Then
                    Dim almostMillsPlayer = isAlmostMill(i, "player")
                    Dim almostAlmostMillsPlayer = isAlmostAlmostMill(i, "player")
                    Dim priority = (almostMillsPlayer * 1) + (almostAlmostMillsPlayer * 0.25)
                    If (priority >= highestPriorityNum) Then
                        highestPriorityButton = i
                        highestPriorityNum = priority
                    End If
                ElseIf (Buttons.theGame.allPiecesDict(i) = "player") Then
                    numInMill += 1
                End If
            Next
            If (numMills = Buttons.theGame.getPlayerPiecesNum()) Then
                For i = 1 To 24 Step 1
                    If (Buttons.theGame.allPiecesDict(i) = "player") Then
                        Dim almostMillsPlayer = isAlmostMill(i, "player")
                        Dim almostAlmostMillsPlayer = isAlmostAlmostMill(i, "player")
                        Dim priority = (almostMillsPlayer * 1) + (almostAlmostMillsPlayer * 0.25)
                        If (priority >= highestPriorityNum) Then
                            highestPriorityButton = i
                            highestPriorityNum = priority
                        End If
                    End If
                Next
            End If
            Buttons.aiButtons(highestPriorityButton, "False")
            Buttons.thePlayer.removePlayerPiece()
            playerMillsDict(highestPriorityButton) = False
            Buttons.thePlayer.isThirdPhase()
            removeMillAI(highestPriorityButton)
        End If

    End Sub

    Public Sub removeMillAI(ByVal buttonNum As Integer)
        Dim result = isMillAI(buttonNum, "player")
        If (result = 0) Then
            Dim num1 = possibleMills(buttonNum - 1, 0, 1)
            Dim num2 = possibleMills(buttonNum - 1, 0, 2)
            Dim num3 = possibleMills(buttonNum - 1, 1, 1)
            Dim num4 = possibleMills(buttonNum - 1, 1, 2)
            If (isMillAI(num1, "player") = 0) Then
                playerMillsDict(num1) = False
            End If
            If (isMillAI(num2, "player") = 0) Then
                playerMillsDict(num2) = False
            End If
            If (isMillAI(num3, "player") = 0) Then
                playerMillsDict(num3) = False
            End If
            If (isMillAI(num4, "player") = 0) Then
                playerMillsDict(num4) = False
            End If
        End If
    End Sub

End Class
