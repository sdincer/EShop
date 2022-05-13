namespace EShop.Services.Order.Repository.Sql.Entity
{
    public enum OrderStatus
    {
        New = 0,
        PaymentReceived = 1,
        PaymentFailed = 2,
        InProgress = 3,
        Completed = 4,
        Closed = 5,
        Cancelled = 6
    }
}
