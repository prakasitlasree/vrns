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
    Partial Public Class VRNS_Device_Registered
        #Region "Primitive Properties"
    
        Public Overridable Property ID As Long
    
        Public Overridable Property BRANCH_CODE As String
    
        Public Overridable Property LAN_IP As String
    
        Public Overridable Property ISP As String
    
        Public Overridable Property Cur_Status_CODE As Nullable(Of Integer)
            Get
                Return _cur_Status_CODE
            End Get
            Set(ByVal value As Nullable(Of Integer))
                Try
                    _settingFK = True
                    If Not Equals (_cur_Status_CODE, value) Then
                        If VRNS_Status IsNot Nothing AndAlso Not Equals(VRNS_Status.CODE, value) Then
                            VRNS_Status = Nothing
                        End If
                        _cur_Status_CODE = value
                    End If
                Finally
                    _settingFK = False
                End Try
            End Set
        End Property
        Private _cur_Status_CODE As Nullable(Of Integer)
    
        Public Overridable Property Cur_Status_UPD As Nullable(Of Date)
    
        Public Overridable Property Cur_Status_F As Nullable(Of Boolean)
    
        Public Overridable Property Prev_Status_CODE As Nullable(Of Integer)
    
        Public Overridable Property Prev_Status_UPD As Nullable(Of Date)
    
        Public Overridable Property LAST_UPD As Nullable(Of Date)
    
        Public Overridable Property LAST_UPD_LOGIN As String
    
        Public Overridable Property LAST_UPD_DISPLAY_NM As String

        #End Region
        #Region "Navigation Properties"
    
        Public Overridable Property VRNS_Status As VRNS_Status
            Get
                Return _vRNS_Status
            End Get
            Set(ByVal value As VRNS_Status)
                If _vRNS_Status IsNot value Then
                    Dim previousValue As VRNS_Status = _vRNS_Status
                    _vRNS_Status = value
                    FixupVRNS_Status(previousValue)
                End If
            End Set
        End Property
        Private _vRNS_Status As VRNS_Status
        Public Overridable Property VRNS_Maintainance_Record As ICollection(Of VRNS_Maintainance_Record)
            Get
                If _vRNS_Maintainance_Record Is Nothing Then
                    Dim newCollection As New FixupCollection(Of VRNS_Maintainance_Record)
                    AddHandler newCollection.CollectionChanged, AddressOf FixupVRNS_Maintainance_Record
                    _vRNS_Maintainance_Record = newCollection
                End If
                Return _vRNS_Maintainance_Record
            End Get
            Set(ByVal value As ICollection(Of VRNS_Maintainance_Record))
                If _vRNS_Maintainance_Record IsNot value Then
                    Dim previousValue As FixupCollection(Of VRNS_Maintainance_Record) = TryCast(_vRNS_Maintainance_Record, FixupCollection(Of VRNS_Maintainance_Record))
                    If previousValue IsNot Nothing Then
                        RemoveHandler previousValue.CollectionChanged, AddressOf FixupVRNS_Maintainance_Record
                    End If
                    _vRNS_Maintainance_Record = value
                    Dim newValue As FixupCollection(Of VRNS_Maintainance_Record) = TryCast(value, FixupCollection(Of VRNS_Maintainance_Record))
                    If newValue IsNot Nothing Then
                        AddHandler newValue.CollectionChanged, AddressOf FixupVRNS_Maintainance_Record
                    End If
                End If
            End Set
        End Property
        Private _vRNS_Maintainance_Record As ICollection(Of VRNS_Maintainance_Record)

        #End Region
        #Region "Association Fixup"
        Private _settingFK As Boolean = False
    
        Private Sub FixupVRNS_Status(ByVal previousValue As VRNS_Status)
            If previousValue IsNot Nothing AndAlso previousValue.VRNS_Device_Registered.Contains(Me) Then
                previousValue.VRNS_Device_Registered.Remove(Me)
            End If
            If VRNS_Status IsNot Nothing Then
                If Not VRNS_Status.VRNS_Device_Registered.Contains(Me) Then
                    VRNS_Status.VRNS_Device_Registered.Add(Me)
                End If
                If Not Equals(Cur_Status_CODE, VRNS_Status.CODE) Then
                    Cur_Status_CODE = VRNS_Status.CODE
                End If
            ElseIf Not _settingFK Then
                Cur_Status_CODE = Nothing
            End If
        End Sub
        Private Sub FixupVRNS_Maintainance_Record(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If e.NewItems IsNot Nothing Then
                For Each item As VRNS_Maintainance_Record In e.NewItems
                    item.VRNS_Device_Registered = Me
                Next
            End If
            If e.OldItems IsNot Nothing Then
                For Each item As VRNS_Maintainance_Record In e.OldItems
                    If item.VRNS_Device_Registered Is Me Then
                        item.VRNS_Device_Registered = Nothing
                    End If
                Next
            End If
        End Sub

        #End Region
    End Class
End Namespace
