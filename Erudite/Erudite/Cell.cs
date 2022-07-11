using System.Drawing;

namespace Erudite
{
    /// <summary>Тип ячейки</summary>
    public enum CellType
    {
        White,  // x1
        Gray,   // x1
        Green,  // x2
        Blue,   // all x2
        Yellow, // x3
        Red     // all x3
    }

    /// <summary>Ячейка</summary>
    public class Cell
    {
        /// <summary>Тип ячейки</summary>
        public CellType CellType;

        /// <summary>Прямоугольник, в котором отображается ячейка</summary>
        public Rectangle Rectangle;

        /// <summary>Буква, которую содержит ячейка</summary>
        private Letter m_letter;

        /// <summary>Буква, которую содержит ячейка</summary>
        public Letter Letter
        {
            set
            {
                m_letter = value;
                if (m_letter != null)
                {
                    m_letter.Rectangle = Rectangle;
                }
            }
            get
            {
                return m_letter;
            }
        }

        /// <summary>Наведён ли курсор мыши на ячейку</summary>
        public bool IsEntered;

        /// <summary>Создаёт ячейку</summary>
        /// <param name="cell_type">Тип ячейки</param>
        public Cell(CellType cell_type = CellType.White)
        {
            CellType = cell_type;
            Letter = null;
            IsEntered = false;
        }
    }
}
