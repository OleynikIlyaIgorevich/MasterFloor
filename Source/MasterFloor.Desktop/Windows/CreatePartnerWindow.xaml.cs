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
    /// Логика взаимодействия для CreatePartnerWindow.xaml
    /// </summary>
    public partial class CreatePartnerWindow : Window
    {
        public CreatePartnerWindow()
        {
            // Инициализация компонентов пользовательского интерфейса, 
            // описанных в XAML-разметке этого окна
            InitializeComponent();

            // Загрузка данных для выпадающего списка типов партнеров 
            // из базы данных при создании окна
            LoadPartnerTypesData();
        }

        private void LoadPartnerTypesData()
        {
            try
            {
                // Создание контекста базы данных для взаимодействия с БД
                var dbContext = new MasterFloorContext();

                // Получение всех записей из таблицы PartnerTypes и преобразование в список
                var partnerTypes = dbContext.PartnerTypes.ToList();

                // Привязка полученных данных к выпадающему списку (ComboBox)
                // PartnerTypeCB - элемент управления для выбора типа партнера
                PartnerTypeCB.ItemsSource = partnerTypes;
            }
            catch
            {
                // Обработка ошибок при подключении к БД или работе с данными.
                // В реальном проекте здесь следует добавить логирование ошибки
                // и использовать более информативные сообщения для пользователя
                MessageBox.Show("При подгрузке типов партнеров произошло исключение!", "Исключение!");
            }
        }

        private void CreatePartner(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение данных из элементов управления формы
                var selectedPartnerType = PartnerTypeCB.SelectedItem as PartnerType; // Выбранный тип партнера из ComboBox
                var title = TitleTB.Text; // Название из TextBox
                var directorLastname = DirectorLastnameTB.Text; // Фамилия директора
                var directorFirstname = DirectorFirstnameTB.Text; // Имя директора
                var directorMiddlename = DirectorMiddlenameTB.Text; // Отчество директора
                var email = EmailTB.Text; // Электронная почта
                var phone = PhoneTB.Text; // Номер телефона   
                var address = AddressTB.Text; // Адрес
                var inn = InnTB.Text; // ИНН
                var rate = RateTB.Text; // Рейтинг (текстовое поле)

                // Проверка выбора типа партнера
                var isPartnerTypeSelected = selectedPartnerType != null;
                if (!isPartnerTypeSelected)
                {
                    MessageBox.Show("Тип партнера не был выбран!", "Ошибка!");
                    return;
                }

                // Валидация названия партнера (длина 1-32 символа)
                var isTitleValid = !string.IsNullOrWhiteSpace(title) && title.Length <= 32;
                if (!isTitleValid)
                {
                    MessageBox.Show("Название партнера не может быть пустым или превышать 32 символа!");
                    return;
                }

                // Валидация фамилии директора (длина 1-64 символа)
                var isDirectorLastnameValid = !string.IsNullOrWhiteSpace(directorLastname) && directorLastname.Length <= 64;
                if (!isDirectorLastnameValid)
                {
                    MessageBox.Show("Фамилия директора не может быть пустой или превышать 64 символа!", "Ошибка!");
                    return;
                }

                // Валидация имени директора (длина 1-64 символа)
                var isDirectorFirstnameValid = !string.IsNullOrWhiteSpace(directorFirstname) && directorFirstname.Length <= 64;
                if (!isDirectorFirstnameValid)
                {
                    MessageBox.Show("Имя директора не может быть пустым или превышать 64 символа!", "Ошибка!");
                    return;
                }

                // Валидация отчества директора (длина до 64 символов, допускается пустое)
                var isDirectorMiddlenameValid = directorMiddlename.Length <= 64; // Ошибка в оригинале: проверка directorFirstname вместо directorMiddlename
                if (!isDirectorMiddlenameValid)
                {
                    MessageBox.Show("Отчество директора не может быть пустым или превышать 64 символа!", "Ошибка!");
                    return;
                }

                // Валидация email (длина 1-128 символов)
                var isEmailValid = !string.IsNullOrWhiteSpace(email) && email.Length <= 128;
                if (!isEmailValid)
                {
                    MessageBox.Show("Почта не может быть пустой или превышать 128 символов", "Ошибка!");
                    return;
                }

                // Валидация телефона (длина 1-20 символов)
                var isPhoneValid = !string.IsNullOrWhiteSpace(phone) && phone.Length <= 20;
                if (!isPhoneValid)
                {
                    MessageBox.Show("Номер телефона не может быть пустым или превышать 20 символов", "Ошибка!");
                    return;
                }

                // Валидация адреса (длина 1-256 символов)
                var isAddressValid = !string.IsNullOrWhiteSpace(address) && address.Length <= 256;
                if (!isAddressValid)
                {
                    MessageBox.Show("Адресс не может быть пустым или превышать 256 символов", "Ошибка!");
                    return;
                }

                // Валидация ИНН (длина 1-32 символа)
                var isInnValid = !string.IsNullOrWhiteSpace(inn) && inn.Length <= 32;
                if (!isInnValid)
                {
                    MessageBox.Show("ИНН не может быть пустым или превышать 32 символов", "Ошибка!");
                    return;
                }

                // Проверка формата рейтинга (целое число)
                var rateParsedToInt = 0;
                var rateParseResult = Int32.TryParse(rate, out rateParsedToInt);
                if (!rateParseResult)
                {
                    MessageBox.Show("Рейтинг партнера не может быть пустым и может быть только целым числом!", "Ошибка!");
                    return;
                }

                // Проверка диапазона рейтинга (1-10)
                var isRateValid = 1 <= rateParsedToInt && rateParsedToInt <= 10;
                if (!isRateValid)
                {
                    MessageBox.Show("Рейтнг партнера может быть от 1 до 10!", "Ошибка!");
                    return;
                }

                // Проверка уникальности данных в БД
                var dbContext = new MasterFloorContext();

                // Проверка уникальности названия
                var isTitleExist = dbContext.Partners.Any(x => x.Title == title);
                if (isTitleExist)
                {
                    MessageBox.Show("Введенное название партнера уже существует!", "Ошибка!");
                    return;
                }

                // Проверка уникальности email
                var isEmailExist = dbContext.Partners.Any(x => x.Email == email);
                if (isEmailExist)
                {
                    MessageBox.Show("Введенная почта уже существует!", "Ошибка!");
                    return;
                }

                // Проверка уникальности телефона
                var isPhoneExist = dbContext.Partners.Any(x => x.Phone == phone);
                if (isPhoneExist)
                {
                    MessageBox.Show("Введенный номер телефона уже существует!", "Ошибка!");
                    return;
                }

                // Проверка уникальности адреса
                var isAddressExist = dbContext.Partners.Any(x => x.Address == address);
                if (isAddressExist)
                {
                    MessageBox.Show("Введенный адресс уже существует!", "Ошибка!");
                    return;
                }

                // Проверка уникальности ИНН
                var isInnExist = dbContext.Partners.Any(x => x.Inn == inn);
                if (isInnExist)
                {
                    MessageBox.Show("Введенный ИНН уже существует!", "Ошибка");
                    return;
                }

                // Создание объекта партнера и заполнение данных
                var partner = new Partner()
                {
                    PartnerTypeId = selectedPartnerType.Id,
                    Title = title,
                    DirectorLastname = directorLastname,
                    DirectorFirstname = directorFirstname,
                    DirectorMiddlename = directorMiddlename,
                    Email = email,
                    Phone = phone,
                    Address = address,
                    Inn = inn,
                    Rate = rateParsedToInt
                };

                // Добавление в БД и сохранение изменений
                dbContext.Partners.Add(partner);
                dbContext.SaveChanges();

                // Установка результата диалога как успешного
                DialogResult = true;
            }
            catch
            {
                // Обработка непредвиденных исключений
                MessageBox.Show("Произошло исключение при попытке создать партнера!");
            }
        }
    }
}
