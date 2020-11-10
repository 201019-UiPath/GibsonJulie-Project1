namespace SoilMatesDB
{
    /// <summary>
    /// Repository interfaces for all models
    /// </summary>
    public interface IRepository : ICustomerRepo, ILocationRepo, IManagerRepo, IOrdersRepo, IProductRepo, IIventoryRepo, IOrderProduct
    {

    }
}