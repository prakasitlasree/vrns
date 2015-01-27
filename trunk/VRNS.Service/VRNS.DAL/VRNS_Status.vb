'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Namespace EntityModel
    <Serializable()> _
    Partial Public Class VRNS_Status
        #Region "Primitive Properties"
    
        Public Overridable Property CODE As Integer
    
        Public Overridable Property DESCRIPTION As String
    
        Public Overridable Property LAST_UPD As Nullable(Of Date)
    
        Public Overridable Property LAST_UPD_LOGIN As String
    
        Public Overridable Property LAST_UPD_DISPLAY_NM As String

        #End Region
        #Region "Navigation Properties"
        Public Overridable Property VRNS_Device_Registered As ICollection(Of VRNS_Device_Registered)
            Get
                If _vRNS_Device_Registered Is Nothing Then
                    Dim newCollection As New FixupCollection(Of VRNS_Device_Registered)
                    AddHandler newCollection.CollectionChanged, AddressOf FixupVRNS_Device_Registered
                    _vRNS_Device_Registered = newCollection
                End If
                Return _vRNS_Device_Registered
            End Get
            Set(ByVal value As ICollection(Of VRNS_Device_Registered))
                If _vRNS_Device_Registered IsNot value Then
                    Dim previousValue As FixupCollection(Of VRNS_Device_Registered) = TryCast(_vRNS_Device_Registered, FixupCollection(Of VRNS_Device_Registered))
                    If previousValue IsNot Nothing Then
                        RemoveHandler previousValue.CollectionChanged, AddressOf FixupVRNS_Device_Registered
                    End If
                    _vRNS_Device_Registered = value
                    Dim newValue As FixupCollection(Of VRNS_Device_Registered) = TryCast(value, FixupCollection(Of VRNS_Device_Registered))
                    If newValue IsNot Nothing Then
                        AddHandler newValue.CollectionChanged, AddressOf FixupVRNS_Device_Registered
                    End If
                End If
            End Set
        End Property
        Private _vRNS_Device_Registered As ICollection(Of VRNS_Device_Registered)

        #End Region
        #Region "Association Fixup"
        Private Sub FixupVRNS_Device_Registered(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If e.NewItems IsNot Nothing Then
                For Each item As VRNS_Device_Registered In e.NewItems
                    item.VRNS_Status = Me
                Next
            End If
            If e.OldItems IsNot Nothing Then
                For Each item As VRNS_Device_Registered In e.OldItems
                    If item.VRNS_Status Is Me Then
                        item.VRNS_Status = Nothing
                    End If
                Next
            End If
        End Sub

        #End Region
    End Class
End Namespace
