using System;
using System.Drawing;

namespace Erudite
{
    /// <summary>Тип буквы</summary>
    public enum LetterType
    {
        /// <summary>Буква находится у игрока</summary>
        Player,

        /// <summary>Букву находится на поле (но ещё не проверена)</summary>
        Board,

        /// <summary>Букву находится на поле (уже проверена, входит в состав слова)</summary>
        Fixed
    }

    /// <summary>Буква</summary>
    public class Letter
    {
        /// <summary>Тип буквы</summary>
        public LetterType LetterType;

        /// <summary>Символ, соответствующий букве</summary>
        private char m_symbol;

        /// <summary>Символ, соответствующий букве</summary>
        public char Symbol
        {
            get
            {
                return m_symbol;
            }
        }

        /// <summary>Количество очков за букву</summary>
        public int Points;

        /// <summary>Прямоугольник, в котором отображается буква</summary>
        public Rectangle Rectangle;

        /// <summary>Находится ли буква в подтверждённом состоянии на поле (в этом случае она является частью правильного слова)</summary>
        public bool IsConfirmed;

        /// <summary>Передвигает ли игрок букву в данный момент</summary>
        public bool IsMoving;

        /// <summary>Создаёт букву</summary>
        /// <param name="symbol">Символ, соответствующий букве</param>
        /// <param name="cell">Ячейка, в которой будет располагаться буква (если null - то пока что нигде не расположена)</param>
        public Letter(char symbol, Cell cell = null)
        {
            LetterType = LetterType.Player; // при создании ячейка всегда будет у игрока

            m_symbol = symbol;
            if (m_symbol == 'А') Points = 1;
            else if (m_symbol == 'Б') Points = 3;
            else if (m_symbol == 'В') Points = 2;
            else if (m_symbol == 'Г') Points = 3;
            else if (m_symbol == 'Д') Points = 2;
            else if (m_symbol == 'Е') Points = 1;
            else if (m_symbol == 'Ё') Points = 5;
            else if (m_symbol == 'Ж') Points = 5;
            else if (m_symbol == 'З') Points = 5;
            else if (m_symbol == 'И') Points = 1;
            else if (m_symbol == 'Й') Points = 2;
            else if (m_symbol == 'К') Points = 2;
            else if (m_symbol == 'Л') Points = 2;
            else if (m_symbol == 'М') Points = 2;
            else if (m_symbol == 'Н') Points = 1;
            else if (m_symbol == 'О') Points = 1;
            else if (m_symbol == 'П') Points = 2;
            else if (m_symbol == 'Р') Points = 2;
            else if (m_symbol == 'С') Points = 2;
            else if (m_symbol == 'Т') Points = 2;
            else if (m_symbol == 'У') Points = 3;
            else if (m_symbol == 'Ф') Points = 10;
            else if (m_symbol == 'Х') Points = 5;
            else if (m_symbol == 'Ц') Points = 10;
            else if (m_symbol == 'Ч') Points = 5;
            else if (m_symbol == 'Ш') Points = 10;
            else if (m_symbol == 'Щ') Points = 10;
            else if (m_symbol == 'Ъ') Points = 10;
            else if (m_symbol == 'Ы') Points = 5;
            else if (m_symbol == 'Ь') Points = 5;
            else if (m_symbol == 'Э') Points = 10;
            else if (m_symbol == 'Ю') Points = 10;
            else if (m_symbol == 'Я') Points = 3;

            if (cell != null)
            {
                Rectangle = new Rectangle(cell.Rectangle.Location, cell.Rectangle.Size); // копируем прямоугольник ячейки в прямоугольник буквы (теперь буква лежит там же, где и ячейка cell)
            }
        }

        /// <summary>Возвращает случайную букву</summary>
        /// <param name="random">Ключ случайного числа</param>
        /// <returns>Буква</returns>
        public static Letter GetRandomLetter(Random random)
        {
            int value = random.Next(0, 132);
            if (value >= 0 && value < 10) return new Letter('А');
            else if (value >= 10 && value < 13) return new Letter('Б');
            else if (value >= 13 && value < 18) return new Letter('В');
            else if (value >= 18 && value < 21) return new Letter('Г');
            else if (value >= 21 && value < 26) return new Letter('Д');
            else if (value >= 26 && value < 35) return new Letter('Е');
            else if (value >= 35 && value < 38) return new Letter('Ё');
            else if (value >= 38 && value < 40) return new Letter('Ж');
            else if (value >= 40 && value < 42) return new Letter('З');
            else if (value >= 42 && value < 50) return new Letter('И');
            else if (value >= 50 && value < 54) return new Letter('Й');
            else if (value >= 54 && value < 60) return new Letter('К');
            else if (value >= 60 && value < 64) return new Letter('Л');
            else if (value >= 64 && value < 69) return new Letter('М');
            else if (value >= 69 && value < 77) return new Letter('Н');
            else if (value >= 77 && value < 87) return new Letter('О');
            else if (value >= 87 && value < 93) return new Letter('П');
            else if (value >= 93 && value < 99) return new Letter('Р');
            else if (value >= 99 && value < 105) return new Letter('С');
            else if (value >= 105 && value < 110) return new Letter('Т');
            else if (value >= 110 && value < 113) return new Letter('У');
            else if (value >= 113 && value < 114) return new Letter('Ф');
            else if (value >= 114 && value < 116) return new Letter('Х');
            else if (value >= 116 && value < 117) return new Letter('Ц');
            else if (value >= 117 && value < 119) return new Letter('Ч');
            else if (value >= 119 && value < 120) return new Letter('Ш');
            else if (value >= 120 && value < 121) return new Letter('Щ');
            else if (value >= 121 && value < 122) return new Letter('Ъ');
            else if (value >= 122 && value < 124) return new Letter('Ы');
            else if (value >= 124 && value < 126) return new Letter('Ь');
            else if (value >= 126 && value < 127) return new Letter('Э');
            else if (value >= 127 && value < 128) return new Letter('Ю');
            else if (value >= 128 && value < 131) return new Letter('Я');
            else return new Letter('О');
        }
    }
}
