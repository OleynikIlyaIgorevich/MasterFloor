using MasterFloor.Desktop.DbContexts;
using MasterFloor.Desktop.Entities;
using System;
using System.Collections.Generic;
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

namespace MasterFloor.Desktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdatePartnerWindow.xaml
    /// </summary>
    public partial class UpdatePartnerWindow : Window
    {
        private readonly int _partnerId; // Хранение ID партнера для редактирования

        public UpdatePartnerWindow(int partnerId)
        {
            InitializeComponent(); // Инициализация UI из XAML

            _partnerId = partnerId; // Сохранение переданного ID партнера

            // Загрузка данных при открытии окна:
            LoadPartnerTypesData(); // Заполнение ComboBox типами партнеров
            LoadPartnerDetailsData(); // Загрузка данных выбранного партнера
        }

        private void LoadPartnerTypesData()
        {
            try
            {
                var dbContext = new MasterFloorContext(); // Создание контекста БД
                var partnerTypes = dbContext.PartnerTypes.ToList(); // Получение всех типов партнеров
                PartnerTypeCB.ItemsSource = partnerTypes; // Привязка данных к ComboBox
            }
            catch
            {
                MessageBox.Show("При подгрузке типов партнеров произошло исключение!", "Исключение!");
            }
        }

        private void LoadPartnerDetailsData()
        {
            try
            {
                var dbContext = new MasterFloorContext();
                // Поиск партнера по ID:
                var partner = dbContext.Partners.SingleOrDefault(x => x.Id == _partnerId);

                if (partner == null)
                {
                    MessageBox.Show("Ошибка!", "Партнер не найден!");
                    DialogResult = false; // Закрытие окна с отрицательным результатом
                    return;
                }

                // Установка выбранного типа партнера в ComboBox:
                var selectedPartnerType = PartnerTypeCB.Items.Cast<PartnerType>().SingleOrDefault(x => x.Id == partner.PartnerTypeId);
                PartnerTypeCB.SelectedItem = selectedPartnerType;

                // Заполнение полей формы текущими значениями:
                TitleTB.Text = partner.Title;
                DirectorLastnameTB.Text = partner.DirectorLastname;
                DirectorFirstnameTB.Text = partner.DirectorFirstname;
                DirectorMiddlenameTB.Text = partner.DirectorMiddlename;
                EmailTB.Text = partner.Email;
                PhoneTB.Text = partner.Phone;
                AddressTB.Text = partner.Address;
                InnTB.Text = partner.Inn;
                RateTB.Text = partner.Rate.ToString(); // Конвертация числа в строку
            }
            catch
            {
                MessageBox.Show("При подгрузке данных партнера произошло исключение!", "Исключение!");
            }
        }

        private void UpdatePartner(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение данных из полей формы:
                var selectedPartnerType = PartnerTypeCB.SelectedItem as PartnerType;
                var title = TitleTB.Text;
                var directorLastname = DirectorLastnameTB.Text;
                var directorFirstname = DirectorFirstnameTB.Text;
                var directorMiddlename = DirectorMiddlenameTB.Text;
                var email = EmailTB.Text;
                var phone = PhoneTB.Text;
                var address = AddressTB.Text;
                var inn = InnTB.Text;
                var rate = RateTB.Text;

                // Валидация выбранного типа партнера:
                var isPartnerTypeSelected = selectedPartnerType != null;
                if (!isPartnerTypeSelected)
                {
                    MessageBox.Show("Тип партнера не был выбран!", "Ошибка!");
                    return;
                }

                // Валидация названия (1-32 символа):
                var isTitleValid = !string.IsNullOrWhiteSpace(title) && title.Length <= 32;
                if (!isTitleValid)
                {
                    MessageBox.Show("Название партнера не может быть пустым или превышать 32 символа!");
                    return;
                }

                // Валидация фамилии директора (1-64 символа):
                var isDirectorLastnameValid = !string.IsNullOrWhiteSpace(directorLastname) && directorLastname.Length <= 64;
                if (!isDirectorLastnameValid)
                {
                    MessageBox.Show("Фамилия директора не может быть пустой или превышать 64 символа!", "Ошибка!");
                    return;
                }

                // Валидация имени директора (1-64 символа):
                var isDirectorFirstnameValid = !string.IsNullOrWhiteSpace(directorFirstname) && directorFirstname.Length <= 64;
                if (!isDirectorFirstnameValid)
                {
                    MessageBox.Show("Имя директора не может быть пустым или превышать 64 символа!", "Ошибка!");
                    return;
                }

                // Валидация отчества директора (до 64 символов, допускается пустое):
                var isDirectorMiddlenameValid = directorMiddlename.Length <= 64; // Ошибка: проверка directorFirstname вместо directorMiddlename
                if (!isDirectorMiddlenameValid)
                {
                    MessageBox.Show("Отчество директора не может быть пустым или превышать 64 символа!", "Ошибка!");
                    return;
                }

                // Валидация email (1-128 символов):
                var isEmailValid = !string.IsNullOrWhiteSpace(email) && email.Length <= 128;
                if (!isEmailValid)
                {
                    MessageBox.Show("Почта не может быть пустой или превышать 128 символов", "Ошибка!");
                    return;
                }

                // Валидация телефона (1-20 символов):
                var isPhoneValid = !string.IsNullOrWhiteSpace(phone) && phone.Length <= 20;
                if (!isPhoneValid)
                {
                    MessageBox.Show("Номер телефона не может быть пустым или превышать 20 символов", "Ошибка!");
                    return;
                }

                // Валидация адреса (1-256 символов):
                var isAddressValid = !string.IsNullOrWhiteSpace(address) && address.Length <= 256;
                if (!isAddressValid)
                {
                    MessageBox.Show("Адресс не может быть пустым или превышать 256 символов", "Ошибка!");
                    return;
                }

                // Валидация ИНН (1-32 символа):
                var isInnValid = !string.IsNullOrWhiteSpace(inn) && inn.Length <= 32;
                if (!isInnValid)
                {
                    MessageBox.Show("ИНН не может быть пустым или превышать 32 символов", "Ошибка!");
                    return;
                }

                // Парсинг рейтинга (целое число):
                var rateParsedToInt = 0;
                var rateParseResult = Int32.TryParse(rate, out rateParsedToInt);
                if (!rateParseResult)
                {
                    MessageBox.Show("Рейтинг партнера не может быть пустым и может быть только целым числом!", "Ошибка!");
                    return;
                }

                // Проверка диапазона рейтинга (1-10):
                var isRateValid = 1 <= rateParsedToInt && rateParsedToInt <= 10;
                if (!isRateValid)
                {
                    MessageBox.Show("Рейтнг партнера может быть от 1 до 10!", "Ошибка!");
                    return;
                }

                var dbContext = new MasterFloorContext(); // Новый контекст БД

                // Проверка уникальности названия (исключая текущего партнера):
                var isTitleExistForUpdate = dbContext.Partners.Any(x => x.Id != _partnerId && x.Title == title);
                if (isTitleExistForUpdate)
                {
                    MessageBox.Show("Введенное название партнера уже существует!", "Ошибка!");
                    return;
                }

                // Проверка уникальности email (исключая текущего партнера):
                var isEmailExistForUpdate = dbContext.Partners.Any(x => x.Id != _partnerId && x.Email == email);
                if (isEmailExistForUpdate)
                {
                    MessageBox.Show("Введенная почта уже существует!", "Ошибка!");
                    return;
                }

                // Проверка уникальности телефона (исключая текущего партнера):
                var isPhoneExistForUpdate = dbContext.Partners.Any(x => x.Id != _partnerId && x.Phone == phone);
                if (isPhoneExistForUpdate)
                {
                    MessageBox.Show("Введенный номер телефона уже существует!", "Ошибка!");
                    return;
                }

                // Проверка уникальности адреса (исключая текущего партнера):
                var isAddressExistForUpdate = dbContext.Partners.Any(x => x.Id != _partnerId && x.Address == address);
                if (isAddressExistForUpdate)
                {
                    MessageBox.Show("Введенный адресс уже существует!", "Ошибка!");
                    return;
                }

                // Проверка уникальности ИНН (исключая текущего партнера):
                var isInnExistForUpdate = dbContext.Partners.Any(x => x.Id != _partnerId && x.Inn == inn);
                if (isInnExistForUpdate)
                {
                    MessageBox.Show("Введенный ИНН уже существует!", "Ошибка");
                    return;
                }

                // Поиск обновляемого партнера:
                var partner = dbContext.Partners.SingleOrDefault(x => x.Id == _partnerId);
                if (partner == null)
                {
                    MessageBox.Show("Ошибка!", "Партнер не найден!");
                    DialogResult = false;
                    return;
                }

                // Обновление полей партнера:
                partner.PartnerTypeId = selectedPartnerType.Id;
                partner.Title = title;
                partner.DirectorLastname = directorLastname;
                partner.DirectorFirstname = directorFirstname;
                partner.DirectorMiddlename = directorMiddlename;
                partner.Email = email;
                partner.Phone = phone;
                partner.Address = address;
                partner.Inn = inn;
                partner.Rate = rateParsedToInt;

                dbContext.SaveChanges(); // Сохранение изменений в БД

                DialogResult = true; // Успешное завершение
            }
            catch
            {
                MessageBox.Show("Произошло исключение при попытке обновить партнера!", "Исключенние!");
            }
        }
    }
}
