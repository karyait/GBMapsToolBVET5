Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media

Namespace WpfControlLibrary1
    Public NotInheritable Class DataGridExtensions
        Private Sub New()
        End Sub
        Public Shared Sub SelectRowByIndex(dataGrid As DataGrid, rowIndex As Integer)
            If Not dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.FullRow) Then
                Throw New ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.")
            End If

            If rowIndex < 0 OrElse rowIndex > (dataGrid.Items.Count - 1) Then
                Throw New ArgumentException(String.Format("{0} is an invalid row index.", rowIndex))
            End If

            dataGrid.SelectedItems.Clear()
            ' set the SelectedItem property 

            Dim item As Object = dataGrid.Items(rowIndex)
            ' = Product X
            dataGrid.SelectedItem = item

            Dim row As DataGridRow = TryCast(dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex), DataGridRow)
            If row Is Nothing Then
                ' bring the data item (Product object) into view
                '                 * in case it has been virtualized away 

                dataGrid.ScrollIntoView(item)
                row = TryCast(dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex), DataGridRow)
            End If
            If row IsNot Nothing Then
                Dim cell As DataGridCell = GetCell(dataGrid, row, 0)
                If cell IsNot Nothing Then
                    cell.Focus()
                End If
            End If

        End Sub

        Public Shared Function GetCell(dataGrid As DataGrid, rowContainer As DataGridRow, column As Integer) As DataGridCell
            If rowContainer IsNot Nothing Then
                Dim presenter As DataGridCellsPresenter = FindVisualChild(Of DataGridCellsPresenter)(rowContainer)
                If presenter Is Nothing Then
                    ' if the row has been virtualized away, call its ApplyTemplate() method 
                    '                     * to build its visual tree in order for the DataGridCellsPresenter
                    '                     * and the DataGridCells to be created 

                    rowContainer.ApplyTemplate()
                    presenter = FindVisualChild(Of DataGridCellsPresenter)(rowContainer)
                End If
                If presenter IsNot Nothing Then
                    Dim cell As DataGridCell = TryCast(presenter.ItemContainerGenerator.ContainerFromIndex(column), DataGridCell)
                    If cell Is Nothing Then
                        ' bring the column into view
                        '                         * in case it has been virtualized away 

                        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns(column))
                        cell = TryCast(presenter.ItemContainerGenerator.ContainerFromIndex(column), DataGridCell)
                    End If
                    Return cell
                End If
            End If
            Return Nothing
        End Function

        Public Shared Function FindVisualChild(Of T As DependencyObject)(obj As DependencyObject) As T
            For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(obj) - 1
                Dim child As DependencyObject = VisualTreeHelper.GetChild(obj, i)
                If child IsNot Nothing AndAlso TypeOf child Is T Then
                    Return DirectCast(child, T)
                Else
                    Dim childOfChild As T = FindVisualChild(Of T)(child)
                    If childOfChild IsNot Nothing Then
                        Return childOfChild
                    End If
                End If
            Next
            Return Nothing
        End Function


    End Class
End Namespace

