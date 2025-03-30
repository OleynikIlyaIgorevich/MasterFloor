using MasterFloor.Desktop.DbContexts;

namespace MasterFloor.Desktop.Services;

public class ProductGeneratorService
{
    public int GetMaterialsCount(
     int productId,
     int materialTypeId,
     int requiredQuantity)
    {
        // Создание контекста базы данных для взаимодействия с таблицами
        var dbContext = new MasterFloorContext();

        // Поиск продукта по ID. Если не найден - возвращаем -1
        var product = dbContext.Products.SingleOrDefault(x => x.Id == productId);
        if (product == null) return -1;

        // Поиск типа материала по ID. Если не найден - возвращаем -1
        var material = dbContext.MaterialTypes.SingleOrDefault(x => x.Id == materialTypeId);
        if (material == null) return -1;

        // Проверка корректности запрашиваемого количества
        if (requiredQuantity <= 0) return -1;

        // Расчет необходимого материала с учетом процента брака:
        // requiredQuantity / (1 - коэффициент_брака) 
        // Пример: при 10% брака (0.1) делитель = 0.9, что увеличивает требуемое количество
        var materialCountDecimal = requiredQuantity / (1 - material.RejectionRate);

        // Округление результата вверх до целого числа
        var result = (int)Math.Ceiling(materialCountDecimal);

        return result;
    }

}
