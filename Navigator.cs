namespace SpiralArray
{
    class Navigator
    {

        private Mode mode;

        public Navigator(int columnLength, int rowLength)
        {
            CurrentCell = new Cell() { RowIndex = 0, ColumnIndex = 0 };
            maxRowIndex = rowLength - 1;
            maxColumnIndex = columnLength - 1;
            mode = Mode.IncrementRow;
        }

        public Mode SwitchMode()
        {
            mode = GetNextMode(mode);
            return mode;
        }

        public Cell CurrentCell { get; }
        public int maxColumnIndex;
        public int maxRowIndex;
        public int minColumnIndex;
        public int minRowIndex;

        public Cell GetNextCell()
        {
            Cell nextCell = GetNextCellInternal();

            var isBorderReached = IsBorderReached();
            if (isBorderReached)
            {
                UpdateBoundaries();
                SwitchMode();
            }

            return nextCell;
        }

        private Mode GetNextMode(Mode item)
        {
            Mode nextMode = Mode.None;

            if (item == Mode.None)
            {
                nextMode = Mode.IncrementRow;
            }
            else if (item == Mode.IncrementRow)
            {
                nextMode = Mode.IncrementColumn;
            }
            else if (item == Mode.IncrementColumn)
            {
                nextMode = Mode.DecrementRow;
            }
            else if (item == Mode.DecrementRow)
            {
                nextMode = Mode.DecrementColumn;
            }
            else if (item == Mode.DecrementColumn)
            {
                nextMode = Mode.IncrementRow;
            }

            return nextMode;
        }

        private bool IsBorderReached()
        {
            var isBorderReached =
                (mode == Mode.IncrementRow
                    && CurrentCell.RowIndex == maxRowIndex)
                || (mode == Mode.IncrementColumn
                    && CurrentCell.ColumnIndex == maxColumnIndex)
                || (mode == Mode.DecrementRow
                    && CurrentCell.RowIndex == minRowIndex)
                || (mode == Mode.DecrementColumn
                    && CurrentCell.ColumnIndex == minColumnIndex);

            return isBorderReached;
        }

        private void UpdateBoundaries()
        {
            if (mode == Mode.IncrementRow)
            {
                minColumnIndex++;
            }
            else if (mode == Mode.IncrementColumn)
            {
                maxRowIndex--;
            }
            else if (mode == Mode.DecrementRow)
            {
                maxColumnIndex--;
            }
            else if (mode == Mode.DecrementColumn)
            {
                minRowIndex++;
            }
        }

        private Cell GetNextCellInternal()
        {
            Cell nextCell = new Cell();
            if (mode == Mode.IncrementRow)
            {
                nextCell.RowIndex = CurrentCell.RowIndex++;
                nextCell.ColumnIndex = CurrentCell.ColumnIndex;
            }
            else if (mode == Mode.IncrementColumn)
            {
                nextCell.RowIndex = CurrentCell.RowIndex;
                nextCell.ColumnIndex = CurrentCell.ColumnIndex++;
            }
            else if (mode == Mode.DecrementRow)
            {
                nextCell.RowIndex = CurrentCell.RowIndex--;
                nextCell.ColumnIndex = CurrentCell.ColumnIndex;
            }
            else if (mode == Mode.DecrementColumn)
            {
                nextCell.RowIndex = CurrentCell.RowIndex;
                nextCell.ColumnIndex = CurrentCell.ColumnIndex--;
            }

            return nextCell;
        }
    }
}
