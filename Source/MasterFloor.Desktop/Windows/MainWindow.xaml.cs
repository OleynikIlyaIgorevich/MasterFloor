using MasterFloor.Desktop.DbContexts;
using MasterFloor.Desktop.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterFloor.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Инициализация компонентов окна из XAML-разметки
            InitializeComponent();

            // Загрузка данных о партнерах при запуске приложения
            LoadPartnersData();
        }

        private void LoadPartnersData()
        {
            try // Блок обработки возможных ошибок при работе с БД
            {
                // Создание контекста для взаимодействия с базой данных
                var dbContext = new MasterFloorContext();

                // Получение данных из БД:
                var partners = dbContext.Partners
                    .Include(x => x.PartnerProducts) // Жадная загрузка связанных товаров
                    .Include(x => x.PartnerType)     // Жадная загрузка типа партнера
                    .ToList();                       // Материализация запроса в список

                // Привязка данных к ListView для отображения
                PartnersLV.ItemsSource = partners;
            }
            catch
            {
                // Вывод сообщения об ошибке при возникновении исключения
                MessageBox.Show("Произошло исключение при получении партнеров!", "Произошло исключение!");
            }
        }

        // Обработчик открытия окна с товарами партнера
        private void OpenPartnerProductsWindow(object sender, RoutedEventArgs e)
        {
            // Получение выбранного партнера из ListView
            var selectedPartner = PartnersLV.SelectedItem as Partner;

            // Проверка выбора партнера
            if (selectedPartner == null)
            {
                MessageBox.Show(
                    "Выберите партнера для просмотра реализованной им продукции!",
                    "Партнер не выбран!"
                );
                return;
            }

            // Создание и отображение окна с товарами партнера
            var partnerProductsWindow = new PartnerProductsWindow(selectedPartner.Id);
            partnerProductsWindow.ShowDialog();
        }

        // Обработчик открытия окна редактирования партнера
        private void OpenUpdatePartnerWindow(object sender, RoutedEventArgs e)
        {
            var selectedPartner = PartnersLV.SelectedItem as Partner;

            if (selectedPartner == null)
            {
                MessageBox.Show(
                    "Выберите партнера для редактирования!",
                    "Партнер не выбран!"
                );
                return;
            }

            // Создание окна редактирования с передачей ID партнера
            var updatePartnerWindow = new UpdatePartnerWindow(selectedPartner.Id);

            // Отображение диалога и проверка результата
            var isPartnerUpdated = updatePartnerWindow.ShowDialog();

            // Обновление данных при успешном редактировании
            if (isPartnerUpdated == true)
                LoadPartnersData();
        }

        // Обработчик открытия окна создания партнера
        private void OpenCreatePartnerWindow(object sender, RoutedEventArgs e)
        {
            // Создание окна для добавления нового партнера
            var createPartnerWindow = new CreatePartnerWindow();

            // Отображение диалога и проверка результата
            var isPartnerCreated = createPartnerWindow.ShowDialog();

            // Обновление данных при успешном создании
            if (isPartnerCreated == true)
                LoadPartnersData();
        }
    }
}