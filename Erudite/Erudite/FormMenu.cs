using System;
using System.Windows.Forms;

namespace Erudite
{
    /// <summary>Форма главного меню</summary>
    public partial class FormMenu : Form
    {
        /// <summary>Конструктор формы</summary>
        public FormMenu()
        {
            InitializeComponent();
        }

        /// <summary>Событие нажатия на кнопку "Играть"</summary>
        private void button_play_Click(object sender, EventArgs e)
        {
            FormSettings form_settings = new FormSettings(); // создаём форму с настройками игры
            form_settings.Owner = this; // делаем владельца второй формы - эту форму
            Hide(); // скрываем текущую форму
            form_settings.Show(); // показываем форму с настройками игры в режиме диалога
        }

        /// <summary>Событие нажатия на кнопку "Правила"</summary>
        private void button_rules_Click(object sender, EventArgs e)
        {
            FormRules form_rules = new FormRules(); // создаём форму с правилами игры
            form_rules.Owner = this; // делаем владельца второй формы - эту форму
            Hide(); // скрываем текущую форму
            form_rules.Show(); // показываем форму с правилами игры в режиме диалога
        }

        /// <summary>Событие нажатия на кнопку "Выйти из игры"</summary>
        private void button_exit_Click(object sender, EventArgs e)
        {
            Close(); // закрытие формы
        }
    }
}
