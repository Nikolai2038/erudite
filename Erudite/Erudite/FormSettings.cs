using System;
using System.Windows.Forms;

namespace Erudite
{
    /// <summary>Форма настроек</summary>
    public partial class FormSettings : Form
    {
        /// <summary>Конструктор формы</summary>
        public FormSettings()
        {
            InitializeComponent();
        }

        /// <summary>Событие закрытия формы</summary>
        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show(); // показываем владельца этой формы (форму главного меню)
        }

        /// <summary>Событие изменения чекбокса первого игрока</summary>
        private void checkBox_player_1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox_player_1.Checked) // если игрок отмечен
            {
                textBox_player_1.Enabled = true; // разрешаем менять ник игрока
                pictureBox_player_1.Image = Properties.Resources.player_1_active; // меняем иконку игрока на более яркую
            }
            else // если игрок не отмечен
            {
                textBox_player_1.Enabled = false; // запрещаем менять ник игрока
                pictureBox_player_1.Image = Properties.Resources.player_1_not_active; // меняем иконку игрока на менее яркую
            }

            CheckedPlayers(); // проверяем отмеченных игроков и в зависимости от этого блокируем/разблокируем кнопку старта игры
        }

        /// <summary>Событие изменения чекбокса второго игрока</summary>
        private void checkBox_player_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player_2.Checked) // если игрок отмечен
            {
                textBox_player_2.Enabled = true; // разрешаем менять ник игрока
                pictureBox_player_2.Image = Properties.Resources.player_2_active; // меняем иконку игрока на более яркую
            }
            else // если игрок не отмечен
            {
                textBox_player_2.Enabled = false; // запрещаем менять ник игрока
                pictureBox_player_2.Image = Properties.Resources.player_2_not_active; // меняем иконку игрока на менее яркую
            }

            CheckedPlayers(); // проверяем отмеченных игроков и в зависимости от этого блокируем/разблокируем кнопку старта игры
        }

        /// <summary>Событие изменения чекбокса третьего игрока</summary>
        private void checkBox_player_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player_3.Checked) // если игрок отмечен
            {
                textBox_player_3.Enabled = true; // разрешаем менять ник игрока
                pictureBox_player_3.Image = Properties.Resources.player_3_active; // меняем иконку игрока на более яркую
            }
            else // если игрок не отмечен
            {
                textBox_player_3.Enabled = false; // запрещаем менять ник игрока
                pictureBox_player_3.Image = Properties.Resources.player_3_not_active; // меняем иконку игрока на менее яркую
            }

            CheckedPlayers(); // проверяем отмеченных игроков и в зависимости от этого блокируем/разблокируем кнопку старта игры
        }

        /// <summary>Событие изменения чекбокса четвёртого игрока</summary>
        private void checkBox_player_4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_player_4.Checked) // если игрок отмечен
            {
                textBox_player_4.Enabled = true; // разрешаем менять ник игрока
                pictureBox_player_4.Image = Properties.Resources.player_4_active; // меняем иконку игрока на более яркую
            }
            else // если игрок не отмечен
            {
                textBox_player_4.Enabled = false; // запрещаем менять ник игрока
                pictureBox_player_4.Image = Properties.Resources.player_4_not_active; // меняем иконку игрока на менее яркую
            }

            CheckedPlayers(); // проверяем отмеченных игроков и в зависимости от этого блокируем/разблокируем кнопку старта игры
        }

        /// <summary>Событие нажатия на иконку первого игрока</summary>
        private void pictureBox_player_1_Click(object sender, EventArgs e)
        {
            checkBox_player_1.Checked = !checkBox_player_1.Checked; // меняем чекбокс на противоположный
        }

        /// <summary>Событие нажатия на иконку второго игрока</summary>
        private void pictureBox_player_2_Click(object sender, EventArgs e)
        {
            checkBox_player_2.Checked = !checkBox_player_2.Checked; // меняем чекбокс на противоположный
        }

        /// <summary>Событие нажатия на иконку третьего игрока</summary>
        private void pictureBox_player_3_Click(object sender, EventArgs e)
        {
            checkBox_player_3.Checked = !checkBox_player_3.Checked; // меняем чекбокс на противоположный
        }

        /// <summary>Событие нажатия на иконку четвёртого игрока</summary>
        private void pictureBox_player_4_Click(object sender, EventArgs e)
        {
            checkBox_player_4.Checked = !checkBox_player_4.Checked; // меняем чекбокс на противоположный
        }

        /// <summary>Событие нажатия на кнопку "Выход из игры"</summary>
        private void button_exit_Click(object sender, EventArgs e)
        {
            Close(); // закрытие формы
        }

        /// <summary>Событие нажатия на кнопку "Старт игры"</summary>
        private void button_play_Click(object sender, EventArgs e)
        {
            FormGame form_game = new FormGame(); // создаём форму с игровым полем
            form_game.Owner = this; // делаем владельца второй формы - эту форму

            // передаём значение лимита очков во вторую форму
            if (radioButton_limit_off.Checked) form_game.PointsLimit = -1;
            else form_game.PointsLimit = Convert.ToInt32(numericUpDown_limit.Value);

            // вызываем метод создания игроков из другой формы, передавая в неё какие игроки должны быть созданы и какие у них имена
            form_game.CreatePlayers(checkBox_player_1.Checked, textBox_player_1.Text, checkBox_player_2.Checked, textBox_player_2.Text, checkBox_player_3.Checked, textBox_player_3.Text, checkBox_player_4.Checked, textBox_player_4.Text);

            Hide(); // скрываем текущую форму
            form_game.Show(); // показываем форму с игровым полем в режиме диалога
        }

        /// <summary>Проверяет, достаточно ли игроков отмечено для начала игры (минимум - 2). Если игроков недостаточно, то кнопка начала игры будет заблокирована.</summary>
        private void CheckedPlayers()
        {
            int checked_players = 0; // количество отмеченных игроков
            if (checkBox_player_1.Checked) checked_players++;
            if (checkBox_player_2.Checked) checked_players++;
            if (checkBox_player_3.Checked) checked_players++;
            if (checkBox_player_4.Checked) checked_players++;

            if (checked_players >= 2) // если отмечено достаточное количество
            {
                button_play.Enabled = true; // кнопка доступна
            }
            else
            {
                button_play.Enabled = false; // кнопка недоступна
            }
        }
    }
}
