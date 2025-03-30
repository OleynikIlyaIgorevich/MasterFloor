using MasterFloor.Desktop.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace MasterFloor.Desktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для PartnerProductsWindow.xaml
    /// </summary>
    public partial class PartnerProductsWindow : Window
    {
        // Приватное поле для хранения ID партнера, с которым работает окно
        private readonly int _partnerId;

        // Конструктор класса. Принимает ID партнера для работы с конкретными данными
        public PartnerProductsWindow(int partnerId)
        {
            // Инициализация компонентов окна из XAML-разметки
            InitializeComponent();

            // Сохранение переданного ID партнера в приватное поле
            _partnerId = partnerId;

            // Загрузка данных о товарах партнера при создании окна
            LoadPartnerProductsData();
        }

        // Метод для загрузки данных о товарах партнера из базы данных
        private void LoadPartnerProductsData()
        {
            // Создание контекста базы данных для выполнения запросов
            var dbContext = new MasterFloorContext();

            // Формирование запроса к базе данных:
            var partnerProducts = dbContext.PartnerProducts
                .Include(x => x.Product)            // Жадная загрузка связанных данных о продукте
                .OrderByDescending(x => x.SellAt)   // Сортировка по дате продажи (сначала новые)
                .Where(x => x.PartnerId == _partnerId) // Фильтрация по ID текущего партнера
                .ToList();                          // Материализация запроса в список

            // Привязка полученных данных к ListView для отображения
            PartnerProductsLV.ItemsSource = partnerProducts;
        }
    }
}
