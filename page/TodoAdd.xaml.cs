using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToDo_list.page
{
    public partial class TodoCreate : Window
    {
        private readonly TodoService _todoService;
        public TodoCreate(TodoService todoService)
        {
            InitializeComponent();
            _todoService = todoService;
        }
        public TodoService todoService = new TodoService();
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string title = txt_title.Text;
            string description = new TextRange(txt_description.Document.ContentStart, txt_description.Document.ContentEnd).Text;
            string resultMessage = _todoService.SaveTodo(title, description);
            MessageBox.Show(resultMessage, "Уведомление");

        }

        private void txt_title_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
