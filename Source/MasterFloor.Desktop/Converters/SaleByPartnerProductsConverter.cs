using MasterFloor.Desktop.Entities;
using System.Globalization;
using System.Windows.Data;

namespace MasterFloor.Desktop.Converters;

public class SaleByPartnerProductsConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Преобразуем входное значение в список товаров партнера
        var partnerProducts = value as List<PartnerProduct>;

        // Если преобразование невозможно или список пуст, возвращаем ошибку
        if (partnerProducts == null)
            return "Error";

        // Суммируем стоимость всех проданных товаров
        decimal fullPrice = partnerProducts.Sum(x => x.SellPrice);

        // Определение размера скидки по сумме продаж:
        // Диапазоны проверяются последовательно (от большего к меньшему)
        if (10000 <= fullPrice && fullPrice < 50000)
            return "5%"; // Умеренные продажи

        if (50000 <= fullPrice && fullPrice < 300000)
            return "10%"; // Высокие продажи

        if (fullPrice >= 300000)
            return "15%"; // Максимальный уровень

        // Если сумма меньше 10 000, скидка отсутствует
        return "0%";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
