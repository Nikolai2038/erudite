using System;
using System.Windows.Forms;

namespace Erudite
{
    /// <summary>Форма показа результата игры</summary>
    public partial class FormResult : Form
    {
        /// <summary>Участвовали ли игроки в игре</summary>
        public bool[] IsPlayers = new bool[4];

        /// <summary>Имена игроков</summary>
        public string[] PlayersNames = new string[4];

        /// <summary>Количество набранных очков</summary>
        public int[] PlayersPoints = new int[4];

        /// <summary>Время игры</summary>
        public int SecondsWalkthrough = 0;

        /// <summary>Количество ходов</summary>
        public int TurnsWalkthrough = 0;

        /// <summary>Конструктор формы</summary>
        public FormResult()
        {
            InitializeComponent();
        }

        /// <summary>Событие загрузки формы</summary>
        private void FormResult_Load(object sender, EventArgs e)
        {
            // нахождение максимального количества очков среди результатов игроков
            int max_points = -1;
            for (int i = 0; i < 4; i++)
            {
                if (IsPlayers[i]) // если игрок участвовал
                {
                    if (PlayersPoints[i] > max_points) max_points = PlayersPoints[i];
                }
            }

            // установление иконок игроков
            pictureBox_player_1.Image = Properties.Resources.player_1_not_active;
            pictureBox_player_2.Image = Properties.Resources.player_2_not_active;
            pictureBox_player_3.Image = Properties.Resources.player_3_not_active;
            pictureBox_player_4.Image = Properties.Resources.player_4_not_active;

            // подсчёт количества победителей - игроков с максимальным количеством очков
            int winners = 0;
            for (int i = 0; i < 4; i++)
            {
                if (IsPlayers[i]) // если игрок участвовал
                {
                    if (PlayersPoints[i] == max_points)
                    {
                        winners++;

                        // иконки победивших игроков будут более яркими
                        if (i == 0) pictureBox_player_1.Image = Properties.Resources.player_1_active;
                        else if (i == 1) pictureBox_player_2.Image = Properties.Resources.player_2_active;
                        else if (i == 2) pictureBox_player_3.Image = Properties.Resources.player_3_active;
                        else if (i == 3) pictureBox_player_4.Image = Properties.Resources.player_4_active;
                    }
                }
            }

            if (winners > 1) label_caption.Text = "Игра окончена! Победителей несколько!"; 
            else // если победитель только один
            {
                for (int i = 0; i < 4; i++)
                {
                    if (IsPlayers[i]) // если игрок участвовал
                    {
                        if (PlayersPoints[i] == max_points)
                        {
                            label_caption.Text = "Игра окончена! Победил " + PlayersNames[i] + "!";
                            break; // разрываем цикл
                        }
                    }
                }
            }

            if (IsPlayers[0]) // если игрок 1 был в игре
            {
                label_name_player_1.Text = PlayersNames[0]; // имя игрока
                label_points_player_1.Text = PlayersPoints[0].ToString(); // количество набраннах игроком баллов
            }
            else // если игрок 1 не играл
            {
                label_name_player_1.Text = ""; // имя игрока
                label_points_player_1.Text = ""; // количество набраннах игроком баллов
            }

            if (IsPlayers[1]) // если игрок 2 был в игре
            {
                label_name_player_2.Text = PlayersNames[1]; // имя игрока
                label_points_player_2.Text = PlayersPoints[1].ToString(); // количество набраннах игроком баллов
            }
            else // если игрок 2 не играл
            {
                label_name_player_2.Text = ""; // имя игрока
                label_points_player_2.Text = ""; // количество набраннах игроком баллов
            }

            if (IsPlayers[2]) // если игрок 1 был в игре
            {
                label_name_player_3.Text = PlayersNames[2]; // имя игрока
                label_points_player_3.Text = PlayersPoints[2].ToString(); // количество набраннах игроком баллов
            }
            else // если игрок 1 не играл
            {
                label_name_player_3.Text = ""; // имя игрока
                label_points_player_3.Text = ""; // количество набраннах игроком баллов
            }

            if (IsPlayers[3]) // если игрок 1 был в игре
            {
                label_name_player_4.Text = PlayersNames[3]; // имя игрока
                label_points_player_4.Text = PlayersPoints[3].ToString(); // количество набраннах игроком баллов
            }
            else // если игрок 1 не играл
            {
                label_name_player_4.Text = ""; // имя игрока
                label_points_player_4.Text = ""; // количество набраннах игроком баллов
            }

            // вывод надписи про время - секунды переводятся в часы и минуты
            label_time.Text = "Количество ходов: " + TurnsWalkthrough + ".\n";
            label_time.Text += "Время игры: ";
            int hours = SecondsWalkthrough / 60 / 60;
            int minutes = (SecondsWalkthrough - hours * 60 * 60) / 60;
            int seconds = (SecondsWalkthrough - hours * 60 * 60 - minutes * 60);
            if (hours > 0) label_time.Text += hours + " час. ";
            if (minutes > 0) label_time.Text += minutes + " мин. ";
            label_time.Text += seconds + " сек. ";
        }

        /// <summary>Событие закрытия формы</summary>
        private void FormResult_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Owner.Owner.Show(); // показываем форму главного меню
        }

        /// <summary>Событие нажания на кнопку "Выйти из игры"</summary>
        private void button_exit_Click(object sender, EventArgs e)
        {
            Close(); // закрываем форму
        }

        /// <summary>Событие нажания на кнопку "Играть ещё раз"</summary>
        private void button_play_Click(object sender, EventArgs e)
        {
            Hide(); // скрываем текущую форму
            Owner.Owner.Show(); // показываем форму настроек
        }
    }
}
