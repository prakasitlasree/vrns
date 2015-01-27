Namespace VRNS_Service

    Partial Class ProjectInstaller
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.serviceProcessInstaller1 = New System.ServiceProcess.ServiceProcessInstaller()
            Me.serviceInstaller1 = New System.ServiceProcess.ServiceInstaller()


            Me.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem
            Me.serviceProcessInstaller1.Password = Nothing
            Me.serviceProcessInstaller1.Username = Nothing

            Me.serviceInstaller1.ServiceName = "VRNS_Service"
            Me.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic

            Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.serviceProcessInstaller1, Me.serviceInstaller1})

        End Sub

#End Region
    End Class
End Namespace