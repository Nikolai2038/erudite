using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Erudite
{
    /// <summary>Игровая форма</summary>
    public partial class FormGame : Form
    {
        /// <summary>Количество ячеек карты в линии (строке / столбце)</summary>
        private const int number_cells_in_line = 15;

        /// <summary>Ширина и высота ячейки</summary>
        private const int cell_length = 40;

        /// <summary>Отступ между ячейками</summary>
        private const int margin_between_cells = 2;

        /// <summary>Прямоугольник фона карты</summary>
        private Rectangle m_board_rectangle;

        /// <summary>Список всех ячеек на форме</summary>
        private List<Cell> m_cells;

        /// <summary>Массив ячеек карты</summary>
        private Cell[,] m_map_cells = new Cell[number_cells_in_line, number_cells_in_line];

        /// <summary>Лимит очков (равен -1 в случае отсутствия лимита)</summary>
        public int PointsLimit = -1;

        /// <summary>Игроки</summary>
        private Player[] m_players = new Player[4];

        /// <summary>Время с начала игры (в секундах)</summary>
        private int m_seconds_walkthrough;

        /// <summary>ID игрока, который сейчас ходит</summary>
        private int m_total_moving_player_id;

        /// <summary>Переменная для генерации случайных чисел</summary>
        private Random m_random = new Random();

        /// <summary>Текущая выбранная ячейка</summary>
        private int m_id_total_clicked_cell = -1;

        /// <summary>Было ли поставлено первое слово</summary>
        private bool m_was_first_word = false;

        /// <summary>Номер текущего хода</summary>
        private int m_total_turn;

        /// <summary>Конструктор формы</summary>
        public FormGame()
        {
            InitializeComponent();
        }

        /// <summary>Событие загрузки формы</summary>
        private void FormGame_Load(object sender, EventArgs e)
        {
            m_cells = new List<Cell>(); // список всех ячеек на форме

            // прямоугольник фона карты
            m_board_rectangle = new Rectangle(214, 110, cell_length * number_cells_in_line + margin_between_cells * (number_cells_in_line + 1), cell_length * number_cells_in_line + margin_between_cells * (number_cells_in_line + 1));

            // создание ячеек
            for (int y = 0; y < number_cells_in_line; y++)
            {
                for (int x = 0; x < number_cells_in_line; x++)
                {
                    m_map_cells[y, x] = new Cell(CellType.White);
                    m_map_cells[y, x].Rectangle = new Rectangle(m_board_rectangle.X + margin_between_cells + (cell_length + margin_between_cells) * x, m_board_rectangle.Y + margin_between_cells + (cell_length + margin_between_cells) * y, cell_length, cell_length);
                    m_cells.Add(m_map_cells[y, x]);
                }
            }

            // у каждого игрока свой groupBox. Для удобства выравнивания личных ячеек игроков используется цикл
            GroupBox[] group_boxes = new GroupBox[4];
            group_boxes[0] = groupBox_player_1;
            group_boxes[1] = groupBox_player_2;
            group_boxes[2] = groupBox_player_3;
            group_boxes[3] = groupBox_player_4;

            for (int i = 0; i < 4; i++) // для каждого игрока
            {
                if (m_players[i] != null) // если игрок участвует
                {
                    group_boxes[i].Enabled = true; // делаем доступными элементы его groupBox
                    group_boxes[i].Visible = true; // покахываем элементы его groupBox

                    group_boxes[i].Text = m_players[i].Name; // имя игрока является заголовком его groupBox

                    for (int x = 0; x < 4; x++) // ряд из четырёх ячеек
                    {
                        m_players[i].Cells[x] = new Cell(CellType.White); // создаём ячейку
                        m_players[i].Cells[x].Rectangle = new Rectangle(group_boxes[i].Location.X + 5 + (cell_length + margin_between_cells) * x, group_boxes[i].Location.Y + group_boxes[i].Height + margin_between_cells, cell_length, cell_length); // перемещаем ячейку
                        m_cells.Add(m_players[i].Cells[x]); // добавляем ячейку в список всех ячеек
                    }
                    for (int x = 0; x < 3; x++) // ряд из трёх ячеек
                    {
                        m_players[i].Cells[x + 4] = new Cell(CellType.White); // создаём ячейку
                        m_players[i].Cells[x + 4].Rectangle = new Rectangle(group_boxes[i].Location.X + 5 + (cell_length + margin_between_cells) / 2 + (cell_length + margin_between_cells) * x, group_boxes[i].Location.Y + group_boxes[i].Height + margin_between_cells + cell_length + margin_between_cells, cell_length, cell_length); // перемещаем ячейку
                        m_cells.Add(m_players[i].Cells[x + 4]); // добавляем ячейку в список всех ячеек
                    }
                }
                else // если игрок не участвует
                {
                    group_boxes[i].Enabled = false; // делаем недоступными элементы его groupBox
                    group_boxes[i].Visible = false; // скрываем элементы его groupBox
                }
            }

            // меняем тип центральной ячейки
            m_map_cells[7, 7].CellType = CellType.Gray;

            // меняем тип зелёных ячеек
            m_map_cells[0, 3].CellType = m_map_cells[0, 11].CellType =
            m_map_cells[2, 6].CellType = m_map_cells[2, 8].CellType =
            m_map_cells[3, 0].CellType = m_map_cells[3, 7].CellType = m_map_cells[3, 14].CellType =
            m_map_cells[6, 2].CellType = m_map_cells[6, 6].CellType = m_map_cells[6, 8].CellType = m_map_cells[6, 12].CellType =
            m_map_cells[7, 3].CellType = m_map_cells[7, 11].CellType =
            m_map_cells[8, 2].CellType = m_map_cells[8, 6].CellType = m_map_cells[8, 8].CellType = m_map_cells[8, 12].CellType =
            m_map_cells[11, 0].CellType = m_map_cells[11, 7].CellType = m_map_cells[3, 14].CellType =
            m_map_cells[12, 6].CellType = m_map_cells[12, 8].CellType =
            m_map_cells[14, 3].CellType = m_map_cells[14, 11].CellType = CellType.Green;

            // меняем тип синих ячеек
            m_map_cells[1, 1].CellType = m_map_cells[1, 13].CellType =
            m_map_cells[2, 2].CellType = m_map_cells[2, 12].CellType =
            m_map_cells[3, 3].CellType = m_map_cells[3, 11].CellType =
            m_map_cells[4, 4].CellType = m_map_cells[4, 10].CellType =
            m_map_cells[10, 4].CellType = m_map_cells[10, 10].CellType =
            m_map_cells[11, 3].CellType = m_map_cells[11, 11].CellType =
            m_map_cells[12, 2].CellType = m_map_cells[12, 12].CellType =
            m_map_cells[13, 1].CellType = m_map_cells[13, 13].CellType = CellType.Blue;

            // меняем тип жёлтых ячеек
            m_map_cells[1, 5].CellType = m_map_cells[1, 9].CellType =
            m_map_cells[5, 1].CellType = m_map_cells[5, 13].CellType =
            m_map_cells[9, 1].CellType = m_map_cells[9, 13].CellType =
            m_map_cells[13, 5].CellType = m_map_cells[13, 9].CellType = CellType.Yellow;

            // меняем тип красных ячеек
            m_map_cells[0, 0].CellType = m_map_cells[0, 7].CellType = m_map_cells[0, 14].CellType =
            m_map_cells[7, 0].CellType = m_map_cells[7, 14].CellType =
            m_map_cells[14, 0].CellType = m_map_cells[14, 7].CellType = m_map_cells[14, 14].CellType = CellType.Red;
            
            m_seconds_walkthrough = 0; // обнуляем время
            game_timer.Start(); // запускаем таймер времени

            label_limit.Text = "Лимит очков: ";
            if (PointsLimit == -1) label_limit.Text += "отсутствует";
            else label_limit.Text += PointsLimit;

            m_total_moving_player_id = -1; // id игрока, который сейчас ходит
            NextPlayerMove(); // переход хода к следующему игроку

            update_timer.Start(); // запускаем таймер обновления формы

            m_was_first_word = false; // было ли поставлено первое слово

            m_total_turn = 1;
        }

        /// <summary>Событие закрытия формы</summary>
        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            game_timer.Stop(); // запускаем игровой таймер
            update_timer.Stop(); // запускаем игровой таймер

            FormResult form_result = new FormResult(); // создаём форму с результатом
            form_result.Owner = this; // делаем владельца второй формы - эту форму
            Hide(); // скрываем текущую форму

            // передача данных об игроках в форму показа результата игры
            for (int i = 0; i < 4; i++)
            {
                form_result.IsPlayers[i] = !(m_players[i] is null); // участвовал ли игрок
                if (form_result.IsPlayers[i]) // если игрок участвовал
                {
                    form_result.PlayersNames[i] = m_players[i].Name; // имя игрока
                    form_result.PlayersPoints[i] = m_players[i].Points; // количество набранных очков
                }
            }
            form_result.SecondsWalkthrough = m_seconds_walkthrough;
            form_result.TurnsWalkthrough = m_total_turn;

            form_result.ShowDialog(); // показываем форму с результатом в режиме диалога
        }

        /// <summary>Событие перерисовки формы</summary>
        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            bool is_cursor = false; // должен ли курсор измениться на Hand

            DrawRectagle(e, m_board_rectangle, Brushes.Black); // фон поля

            Brush brush = Brushes.White; // цвет границы ячейки, или цвет всей ячейки (в случае если у ячейки нет границы)
            for (int i = 0; i < m_cells.Count; i++) // для всех ячеек
            {
                bool is_total_moving_player_cell = false; // доступна ли ячейка игроку, который сейчас ходит 
                for (int i2 = 0; i2 < 7; i2++) // для каждой ячейки игрока
                {
                    if (m_cells[i] == m_players[m_total_moving_player_id].Cells[i2]) // если ячейка игрока совпадает с текущей, значит она доступна игроку
                    {
                        is_total_moving_player_cell = true; // ячейка доступна игроку
                        break; // выходим из цикла
                    }
                }
                if (i < 225) is_total_moving_player_cell = true; // все ячейки поля доступны игроку

                if (m_cells[i].Letter == null) // если ячейка пустая (без буквы)
                {
                    string text = "";
                    if (m_cells[i].CellType == CellType.White) // если ячейка - белая (пустая)
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) // если на ячейку наведён курсор и ячейка доступна игроку
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; // курсор нужно поменять на Hand
                        }
                        else brush = Brushes.White;
                    }
                    else if (m_cells[i].CellType == CellType.Gray) // если ячейка - серая (центр)
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) // если на ячейку наведён курсор и ячейка доступна игроку
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; // курсор нужно поменять на Hand
                        }
                        else brush = Brushes.LightGray;
                    }
                    else if (m_cells[i].CellType == CellType.Green) // если ячейка - зелёная
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) // если на ячейку наведён курсор и ячейка доступна игроку
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; // курсор нужно поменять на Hand
                        }
                        else brush = Brushes.LightGreen;
                        text = "x2";
                    }
                    else if (m_cells[i].CellType == CellType.Blue) // если ячейка - синяя
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) // если на ячейку наведён курсор и ячейка доступна игроку
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; // курсор нужно поменять на Hand
                        }
                        else brush = Brushes.Aqua;
                        text = "All\nx2";
                    }
                    else if (m_cells[i].CellType == CellType.Yellow) // если ячейка - жёлтая
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) // если на ячейку наведён курсор и ячейка доступна игроку
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; // курсор нужно поменять на Hand
                        }
                        else brush = Brushes.Yellow;
                        text = "x3";
                    }
                    else if (m_cells[i].CellType == CellType.Red) // если ячейка - красная
                    {
                        if (m_cells[i].IsEntered && is_total_moving_player_cell) // если на ячейку наведён курсор и ячейка доступна игроку
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; // курсор нужно поменять на Hand
                        }
                        else brush = Brushes.Pink;
                        text = "All\nx3";
                    }

                    if (i == m_id_total_clicked_cell) brush = Brushes.Green; // если ячейка является выбранной ячейкой

                    DrawRectagle(e, m_cells[i].Rectangle, Brushes.Black, brush, 1); // рисовка ячейки
                    DrawText(e, m_cells[i].Rectangle, Brushes.Black, text, 0.25); // рисовка текста в ячейке (если ячейка не белая и не серая)
                }
                else // если в ячейке есть буква
                {
                    string text = "" + m_cells[i].Letter.Symbol; // текст ячейки - соответствующая буква

                    brush = Brushes.LightYellow; // цвет границы
                    Brush brush2 = Brushes.Orange; // цвет ячейки

                    if (is_total_moving_player_cell) // если ячейка доступна игроку, который сейчас ходит
                    {
                        if (m_cells[i].IsEntered) // если на ячейку с буквой наведён курсор
                        {
                            brush = Brushes.YellowGreen;
                            is_cursor = true; // курсор нужно поменять на Hand
                        }
                        else // если на ячейку с буквой не наведён курсор
                        {
                            brush = Brushes.Orange;
                        }
                        brush2 = Brushes.Brown;
                    }

                    if (i == m_id_total_clicked_cell) brush = Brushes.Green; // если ячейка сейчас выбрана

                    DrawRectagle(e, m_cells[i].Rectangle, brush2, brush, margin_between_cells); // рисовка самой ячейки

                    DrawText(e, m_cells[i].Rectangle, Brushes.Black, text, 0.4); // рисовка основного текста ячейки - соответствующая буква

                    text = "" + m_cells[i].Letter.Points; // баллы буквы
                    Rectangle letter_points_rectangle = new Rectangle(m_cells[i].Letter.Rectangle.X + cell_length / 2 + margin_between_cells, m_cells[i].Letter.Rectangle.Y + cell_length / 2 + margin_between_cells, cell_length / 2, cell_length / 2); // баллы буквы (отображаются справа снизу ячейки)
                    DrawText(e, letter_points_rectangle, Brushes.Black, text, 0.35); // рисовка дополнительного текст ячейки - количество баллов буквы
                }
            }

            if (is_cursor) // если нужно поменять курсор на Hand
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>Событие передвижения мыши по форме</summary>
        private void FormGame_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < m_cells.Count; i++) // для всех ячеек
            {
                if (m_cells[i].Rectangle.Contains(e.Location)) // если курсор находится в ячейке
                {
                    bool is_total_moving_player_cell = false; // доступна ли ячейка игроку, который сейчас ходит 
                    for (int i2 = 0; i2 < 7; i2++) // для каждой ячейки игрока
                    {
                        if (m_cells[i] == m_players[m_total_moving_player_id].Cells[i2]) // если ячейка игрока совпадает с текущей, значит она доступна игроку
                        {
                            is_total_moving_player_cell = true; // ячейка доступна игроку
                            break; // выходим из цикла
                        }
                    }
                    if (i < 225) is_total_moving_player_cell = true; // все ячейки поля доступны игроку

                    if (!is_total_moving_player_cell) // если ячейка недоступна игроку
                    {
                        m_cells[i].IsEntered = false;
                        continue; // заканчиваем итерацию и переходим к проверке следующей ячейки
                    }

                    if (m_id_total_clicked_cell != -1) // если уже выбрана ячейка с буквой
                    {
                        if (m_cells[i].Letter == null) // если в ячейке нет буквы
                        {
                            m_cells[i].IsEntered = true;
                            continue;
                        }
                        else // если в ячейке есть буква
                        {
                            if (m_cells[i].Letter.LetterType != LetterType.Fixed) // если эту букву поставил игрок на этом ходу
                            {
                                m_cells[i].IsEntered = true;
                                continue;
                            }
                        }
                    }
                    else // если не выбрана ячейка
                    {
                        if (m_cells[i].Letter != null) // если в ячейке есть буква
                        {
                            if (m_cells[i].Letter.LetterType != LetterType.Fixed) // если эту букву поставил игрок на этом ходу
                            {
                                m_cells[i].IsEntered = true;
                                continue;
                            }
                        }
                    }
                    m_cells[i].IsEntered = false;
                }
                else // если курсор вне ячейки
                {
                    m_cells[i].IsEntered = false;
                }
            }

        }

        /// <summary>Событие нажатия кнопки мыши в форме</summary>
        private void FormGame_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < m_cells.Count; i++) // для всех ячеек
            {
                if (m_cells[i].Rectangle.Contains(e.Location)) // если курсор находится в ячейке
                {
                    bool is_total_moving_player_cell = false; // доступна ли ячейка игроку, который сейчас ходит 
                    for (int i2 = 0; i2 < 7; i2++) // для каждой ячейки игрока
                    {
                        if (m_cells[i] == m_players[m_total_moving_player_id].Cells[i2]) // если ячейка игрока совпадает с текущей, значит она доступна игроку
                        {
                            is_total_moving_player_cell = true; // ячейка доступна игроку
                            break; // выходим из цикла
                        }
                    }
                    if (i < 225) is_total_moving_player_cell = true; // все ячейки поля доступны игроку

                    if (!is_total_moving_player_cell) // если ячейка недоступна игроку
                    {
                        m_cells[i].IsEntered = false;
                        continue; // заканчиваем итерацию и переходим к проверке следующей ячейки
                    }

                    if (m_id_total_clicked_cell != -1) // если уже выбрана ячейка с буквой
                    {
                        if (m_cells[i].Letter == null) // если в ячейке нет буквы
                        {
                            // перемещение буквы из кликнутой ранее ячейки в новую ячейку
                            m_cells[i].Letter = m_cells[m_id_total_clicked_cell].Letter; // заносим букву в ячейку на поле
                            m_cells[m_id_total_clicked_cell].Letter = null; // обнуляем ячейку игрока
                            m_id_total_clicked_cell = -1; // сброс выбора
                            if (i < 225) m_cells[i].Letter.LetterType = LetterType.Board; // если буква была перемещена на поле
                            else m_cells[i].Letter.LetterType = LetterType.Player; // иначе - буква была перемещена обратно к игроку
                        }
                        else // если в другой ячейке есть буква
                        {
                            if (m_cells[i].Letter.LetterType != LetterType.Fixed) // если эту букву поставил игрок на этом ходу
                            {
                                if (m_id_total_clicked_cell == i) m_id_total_clicked_cell = -1; // если выбрана та же ячейка - то выбор убирается
                                else m_id_total_clicked_cell = i; // иначе - выбирается ячейка
                            }
                        }
                    }
                    else // если не выбрана ячейка
                    {
                        if (m_cells[i].Letter != null) // если в другой ячейке есть буква
                        {
                            if (m_cells[i].Letter.LetterType != LetterType.Fixed)
                            {
                                m_id_total_clicked_cell = i;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Событие нажатия на кнопку "Применить"</summary>
        private void button_apply_Click(object sender, EventArgs e)
        {
            bool is_error = false; // возникла ли какая-либо ошибка в расположении букв

            bool was_direction_checked = false; // было ли уже найдено направление слова, которое добавил игрок в этом раунде
            bool is_direction_horizontal = true; // направление слова, которое добавил игрок в этом раунде
            int first_finded_letter_cell_id = -1; // id ячейки, содержащей первую найденную букву, которую добавил игрок на этом ходу
            bool is_any_border_letter_near_fixed_letter = false; // соприкасается ли новое слово с добавленными ранее
            for (int i = 0; i < 225; i++)
            {
                if (m_cells[i].Letter != null) // если в ячейке есть буква
                {
                    // проверка на то, что рядом не стоят 4 буквы где бы то ни было
                    if (i % 15 != 14 && i < 210)
                    {
                        if (m_cells[i + 1].Letter != null && m_cells[i + 15].Letter != null && m_cells[i + 16].Letter != null)
                        {
                            MessageBox.Show("Недопустимое расположение букв!\nЧетыре буквы не могут находиться в квадрате 2 на 2.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            is_error = true;
                            break;
                        }
                    }

                    // проверка на то, что буква стоит одна
                    int number_cells_around = 0;
                    if (i % 15 != 0 && m_cells[i - 1].Letter != null) number_cells_around++;
                    if (i % 15 != 14 && m_cells[i + 1].Letter != null) number_cells_around++;
                    if (i > 14 && m_cells[i - 15].Letter != null) number_cells_around++;
                    if (i < 210 && m_cells[i + 15].Letter != null) number_cells_around++;
                    if (number_cells_around == 0)
                    {
                        MessageBox.Show("Недопустимое расположение букв!\nВсе буквы должны соприкасаться между собой.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        is_error = true;
                        break;
                    }

                    // проверка на нахождение букв в одной строке / столбце
                    if (m_cells[i].Letter.LetterType == LetterType.Board) // если буква была добавлена игроком на этом ходе
                    {
                        first_finded_letter_cell_id = i;
                        if (i % 15 != 0 && m_cells[i - 1].Letter != null) // если ячейка слева содержит букву
                        {
                            if (m_cells[i - 1].Letter.LetterType == LetterType.Fixed) // если ячейка слева была добавлена игроками ранее
                            {
                                is_any_border_letter_near_fixed_letter = true; // добавляемое игроком слово соприкасается с предыдущими
                            }
                            if (was_direction_checked && is_direction_horizontal == false) // если известно, что направление добавляемого игроком слова - вертикальное
                            {
                                MessageBox.Show("Недопустимое расположение букв!\nМожно добавить только одно слово за ход - добавляемые буквы должны находится в одной строчке / в одном столбце.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                is_error = true;
                                break;
                            }
                            else
                            {
                                if (m_cells[i - 1].Letter.LetterType == LetterType.Fixed) // если ячейка слева содержит букву, добавленную игроками ранее
                                {
                                    if ((i - 1) % 15 != 0 && m_cells[i - 2].Letter != null) // если ячейка слева слева содержит букву
                                    {
                                        if (m_cells[i - 2].Letter.LetterType == LetterType.Fixed) // если ячейка слева слева содержит букву, добавленную игроками ранее
                                        {
                                            MessageBox.Show("Недопустимое расположение букв!\nНельзя добавлять буквы к уже созданному слову!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            is_error = true;
                                            break;
                                        }
                                    }
                                }
                                was_direction_checked = true;
                                is_direction_horizontal = true;
                            }
                        }
                        if (i % 15 != 14 && m_cells[i + 1].Letter != null) // если ячейка справа содержит букву
                        {
                            if (m_cells[i + 1].Letter.LetterType == LetterType.Fixed) // если ячейка слева была добавлена игроками ранее
                            {
                                is_any_border_letter_near_fixed_letter = true; // добавляемое игроком слово соприкасается с предыдущими
                            }
                            if (was_direction_checked && is_direction_horizontal == false) // если известно, что направление добавляемого игроком слова - вертикальное
                            {
                                MessageBox.Show("Недопустимое расположение букв!\nМожно добавить только одно слово за ход - добавляемые буквы должны находится в одной строчке / в одном столбце.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                is_error = true;
                                break;
                            }
                            else
                            {
                                if (m_cells[i + 1].Letter.LetterType == LetterType.Fixed) // если ячейка справа содержит букву, добавленную игроками ранее
                                {
                                    if ((i + 1) % 15 != 14 && m_cells[i + 2].Letter != null) // если ячейка справа справа содержит букву
                                    {
                                        if (m_cells[i + 2].Letter.LetterType == LetterType.Fixed) // если ячейка справа справа содержит букву, добавленную игроками ранее
                                        {
                                            MessageBox.Show("Недопустимое расположение букв!\nНельзя добавлять буквы к уже созданному слову!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            is_error = true;
                                            break;
                                        }
                                    }
                                }
                                was_direction_checked = true;
                                is_direction_horizontal = true;
                            }
                        }
                        if (i > 14 && m_cells[i - 15].Letter != null) // если ячейка сверху содержит букву
                        {
                            if (m_cells[i - 15].Letter.LetterType == LetterType.Fixed) // если ячейка слева была добавлена игроками ранее
                            {
                                is_any_border_letter_near_fixed_letter = true; // добавляемое игроком слово соприкасается с предыдущими
                            }
                            if (was_direction_checked && is_direction_horizontal == true) // если известно, что направление добавляемого игроком слова - горизонтальное
                            {
                                MessageBox.Show("Недопустимое расположение букв!\nМожно добавить только одно слово за ход - добавляемые буквы должны находится в одной строчке / в одном столбце.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                is_error = true;
                                break;
                            }
                            else
                            {
                                if (m_cells[i - 15].Letter.LetterType == LetterType.Fixed) // если ячейка сверху содержит букву, добавленную игроками ранее
                                {
                                    if ((i - 15) > 14 && m_cells[i - 30].Letter != null) // если ячейка сверху сверху содержит букву
                                    {
                                        if (m_cells[i - 30].Letter.LetterType == LetterType.Fixed) // если ячейка сверху сверху содержит букву, добавленную игроками ранее
                                        {
                                            MessageBox.Show("Недопустимое расположение букв!\nНельзя добавлять буквы к уже созданному слову!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            is_error = true;
                                            break;
                                        }
                                    }
                                }
                                was_direction_checked = true;
                                is_direction_horizontal = false;
                            }
                        }
                        if (i < 210 && m_cells[i + 15].Letter != null) // если ячейка снизу содержит букву
                        {
                            if (m_cells[i + 15].Letter.LetterType == LetterType.Fixed) // если ячейка слева была добавлена игроками ранее
                            {
                                is_any_border_letter_near_fixed_letter = true; // добавляемое игроком слово соприкасается с предыдущими
                            }
                            if (was_direction_checked && is_direction_horizontal == true) // если известно, что направление добавляемого игроком слова - горизонтальное
                            {
                                MessageBox.Show("Недопустимое расположение букв!\nМожно добавить только одно слово за ход - добавляемые буквы должны находится в одной строчке / в одном столбце.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                is_error = true;
                                break;
                            }
                            else
                            {
                                if (m_cells[i + 15].Letter.LetterType == LetterType.Fixed) // если ячейка снизу содержит букву, добавленную игроками ранее
                                {
                                    if ((i + 15) < 210 && m_cells[i + 30].Letter != null) // если ячейка снизу снизу содержит букву
                                    {
                                        if (m_cells[i + 30].Letter.LetterType == LetterType.Fixed) // если ячейка снизу снизу содержит букву, добавленную игроками ранее
                                        {
                                            MessageBox.Show("Недопустимое расположение букв!\nНельзя добавлять буквы к уже созданному слову!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            is_error = true;
                                            break;
                                        }
                                    }
                                }
                                was_direction_checked = true;
                                is_direction_horizontal = false;
                            }
                        }
                    }
                }
            }

            if (!is_error) // если ошибки ещё не возникло
            {
                if (!m_was_first_word) // если добавляемое слово - первое
                {
                    if (m_cells[112].Letter == null) // если центральная ячейка не была задействована
                    {
                        MessageBox.Show("Первое слово должно пересекать центр поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        is_error = true;
                    }
                }
                else // если добавляемое слово - не первое
                {
                    if (!is_any_border_letter_near_fixed_letter) // если добавляемое игроком слово не соприкасается с предыдущими
                    {
                        MessageBox.Show("Новое слово должно пересекать ранее добавленные слова!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        is_error = true;
                    }
                }

                if (!is_error) // если ошибки ещё не возникло
                {
                    int first_word_cell_id = first_finded_letter_cell_id; // переменная, обозначающая ID ячейки первой буквы слова
                    if (is_direction_horizontal) // если направление слова - горизонтальное
                    {
                        while (first_word_cell_id % 15 != 0 && m_cells[first_word_cell_id - 1].Letter != null) // двигаемся влево по слову
                        {
                            first_word_cell_id--;
                        }
                    }
                    else // если направление слова - вертикальное
                    {
                        while (first_word_cell_id > 14 && m_cells[first_word_cell_id - 15].Letter != null) // двигаемся вверх по слову
                        {
                            first_word_cell_id -= 15;
                        }
                    }

                    List<Letter> word_letters = new List<Letter>();
                    int i2 = first_word_cell_id;
                    while(true)
                    {
                        word_letters.Add(new Letter(m_cells[i2].Letter.Symbol));
                        if (is_direction_horizontal) // если направление слова - горизонтальное
                        {
                            i2++; // перемещаемся к букве справа
                            if (i2 % 15 == 0 || m_cells[i2].Letter == null) break; // если достигнут конец слова - разрыв цикла
                        }
                        else // если направление слова - вертикальное
                        {
                            i2 += 15; // перемещаемся к букве снизу
                            if (i2 >= 225 || m_cells[i2].Letter == null) break; // если достигнут конец слова - разрыв цикла
                        }
                    };

                    string word = ""; // слово
                    string text = ""; // выводимый текст
                    int points = 0; // общее количество очков за слово
                    i2 = first_word_cell_id; // id проверяемой ячейки слова
                    for (int i = 0; i < word_letters.Count; i++)
                    {
                        word += word_letters[i].Symbol;
                        if (i2 != first_word_cell_id)
                        {
                            text += " + ";
                        }
                        text += word_letters[i].Points.ToString();
                        if (m_cells[i2].CellType == CellType.Green)
                        {
                            word_letters[i].Points *= 2;
                            text += " * 2";
                        }
                        else if (m_cells[i2].CellType == CellType.Yellow)
                        {
                            word_letters[i].Points *= 3;
                            text += " * 3";
                        }
                        points += word_letters[i].Points;

                        if (is_direction_horizontal) // если направление слова - горизонтальное
                        {
                            i2++; // перемещаемся к букве справа
                        }
                        else // если направление слова - вертикальное
                        {
                            i2 += 15; // перемещаемся к букве снизу
                        }
                    }

                    // проверка слова на нахождение в словаре
                    bool is_word_in_dictionary = false; // найдено ли слово в словаре
                    string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\words.txt";
                    try
                    {
                        string all_text_in_file = System.IO.File.ReadAllText(path); // чтение из файла
                        if (text != "") // если файл не пустой
                        {
                            string[] words = all_text_in_file.Split(new char[] { '\n' }); // создаём массив из текстовых строчек - разбиваем весь текстовый файл на фрагменты, разделённые символом '\n'

                            for (int i = 0; i < words.Length; i++)
                            {
                                if ((word == words[i]) || (word + '\r' == words[i]))
                                {
                                    is_word_in_dictionary = true;
                                    break;
                                }
                            }
                        }
                        else // если файл пустой
                        {
                            throw new Exception("Файл пустой!");
                        }

                        if (!is_word_in_dictionary)
                        {
                            MessageBox.Show("Слово не найдено в словаре!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            is_error = true;
                        }
                    }
                    catch // в случае возникновения какого-либо исключения при чтении файла
                    {
                        MessageBox.Show("Ошибка при чтении файла словаря!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        is_error = true;
                    }


                    if (!is_error) // если ошибки ещё не возникло
                    {
                        // фиксирование букв на поле
                        for (int i = 0; i < 225; i++) // для каждой ячейки поля
                        {
                            if (m_cells[i].Letter != null && m_cells[i].Letter.LetterType == LetterType.Board) // если в ячейке есть буква и эта буква была добавлена игроком в этом раунде
                            {
                                m_cells[i].Letter.LetterType = LetterType.Fixed; // фиксирование буквы
                            }
                        }

                        m_was_first_word = true;

                        i2 = first_word_cell_id;
                        for (int i = 0; i < word_letters.Count; i++)
                        {
                            if (m_cells[i2].CellType == CellType.Blue)
                            {
                                points *= 2;
                                text = "(" + text + ")  * 2";
                            }
                            else if (m_cells[i2].CellType == CellType.Red)
                            {
                                points *= 3;
                                text = "(" + text + ") * 3";
                            }

                            if (is_direction_horizontal) // если направление слова - горизонтальное
                            {
                                i2++; // перемещаемся к букве справа
                            }
                            else // если направление слова - вертикальное
                            {
                                i2 += 15; // перемещаемся к букве снизу
                            }
                        }
                        text += " = " + points + " баллов";

                        m_players[m_total_moving_player_id].Points += points;

                        for (int i = 0; i < 225; i++) // для каждой ячейки поля
                        {
                            if (m_cells[i].Letter != null && m_cells[i].Letter.LetterType == LetterType.Board) // если в ячейке есть буква и эта буква была добавлена игроком в этом раунде
                            {
                                m_cells[i].Letter.LetterType = LetterType.Fixed;
                            }
                        }
                        text = m_players[m_total_moving_player_id].Name + " составил слово \"" + word + "\":\n" + text;
                        MessageBox.Show(text, "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (PointsLimit != -1) // если установлен лимит очков
                        {
                            if (m_players[m_total_moving_player_id].Points >= PointsLimit) // если игрок набрал достаточное количество очков для победы
                            {
                                button_end_game.PerformClick(); // имитация нажатия на кнопку завершения игры
                                return;
                            }
                        }

                        NextPlayerMove(); // переход хода к следующему
                    }
                }
            }

            if (is_error) // в случае ошибки, поле будет очищено от добавленных игроком букв в этом раунде
            {
                for (int i = 0; i < 225; i++) // для каждой ячейки поля
                {
                    if (m_cells[i].Letter != null && m_cells[i].Letter.LetterType == LetterType.Board) // если в ячейке есть буква и эта буква была добавлена игроком в этом раунде
                    {
                        // возвращаем букву в первую пустую ячейку игрока
                        for (int i2 = 0; i2 < 7; i2++)
                        {
                            if (m_players[m_total_moving_player_id].Cells[i2].Letter == null)
                            {
                                m_players[m_total_moving_player_id].Cells[i2].Letter = m_cells[i].Letter;
                                m_cells[i].Letter = null;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Событие нажатия на кнопку пропуска хода</summary>
        private void button_skip_Click(object sender, EventArgs e)
        {
            NextPlayerMove(); // переход хода к следующему
        }

        /// <summary>Событие нажатия на кнопку "Закончить игру досрочно"</summary>
        private void button_end_game_Click(object sender, EventArgs e)
        {
            Close(); // закрываем форму
        }

        /// <summary>Событие тика таймера игры (раз в секунду)</summary>
        private void game_timer_Tick(object sender, EventArgs e)
        {
            m_seconds_walkthrough++; // увеличение счётчика секунд

            // обновление надписи про время
            label_time.Text = "Ход: " + m_total_turn + ". Время с начала игры: ";
            int hours = m_seconds_walkthrough / 60 / 60;
            int minutes = (m_seconds_walkthrough - hours * 60 * 60) / 60;
            int seconds = (m_seconds_walkthrough - hours * 60 * 60 - minutes * 60);
            if (hours > 0) label_time.Text += hours + " час. ";
            if (minutes > 0) label_time.Text += minutes + " мин. ";
            label_time.Text += seconds + " сек. ";
        }

        /// <summary>Событие таймера обновления формы</summary>
        private void update_timer_Tick(object sender, EventArgs e)
        {
            Refresh(); // обновление формы
        }

        /// <summary>Рисует прямоугольник указанного цвета</summary>
        /// <param name="external_rec">Прямоугольник</param>
        /// <param name="external_brush">Кисть</param>
        public void DrawRectagle(PaintEventArgs e, Rectangle external_rec, Brush external_brush)
        {
            e.Graphics.FillRectangle(external_brush, external_rec); // рисовка прямоугольника
        }

        /// <summary>Рисует прямоугольник с границей указанного цвета</summary>
        /// <param name="external_rec">Прямоугольник</param>
        /// <param name="external_brush">Кисть границы</param>
        /// <param name="internal_brush">Кисть заливки</param>
        /// <param name="border_size">Толщина границы</param>
        public void DrawRectagle(PaintEventArgs e, Rectangle external_rec, Brush external_brush, Brush internal_brush, int border_size)
        {
            e.Graphics.FillRectangle(external_brush, external_rec); // рисовка внешнего прямоугольника
            Size internal_size = new Size(external_rec.Width - border_size * 2, external_rec.Height - border_size * 2);
            Point internal_location = new Point(external_rec.X + border_size, external_rec.Y + border_size);
            Rectangle internal_rec = new Rectangle(internal_location, internal_size);
            e.Graphics.FillRectangle(internal_brush, internal_rec); // рисовка внутреннего прямоугольника
        }

        /// <summary>Рисует текст в указанной прямоугольной области</summary>
        /// <param name="external_rec">Прямоугольная область, в которой будет расположен текст</param>
        /// <param name="text_brush">Цвет текста</param>
        /// <param name="text">Текст</param>
        /// <param name="k">Коэффициент (0-1) размера текста от высоты прямоугольной области</param>
        public void DrawText(PaintEventArgs e, Rectangle external_rec, Brush text_brush, string text, double k = 0.5)
        {
            StringFormat format = new StringFormat(); // формат текста
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(text, new Font("Segoe WP Black", (float)(external_rec.Height * k), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), text_brush, external_rec, format); // рисовка текста
        }

        /// <summary>Создаёт игроков в этой форме</summary>
        /// <param name="is_player_1">Участвует ли игрок 1 в игре</param>
        /// <param name="name_player_1">Имя игрока 1</param>
        /// <param name="is_player_2">Участвует ли игрок 2 в игре</param>
        /// <param name="name_player_2">Имя игрока 2</param>
        /// <param name="is_player_3">Участвует ли игрок 3 в игре</param>
        /// <param name="name_player_3">Имя игрока 3</param>
        /// <param name="is_player_4">Участвует ли игрок 4 в игре</param>
        /// <param name="name_player_4">Имя игрока 4</param>
        public void CreatePlayers(bool is_player_1 = true, string name_player_1 = "", bool is_player_2 = true, string name_player_2 = "", bool is_player_3 = true, string name_player_3 = "", bool is_player_4 = true, string name_player_4 = "")
        {
            // если имя игрока пустое или содержит только пробелы, то его имя заменяется стандартным
            if (name_player_1.Split(' ')[0].Length == 0) name_player_1 = "Игрок 1";
            if (name_player_2.Split(' ')[0].Length == 0) name_player_2 = "Игрок 2";
            if (name_player_3.Split(' ')[0].Length == 0) name_player_3 = "Игрок 3";
            if (name_player_4.Split(' ')[0].Length == 0) name_player_4 = "Игрок 4";

            // заполнение массива игроков, если игрок не участвует, то его переменная будет равна null

            if (is_player_1) m_players[0] = new Player(name_player_1);
            else m_players[0] = null;

            if (is_player_2) m_players[1] = new Player(name_player_2);
            else m_players[1] = null;

            if (is_player_3) m_players[2] = new Player(name_player_3);
            else m_players[2] = null;

            if (is_player_4) m_players[3] = new Player(name_player_4);
            else m_players[3] = null;
        }

        /// <summary>Передача хода следующему игроку</summary>
        private void NextPlayerMove()
        {
            m_total_turn++;

            // очистка поля от букв, которые не зафиксированы программой на поле (неподтверждённые слова)
            for (int i = 0; i < 225; i++)
            {
                if (m_cells[i].Letter != null && m_cells[i].Letter.LetterType == LetterType.Board)
                {
                    m_cells[i].Letter = null;
                }
            }
            m_id_total_clicked_cell = -1; // обнуляем id текущей выбранной ячейки

            if (m_total_moving_player_id == -1) // если это - первый ход в игре
            {
                // выдаём буквы каждому игроку
                for (int i2 = 0; i2 < 4; i2++) // для каждого игрока
                {
                    if (m_players[i2] != null) // если игрок участвует в игре
                    {
                        for (int i = 0; i < 7; i++) // для каждой ячейки игрока
                        {
                            if (m_players[i2].Cells[i].Letter == null) // если в ячейке нет буквы
                            {
                                m_players[i2].Cells[i].Letter = Letter.GetRandomLetter(m_random);
                            }
                        }
                    }
                }
            }
            else // если это - не первый ход в игре
            {
                // выдача новых букв заместо пустых ячеек
                for (int i = 0; i < 7; i++) // для каждой ячейки игрока
                {
                    if (m_players[m_total_moving_player_id].Cells[i].Letter == null) // если в ячейке нет буквы
                    {
                        m_players[m_total_moving_player_id].Cells[i].Letter = Letter.GetRandomLetter(m_random); // добавляем случайную букву игроку
                    }
                }
            }

            // меняем id игрока, который сейчас ходит на следующего, если тот участвует в игре
            do
            {
                m_total_moving_player_id++;
                if (m_total_moving_player_id == 4) m_total_moving_player_id = 0; // переход по кругу
            }
            while (m_players[m_total_moving_player_id] == null);

            // у каждого игрока свой groupBox, для удобства обработки используется цикл
            GroupBox[] group_boxes = new GroupBox[4];
            group_boxes[0] = groupBox_player_1;
            group_boxes[1] = groupBox_player_2;
            group_boxes[2] = groupBox_player_3;
            group_boxes[3] = groupBox_player_4;

            // у каждого игрока свой groupBox, для удобства обработки используется цикл
            PictureBox[] picture_boxes = new PictureBox[4];
            picture_boxes[0] = pictureBox_player_1;
            picture_boxes[1] = pictureBox_player_2;
            picture_boxes[2] = pictureBox_player_3;
            picture_boxes[3] = pictureBox_player_4;

            // активация groupBox игрока, делающего ход сейчас, деактивация groupBox других игроков
            for (int i = 0; i < 4; i++)
            {
                if (m_players[i] != null)
                {
                    if (i == m_total_moving_player_id)
                    {
                        group_boxes[i].Enabled = true;
                        if (i == 0) pictureBox_player_1.Image = Properties.Resources.player_1_active;
                        else if (i == 1) pictureBox_player_2.Image = Properties.Resources.player_2_active;
                        else if (i == 2) pictureBox_player_3.Image = Properties.Resources.player_3_active;
                        else if (i == 3) pictureBox_player_4.Image = Properties.Resources.player_4_active;
                    }
                    else
                    {
                        group_boxes[i].Enabled = false;
                        if (i == 0) pictureBox_player_1.Image = Properties.Resources.player_1_not_active;
                        else if (i == 1) pictureBox_player_2.Image = Properties.Resources.player_2_not_active;
                        else if (i == 2) pictureBox_player_3.Image = Properties.Resources.player_3_not_active;
                        else if (i == 3) pictureBox_player_4.Image = Properties.Resources.player_4_not_active;
                    }
                }
            }

            // обновление числа баллов у каждого игрока
            if (m_players[0] != null) label_points_player_1.Text = m_players[0].Points.ToString();
            if (m_players[1] != null) label_points_player_2.Text = m_players[1].Points.ToString();
            if (m_players[2] != null) label_points_player_3.Text = m_players[2].Points.ToString();
            if (m_players[3] != null) label_points_player_4.Text = m_players[3].Points.ToString();
        }
    }
}
