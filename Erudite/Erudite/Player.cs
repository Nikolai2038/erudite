namespace Erudite
{
    /// <summary>Игрок</summary>
    public class Player
    {
        /// <summary>Имя игрока</summary>
        private string m_name;

        /// <summary>Имя игрока</summary>
        public string Name
        {
            get
            {
                return m_name;
            }
        }

        /// <summary>Количество текущих очков</summary>
        public int Points;

        /// <summary>Ячейки с буквами</summary>
        public Cell[] Cells;

        /// <summary>Создаёт игрока</summary>
        /// <param name="icon_id">ID иконки (0-3)</param>
        /// <param name="name">Имя игрока</param>
        public Player(string name)
        {
            m_name = name;

            Points = 0;

            Cells = new Cell[7];
            for (int i = 0; i < 7; i++)
            {
                Cells[i] = new Cell(CellType.White);
            }
        }
    }
}
