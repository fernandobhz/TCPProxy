Module Main

    Sub Main()

        Dim Args() = Environment.GetCommandLineArgs()

        Dim localPort As Integer
        Dim remoteHost As String
        Dim remotePort As Integer

        Select Case Args.Count
            Case 4
                localPort = Args(1)
                remoteHost = Args(2)
                remotePort = Args(3)
            Case 1
                localPort = InputBox("Local port")
                remoteHost = InputBox("Remote host")
                remotePort = InputBox("Remote port")
            Case Else
                Console.WriteLine("Usage TCPProxy localport remoteHost remotePort")
                Exit Sub
        End Select

        TCPProxy.Start(localPort, remoteHost, remotePort).Wait()
    End Sub

End Module
